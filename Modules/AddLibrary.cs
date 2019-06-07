/*
 * Created by Ranorex
 * User: Admin
 * Date: 8/4/2015
 * Time: 8:59 AM
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

namespace SmokeTest.Modules
{
    [TestModule("1A712023-062D-4698-9ACB-9D9790C9DB99", ModuleType.UserCode, 1)]
    public class AddLibrary : ITestModule
    {
    	//Repository Variable
    	Library lib = Library.Instance;
    	
    	string _txtSummary = "";
    	[TestVariable("1A3FE1A8-743F-465B-860C-84C99ED51F97")]
    	public string txtSummary
    	{
    		get { return _txtSummary; }
    		set { _txtSummary = value; }
    	}
    	
    	string _txtPageTitle = "";
    	[TestVariable("6FC31B97-3281-41C0-961A-2B2C4E849B9A")]
    	public string txtPageTitle
    	{
    		get { return _txtPageTitle; }
    		set { _txtPageTitle = value; }
    	}
    	
    	string _lblSectionName = "";
    	[TestVariable("9806A0B4-422F-4DA4-B605-72D91F99E56F")]
    	public string lblSectionName
    	{
    		get { return _lblSectionName; }
    		set { _lblSectionName = value; }
    	}
    	
    	string _time = "";
    	[TestVariable("D2469BEB-A9EE-4CA2-BEF1-D417A9C7F893")]
    	public string time
    	{
    		get { return _time; }
    		set { _time = value; }
    	}
    	
        public AddLibrary()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void Perform(){
        	
        	lib.MainForm.btnLibrary.Click();
        	lib.MainForm.LibraryIndexForm.btnMenuItem.Click();
        	
        	//Click on Section
        	lib.AmicusAttorneyXWin.MenuPopup.Click("62;13");
        	Delay.Seconds(2);
        	
        	//lib.MainForm.LibraryIndexForm.lblEditLabel.Click();
        	
        	//lib.MainForm.LibraryIndexForm.lblEditLabel.PressKeys(lblSectionName + time);
        	//lib.MainForm.LibraryIndexForm.lblEditLabel.PressKeys(lblSectionName);
        	//lib.MainForm.LibraryIndexForm.lblEditLabel.PressKeys("{Return}");
        	//Delay.Seconds(2);
        	
        	lib.MainForm.LibraryIndexForm.listPersonal.Click();
        	Delay.Seconds(2);
        	
        	lib.MainForm.LibraryIndexForm.listSection.Click();
        	Delay.Seconds(2);
        	
        	lib.MainForm.LibraryIndexForm.listSection.Click(System.Windows.Forms.MouseButtons.Right, "76;5");
        	
        	//Click on Page
        	//lib.AmicusAttorneyXWin1.listItemNewPage.Click("47;11");
        	lib.AmicusAttorneyXWin1.listItemNewPage.Click();
        	Delay.Seconds(2);
        	
        	//lib.LibraryDetail.txtpageTitle.PressKeys(txtPageTitle + time);
        	lib.LibraryDetail.txtpageTitle.PressKeys(txtPageTitle);
        	lib.LibraryDetail.txtSummary.PressKeys(txtSummary);
        	lib.LibraryDetail.btnOK.Click();
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
        	
            Perform();
        }
    }
}
