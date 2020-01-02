/*
 * Created by Ranorex
 * User: Admin
 * Date: 7/29/2015
 * Time: 11:31 AM
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
    [TestModule("C2886DE8-A2A4-46B8-A2BE-327FBCDFC0D1", ModuleType.UserCode, 1)]
    public class EditDocument : ITestModule
    {
    	//Repository variable
    	Documents document = Documents.Instance;
    	
    	string _editSummary = "";
    	[TestVariable("8208E68A-651A-4B8A-85EC-3A01D4FE8A8E")]
    	public string editSummary
    	{
    		get { return _editSummary; }
    		set { _editSummary = value; }
    	}
    	
    	string _time = "";
    	[TestVariable("3F1D4F25-5D8F-4181-B1E8-89A8082BB91B")]
    	public string time
    	{
    		get { return _time; }
    		set { _time = value; }
    	}
    	
        public EditDocument()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void EditDocumentWithData()
        {
            document.MainForm.DocumentsIndexForm.listFirstItem.DoubleClick();
        	document.DocumentDetail.MenubarFillPanel.txtDocumentSummary.Click();
        	Keyboard.Press(System.Windows.Forms.Keys.A | System.Windows.Forms.Keys.Control, 30, Keyboard.DefaultKeyPressTime, 1, true);
            document.DocumentDetail.MenubarFillPanel.txtDocumentSummary.PressKeys("{Back}");
        	document.DocumentDetail.MenubarFillPanel.txtDocumentSummary.PressKeys(editSummary);
        	document.DocumentDetail.MenubarFillPanel.btnOK.Click();
        	
        	//Verify
        	document.MainForm.DocumentsIndexForm.listFirstItem.DoubleClick();
        	Report.Success("Edit Document passed");
        	document.DocumentDetail.MenubarFillPanel.btnOK.Click();
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            EditDocumentWithData();
            Utilities.Common.ClosePrompt();
        }
    }
}
