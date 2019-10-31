/*
 * Created by Ranorex
 * User: kumar
 * Date: 10/31/2019
 * Time: 4:16 PM
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

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of createAdjrnApptwithMilestone.
    /// </summary>
    [TestModule("CE24FE51-646F-4564-93E3-8AB5367EDC20", ModuleType.UserCode, 1)]
    public class createAdjrnApptwithMilestone : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        Calendar calendar=Calendar.Instance;
        Common cmn=new Common();
        public createAdjrnApptwithMilestone()
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
		
		private void CreateAdjrnApptwithMilestone()
        {
			string new_Data="";
			calendar.MainForm.Self.Activate();
        	calendar.MainForm.btnCalendar.Click();
        	calendar.MainForm.btnNewAppointment.Click();
        	Delay.Seconds(1);
        	calendar.EventDetailForm.PnlBase.txtAppointmentTitle.PressKeys(data);
        	calendar.EventDetailForm.PnlBase.txtStartTime.PressKeys(System.DateTime.Now.ToShortTimeString());
        	calendar.EventDetailForm.PnlBase.txtEndTime.PressKeys(System.DateTime.Now.AddHours(1).ToShortTimeString());
        	calendar.EventDetailForm.PnlBase.cbMilestone.Check(); 
        	calendar.EventDetailForm.PnlBase.cbShowAdjournments.Check();
        	calendar.EventDetailForm.btnOK.Click();
        	Delay.Seconds(3);
        	AppointmentOverlapPrompt();
        	ValidateEventRemainderPopup();
        	calendar.MainForm.btnCalendar.Click();
        	calendar.MainForm.btnViewMenu.Click();
        	calendar.MainForm.menuListView.Click();
        	Delay.Seconds(3);
        	new_Data+="Milestone: "+data;
        	cmn.VerifyDataExistsInTable(calendar.MainForm.tblCalendar,new_Data,"Calendar List");
			
        	cmn.SelectItemFromTableDblClick(calendar.MainForm.tblCalendar,new_Data,"Calendar List");
        	calendar.EventDetailForm.PnlBase.txtStartDate.Click();
        	calendar.EventDetailForm.PnlBase.txtStartDate.PressKeys(System.DateTime.Now.AddDays(2).ToShortDateString());
        	calendar.EventDetailForm.btnOK.Click();
        	Validate.Exists(calendar.AdjournmentReasonForm.SelfInfo,"Adjournment Reason Form");
        	calendar.AdjournmentReasonForm.txtAdjournReason.Click();
        	calendar.AdjournmentReasonForm.txtAdjournReason.PressKeys(String.Format("Moving 2 days from current Day {0}",System.DateTime.Now.ToShortDateString()));
        	calendar.AdjournmentReasonForm.Toolbar1.ButtonOK.Click();
        	
        	
//        	calendar.MainForm.Toolbar.btnWeek.Click();
//        	day1=System.DateTime.Now;
//			day2=day1.AddDays(2);
//			strday1=day1.ToString("MMMM d, yyyy");
//			strday2=day2.ToString("MMMM d, yyyy");
//			calendar.curwkday=strday1;
//			calendar.MainForm.PnlViews.shrtDay.Click();
//			calendar.appmtData=data;
//			//calendar.MainForm.PnlViews.txtappointment;
//			Delay.Seconds(2);
//			Ranorex.Text sourceappt=calendar.MainForm.PnlViews.txtappointment;
//			calendar.curwkday=strday2;
//			Delay.Seconds(2);
//        	Validate.Exists(calendar.RepeatingEventDialogForm.SelfInfo,"Repeating Event Exception Dialog is seen");
//			calendar.RepeatingEventDialogForm.Toolbar1.btnThisOne.Click();
//			Delay.Seconds(2);
//			calendar.curwkday=strday2;
//			calendar.MainForm.PnlViews.shrtDay.Click();
//			calendar.appmtData=data;
//			Validate.Exists(calendar.MainForm.PnlViews.txtappointmentInfo,"Appt Moved to a new Date");
        	
		}
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            CreateAdjrnApptwithMilestone();
        }
    }
}
