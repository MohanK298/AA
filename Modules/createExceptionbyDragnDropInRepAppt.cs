/*
 * Created by Ranorex
 * User: kumar
 * Date: 10/31/2019
 * Time: 2:39 PM
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
using SmokeTest.Repositories;
using Ranorex;
using Ranorex.AutomationHelpers.UserCodeCollections;
using Ranorex.Core;
using Ranorex.Core.Testing;
using SmokeTest.Modules.Utilities;
namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of createExceptionbyDragnDropInRepAppt.
    /// </summary>
    [TestModule("DAC03C33-2719-4EE3-BAD1-9784D331494E", ModuleType.UserCode, 1)]
    public class createExceptionbyDragnDropInRepAppt : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        Calendar calendar=Calendar.Instance;
        Common cmn=new Common();
        public createExceptionbyDragnDropInRepAppt()
        {
            // Do not delete - a parameterless constructor is required!
        }

        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        static string rndData=System.DateTime.Now.ToString();
		string data=String.Format("Test Data Added {0}",rndData);
		string fileName=String.Format("RanorexTestFile {0}",rndData); 
        public void ValidateEventRemainderPopup()
        {
        	if(calendar.EventReminderForm.SelfInfo.Exists(70000))
        	{
        		calendar.EventReminderForm.btnIllBeThere.Click();
        	}
        }
       public void AppointmentOverlapPrompt()
       {
       	if(calendar.AppointmentOverlapDialog.SelfInfo.Exists(3000))
       	{
       		calendar.AppointmentOverlapDialog.btnOk.Click();
       	}
       }
		
		private void CreateRepeatedAppointment()
        {
			System.DateTime day1;
			System.DateTime day2;
			string strday1,strday2;
			calendar.MainForm.Self.Activate();
        	calendar.MainForm.btnCalendar.Click();
        	calendar.MainForm.btnNewAppointment.Click();
        	Delay.Seconds(1);
        	calendar.EventDetailForm.PnlBase.txtAppointmentTitle.PressKeys(data);
        	calendar.EventDetailForm.PnlBase.txtStartTime.PressKeys(System.DateTime.Now.ToShortTimeString());
        	calendar.EventDetailForm.PnlBase.txtEndTime.PressKeys(System.DateTime.Now.AddHours(1).ToShortTimeString());
        	calendar.EventDetailForm.PnlBase.Repeat.Click();
        	cmn.SelectItemDropdown(calendar.EventDetailForm.PnlBase.cmbbxRepeat,"Weekly","Repeat Dropdown");
        	calendar.weekday=System.DateTime.Now.ToString("ddd");
        	calendar.EventDetailForm.PnlBase.cbWeekday.Check();
        	Delay.Seconds(1);
        	calendar.weekday=System.DateTime.Now.AddDays(1).ToString("ddd");
        	calendar.EventDetailForm.PnlBase.cbWeekday.Check();
        	cmn.SelectItemDropdown(calendar.EventDetailForm.PnlBase.cmbbxHolidayRule,"Cancel that occurrence","Holiday Rule Dropdown");
        	calendar.EventDetailForm.btnOK.Click();
        	Delay.Seconds(3);
        	AppointmentOverlapPrompt();
        	ValidateEventRemainderPopup();
        	calendar.MainForm.btnCalendar.Click();
        	calendar.MainForm.btnViewMenu.Click();
        	calendar.MainForm.menuListView.Click();
        	Delay.Seconds(3);
        	cmn.VerifyDataExistsInTable(calendar.MainForm.tblCalendar,data,"Calendar List");
        	
        	
        	
        	
        	calendar.MainForm.Toolbar.btnWeek.Click();
        	day1=System.DateTime.Now;
			day2=day1.AddDays(2);
			strday1=day1.ToString("MMMM d, yyyy");
			strday2=day2.ToString("MMMM d, yyyy");
			calendar.curwkday=strday1;
			calendar.MainForm.PnlViews.shrtDay.Click();
			calendar.appmtData=data;
			//calendar.MainForm.PnlViews.txtappointment;
			Delay.Seconds(2);

			Ranorex.Text sourceappt=calendar.MainForm.PnlViews.txtappointment;
			calendar.curwkday=strday2;
			DragNDropLibrary.DragAndDrop(sourceappt,calendar.MainForm.PnlViews.shrtDay);
			Delay.Seconds(2);
        	Validate.Exists(calendar.RepeatingEventDialogForm.SelfInfo,"Repeating Event Exception Dialog is seen");
			calendar.RepeatingEventDialogForm.Toolbar1.btnThisOne.Click();
			Delay.Seconds(2);
			calendar.curwkday=strday2;
			calendar.MainForm.PnlViews.shrtDay.Click();
			calendar.appmtData=data;
			Validate.Exists(calendar.MainForm.PnlViews.txtappointmentInfo,"Appt Moved to a new Date");
			
			
        	
        	
        }
        
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            CreateRepeatedAppointment();
            Utilities.Common.ClosePrompt();
        }
    }
}
