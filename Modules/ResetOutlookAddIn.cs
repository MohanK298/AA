/*
 * Created by Ranorex
 * User: kumar
 * Date: 4/15/2020
 * Time: 3:48 PM
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
    /// Description of ResetOutlookAddIn.
    /// </summary>
    [TestModule("68378481-01B6-4ECB-BF2F-7203C44CC884", ModuleType.UserCode, 1)]
    public class ResetOutlookAddIn : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ResetOutlookAddIn()
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
         
        private void UnsetOutlookAddIn()
 		{
 			
 			pref.MainForm.Self.Activate();
 			pref.MainForm.OfficeModule.Click();
			pref.MainForm.View.Click();
			Delay.Seconds(2);
			pref.MainForm.Preferences1.Click();
			Delay.Seconds(2);
			pref.MainForm.Email.Click();
			checkAmicusToolbarNotInstalled();
			CloseProcess();
		
 		}
        
        
         private void checkAmicusToolbarNotInstalled()
		{
        	pref.EmailPreferencesForm.rdoOutlook.Select();
        	
        	pref.EmailPreferencesForm.btnStep1.Click();
        	pref.EmailBasicForm.SelfInfo.WaitForExists(3000);
        	pref.EmailBasicForm.PnlControls.cbEnableAmicusToolbar.Uncheck();
        	pref.EmailBasicForm.PnlControls.cbSavedUnsavedEmail.Uncheck();
        	pref.EmailBasicForm.PnlControls.cbShowEmbeddedView.Uncheck();
        	pref.EmailBasicForm.PnlControls.cbStartTimer.Uncheck();
        	pref.EmailBasicForm.Toolbar1.btnFinish.Click();
        	if(pref.PromptForm.SelfInfo.Exists(10000))
        	{pref.PromptForm.ButtonOK.Click();}
        	
        	pref.EmailPreferencesForm.rdoNone.Click();
        	if(pref.PromptForm.SelfInfo.Exists(10000))
        	{pref.PromptForm.ButtonOK.Click();}
        	
        	pref.EmailPreferencesForm.btnClose.Click();
        	
		}
        private void CloseProcess()
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
            UnsetOutlookAddIn();
        }
    }
}
