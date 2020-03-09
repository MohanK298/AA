/*
 * Created by Ranorex
 * User: Kumar
 * Date: 2019-10-17
 * Time: 12:06 PM
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
    /// Description of verifyAddDocIndexAutoTxtSearch.
    /// </summary>
    [TestModule("49B33D33-8E68-4BD7-AB32-81C58C96A0C0", ModuleType.UserCode, 1)]
    public class verifyAddDocIndexAutoTxtSearch : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        Documents doc=Documents.Instance;
        FirmSettings frm=FirmSettings.Instance;
        Common cmn=new Common();
        public verifyAddDocIndexAutoTxtSearch()
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
        	//frm.MainForm.FirmSettings.Click();
        	frm.MainForm.View.Click();
        	Delay.Seconds(2);
        	frm.MainForm.FirmSettings1.Click();
        	Delay.Seconds(2);
        	frm.MainForm.FirmSettingsForm.lnkDocIndexing.Click();
        	Validate.Exists(frm.DocumentFirmSettingsForm.SelfInfo,"Document File Setting Form Exists");
        	frm.DocumentFirmSettingsForm.cbManageIndex.Check();
        	Validate.AttributeEqual(frm.DocumentFirmSettingsForm.cbManageIndexInfo,"Checked","True","Document Index Checkbox is Checked");
        	frm.DocumentFirmSettingsForm.Toolbar1.btnCancel.Click();
        }
        string localFileName;
		static string rndData=System.DateTime.Now.ToString();
		string data=String.Format("Test Data Added {0}",rndData);
		string fileName=String.Format("RanorexTestFile {0}",rndData);
        private void GenerateDocument()
        {
        	//localFileName=cmn.createLocalFile();
        	localFileName="C:\\Qiao\\DataFiles\\9.txt";
        	doc.MainForm.Self.Activate();
        	doc.MainForm.btnDocuments.Click();
        	Delay.Seconds(5);
        	Keyboard.Press(System.Windows.Forms.Keys.X | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
        	Delay.Seconds(2);
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
        private void ValidateTxtSearchUsingIndexing()
        {
        	ValidateIndexingInFirmSetting();
        	GenerateDocument();
        	FillDocument();
        	doc.MainForm.DocumentsIndexForm.btnSearchMore.Click();
        	Delay.Seconds(2);
        	doc.MainForm.DocumentsIndexForm.txtSearchText.Click();
        	doc.MainForm.DocumentsIndexForm.txtSearchText.PressKeys("Ranorex");
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
            ValidateTxtSearchUsingIndexing();
            Common.ClosePrompt();
        }
    }
}
