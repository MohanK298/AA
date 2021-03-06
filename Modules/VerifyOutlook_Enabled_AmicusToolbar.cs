﻿/*
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
        Login login=Login.Instance;
        SmokeTestRepository str = SmokeTestRepository.Instance;
        
        private void OpenApp()
        {
        	Host.Local.RunApplication(outlookPath);
        	Delay.Seconds(5);
        	outlook.OutlookSplash.SelfInfo.WaitForNotExists(60000);
        	
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
        	login.LoginForm.btnLogin.Click();
        	if(pref.PromptForm.SelfInfo.Exists(15000))
        	{
        		pref.PromptForm.btnYes.Click();
        	}
        	Delay.Seconds(10);
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
			CheckAmicusTasksInOutlook();
		
 		}

        private void checkAmicusToolbarInstalled()
		{
        	string pathLocation="";
        	pref.EmailPreferencesForm.rdoOutlook.Select();
        	
        	pref.EmailPreferencesForm.btnStep1.Click();
        	pref.EmailBasicForm.SelfInfo.WaitForExists(3000);
        	pref.EmailBasicForm.PnlControls.cbEnableAmicusToolbar.Check();
        	pref.EmailBasicForm.PnlControls.cbSavedUnsavedEmail.Check();
        	pref.EmailBasicForm.PnlControls.cbShowEmbeddedView.Check();
        	pref.EmailBasicForm.PnlControls.cbStartTimer.Check();
        	pref.EmailBasicForm.Toolbar1.btnFinish.Click();
        	
        	pref.EmailPreferencesForm.Panel2.btnStep2.Click();
        	Delay.Seconds(1);
        	pathLocation=pref.EmailAttachmentForm.txtAttachmentSaveLocation.GetAttributeValue<String>("UIAutomationValueValue");
        	Report.Info("Path location is ---"+pathLocation);
        	if(pathLocation.Contains(""))
        	{
        		if(pref.EmailAttachmentForm.btnBrowse.Enabled)
        		{
        			pref.EmailAttachmentForm.btnBrowse.Click();
	        		Report.Info("Browse Button is clicked");
	        		pref.BrowseFolder.btnOK.Click();
	        		Report.Info("Ok Button is clicked in Browse Folder");
        		}
        	}
        	pref.EmailAttachmentForm.btnFinish.Click();
        	Report.Info("Finish Button is clicked in Step 2");
        	pref.EmailPreferencesForm.Panel2.btnStep3.Click();
        	pref.EmailAutoSaveForm.btnFinish.Click();
        	Report.Info("Finish Button is clicked in Step 3");
        	pref.EmailPreferencesForm.Panel2.btnStep4.Click();
        	pref.EmailInitialization.PnlControls.cbReviewGuide.Check();
        	pref.EmailInitialization.PnlControls.cbCurrentlyLoggedIn.Check();
        	pref.EmailInitialization.PnlControls.cbReadytoBeginProcess.Check();
        	if(pref.EmailInitialization.PnlControls.cbAppyAutoSave.Enabled)
        	{
        		
        		pref.EmailInitialization.PnlControls.cbAppyAutoSave.Check();
        		Report.Info("Auto Save Checkbox is checked when it is enabled");
        	}
        	pref.EmailInitialization.Toolbar1.btnBeginProcess.Click();
        	Report.Info("Begin Process is clicked in Step 4");
        	if(pref.PromptForm.SelfInfo.Exists(15000))
        	
        	{pref.PromptForm.ButtonOK.Click();}
        	
        	
        	if(pref.PromptForm.SelfInfo.Exists(3000))
        	   {pref.PromptForm.ButtonOK.Click();}
        	pref.EmailInitialization.Toolbar1.btnFinish.Click();
        	Report.Info("Finish Button is clicked in Step 4");
        	pref.EmailPreferencesForm.btnClose.Click();
        	
        	pref.MainForm.Self.Close();
        	OpenAmicusApp();
        	
		}
        
        private void CheckAmicusTasksInOutlook()
        {
        	OpenApp();
        	if(outlook.Outlook.tabAmicusTasksInfo.Exists(3000))
        	{
        		
        		outlook.Outlook.tabAmicusTasks.Click();
        		Report.Success("Amicus Tasks Tab is opened successfully");
        		if(outlook.Outlook.AmicusAttorneyTasks1.SelfInfo.Exists(10000))
        		{
        			if(outlook.Outlook.AmicusAttorneyTasks1.btnAddToFileInfo.Exists(10000))
        			{Validate.Exists(outlook.Outlook.AmicusAttorneyTasks1.btnAddToFile,"Add to File Button are displayed successfully");}
        			else
        			{Validate.Exists(outlook.Outlook.AmicusAttorneyTasks1.btnViewAddToRelatedFileInfo,"View/Add Related to File Button are displayed successfully");}
        				
        			Validate.Exists(outlook.Outlook.AmicusAttorneyTasks1.btnAddToPeople,"Add to People Button are displayed successfully");
        			Validate.Exists(outlook.Outlook.AmicusAttorneyTasks1.btnDetails,"Details Button are displayed successfully");
        			Validate.Exists(outlook.Outlook.AmicusAttorneyTasks1.btnAbout,"About Button are displayed successfully");
        			Validate.Exists(outlook.Outlook.AmicusAttorneyTasks1.btnSearchAmicus,"Search Amicus Button are displayed successfully");
        		}
        	}
        	outlook.Outlook.Self.Close();
        }
        	
        private void verifyOutlook_Enabled_AmicusToolbar()
        {
        	
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
            CloseProcess();
            setOutlookAddIn();
        }
    }
}
