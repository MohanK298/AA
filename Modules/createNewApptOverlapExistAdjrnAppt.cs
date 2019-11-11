/*
 * Created by Ranorex
 * User: kumar
 * Date: 11/4/2019
 * Time: 11:41 AM
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
    /// Description of createNewApptOverlapExistAdjrnAppt.
    /// </summary>
    [TestModule("6CE50DD2-E5C1-4B32-985C-3E7701FF6B7E", ModuleType.UserCode, 1)]
    public class createNewApptOverlapExistAdjrnAppt : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        Calendar calendar=Calendar.Instance;
        Common cmn=new Common();
        public createNewApptOverlapExistAdjrnAppt()
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
		
		private void CreateNewApptOverlapExistAdjrnAppt()
        {
			string new_Data="";
			string adj_data="";
			string strtTime=System.DateTime.Now.ToShortTimeString();
			string endTime=System.DateTime.Now.AddHours(1).ToShortTimeString();
			calendar.MainForm.Self.Activate();
        	calendar.MainForm.btnCalendar.Click();
        	calendar.MainForm.btnNewAppointment.Click();
        	Delay.Seconds(1);
        	calendar.EventDetailForm.PnlBase.txtAppointmentTitle.PressKeys(data);
        	calendar.EventDetailForm.PnlBase.txtStartTime.PressKeys(strtTime);
        	calendar.EventDetailForm.PnlBase.txtEndTime.PressKeys(endTime);
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
        	//calendar.AppointmentOverlapDialog.btnOk.Click();
        	AppointmentOverlapPrompt();
        	adj_data+="[Adjourned to "+System.DateTime.Now.AddDays(2).ToString("MMM dd, yyyy")+"] "+data;
        	cmn.VerifyDataExistsInTable(calendar.MainForm.tblCalendar,adj_data,"Calendar List");
        	
        	calendar.MainForm.btnCalendar.Click();
        	calendar.MainForm.btnNewAppointment.Click();
        	Delay.Seconds(1);
        	calendar.EventDetailForm.PnlBase.txtAppointmentTitle.PressKeys(data+"_2");
        	calendar.EventDetailForm.PnlBase.txtStartTime.PressKeys(strtTime);
        	calendar.EventDetailForm.PnlBase.txtEndTime.PressKeys(endTime);
        	calendar.EventDetailForm.btnOK.Click();
        	Delay.Seconds(3);
        	AppointmentOverlapPrompt();
        	ValidateEventRemainderPopup();
        	cmn.SelectItemFromTableDblClick(calendar.MainForm.tblCalendar,data+"_2","Calendar List");
        	calendar.EventDetailForm.Toolbar1.btnAvailability.Click();
        	Delay.Seconds(2);
        	Validate.Attribute(calendar.PromptForm.txtMsgInfo,"Text","There are currently no conflicts for the scheduling of this Appointment.","No Scheduling Conflict Message");
        	calendar.PromptForm.btnOK.Click();
        	calendar.EventDetailForm.btnCancel.Click();
        	
        	
		}
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            CreateNewApptOverlapExistAdjrnAppt();
        }
    }
}
