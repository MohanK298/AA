/*
 * Created By Asish
 * User: Administrator
 * Date: 2018-01-08
 * Time: 1:52 PM
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
    /// <summary>
    /// Description of CreateManyPhoneCalls.
    /// </summary>
    [TestModule("89B6FE9E-88D2-45F3-8A6E-B52C502E1495", ModuleType.UserCode, 1)]
    public class CreateManyPhoneCalls : ITestModule
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
    	
        public CreateManyPhoneCalls()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void CreateCall()
        {
        	for (int value = 001; value <= 500; value++)
        	{
	        	//Open window to add a new phone call
	        	phoneCall.MainForm.btnCommunications.Click();
	        	phoneCall.MainForm.btnNewMenuItem.Click();
	        	phoneCall.AmicusAttorneyXWin.MenuPopup.Click("47;20");
	
	        	//Add file to task
	        	phoneCall.PhoneDetailForm.MenubarFillPanel.btnAddFile.Click();
	        	phoneCall.FileSelectForm.btnQuickFind.Click();
	        	phoneCall.FindFilesForm.txtFindFile.PressKeys("Ranorex File " + String.Format("{0:000}", value));
	        	phoneCall.FindFilesForm.btnOK.Click();
	        	phoneCall.FileSelectForm.listFirstFoundFile.DoubleClick();
	        	
	        	//Add note to the call
	        	phoneCall.PhoneDetailForm.MenubarFillPanel.txtPhoneCallNote.PressKeys("Ranorex Phone Call "+ String.Format("{0:000}", value));
	        	
	        	//Save phone call
	        	phoneCall.PhoneDetailForm.MenubarFillPanel.btnOK.Click();
	        	
	        	//Verify if the phone call is created
	        	phoneCall.MainForm.btnShowAllFiles.Click();
	        	phoneCall.MainForm.listFirstFile.DoubleClick();
	        	Report.Success("Create Phone Call passed");
	        	phoneCall.PhoneDetailForm.MenubarFillPanel.btnOK.Click();
        	}
        }
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            CreateCall();
        }
    }
}
