/*
 * Created by Ranorex
 * User: Kumar
 * Date: 2019-10-15
 * Time: 2:07 PM
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
    /// Description of verifyAddDocToDocumentGroup.
    /// </summary>
    [TestModule("B026D7D2-2339-489D-BDED-D6AAD181323C", ModuleType.UserCode, 1)]
    public class verifyAddDocToDocumentGroup : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        Documents doc=Documents.Instance;
        Common cmn=new Common();
        FirmSettings frm=FirmSettings.Instance;
        public verifyAddDocToDocumentGroup()
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
        
        private void AddDocumentGroup()
        {
        	string correspondingData="";
        	 GenerateDocument();
        	 FillDocument();
        	 cmn.SelectItemFromTableDblClick(doc.MainForm.DocumentsIndexForm.tblDocuments,fileName,"Documents Table");
        	 doc.DocumentDetail.PnlBase.lnkDocumentGroups.Click();
        	 doc.DocumentDetail.PnlBase.btnAddDocGroups.Click();
        	 cmn.MultipleDocSelection(doc.SimpleDocSelectForm.Panel1.tblDocGroup,1);
        	 doc.SimpleDocSelectForm.Panel1.btnAdd.Click();
        	 Delay.Seconds(2);
        	 correspondingData=cmn.RetrieveCurrentSelectionFromTable(doc.SimpleDocSelectForm.Panel1.tblSelectedDocGroup);
			 doc.SimpleDocSelectForm.Toolbar1.btnOK.Click();        	 
        	 doc.DocumentDetail.MenubarFillPanel.btnOK.Click();
        	 Delay.Seconds(2);
        	 
        	 cmn.VerifyCorrespondingDataExistsInTable(doc.MainForm.DocumentsIndexForm.tblDocuments,fileName,correspondingData,"Documents Table");
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            AddDocumentGroup();
        }
    }
}
