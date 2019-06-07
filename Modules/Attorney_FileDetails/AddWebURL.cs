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
    public class AddWebURL : ITestModule
    {
    	
    	//Repository Variable
    	SmokeTest.Repositories.Files file = new SmokeTest.Repositories.Files();
    	
        public AddWebURL()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void Action(){
        	file.MainForm.FilesIndexForm.listFirstFile.DoubleClick();
        	Delay.Seconds(2);
        	file.FileDetailForm.Documents.Click();
        	Delay.Seconds(1);
        	file.FileDetailForm.AllDocuments.Click();
        	Delay.Seconds(1);
        	file.FileDetailForm.btnNewDoc.Click();
        	Delay.Seconds(1);
        	//file.DocumentDetail.pnlBase.txtDocumentTitle.PressKeys(documentTitle + time);
        	file.DocumentDetail.PnlBase.txtDocumentTitle.PressKeys("Web URL Test");
        	file.DocumentDetail.PnlBase.ButtonEditorDropdownButton.Click();
        	Delay.Seconds(1);
        	file.DropdownSelector.DropdownSelect.Click();
        	Delay.Seconds(1);
        	file.DocumentDetail.PnlBase.EnterURL.PressKeys("http://www.google.ca");
        	Delay.Seconds(1);
        	file.DocumentDetail.summaryTxt.PressKeys("Web URL Summary Test");
        	file.DocumentDetail.btnOK.Click();
        	Validate.Exists(file.FileDetailForm.AllDoc);
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
