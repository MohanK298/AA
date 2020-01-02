/*
 * Created By Asish}
 * User: Administrator
 * Date: 2017-11-01
 * Time: 2:01 PM
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

namespace SmokeTest.Modules.Attorney_FileDetails
{
    /// <summary>
    /// Description of AddOther.
    /// </summary>
    [TestModule("19422362-B116-427A-ADDC-7AD6D6A56F62", ModuleType.UserCode, 1)]
    public class AddOther : ITestModule
    {
       //Repository Variable
       SmokeTest.Repositories.Files file = new SmokeTest.Repositories.Files();
       Common cmn=new Common();
        public AddOther()
        {
            // Do not delete - a parameterless constructor is required!
        }

       	public void Action(){
        	file.MainForm.btnFiles.Click();
        	file.MainForm.FilesIndexForm.listFirstFile.DoubleClick();
        	Delay.Seconds(2);
        	file.FileDetailForm.Documents.Click();
        	Delay.Seconds(1);
        	file.FileDetailForm.AllDocuments.Click();
        	Delay.Seconds(1);
        	file.FileDetailForm.btnNewDoc.Click();
        	Delay.Seconds(1);
        	//file.DocumentDetail.pnlBase.txtDocumentTitle.PressKeys(documentTitle + time);
        	file.DocumentDetail.PnlBase.txtDocumentTitle.PressKeys("Add Other Type Test");
        	file.DocumentDetail.PnlBase.ButtonEditorDropdownButton.Click();
        	//file.DropdownSelector.DropdownSelect2.Click();
        	//doc.DocumentDetail.PnlBase.btnDropdownType.Click();
        	file.DropDownForm.Self.Activate();
        	cmn.SelectItemDropdown(file.tblDpdwnList.Self,"Other");
        	Delay.Seconds(1);
        	file.DocumentDetail.PnlBase.Text.PressKeys("Adding Other Type Test");
        	file.DocumentDetail.summaryTxt.PressKeys("This is adding Other Type Test");
        	file.DocumentDetail.btnOK.Click();
        	
        
        	
        }
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
        Action();
        
        Utilities.Common.ClosePrompt();
        }
    }
}
