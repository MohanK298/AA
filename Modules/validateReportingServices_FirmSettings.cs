/*
 * Created by Ranorex
 * User: qa
 * Date: 7/15/2020
 * Time: 6:43 PM
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
    /// Description of validateReportingServices_FirmSettings.
    /// </summary>
    [TestModule("059ABD1B-9476-4C54-AA72-5510E42A60DC", ModuleType.UserCode, 1)]
    public class validateReportingServices_FirmSettings : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public validateReportingServices_FirmSettings()
        {
            // Do not delete - a parameterless constructor is required!
        }
        Common cmn=new Common();
        FirmSettings firm=FirmSettings.Instance;
        
        private void ReportingServices()
        {
        	firm.MainForm.Self.Activate();
        	firm.MainForm.txtAttorney.Click();
        	firm.MainForm.Office.Click();
        	Delay.Seconds(2);
			firm.MainForm.View.Click();
			Delay.Seconds(2);
			firm.MainForm.FirmSettings1.Click();
			Delay.Seconds(1);
			
			firm.MainForm.FirmSettingsForm.txtReportingServices.Click();
			
			if(firm.ReportingServicesForm.SelfInfo.Exists(3000))
			{
				Report.Success("Reporting Services Form is displayed successfully");
				Report.Success(String.Format("Title {0} form is displayed successfully",firm.ReportingServicesForm.PnlBase.txtTitle.GetAttributeValue<String>("Text")));
				Validate.AttributeContains(firm.ReportingServicesForm.PnlBase.btnConfigureInfo,"Enabled","False","Configure Button is disabled as expected");
				Validate.AttributeContains(firm.ReportingServicesForm.PnlBase.btnTestInfo,"Enabled","True","Test Button is enabled as expected");
				Validate.AttributeContains(firm.ReportingServicesForm.PnlBase.btnPublishInfo,"Enabled","True","Publish Button is enabled as expected");
				Validate.AttributeContains(firm.ReportingServicesForm.PnlBase.btnEditInfo,"Enabled","True","Edit Button is enabled as expected");
				Report.Success(String.Format("Web Service URL of Reporting Services - {0}.",firm.ReportingServicesForm.PnlBase.txtURL.GetAttributeValue<String>("UIAutomationValueValue")));
				
				firm.ReportingServicesForm.PnlBase.btnTest.Click();
				if(firm.PromptForm.SelfInfo.Exists(3000))
				{
					Report.Success(String.Format("Txt Message - {0}",firm.PromptForm.txtMessage.GetAttributeValue<String>("Text")));
					firm.PromptForm.btnOK.Click();
				}
				
				firm.ReportingServicesForm.PnlBase.btnPublish.Click();
				if(firm.PromptForm.SelfInfo.Exists(3000))
				{
					Report.Success(String.Format("Txt Message - {0}",firm.PromptForm.txtMessage.GetAttributeValue<String>("Text")));
					firm.PromptForm.btnOK.Click();
				}
				firm.ReportingServicesForm.Toolbar1.btnCancel.Click();
								
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
            ReportingServices();
        }
    }
}
