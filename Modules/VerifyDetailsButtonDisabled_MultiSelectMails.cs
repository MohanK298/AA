/*
 * Created by Ranorex
 * User: kumar
 * Date: 4/3/2020
 * Time: 11:40 AM
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
using SmokeTest.Repositories.Premium;
using SmokeTest.Modules.Utilities;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of VerifyDetailsButtonDisabled_MultiSelectMails.
    /// </summary>
    [TestModule("F34C5A6D-BBDF-49F9-9526-B2BD54F3160E", ModuleType.UserCode, 1)]
    public class VerifyDetailsButtonDisabled_MultiSelectMails : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public VerifyDetailsButtonDisabled_MultiSelectMails()
        {
            // Do not delete - a parameterless constructor is required!
        }

        string outlookPath="C:\\Program Files (x86)\\Microsoft Office\\root\\Office16\\OUTLOOK.EXE";
        Common cmn=new Common();
        FirmSettings frm=FirmSettings.Instance;
        Preferences pref=Preferences.Instance;
        Outlook_AddIn outlook=Outlook_AddIn.Instance;
        
        private void OpenApp()
        {
        	Host.Local.RunApplication(outlookPath);
        	Delay.Seconds(5);
        	outlook.OutlookSplash.SelfInfo.WaitForNotExists(60000);
        	
        }
        
        private void ValidateDetailsButton_MultiSelectMails()
        {
        	OpenApp();
        	cmn.MultiSelectEmail(3);
        	outlook.Outlook.tabAmicusTasks.Click();
    		Report.Success("Amicus Tasks Tab is opened successfully");
    		Delay.Seconds(2);
   			Validate.Attribute(outlook.Outlook.AmicusAttorneyTasks1.btnDetailsInfo,"Enabled","False","Details Button is disabled as expected");	
    		outlook.Outlook.Self.Close();
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
            ValidateDetailsButton_MultiSelectMails();
        }
    }
}
