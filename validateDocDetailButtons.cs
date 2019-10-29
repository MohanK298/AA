/*
 * Created by Ranorex
 * User: Kumar
 * Date: 2019-10-15
 * Time: 12:10 PM
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
    /// Description of validateDocDetailButtons.
    /// </summary>
    [TestModule("94FE2F07-989F-4BD7-990C-6EC033FEF26B", ModuleType.UserCode, 1)]
    public class validateDocDetailButtons : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        Documents doc=new Documents();
        Common cmn=new Common();
        public validateDocDetailButtons()
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
        	doc.MainForm.Self.Activate();
        	Keyboard.Press(System.Windows.Forms.Keys.X | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
        	Keyboard.Press(System.Windows.Forms.Keys.N | System.Windows.Forms.Keys.Control, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
        	Validate.Exists(doc.DocumentDetail.SelfInfo,"Document Detail Form Opened");
        }
		
        private void FillDocument()
        {

        	localFileName=cmn.createLocalFile();
        	doc.DocumentDetail.Self.Activate();
        	doc.DocumentDetail.PnlBase.txtDocumentTitle.PressKeys(fileName);
        	doc.DocumentDetail.PnlBase.fileLocationPathText.Element.SetAttributeValue("Text", localFileName);
        	doc.DocumentDetail.MenubarFillPanel.txtDocumentSummary.PressKeys(data);
        	doc.DocumentDetail.PnlBase.btnFilesAndPeople.Click();
        	doc.DocumentDetail.PnlBase.btnAddFile.Click();
        	doc.FileSelectForm.listFirstFoundFile.DoubleClick();
        	doc.DocumentDetail.MenubarFillPanel.btnOK.Click();
        }
        
         private void ValidateButtonsFunctionality()
         {
         	GenerateDocument();
         	FillDocument();
         	//Select a Document
         	cmn.SelectItemFromTableDblClick(doc.MainForm.DocumentsIndexForm.tblDocuments,fileName,"Documents Table");
         	//Validate Document Summary is the same as entered
         	Validate.AttributeContains(doc.DocumentDetail.MenubarFillPanel.txtDocumentSummaryInfo,"Text",data,String.Format("Document Summary is {0}",data));
         	//Navigate to Next Document
         	doc.DocumentDetail.MenubarFillPanel.btnNext.Click();
         	Delay.Seconds(2);
         	Validate.AttributeNotContains(doc.DocumentDetail.PnlBase.txtDocumentTitleInfo,"Text",fileName,String.Format("Document Current File Name is {0}",doc.DocumentDetail.PnlBase.txtDocumentTitle.TextValue));
			//Navigate to Previous Document
         	doc.DocumentDetail.MenubarFillPanel.btnPrev.Click();
			Delay.Seconds(2);
			Validate.AttributeContains(doc.DocumentDetail.PnlBase.txtDocumentTitleInfo,"Text",fileName,String.Format("Document Current File Name is {0}",doc.DocumentDetail.PnlBase.txtDocumentTitle.TextValue));
			//Validate Time Entry Button			
			doc.DocumentDetail.MenubarFillPanel.btnDoTimeEntry.Click();
			Validate.Exists(doc.TimeEntryDetailsForm.SelfInfo,"Time Entry Form Exists");
			doc.TimeEntryDetailsForm.Toolbar1.btnCancel.Click();
			//Validate Restrict Button
			doc.DocumentDetail.MenubarFillPanel.btnRestrict.Click();
			Validate.Exists(doc.RestrictionsForm.SelfInfo,"Restriction Form Exists");
			doc.RestrictionsForm.Toolbar1.btnCancel.Click();
			doc.DocumentDetail.MenubarFillPanel.btnPortal.Click();
			//Validate Portal Sharing Button
			Validate.Exists(doc.PortalForm.SelfInfo,"Portal Sharing Form Exists");
			doc.PortalForm.Toolbar1.btnCancel.Click();
			doc.DocumentDetail.MenubarFillPanel.btnDelete.Click();
			//Validate Delete Button
			Validate.Exists(doc.PromptForm.SelfInfo,"Delete Prompt Exists");
			doc.PromptForm.btnCancel.Click();
			Delay.Seconds(2);
			//Validate Cancel Button
			doc.DocumentDetail.MenubarFillPanel.btnCancel.Click();
			Delay.Seconds(2);
			Validate.NotExists(doc.DocumentDetail.SelfInfo,"Document Detail Not Exists");
         }
         
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            ValidateButtonsFunctionality();
        }
    }
}
