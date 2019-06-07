/*
 * Created By Asish
 * User: Administrator
 * Date: 2017-11-08
 * Time: 9:53 AM
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

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

using SmokeTest.Repositories;
using SmokeTest.Modules;

namespace SmokeTest.Modules
{
   
    [TestModule("9C140D64-1D4E-4AD0-ABEC-590EC42BE352", ModuleType.UserCode, 1)]
    public class AddFile1 : ITestModule
    {
    	
    	//Repository Variable
    	Files file = Files.Instance;
    	
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
    	
    	
        public AddFile1()
        {
            // Do not delete - a parameterless constructor is required!
        }
        public void FindFile(){
        	//Find file
        	file.MainForm.FilesIndexForm.btnQuickFind.Click();
        	file.FindFilesForm.txtFindFile.TextValue = fileName + time;
        	file.FindFilesForm.btnOK.Click();
        }
        
        public void CreateFile(){
        	
        	//Open window to add a file
        	file.MainForm.btnFiles.Click();
        	file.MainForm.FilesIndexForm.btnNewFile.Click();
        	
        	if (file.PromptForm.ButtonNoInfo.Exists(500))
        	{
        		file.PromptForm.ButtonNo.Click();
        	}
        		else
        		{
        			Report.Info("New File Creating");
        		}
        
        	//file.PromptForm.ButtonNo.Click();
        	//Delay.Seconds(3);
        	
        	//Type the file name and other variables
        	//file.NewFileForm.txtFileName.TextValue = fileName + time + "2";
        	file.NewFileForm.txtFileName.TextValue = fileName + time;
        	
        	Delay.Seconds(10);
        	
        	file.NewFileForm.btnAddContact.Click();
        	file.PeopleSelectForm.btnQuickFind.Click();
        	file.FindContactsForm.txtFindContact.TextValue = lastName + time;
        	file.FindContactsForm.btnOK.Click();
        	file.PeopleSelectForm.listFirstValue.Click();
        	file.PeopleSelectForm.btnAddToRight.Click();
        	file.PeopleSelectForm.btnOK.Click();
        	
        	//file.NewFileForm.btnNext.Click();
        	
        	Delay.Seconds(10);
        	file.NewFileForm.btnSaveOpen.Click();
        	
        	FindFile();
        	
        	//Verify File
        	file.MainForm.FilesIndexForm.listFirstFile.DoubleClick();
        	//Validate.Equals(file.FileDetailForm.titlebarFileDetail.Text, fileName + time + "2");
        	Validate.Equals(file.FileDetailForm.titlebarFileDetail.Text, fileName + time);
        	Delay.Seconds(3);
        	
        	
        	file.FileDetailForm.Admin.Click();
        	Delay.Seconds(1);
        	file.FileDetailForm.Accounting.Click();
        	Delay.Seconds(2);

        	//file.FileDetailForm.clientID.TextValue = time.TrimEnd('3');
        	//file.FileDetailForm.matterID.TextValue = time.TrimStart('2');
        	file.FileDetailForm.clientID.TextValue = (time.Equals("")) ? System.DateTime.Now.ToString() : time.TrimEnd('3');
        	file.FileDetailForm.matterID.TextValue = (time.Equals("")) ? System.DateTime.Now.ToString() : time.TrimStart('2');
        	
        	Delay.Seconds(1);
        	file.FileDetailForm.btnSaveClose.Click();
        	Delay.Seconds(1);
        	file.PromptForm.ButtonYes.Click();
        }

        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            CreateFile();
        }
    }
}
