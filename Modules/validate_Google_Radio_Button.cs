/*
 * Created by Ranorex
 * User: qa
 * Date: 9/21/2020
 * Time: 9:42 AM
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
	/// Description of validate_Google_Radio_Button.
	/// </summary>
	[TestModule("567565CE-966C-4E81-9200-990DD906B815", ModuleType.UserCode, 1)]
	public class validate_Google_Radio_Button : ITestModule
	{
		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		public validate_Google_Radio_Button()
		{
			// Do not delete - a parameterless constructor is required!
		}

		Preferences pref=Preferences.Instance;
		Common cmn=new Common();
		
		private void Google_Radio_Button_Exists()
		{
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
        		
        		Validate.Attribute(pref.OutlookPreferenceForm.PanelBase.rdoGoogleInfo,"Visible","True","Google Radio Button is visible as expected");
        		pref.OutlookPreferenceForm.PanelBase.rdoGoogle.Select();
        		Delay.Milliseconds(500);
        		Validate.Attribute(pref.OutlookPreferenceForm.PanelBase.rdoGoogleInfo,"Checked","True","Google Radio Button is selected as expected");
        		
        		pref.OutlookPreferenceForm.Toolbar1.Cancel.Click();
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
			Google_Radio_Button_Exists();
			cmn.ClosePrompt();
		}
	}
}
