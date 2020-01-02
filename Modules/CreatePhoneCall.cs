/*
 * Created by Ranorex
 * User: hpatel
 * Date: 7/28/2015
 * Time: 10:55 AM
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
using OpenQA.Selenium;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using SmokeTest.Repositories;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of CreatePhoneCall.
    /// </summary>
    [TestModule("D63ED9D9-5429-4313-BF0F-839643ACA4AE", ModuleType.UserCode, 1)]
    public class CreatePhoneCall : ITestModule
    {
    	//Repository variable
    	Communications phoneCall = Communications.Instance;
    	
    	string _time = "";
    	[TestVariable("A5B395D0-5507-4949-9806-A866115FEE46")]
    	public string time
    	{
    		get { return _time; }
    		set { _time = value; }
    	}
    	
    	string _fileName = "";
    	[TestVariable("817AF091-67D6-48D8-A11C-D801061C213D")]
    	public string fileName
    	{
    		get { return _fileName; }
    		set { _fileName = value; }
    	}
    	
    	string _phoneCallNote = "";
    	[TestVariable("E856405F-72B1-4970-846A-40D506A6FECD")]
    	public string phoneCallNote
    	{
    		get { return _phoneCallNote; }
    		set { _phoneCallNote = value; }
    	}
    	
        public CreatePhoneCall()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void CreateCall(){
        	
        	//Open window to add a new phone call
        	phoneCall.MainForm.btnCommunications.Click();
        	phoneCall.MainForm.btnNewMenuItem.Click();
        	phoneCall.AmicusAttorneyXWin.MenuPopup.Click("47;20");
        	//Keyboard.PrepareFocus(repo.CefForm.Open);
        	//Keyboard.Press(System.Windows.Forms.Keys.P | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
//        	Keyboard.Press("{ControlKey down}{ShiftKey down}{P}{ControlKey up}");
        	//Add file to task
        	phoneCall.PhoneDetailForm.MenubarFillPanel.btnAddFile.Click();
        	phoneCall.FileSelectForm.btnQuickFind.Click();
        	phoneCall.FindFilesForm.txtFindFile.TextValue = fileName + time;
        	phoneCall.FindFilesForm.btnOK.Click();
        	phoneCall.FileSelectForm.listFirstFoundFile.DoubleClick();
        	
        	//Add note to the call
        	phoneCall.PhoneDetailForm.MenubarFillPanel.txtPhoneCallNote.PressKeys(phoneCallNote);
        	
        	//Save phone call
        	phoneCall.PhoneDetailForm.MenubarFillPanel.btnOK.Click();
        	
        	//Verify if the phone call is created
        	phoneCall.MainForm.btnShowAllFiles.Click();
        	phoneCall.MainForm.listFirstFile.DoubleClick();
        	Report.Success("Create Phone Call passed");
        	phoneCall.PhoneDetailForm.MenubarFillPanel.btnOK.Click();
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            CreateCall();
            Utilities.Common.ClosePrompt();
        }
    }
}
