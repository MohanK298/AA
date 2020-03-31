/*
 * Created by Ranorex
 * User: kumar
 * Date: 1/14/2020
 * Time: 3:06 PM
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
    /// Description of validate_Existing_Time_Entry_OnFile_Msg.
    /// </summary>
    [TestModule("2A0330DB-ABC1-4877-983E-02291603401D", ModuleType.UserCode, 1)]
    public class validate_Existing_Time_Entry_OnFile_Msg : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public validate_Existing_Time_Entry_OnFile_Msg()
        {
            // Do not delete - a parameterless constructor is required!
        }
		
        TimeSheets ts=TimeSheets.Instance;
        Common cmn=new Common();
        Calendar calendar=Calendar.Instance;
        static string rndData=System.DateTime.Now.ToString();
		string data=String.Format("Test Data Added {0}",rndData);
		
        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
       private void ValidateEventRemainderPopup()
		{
			if(calendar.EventReminderForm.SelfInfo.Exists(70000))
			{
				calendar.EventReminderForm.btnIllBeThere.Click();
			}
		}
		private void AppointmentOverlapPrompt()
		{
			if(calendar.AppointmentOverlapDialog.SelfInfo.Exists(3000))
			{
				calendar.AppointmentOverlapDialog.btnOk.Click();
			}
		}
        private void existTEValidation()
        {
        	
    		calendar.MainForm.Self.Activate();
        	calendar.MainForm.btnCalendar.Click();
        	calendar.MainForm.btnNewAppointment.Click();
        	Delay.Seconds(1);
        	calendar.EventDetailForm.PnlBase.txtAppointmentTitle.PressKeys(data+"_1");
        	calendar.EventDetailForm.PnlBase.txtStartTime.PressKeys(System.DateTime.Now.ToShortTimeString());
        	calendar.EventDetailForm.PnlBase.txtEndTime.PressKeys(System.DateTime.Now.AddHours(1).ToShortTimeString());
        	calendar.EventDetailForm.PnlBase.FilesAndPeople.Click();
        	calendar.EventDetailForm.PnlBase.btnAddFile.Click();
        	calendar.FileSelectForm.listFirstFoundFile.DoubleClick();
        	calendar.EventDetailForm.btnOK.Click();
        	AppointmentOverlapPrompt();
        	ValidateEventRemainderPopup();
        	Report.Success(String.Format("Appoitnment Created with file attached for {0}",data+"_1"));
        	
	        	
	        	
	        	
	        ts.MainForm.Self.Activate();
        	Delay.Seconds(1);
        	ts.MainForm.btnTimeSheets.Click();
        	Delay.Seconds(5);
        	ts.MainForm.Toolbar.btnTimeEntryAssistant.Click();
        	ts.TimeEntryAssistantForm.SelfInfo.WaitForExists(3000);
        	cmn.SelectItemFromTableSingleClick(ts.TimeEntryAssistantForm.PnlBase.tbTimeEntryAssistant,data+"_1","Time Entry Assistant Table");
        	ts.TimeEntryAssistantForm.Toolbar1.btnTimeSaver.Click();
        	
       	
        	if(ts.PromptForm.txtPrompt.TextValue.Contains("The Timekeeper already has a Time Entry on this File on this date. Do you want to combine them?"))
        	{
        		Report.Success("Prompt shown successfully for peforming Time Saver on Files for which Time Entries are already created");
        	}
        	else
        	{
        		Report.Failure(String.Format("Invalid Prompt shown as {0}",ts.PromptForm.txtPrompt.TextValue));
        	}
        	if(ts.PromptForm.SelfInfo.Exists(3000))
        	   {        	ts.PromptForm.btnNo.Click();}
        	ts.TimeEntryAssistantForm.Toolbar1.btnClose.Click();
        	Delay.Seconds(1);
        	ts.MainForm.TimeIndexControlPanelControl.lnkUnposted.Click();
        	cmn.VerifyDataExistsInTable(ts.MainForm.tblTimeSheet,data+"_1","Time Entry Table");
        	
        	
        	
        	
        }

        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            existTEValidation();
            cmn.ClosePrompt();
        }
    }
}
