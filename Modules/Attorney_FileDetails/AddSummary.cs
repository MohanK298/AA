/*
 * Created by Ranorex
 * User: Het Patel
 * Date: 7/26/2016
 * Time: 11:29 AM
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
    [TestModule("EA681289-5F56-4977-B7AD-826657B454EB", ModuleType.UserCode, 1)]
    public class AddSummary : ITestModule
    {
    	//Repository Variable
    	SmokeTest.Repositories.Files file = new SmokeTest.Repositories.Files();
    	
        public AddSummary()
        {
            // Do not delete - a parameterless constructor is required!
        }

        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            Action();
            Utilities.Common.ClosePrompt();
        }
        
        public void Action(){
        	file.MainForm.FilesIndexForm.listFirstFile.DoubleClick();
        	Delay.Seconds(2);
        	file.FileDetailForm.Summary.Click();
        	Delay.Seconds(1);
        	file.FileDetailForm.txtSummary.PressKeys("This is a Smoke Test text.");
        	Delay.Seconds(2);
        	file.FileDetailForm.btnSaveClose.Click();
        	Delay.Seconds(2);
        	file.MainForm.FilesIndexForm.listFirstFile.DoubleClick();
        	Delay.Seconds(2);
        	Validate.Attribute(file.FileDetailForm.txtSummaryInfo, "Text", "This is a Smoke Test text.");
        	file.FileDetailForm.btnSaveClose.Click();
        	
        	
        }
    }
}
