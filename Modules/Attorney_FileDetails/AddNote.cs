/*
 * Created By Asish
 * User: Administrator
 * Date: 2017-11-02
 * Time: 11:31 AM
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

namespace SmokeTest.Modules.Attorney_FileDetails
{
    /// <summary>
    /// Description of AddNote.
    /// </summary>
    [TestModule("000EA7AA-65A2-40A9-A29E-F52FF9E3F883", ModuleType.UserCode, 1)]
    public class AddNote : ITestModule
    {
        //Repository Variable
    	SmokeTest.Repositories.Files file = new SmokeTest.Repositories.Files();
    	Common cmn=new Common();
        public AddNote()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void Action(){
        	file.MainForm.Self.Activate();
        	Delay.Seconds(2);
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
            cmn.ClosePrompt();
        }
    }
}
