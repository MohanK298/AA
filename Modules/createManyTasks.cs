/*
 * Created by Ranorex
 * User: kumar
 * Date: 4/21/2020
 * Time: 1:37 PM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;
using SmokeTest.Modules.Utilities;
using SmokeTest.Repositories;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of createManyTasks.
    /// </summary>
    [TestModule("74631AB9-6B1B-4EC6-80D1-106028F83737", ModuleType.UserCode, 1)]
    public class createManyTasks : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public createManyTasks()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        Task task=Task.Instance;

        
        
        
        public void CreateManyTasksData()
        {
        	//Open Task module and create a task
        	task.MainForm.Self.Activate();
        	task.MainForm.btnTasks.Click();
        	
        	for (int value = 000; value < 20; value++)
        	{
        	
        		task.MainForm.Self.Activate();
        		task.MainForm.btnNewTask.Click();
        	
	        	//Add data to task
	        	task.EventDetailForm.MenubarFillPanel.txtTaskTitle.PressKeys(value+"-Task Created on "+ System.DateTime.Now.ToString());
	        	task.EventDetailForm.MenubarFillPanel.txtStartDate.PressKeys(System.DateTime.Now.AddDays(value).ToShortDateString());
	        	task.EventDetailForm.MenubarFillPanel.txtDeadline.PressKeys(System.DateTime.Now.AddDays(value+1).ToShortDateString());
	        	//Add file to task
	        	task.EventDetailForm.MenubarFillPanel.btnAddFile.Click();
	        	task.FileSelectForm.listFirstFoundFile.DoubleClick();
	        	        	
	        	//Save task
	        	task.EventDetailForm.MenubarFillPanel.btnOK.Click();
	        	
	        	//Verify if the task is added
	        	//task.MainForm.listFirstTask.DoubleClick();
	//        	task.MainForm.listSecondTask.DoubleClick();
	//        	Report.Success("Create Task passed" + "Task Title: " + taskTitle + time);
	//        	Delay.Seconds(2);
	//        	task.EventDetailForm.MenubarFillPanel.btnOK.Click();
        }
        
    }
        
        
        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            CreateManyTasksData();
        }
    }
}
