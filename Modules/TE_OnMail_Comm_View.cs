/*
 * Created by Ranorex
 * User: kumar
 * Date: 4/15/2020
 * Time: 5:12 PM
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
using SmokeTest.Modules;
using SmokeTest.Modules.Utilities;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of TE_OnMail_Comm_View.
    /// </summary>
    [TestModule("A25A5D8F-D2EB-4206-9DCA-2B20B8645DAB", ModuleType.UserCode, 1)]
    public class TE_OnMail_Comm_View : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TE_OnMail_Comm_View()
        {
            // Do not delete - a parameterless constructor is required!
        }
		
        Communications comm=Communications.Instance;
        TimeSheets ts=TimeSheets.Instance;
        Common cmn=new Common();
        static string rndData=System.DateTime.Now.ToString();
		string data=String.Format("Test Data Added {0}",rndData);
        
        
        private void TimeEntry_Perform_onMail()
        {
        	
        	string activitydesc="";
        	string[] toMail={"qaabacusnext@outlook.com"};
        	System.DateTime day1;
			day1=System.DateTime.Now;
        	comm.MainForm.Self.Activate();
        	Delay.Seconds(2);
			cmn.SendEmail(toMail,data);
			
        	if(comm.MainForm.btnCommunications1Info.Exists(3000))
        	{comm.MainForm.btnCommunications1.Click();}
        	else
        	{
        		comm.MainForm.btnCommunications.Click();
        	}
        	
        	comm.MainForm.txtOutstanding.Click();
        	comm.MainForm.PnlRestrictions.CheckBoxCalls.Uncheck();
        	comm.MainForm.PnlRestrictions.CheckBoxMessages.Uncheck();
        	Delay.Seconds(2);
        	comm.MainForm.btnSyncNow.Click();
        	Delay.Seconds(15);
        	cmn.SelectItemFromTableDblClick(comm.MainForm.tblCommunications,data,"Email Communications Table");
        	Delay.Seconds(2);
        	comm.EmailDetailForm.Toolbar1.btnDoTimeEntry.Click();
        	
        	comm.FileSelectForm.listFirstFoundFile.DoubleClick();
        	if(comm.PromptForm.SelfInfo.Exists(3000))
        	{
        		comm.PromptForm.btnYes.Click();
        	}
        	
        	activitydesc=comm.TimeEntryDetailsForm.MenubarFillPanel.txtActivityDescription.GetAttributeValue<String>("Text");
        	comm.TimeEntryDetailsForm.MenubarFillPanel.txtDate.PressKeys(day1.ToShortDateString());
			comm.TimeEntryDetailsForm.MenubarFillPanel.btnOK.Click();
        	ValidatePromptExists();
        	comm.EmailDetailForm.Toolbar1.btnOk.Click();
        	if(comm.PromptForm.SelfInfo.Exists())
        	{
        		comm.PromptForm.btnYes.Click();
        		
        	}
        	if(comm.PromptForm.SelfInfo.Exists())
        	{
        		comm.PromptForm.btnOK.Click();
        		
        	}
        	ValidateInTimeEntryModule(activitydesc);
        	
        	
        }
        
        public void ValidatePromptExists()
        {
        	if(comm.PromptForm.SelfInfo.Exists())
        	{
        		comm.PromptForm.btnNo.Click();
        		Report.Info("Time Entry Exists and not combined.");
        	}
        }
        
        
         public void ValidateInTimeEntryModule(string desc)
        {
        	Delay.Seconds(3);
        	ts.MainForm.Self.Activate();
        	ts.MainForm.btnTimeSheets.Click();
        	Delay.Seconds(3);
        	cmn.VerifyDataExistsInTable(ts.MainForm.tblTimeSheet,desc,"Time Entry Table");
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
            TimeEntry_Perform_onMail();
            
        }
    }
}
