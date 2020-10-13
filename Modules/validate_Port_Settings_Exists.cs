/*
 * Created by Ranorex
 * User: qa
 * Date: 9/15/2020
 * Time: 3:59 PM
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
    /// Description of validate_Port_Settings_Exists.
    /// </summary>
    [TestModule("E2482148-BEBB-4D4D-B01D-4BB3C00860B4", ModuleType.UserCode, 1)]
    public class validate_Port_Settings_Exists : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public validate_Port_Settings_Exists()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        FirmSettings frm=FirmSettings.Instance;
        
        private void ValidatePortSettings_Exists()
        {
        	string preferredPort,currentPort="";
        	frm.MainForm.Self.Activate();
        	frm.MainForm.txtAttorney.Click();
        	frm.MainForm.Office.Click();
        	Delay.Seconds(2);
			frm.MainForm.View.Click();
			Delay.Seconds(2);
			frm.MainForm.FirmSettings1.Click();
			
			frm.MainForm.FirmSettingsForm.txtFirmBasics.Click();
			
			if(frm.ReportingServicesForm.SelfInfo.Exists(3000))
			{
				Report.Success("Firm Basics is displayed as expected");
				preferredPort=frm.ReportingServicesForm.PnlBase.txt_Preferred_TCP_Port.GetAttributeValue<String>("UIAutomationValueValue");
				if(preferredPort=="")
				{
					Report.Success("Preferred Port value is empty");
				}
				else
				{
					Report.Success("Preferred Port value is - "+preferredPort);
				}

				currentPort=frm.ReportingServicesForm.PnlBase.txt_Current_TCP_Port.GetAttributeValue<String>("UIAutomationValueValue");
				Report.Success("Current Port value is - "+currentPort);
				
				frm.ReportingServicesForm.Toolbar1.btnOk.Click();
			}
			
			if(frm.PromptForm.SelfInfo.Exists(5000))
			{
				Report.Success(frm.PromptForm.txtMessage.GetAttributeValue<String>("Text"));
				frm.PromptForm.btnOK.Click();
				Report.Success("Ok Button is clicked");
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
            ValidatePortSettings_Exists();
        }
    }
}
