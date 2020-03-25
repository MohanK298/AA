/*
 * Created by Ranorex
 * User: kumar
 * Date: 3/25/2020
 * Time: 4:19 PM
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
    /// Description of validatePreferenceLinks.
    /// </summary>
    [TestModule("AF4B7F3B-2AED-4790-9A73-C3A41128A7D1", ModuleType.UserCode, 1)]
    public class validatePreferenceLinks : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public validatePreferenceLinks()
        {
            // Do not delete - a parameterless constructor is required!
        }
		Common cmn=new Common();
        FirmSettings frm=FirmSettings.Instance;
        Preferences pref=Preferences.Instance;
        
        private void verifyPreferencesLinks()
        {
        	pref.MainForm.Self.Activate();
 			pref.MainForm.OfficeModule.Click();
			pref.MainForm.View.Click();
			Delay.Seconds(2);
			pref.MainForm.Preferences1.Click();
			Delay.Seconds(2);
			GeneralHeaderValidation();
			MyApplicationHeaderValidation();
			DailiesHeaderValidation();
			FilesHeaderValidation();
			CalendarHeaderValidation();
			PeopleHeaderValidation();
        }
        
        
        private void GeneralHeaderValidation()
        {
        	pref.MainForm.PreferencesForm.MyProfile.Click();
        	if(pref.GeneralPreferencesForm.SelfInfo.Exists(3000))
        	{
        		if(pref.GeneralPreferencesForm.btnEditInfo.Exists(3000))
        			Report.Success("My Profile Window is opened successfully");
        		pref.GeneralPreferencesForm.ButtonOK.Click();
        	}
        	pref.MainForm.PreferencesForm.MyWorkgroup.Click();
        	if(pref.GeneralPreferencesForm.SelfInfo.Exists(3000))
        	{
        		if(pref.GeneralPreferencesForm.txtMyWorkgroupInfo.Exists(3000))
        			Report.Success("My Workgroup Window is opened successfully");
        		pref.GeneralPreferencesForm.ButtonOK.Click();
        	}
        }
        
        private void MyApplicationHeaderValidation()
        {
        	pref.MainForm.PreferencesForm.DefaultsOnLogin.Click();
        	if(pref.MyAppPrefForm.SelfInfo.Exists(3000))
        	{
        		if(pref.MyAppPrefForm.txtMyApplicationInfo.Exists(3000))
        			Report.Success("Defaults on Login Window is opened successfully");
        		pref.MyAppPrefForm.Toolbar1.ButtonOK.Click();
        	}
        	
        	
        	pref.MainForm.PreferencesForm.Toolbars.Click();
        	if(pref.MyAppPrefForm.SelfInfo.Exists(3000))
        	{
        		if(pref.MyAppPrefForm.txtMyApplicationInfo.Exists(3000))
        			Report.Success("Toolbars Window is opened successfully");
        		Validate.AttributeEqual(pref.MyAppPrefForm.txtMyApplicationInfo,"Text","My Application - Toolbars","My Application - Toolbars text is displayed successfully");
        		pref.MyAppPrefForm.Toolbar1.ButtonOK.Click();
        	}
        	
        	
        	pref.MainForm.PreferencesForm.SpellCheck.Click();
        	if(pref.MyAppPrefForm.SelfInfo.Exists(3000))
        	{
        		if(pref.MyAppPrefForm.txtMyApplicationInfo.Exists(3000))
        			Report.Success("Spell Check Window is opened successfully");
        		Validate.AttributeEqual(pref.MyAppPrefForm.txtMyApplicationInfo,"Text","My Application - Spell Check","My Application - Spell Check text is displayed successfully");
        		pref.MyAppPrefForm.Toolbar1.ButtonOK.Click();
        	}
        	
        	
        	
        }
        
        private void DailiesHeaderValidation()
        {
        	pref.MainForm.PreferencesForm.DailiesPages.Click();
        	if(pref.DailiesPrefForm.SelfInfo.Exists(3000))
        	{
        		if(pref.DailiesPrefForm.txtDailiesInfo.Exists(3000))
        			Report.Success("Dailies Window is opened successfully");
        		Validate.AttributeEqual(pref.DailiesPrefForm.txtDailiesInfo,"Text","Dailies - Pages","Dailies - Pages text is displayed successfully");
        		pref.DailiesPrefForm.Toolbar1.ButtonOK.Click();
        	}
        	
        	
        	pref.MainForm.PreferencesForm.TodaysPractice.Click();
        	if(pref.DailiesPrefForm.SelfInfo.Exists(3000))
        	{
        		if(pref.DailiesPrefForm.txtDailiesInfo.Exists(3000))
        			Report.Success("Today's Practices Window is opened successfully");
        		Validate.AttributeEqual(pref.DailiesPrefForm.txtDailiesInfo,"Text","Dailies - Today's Practice Reminders","Dailies - Today's Practice Reminders text is displayed successfully");
        		pref.DailiesPrefForm.Toolbar1.ButtonOK.Click();
        	}
        	
        }
    
        private void FilesHeaderValidation()
        {
        	pref.MainForm.PreferencesForm.FilesDisplay.Click();
        	if(pref.FilesPrefForm.SelfInfo.Exists(3000))
        	{
        		if(pref.FilesPrefForm.txtFilesInfo.Exists(3000))
        			Report.Success("Files Display Window is opened successfully");
        		Validate.AttributeEqual(pref.FilesPrefForm.txtFilesInfo,"Text","Files - Display","Files - Display text is displayed successfully");
        		pref.FilesPrefForm.Toolbar1.ButtonOK.Click();
        	}
        	
            	
        	
        	pref.MainForm.PreferencesForm.FilesNewEntries.Click();
        	if(pref.FilesPrefForm.SelfInfo.Exists(3000))
        	{
        		if(pref.FilesPrefForm.txtFilesInfo.Exists(3000))
        			Report.Success("Files New Entries Window is opened successfully");
        		Validate.AttributeEqual(pref.FilesPrefForm.txtFilesInfo,"Text","Files - New Entries","Files - New Entries text is displayed successfully");
        		pref.FilesPrefForm.Toolbar1.ButtonOK.Click();
        	}
        }
        
        private void CalendarHeaderValidation()
        {
        	pref.MainForm.PreferencesForm.CalendarDisplay.Click();
        	if(pref.CalendarPrefForm.SelfInfo.Exists(3000))
        	{
        		if(pref.CalendarPrefForm.txtCalendarInfo.Exists(3000))
        			Report.Success("Calendar Display Window is opened successfully");
        		Validate.AttributeEqual(pref.CalendarPrefForm.txtCalendarInfo,"Text","Calendar - Display","Calendar - Display text is displayed successfully");
        		pref.CalendarPrefForm.Toolbar1.ButtonOK.Click();
        	}
        	
        	pref.MainForm.PreferencesForm.CalendarNewEntries.Click();
        	if(pref.CalendarPrefForm.SelfInfo.Exists(3000))
        	{
        		if(pref.CalendarPrefForm.txtCalendarInfo.Exists(3000))
        			Report.Success("Calendar New Entries Window is opened successfully");
        		Validate.AttributeEqual(pref.CalendarPrefForm.txtCalendarInfo,"Text","Calendar - New Entries","Calendar - New Entries text is displayed successfully");
        		pref.CalendarPrefForm.Toolbar1.ButtonOK.Click();
        	}
        	
        	
        	pref.MainForm.PreferencesForm.CalendarOther.Click();
        	if(pref.CalendarPrefForm.SelfInfo.Exists(3000))
        	{
        		if(pref.CalendarPrefForm.txtCalendarInfo.Exists(3000))
        			Report.Success("Calendar Other Window is opened successfully");
        		Validate.AttributeEqual(pref.CalendarPrefForm.txtCalendarInfo,"Text","Calendar - Other","Calendar - Other text is displayed successfully");
        		pref.CalendarPrefForm.Toolbar1.ButtonOK.Click();
        	}
        	
        }
        
        
         private void PeopleHeaderValidation()
        {
        	pref.MainForm.PreferencesForm.PeopleDisplay.Click();
        	if(pref.PeoplePrefForm.SelfInfo.Exists(3000))
        	{
        		if(pref.PeoplePrefForm.txtPeopleInfo.Exists(3000))
        			Report.Success("People Display Window is opened successfully");
        		Validate.AttributeEqual(pref.PeoplePrefForm.txtPeopleInfo,"Text","People - Display","People - Display text is displayed successfully");
        		pref.PeoplePrefForm.Toolbar1.ButtonOK.Click();
        	}
        	
            	
        	
        	pref.MainForm.PreferencesForm.PeopleNewEntries.Click();
        	if(pref.PeoplePrefForm.SelfInfo.Exists(3000))
        	{
        		if(pref.PeoplePrefForm.txtPeopleInfo.Exists(3000))
        			Report.Success("People New Entries Window is opened successfully");
        		Validate.AttributeEqual(pref.PeoplePrefForm.txtPeopleInfo,"Text","People - New Entries","People - New Entries text is displayed successfully");
        		pref.PeoplePrefForm.Toolbar1.ButtonOK.Click();
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
            verifyPreferencesLinks();
        }
    }
}
