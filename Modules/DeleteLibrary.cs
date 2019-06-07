/*
 * Created by Ranorex
 * User: Admin
 * Date: 8/4/2015
 * Time: 10:10 AM
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
    [TestModule("230B721D-A6D9-41A0-A61A-976BD4137FE7", ModuleType.UserCode, 1)]
    public class DeleteLibrary : ITestModule
    {
        //Repository Variable
        Library lib = Library.Instance;
        
        public DeleteLibrary()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void Perform(){
        	
        	/*
        	lib.MainForm.Panel1.listPage.Click();
        	Delay.Seconds(2);
        	lib.MainForm.Panel1.listPage.Click(System.Windows.Forms.MouseButtons.Right, "96;10");
        	lib.AmicusAttorneyXWin1.listDelete.Click();
        	lib.PromptForm.btnOK.Click();
        	Delay.Seconds(1);
        	lib.MainForm.Panel1.listSection.Click();
        	lib.MainForm.Panel1.listSection.Click(System.Windows.Forms.MouseButtons.Right, "25;7");
        	lib.AmicusAttorneyXWin1.listDelete.Click();
        	lib.PromptForm.btnOK.Click();
        	*/
        	
        	lib.MainForm.LibraryIndexForm.listSection.DoubleClick();
        	Delay.Seconds(2);
        	
        	lib.MainForm.Panel1.listPage.Click();
        	Delay.Seconds(2);
        	
        	lib.MainForm.Panel1.listPage.Click(System.Windows.Forms.MouseButtons.Right, "96;10");
        	lib.AmicusAttorneyXWin1.listDelete.Click();
        	Delay.Seconds(2);
        	
        	lib.PromptForm.btnOK.Click();
        	Delay.Seconds(2);
        	
        	lib.MainForm.LibraryIndexForm.listSection.Click();
        	lib.MainForm.LibraryIndexForm.listSection.Click(System.Windows.Forms.MouseButtons.Right, "25;7");
        	lib.AmicusAttorneyXWin1.listDelete.Click();
        	lib.PromptForm.btnOK.Click();
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
