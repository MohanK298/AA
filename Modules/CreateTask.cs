/*
 * Created by Ranorex
 * User: hpatel
 * Date: 7/28/2015
 * Time: 9:15 AM
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
    /// Description of CreateTask.
    /// </summary>
    [TestModule("FE7E13FE-6EDF-41C2-8DF4-BDFE8AB25CB4", ModuleType.UserCode, 1)]
    public class CreateTask : ITestModule
    {
    	//Repository variable
    	Task task = Task.Instance;
        
    	
    	string _time = "";
    	[TestVariable("EAE0D9CB-258F-49BF-88FE-79E8D040685B")]
    	public string time
    	{
    		get { return _time; }
    		set { _time = value; }
    	}
    	
    	string _fileName = "";
    	[TestVariable("6D74E041-B41B-4876-82E6-FF655CCA92DA")]
    	public string fileName
    	{
    		get { return _fileName; }
    		set { _fileName = value; }
    	}
    	
    	string _taskTitle = "";
    	[TestVariable("81C6835E-8877-4916-A754-54BEDF32DA34")]
    	public string taskTitle
    	{
    		get { return _taskTitle; }
    		set { _taskTitle = value; }
    	}
    	
        public CreateTask()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void CreateTaskData(){
        	//Open Task module and create a task
        	task.MainForm.btnTasks.Click();
        	task.MainForm.btnNewTask.Click();
        	
        	//Add data to task
        	task.EventDetailForm.MenubarFillPanel.txtTaskTitle.PressKeys(taskTitle + time);
        	
        	//Add file to task
        	task.EventDetailForm.MenubarFillPanel.btnAddFile.Click();
        	task.FileSelectForm.btnQuickFind.Click();
        	task.FindFilesForm.txtFindFile.TextValue = fileName + time;
        	task.FindFilesForm.btnOK.Click();
        	task.FileSelectForm.listFirstFoundFile.DoubleClick();
        	
        	//Save task
        	task.EventDetailForm.MenubarFillPanel.btnOK.Click();
        	
        	//Verify if the task is added
        	//task.MainForm.listFirstTask.DoubleClick();
        	task.MainForm.listSecondTask.DoubleClick();
        	Report.Success("Create Task passed" + "Task Title: " + taskTitle + time);
        	Delay.Seconds(2);
        	task.EventDetailForm.MenubarFillPanel.btnOK.Click();
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
            
            CreateTaskData();
            Utilities.Common.ClosePrompt();
        }
    }
}
