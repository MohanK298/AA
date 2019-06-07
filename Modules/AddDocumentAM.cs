/*
 * Created By Asish
 * User: Administrator
 * Date: 2018-01-05
 * Time: 11:44 AM
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

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of AddDocumentAM.
    /// </summary>
    [TestModule("6261295E-CDAB-4332-BF04-9A6FE398CB07", ModuleType.UserCode, 1)]
    public class AddDocumentAM : ITestModule
   {
        //Repository Variable
       SmokeTest.Repositories.Files file = new SmokeTest.Repositories.Files();
        public AddDocumentAM()
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
        	file.DocumentDetail.PnlBase.txtDocumentTitle.PressKeys("Add Document Test");
        	file.DocumentDetail.PnlBase.ButtonEditorDropdownButton.Click();
        	Delay.Seconds(1);
        	file.DropdownSelector.DropdownSelect0.Click();
        	Delay.Seconds(1);
        	file.DocumentDetail.PnlBase.btnLocation.Click();
        	Delay.Seconds(1);
        	file.OpenFile.ViewWnd.DocumentFolder.Click();
        	Delay.Seconds(1);
        	file.OpenFile.ViewWnd.Document.DoubleClick();   	
     		//file.OpenFolder.btnOK.Click();
        	Delay.Seconds(2);        	
        	file.DocumentDetail.summaryTxt.PressKeys("Document Adding Test");
        	file.DocumentDetail.btnOK.Click();  
        	Delay.Seconds(2);
        	Validate.Exists(file.FileDetailForm.DocumentAdded);
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
