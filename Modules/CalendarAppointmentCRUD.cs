/*
 * Created by Ranorex
 * User: Qiao
 * Date: 11/15/2018
 * Time: 1:08 PM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;
using SmokeTest.Modules.Utilities;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

using SmokeTest.Repositories;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of CRUD.
    /// </summary>
    [TestModule("277A2370-F709-4B30-9D4A-9F8C4FB26799", ModuleType.UserCode, 1)]
    public class CalendarAppointmentCRUD : ITestModule
    {
    	System.DateTime appoinmentStartTime = System.DateTime.Now;
    	Duration customWaitTime = new Duration(3000);
    	Calendar2018 calendarRepo = Calendar2018.Instance;
    	Common cmn=new Common();
    	Cell appointment;
    	string apptName="";
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CalendarAppointmentCRUD()
        {
            // Do not delete - a parameterless constructor is required!
        }

        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            cmn.closeDialog();
            createNewAppointment();
            readAppointment();
            updateAppointment();
            deleteAppoinment();
            cmn.ClosePrompt();
        }
        
        private void createNewAppointment()
        {
			goToCalendarModule();
        	calendarRepo.MainForm.newEventBtn.Click();
        	
        	try {
        		calendarRepo.EventDetailForm.SelfInfo.WaitForExists(customWaitTime);
        	} catch (Exception) {
        		calendarRepo.MainForm.newEventBtn.Click();
        	}
        	
        	calendarRepo.EventDetailForm.titleTextInfo.WaitForAttributeEqual(customWaitTime, "Visible", true);
        	calendarRepo.EventDetailForm.titleText.PressKeys("Ranorex sanity " + appoinmentStartTime.ToString("hh:mm tt"));
        	calendarRepo.EventDetailForm.startTimeText.PressKeys(appoinmentStartTime.AddMinutes(30).ToString("hh:mm tt"));
        	calendarRepo.EventDetailForm.locationText.Click();
        	calendarRepo.EventDetailForm.locationText.PressKeys("Meeting Room");
        	calendarRepo.EventDetailForm.okBtn.Click();
        	
        	try {
        		calendarRepo.EventDetailForm.SelfInfo.WaitForNotExists(customWaitTime);
        	} catch (Exception) {
        		if (calendarRepo.AppointmentOverlapDialog.SelfInfo.Exists()) {
        			calendarRepo.AppointmentOverlapDialog.itsOkRadioBtn.Click();
        			calendarRepo.AppointmentOverlapDialog.okBtn.Click();
        		
	        		try {
	        			calendarRepo.AppointmentOverlapDialog.SelfInfo.WaitForNotExists(customWaitTime);
	        		} catch (Exception) {
	        			Report.Log(ReportLevel.Failure, "Failed to dismiss the appointment overlap dialog");
	        		}
        		}
        		
        		if (calendarRepo.EventDetailForm.okBtnInfo.Exists()) {
        			calendarRepo.EventDetailForm.okBtn.Click();
        		}
        	}
        	
        	try {
        		calendarRepo.EventDetailForm.SelfInfo.WaitForNotExists(customWaitTime);
        	} catch (Exception) {
        		Report.Log(ReportLevel.Failure, "Failed to create new appointment");
        	}
        	
        	calendarRepo.MainForm.CalendarIndexFormBottomPanel.Today.Click();
        	calendarRepo.MainForm.DayView.leftPanelInfo.WaitForExists(customWaitTime);
        	calendarRepo.MainForm.DayView.rightListInfo.WaitForExists(customWaitTime);
        	calendarRepo.MainForm.DayView.ToDos.Click();
        	calendarRepo.AmicusAttorneyXWin.appointmentMenuItem.Select();
        	        	
        	try {
        		appointment = String.Format("?/?/form[@controlname='CalendarIndexForm']/container[@controlname='pnlBase']//table[@accessiblename='Band 0']/row/cell[@text='Ranorex sanity {0}']", appoinmentStartTime.ToString("hh:mm tt"));
        		apptName=String.Format("Ranorex sanity {0}",appoinmentStartTime.ToString("hh:mm tt"));
        		Report.Info("New Ranorex automation appointment created: " + appointment.Text);
        		
        	} catch (Exception) {
        		
        		Report.Log(ReportLevel.Info, "Ranorex automation appointment visible? " + appointment.Element.Visible.ToString());
        	}
        	
//        	try {
//        		IList<Cell>events = calendarRepo.MainForm.DayView.eventTable.FindDescendants<Cell>();
//        		Report.Info("Table: " + calendarRepo.MainForm.DayView.eventTable.ToString());
//        		foreach (Cell cell in events) {
//        			Report.Info("Cell: " + cell.Text);
//        		}
//        	} catch (Exception) {
//        		
//        		throw;
//        	}
        }
        
        private void readAppointment()
        {
//        	goToCalendarModule();
        	try {
//        		appointment.Select();
        		//appointment.DoubleClick();
        		cmn.SelectItemFromTableDblClick(calendarRepo.MainForm.tblCalendar,apptName,"Calendar List");
        		calendarRepo.EventDetailForm.SelfInfo.WaitForExists(customWaitTime);
        	} catch (Exception) {
        		Report.Log(ReportLevel.Failure, "Failed to read appointment " + appointment.Text);
        	}
        	Report.Info(calendarRepo.EventDetailForm.titleText.TextValue);
        	Validate.Equals(calendarRepo.EventDetailForm.titleText.TextValue, "Ranorex sanity " + appoinmentStartTime.ToString("hh:mm tt"));
        	Report.Info(calendarRepo.EventDetailForm.startTimeText.TextValue);
        	Validate.Equals(calendarRepo.EventDetailForm.startTimeText.TextValue, appoinmentStartTime.ToString("hh:mm tt"));
        	
        	calendarRepo.EventDetailForm.okBtn.Click();
        }
        
        private void updateAppointment()
        {
        	goToCalendarModule();
        	Delay.Seconds(3);
        	try {
        	//Report.Info(appointment.Text);
        		//appointment.DoubleClick();
        		cmn.SelectItemFromTableDblClick(calendarRepo.MainForm.tblCalendar,apptName,"Calendar List");
        		calendarRepo.EventDetailForm.SelfInfo.WaitForExists(customWaitTime);
        	} catch (Exception) {
        		Report.Log(ReportLevel.Failure, "Update Appointment, failed to open the appointment details.");
        	}
        	
        	calendarRepo.EventDetailForm.titleText.PressKeys("Edited ");
        	calendarRepo.EventDetailForm.okBtn.Click();
        	appointment = String.Format("?/?/form[@controlname='CalendarIndexForm']/container[@controlname='pnlBase']//table[@accessiblename='Band 0']/row/cell[@text='Edited Ranorex sanity {0}']", appoinmentStartTime.ToString("hh:mm tt"));
        	Validate.Equals(appointment, "Edit Ranorex sanity " + appoinmentStartTime.ToString("hh:mm tt"));
        }
        
        private void deleteAppoinment()
        {
        	goToCalendarModule();
        	appointment.DoubleClick();
        	calendarRepo.EventDetailForm.SelfInfo.WaitForExists(customWaitTime*10);
        	
        	calendarRepo.EventDetailForm.deleteBtn.Click();
        	try {
        		calendarRepo.PromptForm.SelfInfo.WaitForExists(customWaitTime);
        	} catch (Exception) {
        		calendarRepo.EventDetailForm.deleteBtn.Click();
        	}
        	
        	if (calendarRepo.PromptForm.SelfInfo.Exists()) {
        		calendarRepo.PromptForm.yesBtn.Click();
        	} else {
        		Report.Log(ReportLevel.Failure, "Appointment Deletetion Confirmation Prompt Not Found.");
        	}
        	
        	try {
        		calendarRepo.EventDetailForm.SelfInfo.WaitForNotExists(customWaitTime * 10);
        	} catch (Exception) {
        		Report.Log(ReportLevel.Info, "Delete Appoinment, appoinment cell path was found after 30 seconds.");
        	}
        	
        	Validate.NotExists(String.Format("?/?/form[@controlname='CalendarIndexForm']/container[@controlname='pnlBase']//table[@accessiblename='Band 0']/row/cell[@text='Edited Ranorex sanity {0}']", appoinmentStartTime.ToString("hh:mm tt")));
        }
        
        private void goToCalendarModule()
        {
        	calendarRepo.MainForm.calendarMenuBtn.Click();
        	calendarRepo.MainForm.calendarViewTitleInfo.WaitForAttributeEqual(customWaitTime, "Text", "Calendar");
        	calendarRepo.MainForm.newEventBtnInfo.WaitForAttributeEqual(customWaitTime, "Enabled", true);
        }
    }
}
