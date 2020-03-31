/*
 * Created By Asish
 * User: Administrator
 * Date: 2018-02-01
 * Time: 3:53 PM
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
    /// Description of AddToDo.
    /// </summary>
    [TestModule("0F74561C-049C-4B01-B100-B9979C5EB9A3", ModuleType.UserCode, 1)]
    public class AddToDo : ITestModule
    {
        SmokeTest.Repositories.Files file = new SmokeTest.Repositories.Files();
        Common cmn=new Common();
        	
    	SmokeTest.Repositories.Calendar calendar = new SmokeTest.Repositories.Calendar();
    	
        public AddToDo()
        {
            // Do not delete - a parameterless constructor is required!
        }

   
        
        public void Action()
        {
        	file.MainForm.Self.Activate();
        	Delay.Seconds(2);
        	file.MainForm.FilesIndexForm.listFirstFile.DoubleClick();
        	Delay.Seconds(2);
        	file.FileDetailForm.Events.Click();
        	file.FileDetailForm.AllMyEvents.Click();
        	file.FileDetailForm.btnNew.Click();
        	Delay.Seconds(3);
        	
        	//Add data to create an appointment
        	calendar.EventDetailForm.PnlBase.SelectEvent.Click();
        	calendar.List1000.ToDo.Click();
        	calendar.EventDetailForm.PnlBase.txtAppointmentTitle.PressKeys("Test for Precedents ToDo");
        	
        	
        	//Save the appointment
        	calendar.EventDetailForm.btnOK.Click();
        	Delay.Seconds(5);
        	file.FileDetailForm.btnSaveClose.Click();
        	
        	file.MainForm.FilesIndexForm.listFirstFile.DoubleClick();
        	Delay.Seconds(2);
        	file.FileDetailForm.Events.Click();
        	file.FileDetailForm.AllMyEvents.Click();
        	//Validate.Attribute(file.FileDetailForm.TitleInfo, "Text", "Test for Precedents ToDo");
        	file.FileDetailForm.btnSaveClose.Click();
        }
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            Action();
            cmn.ClosePrompt();
        }
    }
}
