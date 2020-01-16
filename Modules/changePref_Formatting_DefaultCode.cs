/*
 * Created by Ranorex
 * User: kumar
 * Date: 1/16/2020
 * Time: 11:01 AM
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
    /// Description of changePref_Formatting_DefaultCode.
    /// </summary>
    [TestModule("FA1CC588-EED7-41F4-8BEA-81D8A7381D86", ModuleType.UserCode, 1)]
    public class changePref_Formatting_DefaultCode : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public changePref_Formatting_DefaultCode()
        {
            // Do not delete - a parameterless constructor is required!
        }

        Preferences pref=Preferences.Instance;
        Common cmn=new Common();
        TimeSheets ts=TimeSheets.Instance;
        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
       
        private void changepref_Validate_format_Default_Activity()
        {
        	//Navigate to Preferences
        	pref.MainForm.OfficeModule.Click();
			pref.MainForm.View.Click();
			Delay.Seconds(2);
			pref.MainForm.Preferences1.Click();
			Delay.Seconds(2);
			
			//Select a Default Activity Code
			pref.MainForm.PreferencesForm.ActivityCodes.Click();
			pref.TimePreferencesForm.cmbbxDefaultCodes.Click();
			cmn.SelectItemDropdown(pref.DropDownForm.tbDropdown,"Attend trial");
			pref.TimePreferencesForm.Toolbar1.btnOK.Click();
			Delay.Seconds(2);
			//Select the Formatting as Minutes
			pref.MainForm.PreferencesForm.Formatting.Click();
			pref.TimePreferencesForm.rdoMinutes.Select();
			pref.TimePreferencesForm.Toolbar1.btnOK.Click();
			
			//Validate the changes for Time Entry Creation
			ts.MainForm.Self.Activate();
        	Delay.Seconds(1);
        	ts.MainForm.btnTimeSheets.Click();
        	Delay.Seconds(1);
        	ts.MainForm.btnAddTimeEntry.Click();
        	ts.FileSelectForm.listFirstFoundFile.DoubleClick();
        	if(ts.FileSelectForm.Toolbar1.ButtonOKInfo.Exists(3000))
        	{
        		ts.FileSelectForm.Toolbar1.ButtonOK.Click();
        	}
        	
        	if(ts.TimeEntryDetailsForm.cmbbxActivityCodes.Text=="Attend trial")
        	{
        		Report.Success("Attend Trial activity is set to default value in the dropdown as selected in the Preferences");
        	}
        	else
        	{
        		Report.Failure(String.Format("Attend Trial activity is not set to default value in the dropdown as selected in the Preferences and the default value is currently set to {0}",ts.TimeEntryDetailsForm.cmbbxActivityCodes.Text));
        	}
        	if(ts.TimeEntryDetailsForm.MenubarFillPanel.txtStrtStpTime.TextValue=="00:06:00")
        	{
        		Report.Success(String.Format("Default Timer value is set to {0} as it is set as Minutes Formatting",ts.TimeEntryDetailsForm.MenubarFillPanel.txtStrtStpTime.TextValue));
        	}
        	else
        	{
        		Report.Failure(String.Format("Default Timer value is set to {0} and is not as set in Formatting",ts.TimeEntryDetailsForm.MenubarFillPanel.txtStrtStpTime.TextValue));
        	}
        	ts.TimeEntryDetailsForm.MenubarFillPanel.Cancel.Click();
        	
        	//Navigate to Preferences
        	pref.MainForm.OfficeModule.Click();
			pref.MainForm.View.Click();
			Delay.Seconds(2);
			pref.MainForm.Preferences1.Click();
			Delay.Seconds(2);
			
			
			//Select a Default Activity Code
			pref.MainForm.PreferencesForm.ActivityCodes.Click();
			pref.TimePreferencesForm.cmbbxDefaultCodes.Click();
			cmn.SelectItemDropdown(pref.DropDownForm.tbDropdown,"None");
			pref.TimePreferencesForm.Toolbar1.btnOK.Click();
			Delay.Seconds(2);
			//Select the Formatting as Tenths
			pref.MainForm.PreferencesForm.Formatting.Click();
			pref.TimePreferencesForm.rdoTenths.Select();
			pref.TimePreferencesForm.Toolbar1.btnOK.Click();
			
			
        }

        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            changepref_Validate_format_Default_Activity();
            Utilities.Common.ClosePrompt();
        }
    }
}
