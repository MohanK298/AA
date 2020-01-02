/*
 * Created by Ranorex
 * User: Het Patel
 * Date: 7/26/2016
 * Time: 2:16 PM
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

namespace SmokeTest.Modules.Attorney_FileDetails
{
    [TestModule("92F81089-3096-48F5-9097-207B8E24471C", ModuleType.UserCode, 1)]
    public class AddStatusReport : ITestModule
    {
    	SmokeTest.Repositories.Files file = new SmokeTest.Repositories.Files();
    	
        public AddStatusReport()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void Action(){
        	file.MainForm.FilesIndexForm.listFirstFile.DoubleClick();
        	Delay.Seconds(2);
        	file.FileDetailForm.StatusReport.Click();
        	Delay.Seconds(2);
        	file.FileDetailForm.txtStatusReport.PressKeys("Testing Status Report tab.");
        	Delay.Seconds(2);
        	file.FileDetailForm.btnSaveClose.Click();
        	Delay.Seconds(2);
        	file.MainForm.FilesIndexForm.listFirstFile.DoubleClick();
        	Delay.Seconds(2);
        	file.FileDetailForm.StatusReport.Click();
        	Delay.Seconds(2);
        	Validate.Attribute(file.FileDetailForm.txtStatusReportInfo, "Text", "Testing Status Report tab.");
        	file.FileDetailForm.btnSaveClose.Click();
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            Action();
            Utilities.Common.ClosePrompt();
        }
    }
}
