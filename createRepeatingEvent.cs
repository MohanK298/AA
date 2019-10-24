/*
 * Created by Ranorex
 * User: Kumar
 * Date: 2019-10-21
 * Time: 2:30 PM
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
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest
{
    /// <summary>
    /// Description of createRepeatingEvent.
    /// </summary>
    [TestModule("D9A7F1F5-B5BC-4DB9-9A38-16897E14C640", ModuleType.UserCode, 1)]
    public class createRepeatingEvent : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        Calendar calendar = Calendar.Instance;
        Common cmn=new Common();
        
        public createRepeatingEvent()
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
		
		private void CreateRepeatedAppointment()
        {
			//calendar.MainForm.Self.Activate();
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
        	Delay.Seconds(1);
        	calendar.weekday=System.DateTime.Now.AddDays(2).ToString("ddd");
        	calendar.EventDetailForm.PnlBase.cbWeekday.Check();
        	calendar.EventDetailForm.btnOK.Click();
        	Delay.Seconds(3);
        	AppointmentOverlapPrompt();
        	ValidateEventRemainderPopup();
        	calendar.MainForm.btnCalendar.Click();
        	calendar.MainForm.btnViewMenu.Click();
        	calendar.MainForm.menuListView.Click();
        	Delay.Seconds(3);
        	cmn.VerifyDataExistsInTable(calendar.MainForm.tblCalendar,data,"Calendar List");
        }
		private void EditFewAppointment()
		{
			System.DateTime day1;
			System.DateTime day2;
			System.DateTime day3;
			string strday1,strday2,strday3;
			calendar.MainForm.Toolbar.btnWeek.Click();
			Delay.Seconds(2);
			day1=System.DateTime.Now;
			day2=day1.AddDays(1);
			day3=day1.AddDays(2);
			strday1=day1.ToString("MMMM dd, yyyy");
			strday2=day2.ToString("MMMM dd, yyyy");
			strday3=day3.ToString("MMMM dd, yyyy");
			calendar.curwkday=strday1;
			calendar.MainForm.PnlViews.shrtDay.Click();
			calendar.appmtData=data;
			calendar.MainForm.PnlViews.txtappointment.DoubleClick();
			Delay.Seconds(2);
			calendar.EventDetailForm.PnlBase.txtLocation.Click();
			calendar.EventDetailForm.PnlBase.txtLocation.PressKeys(location);
			calendar.EventDetailForm.btnOK.Click();
			Validate.Exists(calendar.RepeatingEventDialogForm.SelfInfo,"Repeating Event Exception Dialog is seen");
			calendar.RepeatingEventDialogForm.Toolbar1.btnThisOne.Click();
			Delay.Seconds(3);
			ValidateEventRemainderPopup();
			calendar.MainForm.PnlViews.txtappointment.DoubleClick();
			Validate.AttributeContains(calendar.EventDetailForm.PnlBase.txtLocationInfo,"UIAutomationValueValue",location,String.Format("Location updated for Appointment booked on {0}",strday1));
			calendar.EventDetailForm.btnCancel.Click();
			Delay.Seconds(3);
			calendar.curwkday=strday2;
			calendar.MainForm.PnlViews.shrtDay.Click();
			calendar.MainForm.PnlViews.txtappointment.DoubleClick();
			Delay.Seconds(2);
			calendar.EventDetailForm.PnlBase.txtLocation.Click();
			calendar.EventDetailForm.PnlBase.txtLocation.PressKeys(location);
			calendar.EventDetailForm.PnlBase.txtEndTime.PressKeys(System.DateTime.Now.AddHours(1).ToShortTimeString());
			calendar.EventDetailForm.btnOK.Click();
			Validate.Exists(calendar.RepeatingEventDialogForm.SelfInfo,"Repeating Event Exception Dialog is seen");
			calendar.RepeatingEventDialogForm.Toolbar1.btnThisOne.Click();
			Delay.Seconds(3);
			calendar.MainForm.PnlViews.txtappointment.DoubleClick();
			Validate.AttributeContains(calendar.EventDetailForm.PnlBase.txtLocationInfo,"UIAutomationValueValue",location,String.Format("Location updated for Appointment booked on {0}",strday2));
			calendar.EventDetailForm.btnCancel.Click();
			Delay.Seconds(3);
			calendar.curwkday=strday3;
			calendar.MainForm.PnlViews.shrtDay.Click();
			calendar.MainForm.PnlViews.txtappointment.DoubleClick();
			Validate.AttributeContains(calendar.EventDetailForm.PnlBase.txtLocationInfo,"UIAutomationValueValue","",String.Format("Location value empty for Appointment booked on {0}",strday3));
			calendar.EventDetailForm.btnCancel.Click();
		}
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            CreateRepeatedAppointment();
            EditFewAppointment();
        }
    }
}
