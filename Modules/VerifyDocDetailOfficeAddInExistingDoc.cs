/*
 * Created by Ranorex
 * User: kumar
 * Date: 3/16/2020
 * Time: 5:58 PM
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

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of VerifyDocDetailOfficeAddInExistingDoc.
    /// </summary>
    [TestModule("4876FAFD-5D59-4A74-988F-C7110D962A65", ModuleType.UserCode, 1)]
    public class VerifyDocDetailOfficeAddInExistingDoc : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public VerifyDocDetailOfficeAddInExistingDoc()
        {
            // Do not delete - a parameterless constructor is required!
        }
	 	string wordPath="C:\\Program Files (x86)\\Microsoft Office\\root\\Office16\\WINWORD.EXE";
        Common cmn=new Common();
        Word_app wapp=Word_app.Instance;
        Documents doc=new Documents();
 		
        string localFileName;
		static string rndData=System.DateTime.Now.ToString();
		string data=String.Format("Test Data Added {0}",rndData);
		string fileName=String.Format("RanorexTestFile {0}",rndData);
        
	
		private void GenerateDocument()
        {
        	//localFileName=cmn.createLocalFile();
        	localFileName="C:\\Qiao\\DataFiles\\Doc1.docx";
        	doc.MainForm.Self.Activate();
        	Keyboard.Press(System.Windows.Forms.Keys.X | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
        	Keyboard.Press(System.Windows.Forms.Keys.N | System.Windows.Forms.Keys.Control, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
        	Validate.Exists(doc.DocumentDetail.SelfInfo,"Document Detail Form Opened");
        }
		
        private void FillDocument()
        {

        	doc.DocumentDetail.Self.Activate();
        	Delay.Seconds(1);
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
        	
        	cmn.SelectItemFromTableDblClick(doc.MainForm.DocumentsIndexForm.tblDocuments,fileName,"Documents Table");
        	Delay.Seconds(2);
        	if(doc.DocumentDetail.PnlBase.lnkVirtualPathInfo.Exists(3000))
        	{
        		doc.DocumentDetail.PnlBase.lnkVirtualPath.Click();
        		wapp.SplashWordInfo.WaitForNotExists(5000);
        	}
        	
        	
        		
        }
        private void OpenApp()
        {
        	Host.Local.RunApplication(wordPath);
        	Delay.Seconds(5);
        	//wapp.Word.BlankDocument.Click();
        	wapp.Word.lnkOpenOtherDocuments.Click();
        	Delay.Seconds(2);
        	wapp.Word.btnBrowse.Click();
        	Delay.Seconds(2);
        	doc.Open.txtFilePath.Element.SetAttributeValue("Text", localFileName);
        	doc.Open.btnOpen.Click();
        }
		
        	private void DocDetailsValidation()
        	{
        		GenerateDocument();
        		FillDocument();
        		if(wapp.WordDocument.tabAmicusTasksInfo.Exists(5000))
 				{
 					Report.Success("Amicus Tasks Toolbar successfully seen in the Word Document");
        			wapp.WordDocument.tabAmicusTasks.Click();
        		}
        		if(wapp.WordDocument.AmicusAttorneyTasks1.btnDetailsInfo.Exists(3000))
        		{
        			Report.Success("Document Detail button enabled for Existing Document associated to a File");
        			wapp.WordDocument.AmicusAttorneyTasks1.btnDetails.Click();
        		}
        		if(doc.DocumentDetail.SelfInfo.Exists(3000))
        		{
        			Report.Success("Document Details Exists and Opens Successfully from Office Add-in");
        		}
        		if(doc.DocumentDetail.MenubarFillPanel.btnCancelInfo.Exists(3000))
        		{
        			doc.DocumentDetail.MenubarFillPanel.btnCancel.Click();
	        		if(doc.DocumentDetail.MenubarFillPanel.btnCancelInfo.Exists(3000))
	        		{
	        			doc.DocumentDetail.MenubarFillPanel.btnCancel.Click();
	        		}
        		
        		}
        		if(wapp.WordDocument.SelfInfo.Exists(5000))
        		{wapp.WordDocument.Self.Close();}
        		
        		
        	CloseProcess();
        		
        	}
        
        
        
        private void CloseProcess()
        {
        	foreach(System.Diagnostics.Process myProc in System.Diagnostics.Process.GetProcesses())
			{
			if (myProc.ProcessName == "WINWORD")
			{
				myProc.Kill();
				Report.Success("Word proccess is closed successfully");
			}
					
			}
        	Delay.Seconds(5);
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
            DocDetailsValidation();
        }
    }
}
