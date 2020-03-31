/*
 * Created by Ranorex
 * User: kumar
 * Date: 1/14/2020
 * Time: 1:27 PM
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
    /// Description of validate_NoFileOn_Time_Entry_Msg.
    /// </summary>
    [TestModule("2D9E4702-B645-4BD4-B047-346563A4836D", ModuleType.UserCode, 1)]
    public class validate_NoFileOn_Time_Entry_Msg : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public validate_NoFileOn_Time_Entry_Msg()
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
         private void create_Appointment()
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
	        	
	        	
	        	calendar.MainForm.Self.Activate();
	        	calendar.MainForm.btnCalendar.Click();
	        	calendar.MainForm.btnNewAppointment.Click();
	        	Delay.Seconds(1);
	        	calendar.EventDetailForm.PnlBase.txtAppointmentTitle.PressKeys(data+"_2");
	        	calendar.EventDetailForm.PnlBase.txtStartTime.PressKeys(System.DateTime.Now.ToShortTimeString());
	        	calendar.EventDetailForm.PnlBase.txtEndTime.PressKeys(System.DateTime.Now.AddHours(1).ToShortTimeString());
	        	calendar.EventDetailForm.btnOK.Click();
	        	AppointmentOverlapPrompt();
	        	ValidateEventRemainderPopup();
	        	Report.Success(String.Format("Appoitnment Created for without file attached for {0}",data+"_2"));
	        	
			}
         private void TE_withNoFile()
         {
         	string[] arrdata=new string[2]{data+"_1",data+"_2"};
         	ts.MainForm.Self.Activate();
        	Delay.Seconds(1);
        	ts.MainForm.btnTimeSheets.Click();
        	Delay.Seconds(5);
        	ts.MainForm.Toolbar.btnTimeEntryAssistant.Click();
        	ts.TimeEntryAssistantForm.SelfInfo.WaitForExists(3000);
        	ts.TimeEntryAssistantForm.PnlBase.cbItemsWithNoFile.Uncheck();
        	cmn.MultipleSelection(ts.TimeEntryAssistantForm.PnlBase.tbTimeEntryAssistant,arrdata);
        	ts.TimeEntryAssistantForm.Toolbar1.btnTimeSaver.Click();
        	ts.PromptForm.SelfInfo.WaitForExists(3000);
        	if(ts.PromptForm.txtPrompt.TextValue.Contains("One or more items have no File assigned. Do you wish to continue?"))
        	{
        		Report.Success("Prompt shown successfully for peforming Time Saver on Files which are not assigned");
        	}
        	else
        	{
        		Report.Failure(String.Format("Invalid Prompt shown as {0}",ts.PromptForm.txtPrompt.TextValue));
        	}
        	ts.PromptForm.btnNo.Click();
        	ts.TimeEntryAssistantForm.PnlBase.cbItemsWithNoFile.Check();
        	if(ts.PromptForm.SelfInfo.Exists(3000))
        	{ts.PromptForm.btnNo.Click();
        	}
        	ts.TimeEntryAssistantForm.Toolbar1.btnClose.Click();
         
        }
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            create_Appointment();
            TE_withNoFile();
            cmn.ClosePrompt();
        }
    }
}
