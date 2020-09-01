/*
 * Created by Ranorex
 * User: qa
 * Date: 8/13/2020
 * Time: 12:57 PM
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
    /// Description of validate_manual_Entry_uncheck.
    /// </summary>
    [TestModule("5A222575-DDD0-4737-B40F-92854F542364", ModuleType.UserCode, 1)]
    public class validate_manual_Entry_uncheck : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public validate_manual_Entry_uncheck()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        FirmSettings firm=FirmSettings.Instance;

        
        
        private void manual_Entry_Uncheck()
        {
        	firm.MainForm.Self.Activate();
        	firm.MainForm.txtAttorney.Click();
        	Delay.Seconds(1);
        	firm.MainForm.Office.Click();
        	Delay.Seconds(2);
			firm.MainForm.View.Click();
			Delay.Seconds(2);
			firm.MainForm.FirmSettings1.Click();
			Delay.Seconds(1);
			firm.MainForm.FirmSettingsForm.lnkAccounting.Click();
			Delay.Seconds(1);
			firm.TimeFirmSettingsForm.cbAmicusBilling.Uncheck();
			Report.Success("Amicus Billing Checkbox is Unchecked");
			
			if(firm.PromptForm.SelfInfo.Exists(5000))
			{
				Report.Success(firm.PromptForm.txtMessage.GetAttributeValue<String>("Text"));
				firm.PromptForm.btnYes.Click();
			}
			
			if(firm.PromptForm.SelfInfo.Exists(5000))
			{
				Report.Success(firm.PromptForm.txtMessage.GetAttributeValue<String>("Text"));
				firm.PromptForm.btnYes.Click();
			}
			
			if(!firm.MainForm.SelfInfo.Exists(10000))
			{
				Report.Success("Amicus Attorney is closed successfully");
			}
        }
        
        private void RestartServices()
    	{
        	foreach(System.Diagnostics.Process myProc in System.Diagnostics.Process.GetProcesses())
			{
				if (myProc.ProcessName == "OUTLOOK")
				{
					myProc.Kill();
					Report.Success("Outlook proccess is closed successfully");
				}
    		}
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
        }
    }
}
