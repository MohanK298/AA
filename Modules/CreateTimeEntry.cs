/*
 * Created by Ranorex
 * User: Admin
 * Date: 7/29/2015
 * Time: 9:48 AM
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
using SmokeTest.Modules.Utilities;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

using SmokeTest.Repositories;

namespace SmokeTest.Modules
{
    [TestModule("361E73A7-9F91-4751-A3C0-1CBEB6425E44", ModuleType.UserCode, 1)]
    public class CreateTimeEntry : ITestModule
    {
    	//Respository Variable
    	TimeSheets timeEntry = TimeSheets.Instance;
    	Common cmn=new Common();
    	string _fileName = "";
    	[TestVariable("93D89583-5A13-46F5-9AF0-3180BB491885")]
    	public string fileName
    	{
    		get { return _fileName; }
    		set { _fileName = value; }
    	}
    	
    	string _time = "";
    	[TestVariable("560FF3B0-25B0-492A-9603-8A79653D2CF5")]
    	public string time
    	{
    		get { return _time; }
    		set { _time = value; }
    	}
    	
    	string _activityDescription = "";
    	[TestVariable("66F9E0BF-F87F-403A-B718-6353A67999B8")]
    	public string activityDescription
    	{
    		get { return _activityDescription; }
    		set { _activityDescription = value; }
    	}
    	
        public CreateTimeEntry()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void CreateTimeEntryWithData(){
        	
        	//Open Time Sheets
        	timeEntry.MainForm.btnTimeSheets.Click();
        	timeEntry.MainForm.btnAddTimeEntry.Click();
        	
        	//Add data
        		//Add file
        	timeEntry.FileSelectForm.btnQuickFind.Click();
        	timeEntry.FindFilesForm.txtFindFile.TextValue = fileName + time;
        	timeEntry.FindFilesForm.btnOK.Click();
        	timeEntry.FileSelectForm.listFirstFoundFile.DoubleClick();
        	timeEntry.TimeEntryDetailsForm.MenubarFillPanel.txtActivityDescription.PressKeys(activityDescription);
        	timeEntry.TimeEntryDetailsForm.MenubarFillPanel.btnOK.Click();
        	
        	//Verify if time entry is done
        	timeEntry.MainForm.listFirstPostedItem.DoubleClick();
        	Report.Success("Create Time Entry passed");
        	timeEntry.TimeEntryDetailsForm.MenubarFillPanel.btnOK.Click();
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            CreateTimeEntryWithData();
            cmn.ClosePrompt();
        }
    }
}
