/*
 * Created by Ranorex
 * User: qa
 * Date: 9/21/2020
 * Time: 3:30 PM
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
using SmokeTest.Repositories.Premium;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest.Modules
{
	/// <summary>
	/// Description of validate_Google_synchronization.
	/// </summary>
	[TestModule("1801E90A-F39A-4CB7-8A16-8F0C89BDB1A5", ModuleType.UserCode, 1)]
	public class validate_Google_synchronization : ITestModule
	{
		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		public validate_Google_synchronization()
		{
			// Do not delete - a parameterless constructor is required!
		}
		
		Preferences pref=Preferences.Instance;
		Common cmn=new Common();
		
		private void Google_Synchronize()
		{
			string status="";
			pref.MainForm.Self.Activate();
			pref.MainForm.OfficeModule.Click();
			
			pref.MainForm.View.Click();
			Delay.Seconds(2);
			pref.MainForm.Preferences1.Click();
			Delay.Seconds(2);
			
			pref.MainForm.CalendarContacts.Click();
        	
        	if(pref.PromptForm.SelfInfo.Exists(3000))
        	{
        		pref.PromptForm.ButtonOK.Click();
        	}
        	
        	if(pref.OutlookPreferenceForm.SelfInfo.Exists(3000))
        	{
        		if(pref.OutlookPreferenceForm.txtCalendarInfo.Exists(3000))
        			Report.Success("Calendar and Contacts Integrations Window is opened successfully");
        		Validate.AttributeEqual(pref.OutlookPreferenceForm.txtCalendarInfo,"Text","Calendar and Contacts Integrations","Calendar and Contacts Integrations text is displayed successfully");
        		
        		
        		pref.OutlookPreferenceForm.PanelBase.rdoGoogle.Select();
        		Delay.Milliseconds(500);
        		Validate.Attribute(pref.OutlookPreferenceForm.PanelBase.rdoGoogleInfo,"Checked","True","Google Radio Button is selected as expected");
        		pref.OutlookPreferenceForm.PanelBase.btnConfigure.Click();
        		Report.Success("Configure Button is clicked");
        		
        		if(pref.Google_Config_Wizard.SelfInfo.Exists(3000))
        		{
        			Report.Success("Google Configuration Window is opened successfully");
        			
        			
        			Validate.Attribute(pref.Google_Config_Wizard.Panel2.btnStep1Info,"Enabled","True","Step 1 is enabled as expected");
        			Validate.Attribute(pref.Google_Config_Wizard.Panel2.btnStep2Info,"Enabled","False","Step 2 is disabled as expected");
        			Validate.Attribute(pref.Google_Config_Wizard.Panel2.btnStep3Info,"Enabled","False","Step 3 is disabled as expected");
        			Validate.Attribute(pref.Google_Config_Wizard.Panel2.btnStep4Info,"Enabled","False","Step 4 is disabled as expected");
        			Validate.Attribute(pref.Google_Config_Wizard.Panel2.btnResetInfo,"Enabled","False","Reset is disabled as expected");
        			
        			Validate.AttributeEqual(pref.Google_Config_Wizard.Panel2.txtSynchronizationSettingsInfo,"Text","Synchronization Settings","Synchronization Settings text is displayed successfully");
        			Validate.AttributeEqual(pref.Google_Config_Wizard.Panel2.txtLinkPreferencesInfo,"Text","Link Preferences","Link Preferences text is displayed successfully");
        			Validate.AttributeEqual(pref.Google_Config_Wizard.Panel2.txtFieldMappingAndMatchingCriteriaInfo,"Text","Field Mapping and Matching Criteria","Field Mapping and Matching Criteria text is displayed successfully");
        			Validate.AttributeEqual(pref.Google_Config_Wizard.Panel2.txtInitializationInfo,"Text","Initialization","Initialization text is displayed successfully");
        			Validate.AttributeEqual(pref.Google_Config_Wizard.Panel2.txtToResetLinkAndReinitializeInfo,"Text","To reset Link and reinitialize","To reset Link and reinitialize text is displayed successfully");
        			
        			status=pref.Google_Config_Wizard.Panel3.txtStatusStep1.GetAttributeValue<String>("Text");
        			if(status=="Complete")
        			{
        				Report.Success("Google link already configured successfully");
        			}
        			else
        			{
        				Report.Success("Google link yet to be configured");
        			}
        			Delay.Milliseconds(200);
        			status=pref.Google_Config_Wizard.Panel3.txtStatusStep2.GetAttributeValue<String>("Text");
        			Report.Success("Step 2 Status is : "+status);
        			Delay.Milliseconds(200);
        			status=pref.Google_Config_Wizard.Panel3.txtStatusStep3.GetAttributeValue<String>("Text");
        			Report.Success("Step 3 Status is : "+status);
        			Delay.Milliseconds(200);
        			status=pref.Google_Config_Wizard.Panel3.txtStatusStep4.GetAttributeValue<String>("Text");
        			Report.Success("Step 4 Status is : "+status);
        			
        			pref.Google_Config_Wizard.Panel2.btnStep1.Click();
        			Report.Success("Step 1 Button is clicked");
        			
        			if(pref.GoogleExchangeSettings.SelfInfo.Exists(3000))
        			{
        				Report.Success("Google Exchange Settings window displayed successfully");
        				pref.GoogleExchangeSettings.btnConnectWithGoogle.Click();
        				Report.Success("Connect with Google Button is clicked successfully");
        				
        				if(pref.SignInGoogleAccounts.SelfInfo.Exists(3000))
        				{
        					Report.Success("Sign In  Google Account Browser window is seen successfully");
        					pref.SignInGoogleAccounts.BCAAsb.lnkgmailAccount.Click();
        					Delay.Seconds(5);
        					
        					Report.Success(pref.SignInGoogleAccounts.BCAAsb.SeeEditDownloadAndPermanentlyDele.GetAttributeValue<String>("InnerText"));
        					Report.Success(pref.SignInGoogleAccounts.BCAAsb.SeeEditShareAndPermanentlyDelete.GetAttributeValue<String>("InnerText"));
        						
        					Delay.Seconds(3);
        					pref.SignInGoogleAccounts.btnAllow.Focus();
        					pref.SignInGoogleAccounts.btnAllow.Click();
        					Report.Success("Allow Button is clicked");
        					Delay.Seconds(3);
//        					Validate.Exists(pref.Google.SomeImgTagInfo,"Successfull");
        					
        					if(pref.PromptForm.SelfInfo.Exists(10000))
        					{
        						Report.Success(pref.PromptForm.txtMsg.GetAttributeValue<String>("Text"));
        						pref.PromptForm.ButtonOK.Click();
        					}
        					
        					
        					
        				}
        				pref.GoogleExchangeSettings.btnFinish.Click();
        				Report.Success("Finish Button is clicked successfully");
        				
        			}
        			pref.Google_Config_Wizard.btnClose.Click();
        			Report.Success("Close Button is clicked successfully");
        			
        			
        		}
        		pref.OutlookPreferenceForm.Toolbar1.Cancel.Click();
        		Report.Success("Cancel Button is clicked successfully");
        		
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
			
			Google_Synchronize();
			cmn.ClosePrompt();
		}
	}
}
