/*
 * Created by Ranorex
 * User: kumar
 * Date: 4/14/2020
 * Time: 4:54 PM
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
    /// Description of TE_OnMail_OL_View.
    /// </summary>
    [TestModule("BFFF3A86-F4A1-4A17-B663-28B39A17C550", ModuleType.UserCode, 1)]
    public class TE_OnMail_OL_View : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public TE_OnMail_OL_View()
        {
            // Do not delete - a parameterless constructor is required!
        }

      	Communications comm=Communications.Instance;
      	TimeSheets ts=TimeSheets.Instance;
      	Common cmn=new Common();
      	
        
        private void PerformTimeEntry()
        {
        	string activitydesc="";
        	comm.MainForm.Self.Activate();
        	Delay.Seconds(2);

        	if(comm.MainForm.btnCommunications1Info.Exists(3000))
        	{comm.MainForm.btnCommunications1.Click();}
        	else
        	{
        		comm.MainForm.btnCommunications.Click();
        	}

        	comm.MainForm.txtOutlook.Click();
        	Delay.Seconds(2);
        	comm.MainForm.FirstMail.Click();
			Delay.Seconds(1);
			comm.MainForm.Toolbar1.btnDoATimeEntry.Click();
			activitydesc=comm.TimeEntryDetailsForm.MenubarFillPanel.txtActivityDescription.GetAttributeValue<String>("Text");
			comm.TimeEntryDetailsForm.MenubarFillPanel.btnOK.Click();
        	ValidatePromptExists();
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
            PerformTimeEntry();
        }
    }
}
