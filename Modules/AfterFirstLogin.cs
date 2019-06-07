/*
 * Created By Qiao
 * User: Administrator
 * Date: 2018-12-14
 * Time: 11:42 AM
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

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using SmokeTest.Repositories;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of AfterFirstLogin.
    /// </summary>
    [TestModule("B3AAD322-BF01-45CC-991B-D2C82D97C9EB", ModuleType.UserCode, 1)]
    public class AfterFirstLogin : ITestModule
    {
    	//Repository Variable
    	SmokeTestRepository str = SmokeTestRepository.Instance;
    	Duration customWaitTime = new Duration(3000);
    	public static SmokeTestRepository repo = SmokeTestRepository.Instance; 
    	
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public AfterFirstLogin()
        {
            // Do not delete - a parameterless constructor is required!
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
            
            PopupWatcher ceipDialogWatcher = new PopupWatcher();
            ceipDialogWatcher.WatchAndClick(str.CustomerExperienceProgramForm, str.CustomerExperienceProgramForm.AcceptInfo);
            ceipDialogWatcher.Start();
            CloseAnnoncementForm();
            CloseAllDetails();
            ceipDialogWatcher.Stop();
            
        }
        
        private void CloseAnnoncementForm()
        {
        	try {
        		str.AnnouncementForm.Self.Activate();
        		str.AnnouncementForm.SelfInfo.WaitForExists(customWaitTime);
        		str.AnnouncementForm.ToolbarToolbarBaseDesigner1.btnOKInfo.WaitForExists(customWaitTime);
        		str.AnnouncementForm.ToolbarToolbarBaseDesigner1.btnOK.Click();
        	} catch (Exception) {
        		
        		Report.Log(ReportLevel.Failure, "Failed to click OK button to close the Annoncement form");
        	}
        }
        
        public static void CloseAllDetails()
        {
        	repo.MainForm.Self.Activate();
        	repo.MainForm.menuItemFileInfo.WaitForExists(new Duration(3000));
        	repo.MainForm.menuItemFile.Select();
        	repo.AmicusAttorneyXWin.CloseAllDetails.Click();
        }
    }
}
