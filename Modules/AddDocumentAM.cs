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
using SmokeTest.Modules.Utilities;
using SmokeTest.Repositories;
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
       Files file = new Files();
       Documents document = Documents.Instance;
       Common cmn=new Common();
        public AddDocumentAM()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void Action(){
        	
        	string localFileName="";// = @"C:\Qiao\RanorexTestFile.txt";
        	localFileName=cmn.createLocalFile();
        	
        	file.MainForm.Self.Activate();
        	Delay.Seconds(2);
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
//        	file.DocumentDetail.PnlBase.ButtonEditorDropdownButton.Click();
//        	Delay.Seconds(1);
//        	file.DropdownSelector.DropdownSelect0.Click();
//        	Delay.Seconds(1);
//        	file.DocumentDetail.PnlBase.btnLocation.Click();
//        	Delay.Seconds(1);
//        	file.OpenFile.ViewWnd.DocumentFolder.Click();
//        	Delay.Seconds(1);
//        	file.OpenFile.ViewWnd.Document.DoubleClick();   	
     		//file.OpenFolder.btnOK.Click();
        //	document.DocumentDetail.PnlBase.fileLocationPathText.Element.SetAttributeValue("Text", localFileName);
        	document.DocumentDetail.PnlBase.btnLocation.Click();
        	document.Open.txtFilePath.Element.SetAttributeValue("Text", localFileName);
        	document.Open.btnOpen.Click();
        	document.DocumentDetail.MenubarFillPanel.txtDocumentSummary.PressKeys("Document Adding Test");
        	document.DocumentDetail.PnlBase.btnFilesAndPeople.Click();
        	
//        	//Add file
//        	document.DocumentDetail.PnlBase.btnAddFile.Click();
//        	document.FileSelectForm.btnQuickFind.Click();
//        	document.FindFilesForm.txtFindFile.TextValue = "Add Document Test";
//        	document.FindFilesForm.btnOK.Click();
//        	document.FileSelectForm.listFirstFoundFile.DoubleClick();
        	document.DocumentDetail.MenubarFillPanel.btnOK.Click();
     		
     		Delay.Seconds(2);
//        	file.DocumentDetail.summaryTxt.PressKeys("Document Adding Test");
//        	file.DocumentDetail.btnOK.Click();  
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
        Utilities.Common.ClosePrompt();
        }
    }
}
