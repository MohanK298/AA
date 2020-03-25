/*
 * Created by Ranorex
 * User: kumar
 * Date: 3/23/2020
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
    /// Description of VerifyOutlook_Enabled_AmicusToolbar.
    /// </summary>
    [TestModule("0DF65B44-6467-42B1-915E-F9992BB6DC33", ModuleType.UserCode, 1)]
    public class VerifyOutlook_Enabled_AmicusToolbar : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public VerifyOutlook_Enabled_AmicusToolbar()
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
        	outlook.OutlookSplash.SelfInfo.WaitForNotExists(10000);
        	
        }
        
        	private void setOutlookAddIn()
 		{
 			
 			pref.MainForm.Self.Activate();
 			pref.MainForm.OfficeModule.Click();
			pref.MainForm.View.Click();
			Delay.Seconds(2);
			pref.MainForm.Preferences1.Click();
			Delay.Seconds(2);
			pref.MainForm.Email.Click();
			checkAmicusToolbarInstalled();
			
		
 		}

        private void checkAmicusToolbarInstalled()
		{
        	pref.EmailPreferencesForm.rdoOutlook.Select();
        	
        	pref.EmailPreferencesForm.btnStep1.Click();
        	pref.EmailBasicForm.SelfInfo.WaitForExists(3000);
        	pref.EmailBasicForm.PnlControls.cbEnableAmicusToolbar.Check();
        	pref.EmailBasicForm.PnlControls.cbSavedUnsavedEmail.Check();
        	pref.EmailBasicForm.PnlControls.cbShowEmbeddedView.Check();
        	pref.EmailBasicForm.PnlControls.cbStartTimer.Check();
        	pref.EmailBasicForm.Toolbar1.btnFinish.Click();
        	
        	pref.EmailPreferencesForm.Panel2.btnStep2.Click();
        	pref.EmailAttachmentForm.btnFinish.Click();
        	
        	pref.EmailPreferencesForm.Panel2.btnStep3.Click();
        	pref.EmailAutoSaveForm.btnFinish.Click();
        	
        	pref.EmailPreferencesForm.Panel2.btnStep4.Click();
        	pref.EmailInitialization.PnlControls.cbReviewGuide.Check();
        	pref.EmailInitialization.PnlControls.cbCurrentlyLoggedIn.Check();
        	pref.EmailInitialization.PnlControls.cbReadytoBeginProcess.Check();
        	pref.EmailInitialization.Toolbar1.btnBeginProcess.Click();
        	
        	pref.PromptForm.ButtonOK.Click();
        	pref.PromptForm.ButtonOK.Click();
        	pref.EmailInitialization.Toolbar1.btnFinish.Click();
        	
        	pref.EmailPreferencesForm.btnClose.Click();
        	
        	
        	
 			
		}
        	
        private void verifyOutlook_Enabled_AmicusToolbar()
        {
        	
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
            //OpenApp();
            setOutlookAddIn();
        }
    }
}
