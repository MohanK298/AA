/*
 * Created by Ranorex
 * User: kumar
 * Date: 4/13/2020
 * Time: 5:51 PM
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
    /// Description of embeddedOutlookValidation.
    /// </summary>
    [TestModule("4422519F-F937-4395-B060-7AB538012336", ModuleType.UserCode, 1)]
    public class embeddedOutlookValidation : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public embeddedOutlookValidation()
        {
            // Do not delete - a parameterless constructor is required!
        }
		
        SmokeTest.Repositories.Premium.Preferences pref=SmokeTest.Repositories.Premium.Preferences.Instance;
        Communications comm=Communications.Instance;
        Login login=Login.Instance;
        SmokeTestRepository str = SmokeTestRepository.Instance;
       
        
        private void ValidateOutlookEmbedded()
 		{
 			
 			pref.MainForm.Self.Activate();
 			pref.MainForm.OfficeModule.Click();
			pref.MainForm.View.Click();
			Delay.Seconds(2);
			pref.MainForm.Preferences1.Click();
			Delay.Seconds(2);
			pref.MainForm.Email.Click();
			checkAmicusToolbarInstalled();
			ValidateEmbeddedOutlook();
			
		
 		}
		
        private void OpenAmicusApp()
        {
        	Host.Local.RunApplication("C:\\Amicus\\Amicus Attorney Workstation\\AmicusAttorney.XWin.exe");
        	var datasource=Ranorex.DataSources.Get("LoginData");
        	datasource.Load();
        	
        	login.SelfInfo.WaitForExists(10000);
        	
        	login.LoginForm.FirmId.TextValue=datasource.Rows[0].Values[0].ToString();//"QA Toronto 10";
        	login.LoginForm.UserId.TextValue=datasource.Rows[0].Values[1].ToString();//="admin user";
        	login.LoginForm.Pwd.TextValue=datasource.Rows[0].Values[2].ToString();//"password";
        	login.LoginForm.ServerName.TextValue=datasource.Rows[0].Values[3].ToString();//"J4-Mohanss";
        	Delay.Seconds(5);
        	login.LoginForm.btnLogin.Click();
        	if(pref.PromptForm.SelfInfo.Exists(20000))
        	{
        		pref.PromptForm.btnYes.Click();
        	}
        	Delay.Seconds(10);
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
        	pref.EmailAutoSaveForm.cbAutoSave.Check();
        	Report.Screenshot();
        	pref.EmailAutoSaveForm.btnFinish.Click();
        	
        	pref.EmailPreferencesForm.Panel2.btnStep4.Click();
        	pref.EmailInitialization.PnlControls.cbReviewGuide.Check();
        	if(pref.EmailInitialization.PnlControls.cbAppyAutoSaveInfo.Exists(3000))
        	{
        		pref.EmailInitialization.PnlControls.cbAppyAutoSave.Check();
        	}
        	pref.EmailInitialization.PnlControls.cbCurrentlyLoggedIn.Check();
        	pref.EmailInitialization.PnlControls.cbReadytoBeginProcess.Check();
        	pref.EmailInitialization.Toolbar1.btnBeginProcess.Click();
        	
        	pref.PromptForm.ButtonOK.Click();
        	if(pref.PromptForm.Self.Enabled)
        	   {pref.PromptForm.ButtonOK.Click();}
        	pref.EmailInitialization.Toolbar1.btnFinish.Click();
        	
        	pref.EmailPreferencesForm.btnClose.Click();
        	
        	pref.MainForm.Self.Close();
        	OpenAmicusApp();
        	
		}
        
        private void ValidateEmbeddedOutlook()
        {
        	comm.MainForm.Self.Activate();
        	if(comm.MainForm.btnCommunications1Info.Exists(3000))
        	{comm.MainForm.btnCommunications1.Click();}
        	else{
        		comm.MainForm.btnCommunications.Click();
        	}
        	comm.MainForm.txtOutlook.Click();
        	Delay.Seconds(2);
        	Validate.Exists(comm.MainForm.OutlookMailInfo,"Embedded Outlook is displayed as expected");
        	
        	                
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
            ValidateOutlookEmbedded();
        }
    }
}
