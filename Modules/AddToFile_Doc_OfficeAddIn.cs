/*
 * Created by Ranorex
 * User: kumar
 * Date: 3/17/2020
 * Time: 5:42 PM
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
    /// Description of AddToFile_Doc_OfficeAddIn.
    /// </summary>
    [TestModule("6D49F9EC-16A6-43D9-B6B5-A5436C01975C", ModuleType.UserCode, 1)]
    public class AddToFile_Doc_OfficeAddIn : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public AddToFile_Doc_OfficeAddIn()
        {
            // Do not delete - a parameterless constructor is required!
        }
		string wordPath="C:\\Program Files (x86)\\Microsoft Office\\root\\Office16\\WINWORD.EXE";
		string localFileName="C:\\Qiao\\DataFiles\\Doc2.docx";
		static string rndData=System.DateTime.Now.ToString();
		string data=String.Format("Test Data Added {0}",rndData);
		string fileName=String.Format("RanorexTestFile {0}",rndData);
        Common cmn=new Common();
        Word_app wapp=Word_app.Instance;
        Documents doc=new Documents();
        
        
        private void OpenApp()
        {
        	Host.Local.RunApplication(wordPath);
        	Delay.Seconds(5);
        	//wapp.Word.BlankDocument.Click();
        	wapp.Word.lnkOpenOtherDocuments.Focus();
        	wapp.Word.lnkOpenOtherDocuments.Click();
        	Delay.Seconds(2);
        	wapp.Word.btnBrowse.Click();
        	Delay.Seconds(2);
        	doc.Open.txtFilePath.Element.SetAttributeValue("Text", localFileName);
        	doc.Open.btnOpen.Click();
        }
		
        private void AddtoFileDoc()
        	{
        		OpenApp();
        		if(wapp.WordDocument.tabAmicusTasksInfo.Exists(5000))
 				{
 					Report.Success("Amicus Tasks Toolbar successfully seen in the Word Document");
        			wapp.WordDocument.tabAmicusTasks.Click();
        		
        		if(wapp.WordDocument.AmicusAttorneyTasks1.btnAddToFileInfo.Exists(3000))
        		{
        			
        			Report.Success("Add To File Button button enabled for Existing Document associated to a File");
        			wapp.WordDocument.AmicusAttorneyTasks1.btnAddToFile.Click();
        			Delay.Seconds(2);
        			doc.FileSelectForm.listFirstFoundFile.DoubleClick();
        		if(doc.DocumentDetail.SelfInfo.Exists(3000))
        		{
        			Report.Success("Document Details Exists and Opens Successfully from Office Add-in");
        			doc.DocumentDetail.PnlBase.txtDocumentTitle.PressKeys(fileName);
        			doc.DocumentDetail.MenubarFillPanel.txtDocumentSummary.PressKeys(data);
        			doc.DocumentDetail.MenubarFillPanel.btnOK.Click();
        			wapp.WordDocument.tabAmicusTasks.Click();
        		
        		if(wapp.WordDocument.AmicusAttorneyTasks1.btnDetailsInfo.Exists(3000))
        		{
        			Report.Success("Document Detail button enabled for Existing Document associated to a File");
        			wapp.WordDocument.AmicusAttorneyTasks1.btnDetails.Click();
        			if(doc.PromptForm.SelfInfo.Exists(3000))
        			{doc.PromptForm.btnOK.Click();}
        			
        			doc.DocumentDetail.PnlBase.btnFilesAndPeople.Click();
        			if(doc.DocumentDetail.PnlBase.txtFileNameInfo.Exists(3000))
        			{
        				Report.Success(String.Format("File name added for the document is {0} ",doc.DocumentDetail.PnlBase.txtFileName.TextValue));
        			}
        			
        			doc.DocumentDetail.MenubarFillPanel.btnOK.Click();
        			wapp.WordDocument.Self.Close();
        			if(doc.PromptForm.SelfInfo.Exists(3000))
        			{doc.PromptForm.btnYes.Click();}
//        			wapp.Word.btnClose.Click();
        		}
        		}
        		
        		}
        		}
        		
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
            AddtoFileDoc();
        }
    }
}
