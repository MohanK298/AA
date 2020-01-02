/*
 * Created by Ranorex
 * User: kumar
 * Date: 10/31/2019
 * Time: 10:32 AM
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
using SmokeTest.Repositories;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using SmokeTest.Modules.Utilities;
namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of createAndDeleteToDo.
    /// </summary>
    [TestModule("C4D67E9D-E8DD-4652-BF78-0184C97FF14A", ModuleType.UserCode, 1)]
    public class createAndDeleteToDo : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        Calendar calendar=Calendar.Instance;
        Common cmn=new Common();
        public createAndDeleteToDo()
        {
            // Do not delete - a parameterless constructor is required!
        }

        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        
        static string rndData=System.DateTime.Now.ToString();
		string data=String.Format("Test ToDo Added {0}",rndData);
		
		private void SelectFirstFile()
       {
       	if(calendar.FileSelectForm.SelfInfo.Exists(3000))
       	{
       		calendar.FileSelectForm.listFirstFoundFile.DoubleClick();
       	}
       }
	   private void CloseFileSelectForm()
       {
       	if(calendar.FileSelectForm.SelfInfo.Exists(3000))
       	{
       		calendar.FileSelectForm.btnOK.Click();
       	}
       }
		 private void TimeEntryOverlapPrompt()
       {
       	if(calendar.PromptForm.SelfInfo.Exists(3000))
       	{
       		calendar.PromptForm.btnYes.Click();
       	}
       }
		private void CreatendDeleteToDo()
        {
			calendar.MainForm.Self.Activate();
        	calendar.MainForm.btnCalendar.Click();
        	calendar.MainForm.btnNewAppointment.Click();
        	Delay.Seconds(1);
        	calendar.EventDetailForm.PnlBase.txtAppointmentTitle.PressKeys(data);
        	cmn.SelectItemDropdown(calendar.EventDetailForm.PnlBase.SelectEvent,"To Do","Event Type Dropdown");
        	calendar.EventDetailForm.btnOK.Click();
        	Delay.Seconds(3);
        	calendar.MainForm.btnCalendar.Click();
        	calendar.MainForm.btnViewMenu.Click();
        	calendar.MainForm.menuListView.Click();
        	Delay.Seconds(3);
        	cmn.VerifyDataExistsInTable(calendar.MainForm.tblCalendar,data,"Calendar List");
        	cmn.SelectItemFromTableDblClick(calendar.MainForm.tblCalendar,data,"Calendar List");
        	
        	calendar.EventDetailForm.Toolbar1.btnDoTimeEntry.Click();
        	SelectFirstFile();
        	calendar.TimeEntryDetailsForm.Toolbar1.btnSaveNew.Click();
        	TimeEntryOverlapPrompt();
        	CloseFileSelectForm();
        	calendar.TimeEntryDetailsForm.Toolbar1.btnCancel.Click();
        	
        	calendar.EventDetailForm.btnDelete.Click();
        	calendar.PromptForm.btnYes.Click();
        	Delay.Seconds(2);
        	cmn.VerifyDataNotExistsInTable(calendar.MainForm.tblCalendar,data,"Calendar List");
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            CreatendDeleteToDo();
            Utilities.Common.ClosePrompt();
        }
    }
}
