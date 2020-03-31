/*
 * Created by Ranorex
 * User: Kumar
 * Date: 2019-10-15
 * Time: 10:05 AM
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
namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of validateDocumentIndexViewer.
    /// </summary>
    [TestModule("EDDE5660-5C5A-4291-A286-D87FD79AEC15", ModuleType.UserCode, 1)]
    public class validateDocumentIndexViewer : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        Documents doc=new Documents();
        Common cmn=new Common();
        public validateDocumentIndexViewer()
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
        	localFileName="C:\\Qiao\\DataFiles\\3.txt";
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
        	doc.MainForm.DocumentsIndexForm.menuItemPrevPane.Click();
        	doc.MainForm.DocumentsIndexForm.previewOff.Click();
        }
        private void validatePreviewPane()
        {
        	doc.MainForm.Self.Activate();
        	doc.MainForm.DocumentsIndexForm.menuItemPrevPane.Click();
        	doc.MainForm.DocumentsIndexForm.previewRight.Click();
        	Delay.Seconds(3);
        	cmn.SelectItemFromTableDblClick(doc.MainForm.DocumentsIndexForm.tblDocuments,fileName,"Documents Table");
        	doc.DocumentDetail.MenubarFillPanel.btnCancel.Click();
        	Delay.Seconds(3);
        	doc.MainForm.Self.Activate();
        	Validate.Attribute(doc.MainForm.DocumentsIndexForm.docpreviewInfo,"Visible","True","Right Preview Visible");
        	Delay.Seconds(3);
        	doc.MainForm.DocumentsIndexForm.menuItemPrevPane.Click();
        	doc.MainForm.DocumentsIndexForm.previewBottom.Click();
        	Delay.Seconds(3);
//        	doc.MainForm.DocumentsIndexForm.docpreview.Focus();
        	Validate.Attribute(doc.MainForm.DocumentsIndexForm.docpreviewInfo,"Visible","True","Bottom Preview Visible");
        	Delay.Seconds(3);
        	doc.MainForm.DocumentsIndexForm.menuItemPrevPane.Click();
        	doc.MainForm.DocumentsIndexForm.previewOff.Click();
        	Delay.Seconds(3);
        	Validate.Attribute(doc.MainForm.DocumentsIndexForm.docpreviewInfo,"Visible","False","Preview is turned off");
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            GenerateDocument();
            FillDocument();
            validatePreviewPane();
            cmn.ClosePrompt();
        }
    }
}
