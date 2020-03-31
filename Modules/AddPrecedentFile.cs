/*
 * Created By Asish
 * User: Administrator
 * Date: 2018-02-05
 * Time: 1:59 PM
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
using SmokeTest.Modules.Utilities;
using SmokeTest.Repositories;
using SmokeTest.Modules;

namespace SmokeTest.Modules
{
    
    [TestModule("4B311305-8DCA-4172-99C6-C3E221217FC5", ModuleType.UserCode, 1)]
    public class AddPrecedentFile : ITestModule
    {
        //Repository Variable
    	Files file = Files.Instance;
    	Common cmn=new Common();
    	 string _time = "";
    	[TestVariable("6193B8F1-1EEA-4693-866C-25439B548AA0")]
    	public string time
    	{
    		get { return _time; }
    		set { _time = value; }
    	}
    	
    	string _fileName = "";
    	[TestVariable("DDE10115-729E-4144-AAC6-425EAF372517")]
    	public string fileName
    	{
    		get { return _fileName; }
    		set { _fileName = value; }
    	}
    	
    	
    	
        public AddPrecedentFile()
        {
            // Do not delete - a parameterless constructor is required!
        }

		public void FindFile()
		{
        	//Find file
        	file.MainForm.FilesIndexForm.btnQuickFind.Click();
        	file.FindFilesForm.txtFindFile.TextValue = fileName + time;
        	file.FindFilesForm.btnOK.Click();
        }
        
        public void CreateFile(){
        	string rndData="";
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
        	file.NewFileForm.txtFileName.TextValue = fileName + time;
        	
        	Delay.Seconds(2);
        	
        	file.NewFileForm.btnAddContact.Click();
        	file.PeopleSelectForm.btnQuickFind.Click();
        	file.FindContactsForm.txtFindContact.TextValue = "Ranorex" + time;
        	file.FindContactsForm.btnOK.Click();
        	file.PeopleSelectForm.listFirstValue.Click();
        	file.PeopleSelectForm.btnAddToRight.Click();
        	file.PeopleSelectForm.btnOK.Click();
        	
        	//file.NewFileForm.btnNext.Click();
        	
        	Delay.Seconds(2);
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
        	rndData=RandomData();
        	//file.FileDetailForm.clientID.PressKeys("001");
        	//file.FileDetailForm.matterID.PressKeys("002");
        	//file.FileDetailForm.clientID.TextValue = time.TrimEnd('3');
        	//file.FileDetailForm.matterID.TextValue = time.TrimStart('2');
        	file.FileDetailForm.clientID.TextValue = (time.Equals("")) ? System.DateTime.Now.ToString() : time.TrimEnd('3');
        	file.FileDetailForm.matterID.TextValue = rndData;
        	
        	Delay.Seconds(1);
        	file.FileDetailForm.btnSaveClose.Click();
        	Delay.Seconds(1);
        	if(file.PromptForm.ButtonYesInfo.Exists(3000))
        	
        	   {file.PromptForm.ButtonYes.Click();}
        }
		private string RandomData()
		{
			Random rnd=new Random();
			 StringBuilder builder = new StringBuilder();  
			 builder.Append(rnd.Next());
			 builder.Append(rnd.Next(2,2000));
			 builder.Append(rnd.Next(1, 500));  
    return builder.ToString();  
		}
		
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            CreateFile();
            cmn.ClosePrompt();
        }
    }
}