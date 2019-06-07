/*
 * Created By Asish
 * User: Administrator
 * Date: 2018-01-08
 * Time: 12:11 PM
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
    /// <summary>
    /// Description of CreateManyFiles.
    /// </summary>
    [TestModule("02497DD7-6968-4C50-BA29-F30A1BEB2B4B", ModuleType.UserCode, 1)]
    public class CreateManyFiles : ITestModule
    {
        //Repository Variable
    	Files file = Files.Instance;
    	People people = People.Instance;
    	
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
    	    	
        public CreateManyFiles()
        {
            // Do not delete - a parameterless constructor is required!
        }
     	void ITestModule.Run()
       	{
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            CreateFile();
        }
   
        	
		public void FindFile()
		{
        	//Find file
        	file.MainForm.FilesIndexForm.btnQuickFind.Click();
        	file.FindFilesForm.txtFindFile.TextValue = fileName + time;
        	//file.FindFilesForm.txtFindFile.PressKeys("Ranorex File " + String.Format("{0:000}", value));
        	file.FindFilesForm.btnOK.Click();
        }
        
        public void CreateFile()
        {
        	//Create Many Files
        	for (int value = 001; value <= 500; value++)
        	{
	        	//Open window to add a file
	        	file.MainForm.btnFiles.Click();
	        	file.MainForm.FilesIndexForm.btnNewFile.Click();
	        	
	        	if(file.PromptForm.ButtonNoInfo.Exists())
	        	{
	        		file.PromptForm.ButtonNo.Click();
	        	}
	        	else
	        	{
	        		Report.Info("No File prompt form");
	        		
	        	}
	        	Delay.Seconds(3);
	        	
	        	//Type the file name and other variables
	        	//file.NewFileForm.txtFileName.TextValue = fileName + time + "2";
	        	file.NewFileForm.txtFileName.PressKeys("Ranorex File " + String.Format("{0:000}", value));
	        	
	        	Delay.Seconds(5);
	        	
	        	file.NewFileForm.btnAddContact.Click();
	        	file.PeopleSelectForm.btnQuickFind.Click();
	        	//file.FindContactsForm.txtFindContact.TextValue = lastName + time;
	        	file.FindContactsForm.txtFindContact.PressKeys("Contact Ranorex " + String.Format("{0:000}", value));
	        	file.FindContactsForm.btnOK.Click();
	        	file.PeopleSelectForm.listFirstValue.Click();
	        	file.PeopleSelectForm.btnAddToRight.Click();
	        	file.PeopleSelectForm.btnOK.Click();
	        	
	        	//file.NewFileForm.btnNext.Click();
	        	
	        	Delay.Seconds(5);
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
	        	//file.FileDetailForm.clientID.TextValue = (time.Equals("")) ? System.DateTime.Now.ToString() : time.TrimEnd('3');
	        	//file.FileDetailForm.matterID.TextValue = (time.Equals("")) ? System.DateTime.Now.ToString() : time.TrimStart('2');
	        	file.FileDetailForm.clientID.PressKeys("CID-" + String.Format("{0:000}", value));
	        	file.FileDetailForm.matterID.PressKeys("MID-" + String.Format("{0:000}", value));
	        	
	        	Delay.Seconds(1);
	        	file.FileDetailForm.btnSaveClose.Click();
	        	Delay.Seconds(1);
	        	file.PromptForm.ButtonYes.Click();
	        }

        }
    }
}
