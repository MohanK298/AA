/*
 * Created by Ranorex
 * User: Admin
 * Date: 7/29/2015
 * Time: 11:03 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

using SmokeTest.Repositories;

namespace SmokeTest.Modules
{
    [TestModule("053B03D7-F065-47D1-89DB-C4DEB721AE72", ModuleType.UserCode, 1)]
    public class CreateDocument : ITestModule
    {
    	//Repository variable
    	Documents document = Documents.Instance;
    	string localFileName = "";
    	
    	string _documentTitle = "";
    	[TestVariable("2D9B74CF-4C91-4AC3-AAB1-169571C659D3")]
    	public string documentTitle
    	{
    		get { return _documentTitle; }
    		set { _documentTitle = value; }
    	}
    	
    	string _summary = "";
    	[TestVariable("51DAEBA5-8677-41E6-A187-402A49BE4BC3")]
    	public string summary
    	{
    		get { return _summary; }
    		set { _summary = value; }
    	}
    	
    	string _time = "";
    	[TestVariable("19D2F7BE-EA34-426D-83D2-ECE607823034")]
    	public string time
    	{
    		get { return _time; }
    		set { _time = value; }
    	}
    	
    	
    	string _fileName = "";
    	[TestVariable("8F850066-1050-4181-A8E0-C80D52AF6F86")]
    	public string fileName
    	{
    		get { return _fileName; }
    		set { _fileName = value; }
    	}
    	
    	
        public CreateDocument()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void CreateDocumentWithData(){
        	//Open window to create new document
        	document.MainForm.btnDocuments.Click();
        	document.MainForm.DocumentsIndexForm.btnNewDocument.Click();
        	
        	//Add data
        	document.DocumentDetail.PnlBase.txtDocumentTitle.PressKeys(documentTitle + time);
        	//document.DocumentDetail.PnlBase.txtDocumentTitle.PressKeys("Document Title");
        	document.DocumentDetail.PnlBase.fileLocationPathText.Element.SetAttributeValue("Text", localFileName);
        	
        	/**
        	document.DocumentDetail.PnlBase.btnLocation.Click();
        	document.Open.linkDocuments.Click();
        	document.Open.listItem.DoubleClick();
        	//document.Open.listItem.DoubleClick();
        	document.Open.listItem.Click();
        	document.Open.btnOpen.Click();
        	*/
        	
        	document.DocumentDetail.MenubarFillPanel.txtDocumentSummary.PressKeys(summary);
        	//document.DocumentDetail.MenubarFillPanel.txtDocumentSummary.PressKeys("Document Summary");
        	document.DocumentDetail.PnlBase.btnFilesAndPeople.Click();
        	
        	//Add file
        	document.DocumentDetail.PnlBase.btnAddFile.Click();
        	document.FileSelectForm.btnQuickFind.Click();
        	document.FindFilesForm.txtFindFile.TextValue = fileName + time;
        	//document.FindFilesForm.txtFindFile.TextValue = "Billing";
        	document.FindFilesForm.btnOK.Click();
        	document.FileSelectForm.listFirstFoundFile.DoubleClick();
        	document.DocumentDetail.MenubarFillPanel.btnOK.Click();
        	
        	//Verify
        	document.MainForm.DocumentsIndexForm.listFirstItem.DoubleClick();
        	Report.Success("Create Document passed");
        	document.DocumentDetail.MenubarFillPanel.btnOK.Click();
        }
        
        public void createLocalFile()
        {
        	localFileName = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName +"\\"+ "RanorexTestFile.txt";
        		//@"C:\Qiao\RanorexTestFile.txt";
			try  
			{  
			    // Check if file already exists. If yes, delete it.   
			    if (File.Exists(localFileName))  
			    {  
			        File.Delete(localFileName);  
			    }  
			  
			    // Create a new file   
			    using (FileStream fs = File.Create(localFileName))   
			    {  
			        // Add some text to file  
			        Byte[] title = new UTF8Encoding(true).GetBytes("Ranorex automation test upload document at " + System.DateTime.Now);  
			        fs.Write(title, 0, title.Length);  
			        byte[] author = new UTF8Encoding(true).GetBytes("By Ranorex automation");  
			        fs.Write(author, 0, author.Length);  
			    }  
			}  
			catch (Exception Ex)  
			{  
				Report.Log(ReportLevel.Failure, String.Format("Failed to create local file in %temp% due to {0}",Ex));
			}   
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            createLocalFile();
            CreateDocumentWithData();
        }
    }
}
