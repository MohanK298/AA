/*
 * Created by Ranorex
 * User: Kumar
 * Date: 2019-10-22
 * Time: 4:15 PM
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
using SmokeTest.Modules.Utilities;
using Ranorex.AutomationHelpers.UserCodeCollections;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest
{
    /// <summary>
    /// Description of createApptDrgNDrpWithinSameDay.
    /// </summary>
    [TestModule("F9477D36-A271-46FA-8A00-A70467E1A425", ModuleType.UserCode, 1)]

    public class createApptDrgNDrpWithinSameDay : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        Calendar calendar = Calendar.Instance;
    	Common cmn=new Common();
        public createApptDrgNDrpWithinSameDay()
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
		string location="Meeting Room 1";
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
		
		private void CreateApptDrgNDropWithinSameDay()
        {
			//calendar.MainForm.Self.Activate();
        	calendar.MainForm.btnCalendar.Click();
        	calendar.MainForm.btnNewAppointment.Click();
        	Delay.Seconds(1);
        	calendar.EventDetailForm.PnlBase.txtAppointmentTitle.PressKeys(data);
        	calendar.EventDetailForm.PnlBase.txtStartTime.PressKeys(System.DateTime.Now.ToShortTimeString());
        	calendar.EventDetailForm.PnlBase.txtEndTime.PressKeys(System.DateTime.Now.AddHours(1).ToShortTimeString());
        	calendar.EventDetailForm.btnOK.Click();
        	Delay.Seconds(3);
        	AppointmentOverlapPrompt();
        	ValidateEventRemainderPopup();
        	calendar.MainForm.btnCalendar.Click();
        	calendar.MainForm.btnViewMenu.Click();
        	calendar.MainForm.menuListView.Click();
        	Delay.Seconds(3);
        	cmn.VerifyDataExistsInTable(calendar.MainForm.tblCalendar,data,"Calendar List");
        	calendar.MainForm.Toolbar.btnToday.Click();
        	calendar.MainForm.PnlViews.tbCurrentDay.Click();
        	//calendar.EventDetailForm.btnCancel.Click();
        	calendar.MainForm.Self.Activate();
        	string currentDayData =String.Format("Appointment '{0}'",data);
        	calendar.curdayapptselection=currentDayData;
        	Ranorex.Cell curdaysource = calendar.MainForm.PnlViews.txtCurrentDayAppt;
        	string destTime=RoundUpTimeFormat(System.DateTime.Now);
        	calendar.curdayapptselection=destTime;
        	DragNDropLibrary.DragAndDrop(curdaysource,calendar.MainForm.PnlViews.txtCurrentDayAppt);
        	
        	
        }       
		private string RoundUpTimeFormat(System.DateTime newDate)
		{
			System.TimeSpan ts1;
			int minutes = newDate.Minute;
			if (minutes > 0 && minutes < 30)
			{
			    ts1 = new System.TimeSpan(newDate.Hour +3, 30, 0);
			}
			else
			{
			    ts1 = new System.TimeSpan(newDate.Hour + 4, 00, 0);
			}
			newDate = new System.DateTime(newDate.Year, newDate.Month, newDate.Day, ts1.Hours, ts1.Minutes, newDate.Millisecond);
			string currentdate = newDate.ToString("MMMM dd, yyyy h:mm tt");
			return currentdate;
		}

        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            CreateApptDrgNDropWithinSameDay();
            //Appointment 'Test Data Added 2019-10-22 10:21:34 AM'
            //October 22, 2019 9:30 PM
        }
    }
}
