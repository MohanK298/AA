/*
 * Created by Ranorex
 * User: Kumar
 * Date: 2019-10-18
 * Time: 1:44 PM
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
    /// Description of verifySearchByFullTextDocInIndex.
    /// </summary>
    [TestModule("7795CA54-95E5-4BB4-9EF3-BC7C0F33D9C3", ModuleType.UserCode, 1)]
    public class verifySearchByFullTextDocInIndex : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        Documents doc=Documents.Instance;
        FirmSettings frm=FirmSettings.Instance;
        Common cmn=new Common();
        
        public verifySearchByFullTextDocInIndex()
        {
            // Do not delete - a parameterless constructor is required!
        }

        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
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
        string localFileName;
		static string rndData=System.DateTime.Now.ToString();
		string data=String.Format("Test Data Added {0}",rndData);
		string fileName=String.Format("RanorexTestFile {0}",rndData);
        private void GenerateDocument()
        {
        	Delay.Seconds(2);
        	doc.MainForm.Self.Activate();
        	Delay.Seconds(2);
        	Keyboard.Press(System.Windows.Forms.Keys.X | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
        	Delay.Seconds(2);
        	Keyboard.Press(System.Windows.Forms.Keys.N | System.Windows.Forms.Keys.Control, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
        	Validate.Exists(doc.DocumentDetail.SelfInfo,"Document Detail Form Opened");
        }
		
        private void FillDocument()
        {

        	localFileName=cmn.createLocalFile(rndData);
        	doc.DocumentDetail.Self.Activate();
        	doc.DocumentDetail.PnlBase.txtDocumentTitle.PressKeys(fileName);
        	doc.DocumentDetail.PnlBase.fileLocationPathText.Element.SetAttributeValue("Text", localFileName);
        	doc.DocumentDetail.MenubarFillPanel.txtDocumentSummary.PressKeys(data);
        	doc.DocumentDetail.PnlBase.btnFilesAndPeople.Click();
        	doc.DocumentDetail.PnlBase.btnAddFile.Click();
        	doc.FileSelectForm.listFirstFoundFile.DoubleClick();
        	doc.DocumentDetail.MenubarFillPanel.btnOK.Click();

        }
        private void ValidateFullTxtSearchUsingIndexing()
        {
        	ValidateIndexingInFirmSetting();
        	GenerateDocument();
        	FillDocument();
        	doc.MainForm.DocumentsIndexForm.btnSearchMore.Click();
        	Delay.Seconds(2);
        	cmn.SelectItemDropdown(doc.MainForm.DocumentsIndexForm.cmbbxSearchType,"Perform full text search","Search Type");
        	doc.MainForm.DocumentsIndexForm.rdbtnBasedOnList.Click();
        	doc.MainForm.DocumentsIndexForm.txtSearchText.Click();
        	doc.MainForm.DocumentsIndexForm.txtSearchText.PressKeys("Ranorex");
        	doc.MainForm.DocumentsIndexForm.imgSearchIcon.Click();
        	Validate.Exists(doc.MainForm.DocumentsIndexForm.txtDocumentsListCountInfo,"No of Documents Count Label Exists");
        	Report.Success(String.Format("The number of Documents retrieved based on the Search is {0}",doc.MainForm.DocumentsIndexForm.txtDocumentsListCount.TextValue));
        	doc.MainForm.DocumentsIndexForm.lnkClearSearchText.Click();
        	Delay.Seconds(2);
        	doc.MainForm.DocumentsIndexForm.btnSearchLess.Click();
        	
        }
        
          private void ValidateFullTxtSearchUsingAllDocIndexing()
        {
        	doc.MainForm.DocumentsIndexForm.btnSearchMore.Click();
        	Delay.Seconds(2);
        	cmn.SelectItemDropdown(doc.MainForm.DocumentsIndexForm.cmbbxSearchType,"Perform full text search","Search Type");
        	doc.MainForm.DocumentsIndexForm.rdbtnBasedOnAll.Click();
        	doc.MainForm.DocumentsIndexForm.txtSearchText.Click();
        	doc.MainForm.DocumentsIndexForm.txtSearchText.PressKeys("Ranorex");
        	doc.MainForm.DocumentsIndexForm.imgSearchIcon.Click();
        	Validate.Exists(doc.MainForm.DocumentsIndexForm.txtDocumentsListCountInfo,"No of Documents Count Label Exists");
        	Report.Success(String.Format("The number of Documents retrieved based on the Search is {0}",doc.MainForm.DocumentsIndexForm.txtDocumentsListCount.TextValue));
//        	doc.MainForm.DocumentsIndexForm.lnkClearSearchText.Click();
//        	Delay.Seconds(2);
//        	doc.MainForm.DocumentsIndexForm.btnSearchLess.Click();
        	
        }
          
          
         private void RefineSearch()
        {
//        	doc.MainForm.DocumentsIndexForm.btnSearchMore.Click();
//        	Delay.Seconds(2);
//        	cmn.SelectItemDropdown(doc.MainForm.DocumentsIndexForm.cmbbxSearchType,"Perform full text search","Search Type");
//        	doc.MainForm.DocumentsIndexForm.rdbtnBasedOnAll.Click();
			doc.MainForm.DocumentsIndexForm.lnkRefineSearchText.Click();
        	doc.MainForm.DocumentsIndexForm.txtSearchText.Click();
        	doc.MainForm.DocumentsIndexForm.txtSearchText.PressKeys(rndData);
        	Report.Info(String.Format("Entered data for refining is {0}",rndData));
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
            ValidateFullTxtSearchUsingIndexing();
            ValidateFullTxtSearchUsingAllDocIndexing();
            RefineSearch();
        }
    }
}
