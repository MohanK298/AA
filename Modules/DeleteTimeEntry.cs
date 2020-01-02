/*
 * Created by Ranorex
 * User: Admin
 * Date: 7/29/2015
 * Time: 10:11 AM
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
    [TestModule("870E238D-C9B4-47AB-9449-E55FD5EC38F2", ModuleType.UserCode, 1)]
    public class DeleteTimeEntry : ITestModule
    {
    	//Respository variable
    	TimeSheets timeEntry = TimeSheets.Instance;
    	
        public DeleteTimeEntry()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void DeleteTimeEntryWithData(){
        	timeEntry.MainForm.listFirstPostedItem.DoubleClick();
        	timeEntry.TimeEntryDetailsForm.MenubarFillPanel.btnDelete.Click();
        	timeEntry.PromptForm.btnYes.Click();
        	
        	Report.Success("Edit Time Delete passed");
        	
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            DeleteTimeEntryWithData();
            Utilities.Common.ClosePrompt();
        }
    }
}
