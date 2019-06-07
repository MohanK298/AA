/*
 * Created by Ranorex
 * User: hpatel
 * Date: 7/28/2015
 * Time: 9:36 AM
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
    [TestModule("D46ADF6E-82F2-4ABB-AA65-DF691675A923", ModuleType.UserCode, 1)]
    public class DeleteTask : ITestModule
    {
    	//Repository variable
    	Task task = Task.Instance;
    	
        public DeleteTask()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void DeleteTaskFromList(){
        	//Open Task
        	//task.MainForm.listFirstTask.DoubleClick();
        	task.MainForm.listSecondTask.DoubleClick();
        	
        	//Delete Task
        	task.EventDetailForm.MenubarFillPanel.btnDelete.Click();
        	task.PromptForm.btnYes.Click();
        	
        	Report.Success("Delete Task passed");
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            DeleteTaskFromList();
        }
    }
}
