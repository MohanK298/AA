/*
 * Created by Ranorex
 * User: Kumar
 * Date: 2019-10-16
 * Time: 3:12 PM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;
using SmokeTest.Repositories;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using SmokeTest.Modules.Utilities;
namespace SmokeTest
{
    /// <summary>
    /// Description of verifyAddNotes.
    /// </summary>
    [TestModule("4DAF26A7-D293-4E3E-B3BA-C4EFED986C71", ModuleType.UserCode, 1)]
    public class verifyAddNotes : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        Documents doc=Documents.Instance;
        Common cmn=new Common();
        public verifyAddNotes()
        {
            // Do not delete - a parameterless constructor is required!
        }

        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        
         string localFileName;
		static string rndData=System.DateTime.Now.ToString();
		string data=String.Format("Test Data Added {0}",rndData);
		string fileName=String.Format("RanorexTestFile {0}",rndData);
        private void GenerateDocument()
        {
        	//localFileName=cmn.createLocalFile();
        	localFileName="C:\\Qiao\\DataFiles\\8.txt";
        	doc.MainForm.Self.Activate();
        	Keyboard.Press(System.Windows.Forms.Keys.X | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
        	Keyboard.Press(System.Windows.Forms.Keys.N | System.Windows.Forms.Keys.Control, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
        	Validate.Exists(doc.DocumentDetail.SelfInfo,"Document Detail Form Opened");
        }
		
        private void FillDocument()
        {

        	
        	doc.DocumentDetail.Self.Activate();
        	doc.DocumentDetail.PnlBase.txtDocumentTitle.PressKeys(fileName);
        	//doc.DocumentDetail.PnlBase.fileLocationPathText.Element.SetAttributeValue("Text", localFileName);
        	doc.DocumentDetail.PnlBase.btnLocation.Click();
        	doc.Open.txtFilePath.Element.SetAttributeValue("Text", localFileName);
        	doc.Open.btnOpen.Click();
        	doc.DocumentDetail.MenubarFillPanel.txtDocumentSummary.PressKeys(data);
        	doc.DocumentDetail.PnlBase.btnFilesAndPeople.Click();
        	doc.DocumentDetail.PnlBase.btnAddFile.Click();
        	doc.FileSelectForm.listFirstFoundFile.DoubleClick();
        	doc.DocumentDetail.MenubarFillPanel.btnOK.Click();

        }
        
        private void AddNotes()
        {
        	 //string correspondingData="";
        	 GenerateDocument();
        	 FillDocument();
        	 cmn.SelectItemFromTableDblClick(doc.MainForm.DocumentsIndexForm.tblDocuments,fileName,"Documents Table");
        	 
        	 doc.DocumentDetail.PnlBase.lnkNotes.Click();
        	 doc.DocumentDetail.PnlBase.btnNewNote.Click();
        	 doc.NoteDetail.MenubarFillPanel.txtNoteBoxEdit.PressKeys("Test Data Added");
        	 doc.NoteDetail.MenubarFillPanel.btnOK.Click();
        	 Delay.Seconds(2);
        	 cmn.VerifyDataExistsInTable(doc.DocumentDetail.PnlBase.tblNotesInDocDetail,"Test Data Added","Notes Table In Document Detail");
        	 doc.DocumentDetail.MenubarFillPanel.btnOK.Click();
       	
        }
        
        
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            AddNotes();
            Common.ClosePrompt();
        }
    }
}
