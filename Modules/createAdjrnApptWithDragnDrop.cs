/*
 * Created by Ranorex
 * User: kumar
 * Date: 11/4/2019
 * Time: 12:16 PM
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
using Ranorex.AutomationHelpers.UserCodeCollections;
namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of createAdjrnApptWithDragnDrop.
    /// </summary>
    [TestModule("94A93AE6-06E1-4F40-9875-95FCCCC2434E", ModuleType.UserCode, 1)]
    public class createAdjrnApptWithDragnDrop : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        Calendar calendar=Calendar.Instance;
        Common cmn=new Common();
        public createAdjrnApptWithDragnDrop()
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
		
		private void CreateAdjrnApptWithDragnDrop()
        {
			string new_Data="";
			string strday1,strday2;
			System.DateTime day1,day2;
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
			
        	calendar.MainForm.Toolbar.btnWeek.Click();
        	day1=System.DateTime.Now;
			day2=day1.AddDays(2);
			strday1=day1.ToString("MMMM d, yyyy");
			strday2=day2.ToString("MMMM d, yyyy");
			calendar.curwkday=strday1;
			calendar.MainForm.PnlViews.shrtDay.Click();
			calendar.appmtData=data;
			
			Delay.Seconds(2);
			Validate.Exists(calendar.MainForm.PnlViews.txtappointmentInfo,"Adjourned Appointment present as expected");
			Ranorex.Text sourceappt=calendar.MainForm.PnlViews.txtappointment;
			calendar.curwkday=strday2;
			DragNDropLibrary.DragAndDrop(sourceappt,calendar.MainForm.PnlViews.shrtDay);
			Delay.Seconds(2);
       	
        	Validate.Exists(calendar.AdjournmentReasonForm.SelfInfo,"Adjournment Reason Form");
        	calendar.AdjournmentReasonForm.txtAdjournReason.Click();
        	calendar.AdjournmentReasonForm.txtAdjournReason.PressKeys(String.Format("Moving 2 days from current Day {0}",System.DateTime.Now.ToShortDateString()));
        	calendar.AdjournmentReasonForm.Toolbar1.ButtonOK.Click();
        	calendar.curwkday=strday2;
			calendar.MainForm.PnlViews.shrtDay.Click();
			calendar.appmtData=data;
			Validate.Exists(calendar.MainForm.PnlViews.txtappointmentInfo,"Master Instance of the new Appointment Exists as expected");
        	

        	
		}
        
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            CreateAdjrnApptWithDragnDrop();
            cmn.ClosePrompt();
        }
    }
}
