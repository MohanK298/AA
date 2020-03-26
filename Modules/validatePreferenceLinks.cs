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
			DocumentHeaderValidation();
			TimeHeaderValidation();
			NotesHeaderValidation();
			CommHeaderValidation();
			LibraryHeaderValidation();
			EmailHeaderValidation();
			
			
			
		
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
         
         
         private void DocumentHeaderValidation()
         {
         	pref.MainForm.PreferencesForm.Management.Click();
        	if(pref.DocTemplatePrefForm.SelfInfo.Exists(3000))
        	{
        		if(pref.DocTemplatePrefForm.txtDocumentsInfo.Exists(3000))
        			Report.Success("Document Management Window is opened successfully");
        		Validate.AttributeEqual(pref.DocTemplatePrefForm.txtDocumentsInfo,"Text","Documents - Management","Documents - Management text is displayed successfully");
        		pref.DocTemplatePrefForm.Toolbar1.ButtonOK.Click();
        	}
        	
            	
        	
        	pref.MainForm.PreferencesForm.DocumentAssembly.Click();
        	if(pref.DocTemplatePrefForm.SelfInfo.Exists(3000))
        	{
        		if(pref.DocTemplatePrefForm.txtDocumentsInfo.Exists(5000))
        			Report.Success("Document assembly Window is opened successfully");
        		Validate.AttributeEqual(pref.DocTemplatePrefForm.txtDocumentsInfo,"Text","Documents - Document Assembly","Documents - Document Assembly text is displayed successfully");
        		pref.DocTemplatePrefForm.Toolbar1.ButtonOK.Click();
        	}
         }
         
         
          private void TimeHeaderValidation()
         {
         	pref.MainForm.PreferencesForm.BillingRates.Click();
        	if(pref.TimePreferencesForm.SelfInfo.Exists(3000))
        	{
        		if(pref.TimePreferencesForm.txtTimeInfo.Exists(3000))
        			Report.Success("Billing Rates Window is opened successfully");
        		Validate.AttributeEqual(pref.TimePreferencesForm.txtTimeInfo,"Text","Time - Billing Rates","Time - Billing Rates text is displayed successfully");
        		pref.TimePreferencesForm.Toolbar1.btnOK.Click();
        	}
        	
            	
        	
        	pref.MainForm.PreferencesForm.TimeNewEntries.Click();
        	if(pref.TimePreferencesForm.SelfInfo.Exists(3000))
        	{
        		if(pref.TimePreferencesForm.txtTimeInfo.Exists(3000))
        			Report.Success("Time New Entries Window is opened successfully");
        		Validate.AttributeEqual(pref.TimePreferencesForm.txtTimeInfo,"Text","Time - New Entries","Time - New Entries text is displayed successfully");
        		pref.TimePreferencesForm.Toolbar1.btnOK.Click();
        	}
        	
        	
        	pref.MainForm.PreferencesForm.Timer.Click();
        	if(pref.TimePreferencesForm.SelfInfo.Exists(3000))
        	{
        		if(pref.TimePreferencesForm.txtTimeInfo.Exists(3000))
        			Report.Success("Timer Window is opened successfully");
        		Validate.AttributeEqual(pref.TimePreferencesForm.txtTimeInfo,"Text","Time - Timer","Time - Timer text is displayed successfully");
        		pref.TimePreferencesForm.Toolbar1.btnOK.Click();
        	}
        	
        	pref.MainForm.PreferencesForm.Formatting.Click();
        	if(pref.TimePreferencesForm.SelfInfo.Exists(3000))
        	{
        		if(pref.TimePreferencesForm.txtTimeInfo.Exists(3000))
        			Report.Success("Formatting is opened successfully");
        		Validate.AttributeEqual(pref.TimePreferencesForm.txtTimeInfo,"Text","Time - Formatting","Time - Formatting text is displayed successfully");
        		pref.TimePreferencesForm.Toolbar1.btnOK.Click();
        	}
        	
        	
        	pref.MainForm.PreferencesForm.ActivityCodes.Click();
        	if(pref.TimePreferencesForm.SelfInfo.Exists(3000))
        	{
        		if(pref.TimePreferencesForm.txtTimeInfo.Exists(3000))
        			Report.Success("Activity Codes Window is opened successfully");
        		Validate.AttributeEqual(pref.TimePreferencesForm.txtTimeInfo,"Text","Time - My Activity Codes","Time - My Activity Codes text is displayed successfully");
        		pref.TimePreferencesForm.Toolbar1.btnOK.Click();
        	}
        	
        	pref.MainForm.PreferencesForm.Fiscal.Click();
        	if(pref.TimePreferencesForm.SelfInfo.Exists(3000))
        	{
        		if(pref.TimePreferencesForm.txtTimeInfo.Exists(3000))
        			Report.Success("Statistics Window is opened successfully");
        		Validate.AttributeEqual(pref.TimePreferencesForm.txtTimeInfo,"Text","Time - Statistics","Time - Statistics text is displayed successfully");
        		pref.TimePreferencesForm.Toolbar1.btnOK.Click();
        	}
        	
         }
          
          
        private void NotesHeaderValidation()
        {
        	pref.MainForm.PreferencesForm.General.Click();
        	if(pref.NotesPrefForm.SelfInfo.Exists(3000))
        	{
        		if(pref.NotesPrefForm.txtNotesInfo.Exists(3000))
        			Report.Success("General Window is opened successfully");
        		Validate.AttributeEqual(pref.NotesPrefForm.txtNotesInfo,"Text","Notes - General","Notes - General text is displayed successfully");
        		pref.NotesPrefForm.Toolbar1.ButtonOK.Click();
        	}
        
        }
        
        
        private void CommHeaderValidation()
        {
        	pref.MainForm.PreferencesForm.Messages.Click();
        	if(pref.CommPrefForm.SelfInfo.Exists(3000))
        	{
        		if(pref.CommPrefForm.txtCommInfo.Exists(3000))
        			Report.Success("Communication Messages Window is opened successfully");
        		Validate.AttributeEqual(pref.CommPrefForm.txtCommInfo,"Text","Communications - Phone Calls and Messages","Communications - Phone Calls and Messages text is displayed successfully");
        		pref.CommPrefForm.Toolbar1.ButtonOK.Click();
        	}
        
        }
        
        private void LibraryHeaderValidation()
        {
        	pref.MainForm.PreferencesForm.Defaults.Click();
        	if(pref.LibPrefForm.SelfInfo.Exists(3000))
        	{
        		if(pref.LibPrefForm.txtLibInfo.Exists(3000))
        			Report.Success("Library Defaults Window is opened successfully");
        		Validate.AttributeEqual(pref.LibPrefForm.txtLibInfo,"Text","Library - Defaults","Library - Defaults text is displayed successfully");
        		pref.LibPrefForm.Toolbar1.ButtonOK.Click();
        	}
        
        }
        
        private void EmailHeaderValidation()
        {
        	pref.MainForm.Email.Click();
        	if(pref.EmailPreferencesForm.SelfInfo.Exists(3000))
        	{
        		if(pref.EmailPreferencesForm.txtEmailInfo.Exists(3000))
        			Report.Success("Email Links Window is opened successfully");
        		Validate.AttributeEqual(pref.EmailPreferencesForm.txtEmailInfo,"Text","Outlook / Exchange E-mail","Outlook / Exchange E-mail text is displayed successfully");
        		pref.EmailPreferencesForm.btnClose.Click();
        	}
        	
        	
        	pref.MainForm.CalendarContacts.Click();
        	if(pref.OutlookPreferenceForm.SelfInfo.Exists(3000))
        	{
        		if(pref.OutlookPreferenceForm.txtCalendarInfo.Exists(3000))
        			Report.Success("Calendar and Contacts Integrations Window is opened successfully");
        		Validate.AttributeEqual(pref.OutlookPreferenceForm.txtCalendarInfo,"Text","Calendar and Contacts Integrations","Calendar and Contacts Integrations text is displayed successfully");
        		pref.OutlookPreferenceForm.Toolbar1.ButtonOK.Click();
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
