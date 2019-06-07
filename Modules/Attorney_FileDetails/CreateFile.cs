/*
 * Created by Ranorex
 * User: Het Patel
 * Date: 7/26/2016
 * Time: 10:35 AM
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

namespace SmokeTest.Modules.Attorney_FileDetails
{
    [TestModule("B427C117-4C7B-4452-B8AF-80DCA64F75A2", ModuleType.UserCode, 1)]
    public class CreateFile : ITestModule
    {
    	//Repository Variable
    	SmokeTest.Repositories.Files file = new SmokeTest.Repositories.Files();
    	
    	//Variables
    	
    	string _time = "";
    	[TestVariable("6193B8F1-1EEA-4693-866C-25439B548AA0")]
    	public string time
    	{
    		set { 
    			_time = " " + System.DateTime.Now.ToString(); 
    			_time = _time.Replace("/", string.Empty);
    			_time = _time.Replace(":", string.Empty);
    			_time = _time.Replace(" ", string.Empty);
    		}
    		get { return _time; }
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
    	
    	public void FindFile(){
        	//Find file
        	file.MainForm.FilesIndexForm.btnQuickFind.Click();
        	file.FindFilesForm.txtFindFile.TextValue = fileName + time + "2";
        	file.FindFilesForm.btnOK.Click();
        }
        
        public void Action(){
        	//Open window to add a file
        	file.MainForm.btnFiles.Click();
        	file.MainForm.FilesIndexForm.btnNewFile.Click();
        	
        	//Type the file name and other variables
        	file.NewFileForm.txtFileName.TextValue = fileName + time;
        	file.NewFileForm.btnAddContact.Click();
        	file.PeopleSelectForm.btnQuickFind.Click();
        	file.FindContactsForm.txtFindContact.TextValue = lastName + time;
        	file.FindContactsForm.btnOK.Click();
        	file.PeopleSelectForm.listFirstValue.Click();
        	file.PeopleSelectForm.btnAddToRight.Click();
        	file.PeopleSelectForm.btnOK.Click();
        	file.NewFileForm.btnSaveOpen.Click();
        	
        	FindFile();
        	
        	//Verify File
        	file.MainForm.FilesIndexForm.listFirstFile.DoubleClick();
        	Validate.Equals(file.FileDetailForm.titlebarFileDetail.Text, fileName + time + "2");
        	Delay.Seconds(3);
        	file.FileDetailForm.Admin.Click();
        	Delay.Seconds(1);
        	file.FileDetailForm.Accounting.Click();
        	Delay.Seconds(1);
        	file.FileDetailForm.clientID.TextValue = time.TrimEnd('3');
        	file.FileDetailForm.matterID.TextValue = time.TrimStart('2');
        	Delay.Seconds(1);
        	file.FileDetailForm.btnSaveClose.Click();
        	Delay.Seconds(1);
        	file.PromptForm.ButtonYes.Click();
        }
    	
        public CreateFile()
        {
            // Do not delete - a parameterless constructor is required!
        }

        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            Action();
        }
    }
}
