/*
 * Created by Ranorex
 * User: HPatel
 * Date: 7/29/2015
 * Time: 11:35 AM
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
    [TestModule("673DE6E6-28B2-4346-A905-E834EBE0E73C", ModuleType.UserCode, 1)]
    public class DeleteDocument : ITestModule
    {
    	//Repository variable
    	Documents document = Documents.Instance;
    	
        public DeleteDocument()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void DeleteDocumentWithData(){
        	document.MainForm.DocumentsIndexForm.listFirstItem.DoubleClick();
        	document.DocumentDetail.MenubarFillPanel.btnDelete.Click();
        	document.PromptForm.btnOK.Click();
        	Report.Success("Delete Document passed");
        	
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            DeleteDocumentWithData();
        }
    }
}
