/*
 * Created by Ranorex
 * User: Kumar
 * Date: 2019-10-18
 * Time: 12:57 PM
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
using SmokeTest.Modules.Utilities;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest
{
    /// <summary>
    /// Description of verifySearchByTitleandSummaryFields.
    /// </summary>
    [TestModule("EDF56377-4B39-4BF0-B911-270883140B37", ModuleType.UserCode, 1)]
    public class verifySearchByTitleandSummaryFields : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        Documents doc=Documents.Instance;
        Common cmn=new Common();
        FirmSettings frm=FirmSettings.Instance;
        public verifySearchByTitleandSummaryFields()
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
        private void ValidateIndexingInFirmSetting()
        {
        	frm.MainForm.Self.Activate();
        	frm.MainForm.Office.Click();
        	Delay.Seconds(2);
//        	frm.MainForm.FirmSettings.Click();
//        	Delay.Seconds(2);
			frm.MainForm.View.Click();
			Delay.Seconds(2);
			frm.MainForm.FirmSettings1.Click();
			Delay.Seconds(2);
        	frm.MainForm.FirmSettingsForm.lnkDocIndexing.Click();
        	Validate.Exists(frm.DocumentFirmSettingsForm.SelfInfo,"Document File Setting Form Exists");
        	Validate.AttributeEqual(frm.DocumentFirmSettingsForm.cbManageIndexInfo,"Checked","True","Document Index Checkbox is Checked");
        	frm.DocumentFirmSettingsForm.Toolbar1.btnCancel.Click();
        }
		private void GenerateDocument()
        {
			localFileName=cmn.createLocalFile();
        	doc.MainForm.Self.Activate();
        	doc.MainForm.btnDocuments.Click();
        	Delay.Seconds(2);
        	Keyboard.Press(System.Windows.Forms.Keys.X | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
        	Delay.Seconds(2);
        	Keyboard.Press(System.Windows.Forms.Keys.N | System.Windows.Forms.Keys.Control, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
        	Validate.Exists(doc.DocumentDetail.SelfInfo,"Document Detail Form Opened");
        }
		
        private void FillDocument()
        {
        	
        	doc.DocumentDetail.Self.Activate();
        	doc.DocumentDetail.PnlBase.txtDocumentTitle.PressKeys(fileName);
        	doc.DocumentDetail.PnlBase.fileLocationPathText.Element.SetAttributeValue("Text", localFileName);
        	doc.DocumentDetail.MenubarFillPanel.txtDocumentSummary.PressKeys(data);
        	doc.DocumentDetail.PnlBase.btnFilesAndPeople.Click();
        	doc.DocumentDetail.PnlBase.btnAddFile.Click();
        	doc.FileSelectForm.listFirstFoundFile.DoubleClick();
        	doc.DocumentDetail.MenubarFillPanel.btnOK.Click();

        }
        private void SearchByTitleandSummaryFields()
        {
        	ValidateIndexingInFirmSetting();
        	GenerateDocument();
        	FillDocument();
        	doc.MainForm.DocumentsIndexForm.btnSearchMore.Click();
        	Delay.Seconds(2);
        	cmn.SelectItemDropdown(doc.MainForm.DocumentsIndexForm.cmbbxSearchType,"Search Title and Summary Fields only","Search Type");
        	doc.MainForm.DocumentsIndexForm.txtSearchText.Click();
        	doc.MainForm.DocumentsIndexForm.txtSearchText.PressKeys(fileName);
        	doc.MainForm.DocumentsIndexForm.imgSearchIcon.Click();
        	Validate.Exists(doc.MainForm.DocumentsIndexForm.txtDocumentsListCountInfo,"No of Documents Count Label Exists");
        	Report.Success(String.Format("The number of Documents retrieved based on the Search is {0}",doc.MainForm.DocumentsIndexForm.txtDocumentsListCount.TextValue));
        	doc.MainForm.DocumentsIndexForm.lnkClearSearchText.Click();
        	Delay.Seconds(2);
        	doc.MainForm.DocumentsIndexForm.btnSearchLess.Click();
        	
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            SearchByTitleandSummaryFields();
            Common.ClosePrompt();
        }
    }
}
