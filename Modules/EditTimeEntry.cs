/*
 * Created by Ranorex
 * User: Admin
 * Date: 7/29/2015
 * Time: 9:59 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

using SmokeTest.Repositories;

namespace SmokeTest.Modules
{
    [TestModule("14B1208F-731C-49B8-8AFB-5908F745BF2A", ModuleType.UserCode, 1)]
    public class EditTimeEntry : ITestModule
    {
    	//Respository variable
    	TimeSheets timeEntry = TimeSheets.Instance;
    	
    	string _editActivityDescription = "";
    	[TestVariable("FC175A6C-C38A-461D-96A6-2E74FB8607C0")]
    	public string editActivityDescription
    	{
    		get { return _editActivityDescription; }
    		set { _editActivityDescription = value; }
    	}
    	
    	string _time = "";
    	[TestVariable("6976F0FD-A31A-4B99-8505-C74433BB220E")]
    	public string time
    	{
    		get { return _time; }
    		set { _time = value; }
    	}
    	
        public EditTimeEntry()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void EditTimeEntryWithData()
        {
        	timeEntry.MainForm.listFirstPostedItem.DoubleClick();
        	timeEntry.TimeEntryDetailsForm.MenubarFillPanel.txtActivityDescription.Click();
        	Keyboard.Press(System.Windows.Forms.Keys.A | System.Windows.Forms.Keys.Control, 30, Keyboard.DefaultKeyPressTime, 1, true);
            timeEntry.TimeEntryDetailsForm.MenubarFillPanel.txtActivityDescription.PressKeys("{Back}");
        	timeEntry.TimeEntryDetailsForm.MenubarFillPanel.txtActivityDescription.PressKeys(editActivityDescription);
        	timeEntry.TimeEntryDetailsForm.MenubarFillPanel.btnOK.Click();
        	
        	//Verify
        	timeEntry.MainForm.listFirstPostedItem.DoubleClick();
        	Report.Success("Edit Time Entry passed");
        	timeEntry.TimeEntryDetailsForm.MenubarFillPanel.btnOK.Click();
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            EditTimeEntryWithData();
            Utilities.Common.ClosePrompt();
        }
    }
}
