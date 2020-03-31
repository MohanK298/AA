/*
 * Created by Ranorex
 * User: hpatel
 * Date: 7/28/2015
 * Time: 11:34 AM
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
    /// <summary>
    /// Description of EditPhoneCall.
    /// </summary>
    [TestModule("07756101-6C9B-4ED0-9150-15296725B9FB", ModuleType.UserCode, 1)]
    public class EditPhoneCall : ITestModule
    {
    	//Repository variable
    	Communications phoneCall = Communications.Instance;
    	Common cmn=new Common();
    	string _time = "";
    	[TestVariable("5E540042-71BD-4324-8F99-D73912BDEEF0")]
    	public string time
    	{
    		get { return _time; }
    		set { _time = value; }
    	}
    	
    	string _editPhoneCallNote = "";
    	[TestVariable("F2FEC33A-938B-4A5E-BFA3-62B3295ACB34")]
    	public string editPhoneCallNote
    	{
    		get { return _editPhoneCallNote; }
    		set { _editPhoneCallNote = value; }
    	}
    	
        public EditPhoneCall()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void EditCall(){
        	//Open phone call
        	phoneCall.MainForm.listFirstFile.DoubleClick();
        	
        	//Edit phone call
        	phoneCall.PhoneDetailForm.MenubarFillPanel.txtPhoneCallNote.Click();
            Keyboard.Press(System.Windows.Forms.Keys.A | System.Windows.Forms.Keys.Control, 30, Keyboard.DefaultKeyPressTime, 1, true);
            phoneCall.PhoneDetailForm.MenubarFillPanel.txtPhoneCallNote.PressKeys("{Back}");
            phoneCall.PhoneDetailForm.MenubarFillPanel.txtPhoneCallNote.PressKeys(editPhoneCallNote);
            
            //Save phone call
            phoneCall.PhoneDetailForm.MenubarFillPanel.btnOK.Click();
            
            //Verify if the phone call is edited
            phoneCall.MainForm.listFirstFile.DoubleClick();
            Report.Success("Phone Call Edit passed");
            phoneCall.PhoneDetailForm.MenubarFillPanel.btnOK.Click();
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            EditCall();
            cmn.ClosePrompt();
        }
    }
}
