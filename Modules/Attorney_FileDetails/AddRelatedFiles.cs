/*
 * Created by Ranorex
 * User: Het Patel
 * Date: 7/26/2016
 * Time: 3:50 PM
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
    /// Description of AddRelatedFiles.
    /// </summary>
    [TestModule("44ED8D19-9B72-44AC-AC3D-0FFB9D3F55A3", ModuleType.UserCode, 1)]
    public class AddRelatedFiles : ITestModule
    {
    	//Repository Variable
    	SmokeTest.Repositories.Files file = new SmokeTest.Repositories.Files();
    	
        public AddRelatedFiles()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void Action(){
        	file.MainForm.FilesIndexForm.listFirstFile.DoubleClick();
        	Delay.Seconds(2);
        	file.FileDetailForm.RelatedFiles.Click();
        	Delay.Seconds(1);
        	file.FileDetailForm.BtnAdd.Click();
        	Delay.Seconds(1);
        	file.FileSelectForm.QuickFind.Click();
        	Delay.Seconds(1);
        	file.FindFilesForm.txtSearch.PressKeys("Personal - Illness");
        	file.FindFilesForm.btnOK.Click();
        	Delay.Seconds(1);
        	file.FileSelectForm.File.Click();
        	file.FileSelectForm.SomeButton.Click();
        	file.FileSelectForm.btnOK.Click();
        	file.FileDetailForm.btnSaveClose.Click();
        	Delay.Seconds(2);
        	file.MainForm.FilesIndexForm.listFirstFile.DoubleClick();
        	Delay.Seconds(2);
        	file.FileDetailForm.RelatedFiles.Click();
        	Delay.Seconds(1);
        	//Validate.Attribute(file.FileDetailForm.ShortFileNameInfo, "Text", new Regex("Personal - Illness"));
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
