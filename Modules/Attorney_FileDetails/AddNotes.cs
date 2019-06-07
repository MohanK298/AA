/*
 * Created by Ranorex
 * User: Het Patel
 * Date: 7/26/2016
 * Time: 3:31 PM
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
    /// <summary>
    /// Description of AddNotes.
    /// </summary>
    [TestModule("39757ABA-2474-4146-A459-BDA32520C0DA", ModuleType.UserCode, 1)]
    public class AddNotes : ITestModule
    {
    	
    	//Repository Variable
    	SmokeTest.Repositories.Files file = new SmokeTest.Repositories.Files();
    	
        public AddNotes()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void Action(){
        	file.MainForm.FilesIndexForm.listFirstFile.DoubleClick();
        	Delay.Seconds(2);
        	file.FileDetailForm.Notes.Click();
        	Delay.Seconds(1);
        	file.FileDetailForm.MainNote.Click();
        	Delay.Seconds(1);
        	file.FileDetailForm.txtMainNote.PressKeys("Testing Main Note tab.");
        	Delay.Seconds(2);
        	file.FileDetailForm.btnSaveClose.Click();
        	Delay.Seconds(2);
        	file.MainForm.FilesIndexForm.listFirstFile.DoubleClick();
        	Delay.Seconds(2);
        	file.FileDetailForm.Notes.Click();
        	Delay.Seconds(1);
        	file.FileDetailForm.MainNote.Click();
        	Delay.Seconds(1);
        	Validate.Attribute(file.FileDetailForm.txtMainNoteInfo, "Text", "Testing Main Note tab.");
        	file.FileDetailForm.btnSaveClose.Click();
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            Action();
        }
    }
}
