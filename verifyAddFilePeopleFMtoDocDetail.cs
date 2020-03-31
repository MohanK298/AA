/*
 * Created by Ranorex
 * User: Kumar
 * Date: 2019-10-16
 * Time: 10:26 AM
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
    /// Description of verifyAddFilePeopleFMtoDocDetail.
    /// </summary>
    [TestModule("A63EDB99-5884-4F86-8D9B-4B5E1CE9A347", ModuleType.UserCode, 1)]
    public class verifyAddFilePeopleFMtoDocDetail : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        Documents doc=Documents.Instance;
        Common cmn=new Common();
        public verifyAddFilePeopleFMtoDocDetail()
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
        	localFileName="C:\\Qiao\\DataFiles\\6.txt";
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
        
        private void AddFilePeopleFM()
        {
        	string correspondingData1="";
        	string correspondingData2="";
        	string correspondingData3="";
        	 GenerateDocument();
        	 FillDocument();
        	 cmn.SelectItemFromTableDblClick(doc.MainForm.DocumentsIndexForm.tblDocuments,fileName,"Documents Table");
        	 Delay.Seconds(2);
        	 doc.DocumentDetail.PnlBase.btnFilesAndPeople.Click();
        	 doc.DocumentDetail.PnlBase.btnAddFile.Click();
        	// cmn.SelectItemDropdown(doc.FileSelectForm.cmbbxFileType,doc.tblDropdown,"All");
		     doc.FileSelectForm.cmbbxFileType.Click();
		     cmn.SelectItemDropdown(doc.tblDpdwnList.Self,"All");
			 cmn.MultipleDocSelection(doc.FileSelectForm.tblFiles,1);
        	 doc.FileSelectForm.btnAdd.Click();
        	 Delay.Seconds(2);
        	 correspondingData1=cmn.RetrieveCurrentSelectionFromTable(doc.FileSelectForm.tblSelectedFiles);
        	 doc.FileSelectForm.Toolbar1.btnOK.Click();
        	 
			 
			 doc.DocumentDetail.PnlBase.btnAddFM.Click();
		//	 cmn.SelectItemDropdown(doc.PeopleSelectForm.cmbbxPeopleSelection,"All","People Type");
			 doc.PeopleSelectForm.cmbbxPeopleSelection.Click();
		     cmn.SelectItemDropdown(doc.tblDpdwnList.Self,"All");
			 cmn.MultiplePeopleSelection(doc.PeopleSelectForm.Panel1.tblPeople,1);
			 doc.PeopleSelectForm.Panel1.btnAdd.Click();
			 Delay.Seconds(2);
			 correspondingData2=cmn.RetrieveCurrentSelectionFromTable(doc.PeopleSelectForm.Panel1.tblSelectedPeople);
			 doc.PeopleSelectForm.Toolbar1.btnOK.Click();
			 
			 
			 doc.DocumentDetail.PnlBase.btnAddContacts.Click();
			// cmn.SelectItemDropdown(doc.PeopleSelectForm.cmbbxPeopleSelection,"All","People Type");
			 doc.PeopleSelectForm.cmbbxPeopleSelection.Click();
		     cmn.SelectItemDropdown(doc.tblDpdwnList.Self,"All");
		     cmn.MultiplePeopleSelection(doc.PeopleSelectForm.Panel1.tblPeople,1);
		     doc.PeopleSelectForm.Panel1.btnAdd.Click();
			 Delay.Seconds(2);
			 correspondingData3=cmn.RetrieveCurrentSelectionFromTable(doc.PeopleSelectForm.Panel1.tblSelectedPeople);
			 doc.PeopleSelectForm.Toolbar1.btnOK.Click();
			 
			 doc.DocumentDetail.MenubarFillPanel.btnOK.Click();
        	 Delay.Seconds(2);
        	 
        	 cmn.VerifyCorrespondingDataExistsInTable(doc.MainForm.DocumentsIndexForm.tblDocuments,fileName,correspondingData1.Split(','),"Documents Table");
        	// cmn.VerifyCorrespondingDataExistsInTable(doc.MainForm.DocumentsIndexForm.tblDocuments,fileName,correspondingData2,"Documents Table");
        	cmn.VerifyCorrespondingDataExistsInTable(doc.MainForm.DocumentsIndexForm.tblDocuments,fileName,correspondingData3.Split(','),"Documents Table");
        }
        
        
        
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            AddFilePeopleFM();
            cmn.ClosePrompt();
        }
    }
}
