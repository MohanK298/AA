/*
 * Created By Asish
 * User: Administrator
 * Date: 2018-02-02
 * Time: 12:24 PM
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

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of AddPrecedent.
    /// </summary>
    [TestModule("28141BFA-9B58-4FE9-AA7F-A23670343DBA", ModuleType.UserCode, 1)]
    public class AddPrecedent : ITestModule
    {
    	//Repository Variable
    	//Files file = Files.Instance;
        SmokeTest.Repositories.Files file = new SmokeTest.Repositories.Files();
    	SmokeTest.Repositories.Calendar calendar = new SmokeTest.Repositories.Calendar();
    	
    	//Variables
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
    	
    	
        public AddPrecedent()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void Action()
        {
        	file.MainForm.FilesIndexForm.SearchFile.Click();
        	file.FindFilesForm.txtSearch.TextValue = fileName + time;
        	file.FindFilesForm.btnOK.Click();
        	Delay.Milliseconds(200);
        	file.MainForm.FilesIndexForm.listFirstFile.DoubleClick();
        	file.FileDetailForm.Events.Click();
        	file.FileDetailForm.AllMyEvents.Click();
        	file.FileDetailForm.PrecedentAction.Click();
        	file.FileDetailForm.UsePrecedent.Click();
        	file.PrecedentSelectForm.SelectPrecedent.DoubleClick();
        	file.PrecedentSelectForm.btnOk.Click();
        	file.BaseDatesForm.btnOk.Click();
        	Validate.Exists(file.FileDetailForm.VerifyPrecedent1Info);
        	Validate.Exists(file.FileDetailForm.VerifyPrecedent2Info);
        	file.FileDetailForm.btnSaveClose.Click();
        	
        	
        	
        	
        	
        	
        	
        	
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
