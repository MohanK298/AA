/*
 * Created by Ranorex
 * User: Admin
 * Date: 8/4/2015
 * Time: 9:47 AM
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
    [TestModule("D59FA022-2A7C-4F49-89EA-D08DF078C126", ModuleType.UserCode, 1)]
    public class EditLibrary : ITestModule
    {
    	//Repository Variable
    	Library lib = Library.Instance;
    	Common cmn=new Common();
    	string _editSummary = "";
    	[TestVariable("56C815F6-6B0A-4972-8CDE-3FB62A6D0730")]
    	public string editSummary
    	{
    		get { return _editSummary; }
    		set { _editSummary = value; }
    	}
    	
        public EditLibrary()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void Perform(){
        	
        	//lib.MainForm.Panel1.listPersonalUnshelvedMaterialsP.Click("26;7");
        	//Delay.Seconds(2);
        	
        	//lib.MainForm.LibraryIndexForm.listPersonal.Click();
        	//Delay.Seconds(2);
        	
        	//lib.MainForm.Panel1.listSection.Click("33;7");
        	//Delay.Seconds(2);

        	//lib.MainForm.Panel1.listSection.Click("25;7");
        	//Delay.Seconds(2);
        	//lib.MainForm.Panel1.listSection.Click("25;7");
        	//Delay.Seconds(2);
        	//lib.MainForm.Panel1.listSection.Click("25;7");
        	//Delay.Seconds(2);
        	//lib.MainForm.Panel1.listSection.Click("25;7");
        	//Delay.Seconds(2);
        	//lib.MainForm.Panel1.listPage.Click("87;7");
        	
        	lib.MainForm.LibraryIndexForm.listSection.DoubleClick();
        	Delay.Seconds(2);
        	        	
        	//lib.MainForm.Panel1.listPage.Click();
        	//Delay.Seconds(2);
        	
        	//lib.MainForm.Panel1.listPage.DoubleClick("87;7");
        	//lib.MainForm.Panel1.listPage2.DoubleClick();
        	//lib.MainForm.Panel1.listPage.DoubleClick();
        	
        	lib.MainForm.Panel1.listPage.Click();
        	Delay.Seconds(2);
        	
        	lib.MainForm.Panel1.listPage.Click(System.Windows.Forms.MouseButtons.Right, "96;10");
        	lib.AmicusAttorneyXWin1.listDetails.Click();
        	Delay.Seconds(2);
        	
        	//lib.MainForm.Panel1.listPage.Click("87;7");
        	//Delay.Seconds(2);
        	
        	lib.LibraryDetail.txtSummary.PressKeys(editSummary);
        	lib.LibraryDetail.btnOK.Click();
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            Perform();
            cmn.ClosePrompt();
        }
    }
}
