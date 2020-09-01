/*
 * Created by Ranorex
 * User: kumar
 * Date: 4/3/2020
 * Time: 11:25 AM
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
    /// Description of verifyOutlookDisabledToolbar.
    /// </summary>
    [TestModule("95CDA624-0891-4693-91DB-4DC1179D2F6F", ModuleType.UserCode, 1)]
    public class verifyOutlookDisabledToolbar : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public verifyOutlookDisabledToolbar()
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
			CheckAmicusAddInNotInOutlook();
		
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
        	
        	pref.EmailPreferencesForm.Panel2.btnStep2.Click();
        	Delay.Seconds(1);
        	if(!pref.EmailAttachmentForm.btnFinish.Enabled)
        	{
        		if(pref.EmailAttachmentForm.txtAttachmentSaveLocation.GetAttributeValue<String>("Text")=="")
	    	    {
	    	    	pref.EmailAttachmentForm.txtAttachmentSaveLocation.TextValue="\\\\NEWAUTOMATION\\DocumentAssemblyTemplates";
	    	    	pref.EmailAttachmentForm.btnBrowse.Click();
	    	    	Delay.Seconds(1);
	    	    	pref.BrowseFolder.btnOK.Click();
	    	    	
	    	    }
        	}
        	pref.EmailAttachmentForm.btnFinish.Click();
        	
        	pref.EmailPreferencesForm.Panel2.btnStep3.Click();
        	
        	
        	pref.EmailAutoSaveForm.btnFinish.Click();
        	
        	pref.EmailPreferencesForm.Panel2.btnStep4.Click();
        	pref.EmailInitialization.PnlControls.cbReviewGuide.Check();
        	pref.EmailInitialization.PnlControls.cbCurrentlyLoggedIn.Check();
        	pref.EmailInitialization.PnlControls.cbReadytoBeginProcess.Check();
        	pref.EmailInitialization.Toolbar1.btnBeginProcess.Click();
        	if(pref.PromptForm.SelfInfo.Exists(15000))
        	{pref.PromptForm.ButtonOK.Click();}
        	if(pref.PromptForm.SelfInfo.Exists(3000))
        	   {pref.PromptForm.ButtonOK.Click();}
        	pref.EmailInitialization.Toolbar1.btnFinish.Click();
        	
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
         
         
        private void CheckAmicusAddInNotInOutlook()
        {
        	OpenApp();
        	Validate.NotExists(outlook.Outlook.tabAmicusTasksInfo,"Amicus Tasks Toolbar not installed as expected");
        	outlook.Outlook.Self.Close();
        	CloseProcess();
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
            CloseProcess();
            UnsetOutlookAddIn();
        }
    }
}
