/*
 * Created by Ranorex
 * User: kumar
 * Date: 3/18/2020
 * Time: 1:01 PM
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
    /// Description of AddToLibrary_Doc_OfficeAddIn.
    /// </summary>
    [TestModule("BBAE675F-7C4C-4EDA-96CB-F9F4792AA9AE", ModuleType.UserCode, 1)]
    public class AddToLibrary_Doc_OfficeAddIn : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public AddToLibrary_Doc_OfficeAddIn()
        {
            // Do not delete - a parameterless constructor is required!
        }
		string wordPath="C:\\Program Files (x86)\\Microsoft Office\\root\\Office16\\WINWORD.EXE";
		string localFileName="C:\\Qiao\\DataFiles\\Doc4.docx";
		static string rndData=System.DateTime.Now.ToString();
		string data=String.Format("Test Data Added {0}",rndData);
		string fileName=String.Format("RanorexTestFile {0}",rndData);
        Common cmn=new Common();
        Word_app wapp=Word_app.Instance;
        Documents doc=new Documents();
        Library lib = Library.Instance;
        
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
		
        private void AddtoLibraryDoc()
    	{
    		OpenApp();
    		if(wapp.WordDocument.tabAmicusTasksInfo.Exists(5000))
				{
					Report.Success("Amicus Tasks Toolbar successfully seen in the Word Document");
    			wapp.WordDocument.tabAmicusTasks.Click();
    		
    		if(wapp.WordDocument.AmicusAttorneyTasks1.btnAddToLibraryInfo.Exists(3000))
    		{
    			
    			Report.Success("Add To Library Button button enabled for Existing Document associated to a File");
    			wapp.WordDocument.AmicusAttorneyTasks1.btnAddToLibrary.Click();
    			Delay.Seconds(2);
    		if(lib.LibraryDetail.SelfInfo.Exists(3000))
    		{
    			Report.Success("Library Details Exists and Opens Successfully from Office Add-in");
    			lib.LibraryDetail.txtSummary.PressKeys(data);
    			lib.LibraryDetail.lnkFiles.Click();
    			Delay.Seconds(2);
    			lib.LibraryDetail.btnAddFiles.Click();
    			Delay.Seconds(2);
    			lib.FileSelectForm.listFirstFoundFile.DoubleClick();
    			lib.LibraryDetail.btnOK.Click();
    			wapp.WordDocument.tabAmicusTasks.Click();
    		
    		if(wapp.WordDocument.AmicusAttorneyTasks1.btnDetailsInfo.Exists(3000))
    		{
    			Report.Success("Library Detail button enabled for Existing Document associated to a File");
    			wapp.WordDocument.AmicusAttorneyTasks1.btnDetails.Click();
    			if(lib.PromptForm.SelfInfo.Exists(3000))
    			{lib.PromptForm.btnOK.Click();}
    			
    			
    			lib.LibraryDetail.lnkFiles.Click();
    			if(lib.LibraryDetail.txtFileNameInfo.Exists(3000))
    			{
        				Report.Success(String.Format("File associated to the library for the document is {0} ",lib.LibraryDetail.txtFileName.TextValue));
    			}
    			
    			lib.LibraryDetail.btnOK.Click();
    			wapp.WordDocument.Self.Close();
    			if(lib.PromptForm.SelfInfo.Exists(3000))
    			{lib.PromptForm.btnYes.Click();}
    			
    		}
    		}
    		
    		}
    		}
    	
    		
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
            AddtoLibraryDoc();
        }
    }
}
