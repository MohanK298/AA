/*
 * Created By Asish
 * User: Administrator
 * Date: 2017-11-02
 * Time: 10:45 AM
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
using SmokeTest.Modules;
using SmokeTest.Repositories;

namespace SmokeTest.Modules.Attorney_FileDetails
{
    /// <summary>
    /// Description of AddDocument.
    /// </summary>
    [TestModule("833FA8D2-53DD-4F83-A862-2175EE24F816", ModuleType.UserCode, 1)]
    public class AddDocument : ITestModule
    {
        //Repository Variable
       Files file = Files.Instance;
       Documents document = Documents.Instance;
       Common cmn=new Common();
        public AddDocument()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void Action()
        {
        	file.MainForm.FilesIndexForm.listFirstFile.DoubleClick();
        	Delay.Seconds(2);
        	file.FileDetailForm.Documents.Click();
        	Delay.Seconds(1);
        	file.FileDetailForm.AllDocuments.Click();
        	Delay.Seconds(1);
        	file.FileDetailForm.btnNewDoc.Click();
        	Delay.Seconds(1);
        	//file.DocumentDetail.pnlBase.txtDocumentTitle.PressKeys(documentTitle + time);
//        	file.DocumentDetail.PnlBase.txtDocumentTitle.PressKeys("Add Document Test");
//        	file.DocumentDetail.PnlBase.ButtonEditorDropdownButton.Click();
//        	Delay.Seconds(1);
//        	file.DropdownSelector.DropdownSelect0.Click();
//        	Delay.Seconds(1);
//        	file.DocumentDetail.PnlBase.btnLocation.Click();
//        	Delay.Seconds(1);
//        	file.OpenFile.ViewWnd.DocumentFolder.Click();
//        	Delay.Seconds(1);
//        	file.OpenFile.ViewWnd.Document.DoubleClick();   	
//     		//file.OpenFolder.btnOK.Click();
//        	Delay.Seconds(1);        	
//        	file.DocumentDetail.summaryTxt.PressKeys("Document Adding Test");
//        	file.DocumentDetail.btnOK.Click();  
//        	Validate.Exists(file.FileDetailForm.DocumentAdded);
//           	file.FileDetailForm.btnSaveClose.Click();
        	
        	string localFileName="";// = @"C:\Qiao\RanorexTestFile.txt";
        	localFileName=cmn.createLocalFile();
        	document.DocumentDetail.PnlBase.txtDocumentTitle.PressKeys("Add Document Test");
        	document.DocumentDetail.PnlBase.fileLocationPathText.Element.SetAttributeValue("Text", localFileName);
        	document.DocumentDetail.MenubarFillPanel.txtDocumentSummary.PressKeys("Document Adding Test");
        	document.DocumentDetail.PnlBase.btnFilesAndPeople.Click();
        	
//        	//Add file
//        	document.DocumentDetail.PnlBase.btnAddFile.Click();
//        	document.FileSelectForm.btnQuickFind.Click();
//        	document.FindFilesForm.txtFindFile.TextValue = "Add Document Test";
//        	document.FindFilesForm.btnOK.Click();
//        	document.FileSelectForm.listFirstFoundFile.DoubleClick();
        	document.DocumentDetail.MenubarFillPanel.btnOK.Click();
        	Validate.Exists(file.FileDetailForm.RanorexTestDoc);
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
