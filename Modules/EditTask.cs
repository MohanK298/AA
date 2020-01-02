/*
 * Created by Ranorex
 * User: hpatel
 * Date: 7/28/2015
 * Time: 9:32 AM
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
    [TestModule("921851AC-BD6C-4FF7-927F-7302CD67F4E0", ModuleType.UserCode, 1)]
    public class EditTask : ITestModule
    {
        Task task = Task.Instance;
        
        string _time = "";
        [TestVariable("753C10F0-404E-40C5-B1A6-3198814A31BC")]
        public string time
        {
        	get { return _time; }
        	set { _time = value; }
        }
        
        string _editTaskTitle = "";
        [TestVariable("C95549EA-0D5C-4D1E-873F-4CCC137986B5")]
        public string editTaskTitle
        {
        	get { return _editTaskTitle; }
        	set { _editTaskTitle = value; }
        }
        
        public EditTask()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void EditTaskData(){
        	//Open the task
        	//task.MainForm.listFirstTask.DoubleClick();
        	task.MainForm.listSecondTask.DoubleClick();
        	
        	//Edit the task
        	task.EventDetailForm.MenubarFillPanel.txtEditText.Click();        	
            Keyboard.PrepareFocus(task.EventDetailForm.MenubarFillPanel.txtEditText);
            Keyboard.Press(System.Windows.Forms.Keys.A | System.Windows.Forms.Keys.Control, 30, Keyboard.DefaultKeyPressTime, 1, true);
            task.EventDetailForm.MenubarFillPanel.txtEditText.PressKeys("{Back}");
            task.EventDetailForm.MenubarFillPanel.txtEditText.PressKeys(editTaskTitle + time);
        	
        	//Save the task
        	task.EventDetailForm.MenubarFillPanel.btnOK.Click();
        	
        	//Verify if the task is edited
        	//task.MainForm.listFirstTask.DoubleClick();
        	task.MainForm.listSecondTask.DoubleClick();
        	Report.Success("Edit Task passed" + "Task Title: " + editTaskTitle + time);
        	task.EventDetailForm.MenubarFillPanel.btnOK.Click();
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            EditTaskData();
            Utilities.Common.ClosePrompt();
        }
    }
}
