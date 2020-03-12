/*
 * Created by Ranorex
 * User: kumar
 * Date: 3/12/2020
 * Time: 12:26 PM
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
using SmokeTest.Repositories.Premium;
using SmokeTest.Modules.Utilities;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of shareDocumentBetweenFM.
    /// </summary>
    [TestModule("6AF27867-6861-48C6-8DB5-5EE255193E69", ModuleType.UserCode, 1)]
    public class shareDocumentBetweenFM : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public shareDocumentBetweenFM()
        {
            // Do not delete - a parameterless constructor is required!
        }
  		Documents doc=Documents.Instance;
        Common cmn=new Common();
        
        string localFileName;
		static string rndData=System.DateTime.Now.ToString();
		string data=String.Format("Test Data Added {0}",rndData);
		string fileName=String.Format("RanorexTestFile {0}",rndData);
		string curuser="";
        string user="";
		//string curuser="Mohan Kumar";
        private void GenerateDocument()
        {
        	//localFileName=cmn.createLocalFile();
        	localFileName="C:\\Qiao\\DataFiles\\10.txt";
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
        
        
        
          private void shareDocBtwnFM()
        {
          	
        	
        	
        	var datasource=Ranorex.DataSources.Get("LoginData");
        	datasource.Load();
        	curuser=datasource.Rows[0].Values[1].ToString();
        	user=datasource.Rows[1].Values[1].ToString();
        	cmn.switchUser(curuser);
        	
        	GenerateDocument();
        	FillDocument();
        	cmn.SelectItemFromTableDblClick(doc.MainForm.DocumentsIndexForm.tblDocuments,fileName,"Documents Table");
        	Delay.Seconds(2);
			doc.DocumentDetail.PnlBase.btnFilesAndPeople.Click();
        	doc.DocumentDetail.PnlBase.btnAddFM.Click();
		//	cmn.SelectItemDropdown(doc.PeopleSelectForm.cmbbxPeopleSelection,"All","People Type");
			doc.PeopleSelectForm.cmbbxPeopleSelection.Click();
		    cmn.SelectItemDropdown(doc.tblDpdwnList.Self,"All");
			cmn.SelectItemFromTableSingleClick(doc.PeopleSelectForm.Panel1.tblPeople,user,"People Selection Table");
			doc.PeopleSelectForm.Panel1.btnAdd.Click();
			Delay.Seconds(2);
			//correspondingData2=cmn.RetrieveCurrentSelectionFromTable(doc.PeopleSelectForm.Panel1.tblSelectedPeople);
			doc.PeopleSelectForm.Toolbar1.btnOK.Click();
        
			doc.DocumentDetail.MenubarFillPanel.btnOK.Click();
        	Delay.Seconds(2);
        	
        	cmn.switchUser(user);
        	
        	doc.MainForm.Self.Activate();
        	doc.MainForm.btnDocuments.Click();
        	cmn.SelectItemDropdown(doc.MainForm.cmbbxDocType,"My Files","To Whom Dropdown");
        	Delay.Seconds(2);
        	cmn.VerifyDataExistsInTable(doc.MainForm.DocumentsIndexForm.tblDocuments,fileName,"Documents Table");
          }
        	
        	
        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            shareDocBtwnFM();
        }
    }
}
