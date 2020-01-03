/*
 * Created by Ranorex
 * User: Admin
 * Date: 8/4/2015
 * Time: 12:41 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;
using SmokeTest.Modules.Utilities;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

using SmokeTest.Repositories;

namespace SmokeTest.Modules
{
    [TestModule("CC21FCFD-0727-4B7F-BEC4-8F3E473AD8EF", ModuleType.UserCode, 1)]
    public class BillingAddFile : ITestModule
    {
    	//Repository Variable
    	BillingFile file = BillingFile.Instance;
    	Common cmn=new Common();
    	//Variables
    	string _time = "";
    	[TestVariable("6193B8F1-1EEA-4693-866C-25439B548AA0")]
    	public string time
    	{
    		get { return _time; }
    		set { _time = value; }
    	}
    	
    	
    	string _lastName = "";
    	[TestVariable("EEAB8051-D07D-447A-972F-314EAB0ECD9C")]
    	public string lastName
    	{
    		get { return _lastName; }
    		set { _lastName = value; }
    	}
    	
    	
    	string _firstName = "";
    	[TestVariable("EAB5AE1D-EA6C-476A-9C0D-9A83926A1A9E")]
    	public string firstName
    	{
    		get { return _firstName; }
    		set { _firstName = value; }
    	}
    	
    	
    	string _fileName = "";
    	[TestVariable("DDE10115-729E-4144-AAC6-425EAF372517")]
    	public string fileName
    	{
    		get { return _fileName; }
    		set { _fileName = value; }
    	}
    	
        public BillingAddFile()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void FindFile(){
        	//Find file
        	file.MainForm.FilesIndexForm.btnQuickFind.Click();
        	file.FindFilesForm.txtFindFile.TextValue = fileName + time;
        	//file.FindFilesForm.txtFindFile.TextValue = fileName;
        	file.FindFilesForm.btnOK.Click();
        }
        
        public void Perform(){
        	//Open window to add a file
        	file.MainForm.Self.Activate();
        	file.MainForm.btnFiles.Click();
        	file.MainForm.FilesIndexForm.btnNewFile.Click();
        	
        	if(file.PromptForm.SelfInfo.Exists(3000))
        	   {
        	   	file.PromptForm.btnNo.Click();
        	   }
        	
        	//Type the file name and other variables
        	file.NewFileForm.txtFileName.TextValue = fileName + time;
        	//file.NewFileForm.txtFileName.TextValue = fileName;
        	file.NewFileForm.btnAddContact.Click();
        	file.PeopleSelectForm.btnQuickFind.Click();
        	file.FindContactsForm.txtFindContact.TextValue = lastName + time;
        	//file.FindContactsForm.txtFindContact.TextValue = lastName;
        	file.FindContactsForm.btnOK.Click();
        	file.PeopleSelectForm.listFirstValue.Click();
        	file.PeopleSelectForm.btnAddToRight.Click();
        	file.PeopleSelectForm.btnOK.Click();
        	
        	//file.NewFileForm.btnNext.Click();
        	
        	file.NewFileForm.btnSaveOpen.Click();
        	
        	FindFile();
        	Delay.Seconds(2);
        	//Verify File
        	cmn.SelectItemFromTableDblClick(file.MainForm.FilesIndexForm.tblFiles,fileName + time,"File List Table");
        	//file.MainForm.FilesIndexForm.listFirstFile.DoubleClick();
        	Validate.Equals(file.FileDetailForm.titlebarFileDetail.Text, fileName + time + "1");
        	Delay.Seconds(3);
        	
        	file.FileDetailForm.Admin.Click();
        	Delay.Seconds(1);
        	file.FileDetailForm.Accounting.Click();
        	Delay.Seconds(2);

        	//file.FileDetailForm.clientID.TextValue = time.TrimEnd('3');
        	//file.FileDetailForm.matterID.TextValue = time.TrimStart('2');
        	file.FileDetailForm.clientID.TextValue = (time.Equals("")) ? System.DateTime.Now.ToString() : time.TrimEnd('3');
        	file.FileDetailForm.matterID.TextValue = (time.Equals("")) ? System.DateTime.Now.ToString() : time.TrimStart('2');
        	file.FileDetailForm.btnSaveClose.Click();
        	Delay.Seconds(1);
        	file.PromptForm.ButtonYes.Click();
//        	file.FileDetailForm.btnSaveClose.Click();
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            Perform();
            //Utilities.Common.ClosePrompt();
        }
    }
}
