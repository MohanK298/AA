/*
 * Created by Ranorex
 * User: qa
 * Date: 9/17/2020
 * Time: 12:00 PM
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
    /// Description of modify_port_Settings.
    /// </summary>
    [TestModule("CD1DAE8D-AAA0-4952-8BBC-25F0DC65F71D", ModuleType.UserCode, 1)]
    public class modify_port_Settings : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public modify_port_Settings()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        FirmSettings frm=FirmSettings.Instance;
        
        private void Modify_PortSettings_Exists()
        {
        	string portValue="42960"; 
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
					frm.ReportingServicesForm.PnlBase.txt_Preferred_TCP_Port.PressKeys(portValue);
					Report.Success("Preferred Port Value entered is"+portValue);
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
			
			
			frm.MainForm.FirmSettingsForm.txtFirmBasics.Click();
			
			if(frm.ReportingServicesForm.SelfInfo.Exists(3000))
			{
				Report.Success("Firm Basics is displayed as expected");
				preferredPort=frm.ReportingServicesForm.PnlBase.txt_Preferred_TCP_Port.GetAttributeValue<String>("UIAutomationValueValue");
				if(preferredPort!="")
				{
					Report.Success("Preferred Port value is - "+preferredPort);
					frm.ReportingServicesForm.PnlBase.txt_Preferred_TCP_Port.Click();
					frm.ReportingServicesForm.PnlBase.txt_Preferred_TCP_Port.PressKeys("{ControlKey down}{AKey}{ControlKey up}{Back}");
					Delay.Seconds(2);
					preferredPort=frm.ReportingServicesForm.PnlBase.txt_Preferred_TCP_Port.GetAttributeValue<String>("UIAutomationValueValue");
					Report.Success("Preferred Port value is - "+preferredPort);
					Report.Success("Preferred Port Value is cleaned");
				}
					frm.ReportingServicesForm.Toolbar1.btnOk.Click();
			
			
				if(frm.PromptForm.SelfInfo.Exists(5000))
				{
					Report.Success(frm.PromptForm.txtMessage.GetAttributeValue<String>("Text"));
					frm.PromptForm.btnOK.Click();
					Report.Success("Ok Button is clicked");
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
            Modify_PortSettings_Exists();
        }
    }
}
