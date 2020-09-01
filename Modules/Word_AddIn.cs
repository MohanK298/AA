/*
 * Created by Ranorex
 * User: kumar
 * Date: 3/13/2020
 * Time: 1:44 PM
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
using SmokeTest.Repositories.Premium;
namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of Word_AddIn.
    /// </summary>
    [TestModule("97EDF10A-7D43-499C-969C-75A8DB0F528D", ModuleType.UserCode, 1)]
    public class Word_AddIn : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public Word_AddIn()
        {
            // Do not delete - a parameterless constructor is required!
        }
        string wordPath="C:\\Program Files (x86)\\Microsoft Office\\root\\Office16\\WINWORD.EXE";
        Common cmn=new Common();
        FirmSettings frm=FirmSettings.Instance;
        Preferences pref=Preferences.Instance;
        Word_app wapp=Word_app.Instance;
 		private void OpenApp()
        {
        	Host.Local.RunApplication(wordPath);
        	Delay.Seconds(10);
        	wapp.Word.Self.Activate();
        	wapp.Word.BlankDocument.Click();
        }
        
 		
 		private void setWordAddIn()
 		{
 			
 			pref.MainForm.Self.Activate();
 			pref.MainForm.OfficeModule.Click();
			pref.MainForm.View.Click();
			Delay.Seconds(2);
			pref.MainForm.Preferences1.Click();
			Delay.Seconds(2);
			pref.MainForm.PreferencesForm.DocumentAssembly.Click();
			checkAmicusToolbarInstalled();
			checkWordTaskToolbarInstalled();
			pref.GeneralPreferencesForm.ButtonOK.Click();
 		}

 		private void checkAmicusToolbarInstalled()
		{
 			if(pref.GeneralPreferencesForm.btnUninstallMergeToolbarInfo.Exists(3000))
 			{
 				Report.Success("Amicus Merge Toolbar is already Installed successfully");
 			}
 			else
 			{
 				if(pref.GeneralPreferencesForm.btnInstallMergeToolbarInfo.Exists(3000))
 				{
 					pref.GeneralPreferencesForm.btnInstallMergeToolbar.Click();
 				}
 				
 				
 				
 				if(wapp.AmicusMergeToolbarInstallShieldWiz.SelfInfo.Exists(10000))
 				{
 					Delay.Seconds(1);
 					wapp.AmicusMergeToolbarInstallShieldWiz.btnNext.Click();
 					Delay.Seconds(1);
 					wapp.AmicusMergeToolbarInstallShieldWiz.btnInstall.Click();
 					Delay.Seconds(5);
 					wapp.AmicusMergeToolbarInstallShieldWiz.btnFinish.Click();
 					Report.Success("Amicus Merge Toolbar is Installed successfully");
 				}
 			}
		}
 		private void checkWordTaskToolbarInstalled()
 		{
 			if(pref.GeneralPreferencesForm.btnWordRemoveInfo.Exists(10000))
 			{
 					Report.Success("Word is already Configured and Installed successfully");
 			}
 			else
 			{
 				pref.GeneralPreferencesForm.btnWordInstall.Click();
 					if(pref.PromptForm.SelfInfo.Exists(3000))
 					{
 						pref.PromptForm.ButtonOK.Click();
 						Report.Info("Warning message to Close all Word Applications displayed and closed successfully");
 					}
 					
 				if(wapp.AmicusAttorneyTasksToolbar.SelfInfo.Exists(3000))
 				{
 					wapp.AmicusAttorneyTasksToolbar.btnNext.Click();
 					wapp.AmicusAttorneyTasksToolbar.btnNext.Click();
 					wapp.AmicusAttorneyTasksToolbar.btnNext.Click();
 					Delay.Seconds(3);
 					wapp.AmicusAttorneyTasksToolbar.btnClose.Click();
 					if(pref.PromptForm.SelfInfo.Exists(3000))
 					{
 						pref.PromptForm.ButtonOK.Click();
 						Report.Info("Warning message to Restart Word displayed and closed successfully");
 					}
 					Report.Success("Word is Configured and Installed successfully");
 				}
 				
 			}

 		}
 		private void ValidateAmicusTaskToolbar()
 		{
 			if(wapp.WordDocument.tabAmicusTasksInfo.Exists(5000))
 			{
 				Report.Success("Amicus Tasks Toolbar successfully seen in the Word Document");
 				wapp.WordDocument.tabAmicusTasks.Click();
 				Validate.Attribute(wapp.WordDocument.AmicusAttorneyTasks1.btnDetailsInfo,"Enabled","False","Details button disabled as expected");
 				Validate.Attribute(wapp.WordDocument.AmicusAttorneyTasks1.btnAddToFileInfo,"Enabled","True","Add to File button is active and Enabled as expected");
 				Validate.Attribute(wapp.WordDocument.AmicusAttorneyTasks1.btnAddToPeopleInfo,"Enabled","True","Add to People button is active and Enabled as expected");
 				Validate.Attribute(wapp.WordDocument.AmicusAttorneyTasks1.btnAddToLibraryInfo,"Enabled","True","Add to Library button is active and Enabled as expected");
 				Validate.Attribute(wapp.WordDocument.AmicusAttorneyTasks1.btnSearchAmicusInfo,"Enabled","True","Search Button is active and Enabled as expected");
 				Validate.Attribute(wapp.WordDocument.AmicusAttorneyTasks1.btnCheckInInfo,"Enabled","False","Check-In button disabled as expected");
 				Validate.Attribute(wapp.WordDocument.AmicusAttorneyTasks1.btnCheckOutInfo,"Enabled","False","Check-Out button disabled as expected");
 				Validate.Attribute(wapp.WordDocument.AmicusAttorneyTasks1.btnAboutInfo,"Enabled","True","About button is active and Enabled as expected");
 			}
 			if(wapp.WordDocument.SelfInfo.Exists(3000))
 			{
 				wapp.WordDocument.Self.Close();
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
           
           setWordAddIn();
           OpenApp();
           ValidateAmicusTaskToolbar();
        }
    }
}
