///*
// * Created by Ranorex
// * User: Kumar
// * Date: 2019-10-04
// * Time: 2:20 PM
// * 
// * To change this template use Tools > Options > Coding > Edit standard headers.
// */
//using System;
//using System.IO;
//using System.Collections.Generic;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Drawing;
//using System.Threading;
//using WinForms = System.Windows.Forms;
//using SmokeTest.Repositories;
//using Ranorex;
//using Ranorex.Core;
//using Ranorex.Core.Testing;
//
//namespace SmokeTest.Modules.Attorney_FileDetails
//{
//    /// <summary>
//    /// Description of CreateMultipleDocuments.
//    /// </summary>
// 
//    	
//    
//    [TestModule("61B93A1F-67A9-45B2-BB67-8AD9C6713490", ModuleType.UserCode, 1)]
//    public class CreateMultipleDocuments : ITestModule
//    {
//        /// <summary>
//        /// Constructs a new instance.
//        /// </summary>
//        Documents document = Documents.Instance;
//    	string localFileName = "";
//    	string projectPath = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName;
//    	
//    	string _documentTitle = "Document";
//    	[TestVariable("d8451176-84c3-440c-ae85-8ab835678f55")]
//    	public string documentTitle
//    	{
//    		get { return _documentTitle; }
//    		set { _documentTitle = value; }
//    	}
//    	
//    	
//    	string _time = "2019-10-0611030PM";
//    	[TestVariable("75f83201-9061-4871-9869-174bb6d41fca")]
//    	public string time
//    	{
//    		get { return _time; }
//    		set { _time = value; }
//    	}
//    	
//    	
//    	string _summary = "Summary for Document module - Smoke Test for Amicus Attorney Premium 2017";
//    	[TestVariable("59f49694-f8cf-4396-ae78-53c3f049a638")]
//    	public string summary
//    	{
//    		get { return _summary; }
//    		set { _summary = value; }
//    	}
//    	
//    	string _fileName = "Client File Pegasus";
//    	[TestVariable("36c891fa-c6d5-4ea7-8db5-a7c395f6e866")]
//    	public string fileName
//    	{
//    		get { return _fileName; }
//    		set { _fileName = value; }
//    	}
//    
//        public CreateMultipleDocuments()
//        {
//            // Do not delete - a parameterless constructor is required!
//        
//       
//        }
//        public void CreateDocumentWithData()
//        {
//        	string[] fileType;
//        	fileType = new string[4] {"File","Folder","WebPageURL","Other"};
//        	
//        	for(int i=0;i<fileType.Length;i++)
//        	{
//	        	//Open window to create new document
//	        	document.MainForm.btnDocuments.Click();
//	        	document.MainForm.DocumentsIndexForm.btnNewDocument.Click();
//	        //	_listItemName=fileType[i];
//	        document.listItemName = fileType[i];
//        	//Add data
//        	document.DocumentDetail.PnlBase.txtDocumentTitle.PressKeys(documentTitle + fileType[i] + time);
//        	//document.DocumentDetail.PnlBase.txtDocumentTitle.PressKeys("Document Title");
//        	
//        	if(string.Equals(fileType[i],"File"))
//        	   {
//        		createLocalFile();
//        	   //	document.DocumentDetail.PnlBase.dpdwnFileType.Element.SetAttributeValue("Text", fileType[i]);
//        	document.DocumentDetail.PnlBase.dpdwnFileType.Click();
//            Keyboard.PrepareFocus(document.DocumentDetail.PnlBase.dpdwnFileType);
//            Keyboard.Press(System.Windows.Forms.Keys.Return, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
//           	document.DocumentDetail.PnlBase.fileLocationPathText.Element.SetAttributeValue("Text", localFileName);
//        	}
//        	
//        	if(string.Equals(fileType[i],"Folder"))
//        	   {
//        		createLocalFolder();
//	        	document.DocumentDetail.PnlBase.dpdwnFileType.Click();
////	        	document.DocumentDetail.PnlBase.listItem.Click();
//	            Keyboard.PrepareFocus(document.DocumentDetail.PnlBase.dpdwnFileType);
//	            Keyboard.Down(System.Windows.Forms.Keys.Down, Keyboard.DefaultScanCode, true);
//	            Keyboard.Press(System.Windows.Forms.Keys.Return, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
//	           	document.DocumentDetail.PnlBase.fileLocationPathText.Element.SetAttributeValue("Text", localFileName);
//        	   }
//        	if(string.Equals(fileType[i],"WebPageURL"))
//        	   {
//
//	        	document.DocumentDetail.PnlBase.dpdwnFileType.Click();
////	        	document.DocumentDetail.PnlBase.listItem.Click();
//	            Keyboard.PrepareFocus(document.DocumentDetail.PnlBase.dpdwnFileType);
//	            Keyboard.Down(System.Windows.Forms.Keys.Down, Keyboard.DefaultScanCode, true);
//	            Keyboard.Down(System.Windows.Forms.Keys.Down, Keyboard.DefaultScanCode, true);
//	            Keyboard.Press(System.Windows.Forms.Keys.Return, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
//	           	document.DocumentDetail.PnlBase.fileLocationPathText.Element.SetAttributeValue("Text", "https://www.abacusnext.com");
//        	   }
//			if(string.Equals(fileType[i],"Other"))
//        	   {
//
//	        	document.DocumentDetail.PnlBase.dpdwnFileType.Click();
//	        	//document.DocumentDetail.PnlBase.listItem.
//	        	document.DocumentDetail.PnlBase.listItem.Click();
//	            Keyboard.PrepareFocus(document.DocumentDetail.PnlBase.dpdwnFileType);
//	            Keyboard.Down(System.Windows.Forms.Keys.Down, Keyboard.DefaultScanCode, true);
//	            Keyboard.Down(System.Windows.Forms.Keys.Down, Keyboard.DefaultScanCode, true);
//	            Keyboard.Down(System.Windows.Forms.Keys.Down, Keyboard.DefaultScanCode, true);
//	            Keyboard.Press(System.Windows.Forms.Keys.Return, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
//	           	document.DocumentDetail.PnlBase.fileLocationPathText.Element.SetAttributeValue("Text", "Empty File Location");
//        	   }
//
//        	
//        	document.DocumentDetail.MenubarFillPanel.txtDocumentSummary.PressKeys(summary);
//        	//document.DocumentDetail.MenubarFillPanel.txtDocumentSummary.PressKeys("Document Summary");
//        	document.DocumentDetail.PnlBase.btnFilesAndPeople.Click();
//        	
//        	//Add file
//        	document.DocumentDetail.PnlBase.btnAddFile.Click();
//        	document.FileSelectForm.btnQuickFind.Click();
//        	document.FindFilesForm.txtFindFile.TextValue = fileName + time;
//        	//document.FindFilesForm.txtFindFile.TextValue = "Billing";
//        	document.FindFilesForm.btnOK.Click();
//        	Delay.Seconds(5);
//        	document.FileSelectForm.listFirstFoundFile.DoubleClick();
//        	document.DocumentDetail.MenubarFillPanel.btnOK.Click();
//        	}
//        	//Verify
////        	document.MainForm.DocumentsIndexForm.listFirstItem.DoubleClick();
////        	Report.Success("Create Document passed");
////        	document.DocumentDetail.MenubarFillPanel.btnOK.Click();
//        
//        }
//        public void createLocalFile()
//        {
//        	localFileName = projectPath +"\\"+ "RanorexTestFile.txt";
//        		//@"C:\Qiao\RanorexTestFile.txt";
//			try  
//			{  
//			    // Check if file already exists. If yes, delete it.   
//			    if (File.Exists(localFileName))  
//			    {  
//			        File.Delete(localFileName);  
//			    }  
//			  
//			    // Create a new file   
//			    using (FileStream fs = File.Create(localFileName))   
//			    {  
//			        // Add some text to file  
//			        Byte[] title = new UTF8Encoding(true).GetBytes("Ranorex automation test upload document at " + System.DateTime.Now);  
//			        fs.Write(title, 0, title.Length);  
//			        byte[] author = new UTF8Encoding(true).GetBytes("By Ranorex automation");  
//			        fs.Write(author, 0, author.Length);  
//			    }  
//			}  
//			catch (Exception Ex)  
//			{  
//				Report.Log(ReportLevel.Failure, String.Format("Failed to create local file due to {0}",Ex));
//			}   
//        }
//        
//        public void createLocalFolder()
//        {
//        	
//       		localFileName = projectPath +"\\"+ "RanorexTestFolder";
//        	try  
//			{  
//        		 System.IO.Directory.CreateDirectory(localFileName);
//			}  
//			catch (Exception Ex)  
//			{  
//				Report.Log(ReportLevel.Failure, String.Format("Failed to create local folder due to {0}",Ex));
//			}  
//        }
//        
//        /// <summary>
//        /// Performs the playback of actions in this module.
//        /// </summary>
//        /// <remarks>You should not call this method directly, instead pass the module
//        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
//        /// that will in turn invoke this method.</remarks>
//        void ITestModule.Run()
//        {
//            Mouse.DefaultMoveTime = 300;
//            Keyboard.DefaultKeyPressTime = 100;
//            Delay.SpeedFactor = 1.0;
//            CreateDocumentWithData();
//        }
//    }
//}
