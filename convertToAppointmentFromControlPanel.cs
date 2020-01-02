/*
 * Created by Ranorex
 * User: Kumar
 * Date: 2019-10-10
 * Time: 12:34 PM
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
namespace SmokeTest
{
    /// <summary>
    /// Description of convertToAppointmentFromControlPanel.
    /// </summary>
    [TestModule("59BC1F30-EB6B-473F-87B7-06ECC8655817", ModuleType.UserCode, 1)]
    public class convertToAppointmentFromControlPanel : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        Note note=Note.Instance;
        Calendar calendar=Calendar.Instance;
        Common cmn=new Common();
        public convertToAppointmentFromControlPanel()
        {
            // Do not delete - a parameterless constructor is required!
        }

        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        string data = "Test Data Added "+System.DateTime.Now.ToString();       
        public void CreateNote()
        {
			note.MainForm.Self.Activate();
        	
        	//Open notes section and window
        	note.MainForm.btnNotes.Click();
        	note.MainForm.btnNewSticky.Click();
        	
        	//Fill data in notes
        	note.PeopleSelectForm.listNameOne.DoubleClick();
        	note.StickyDetails.btnAddFile.Click();
        	note.FileSelectForm.fileListItemOne.DoubleClick();
        	Delay.Seconds(2);
        	note.StickyDetails.txtNoteBox.PressKeys(data);
        	note.StickyDetails.btnSend.Click();
        	Delay.Seconds(3);
        	note.StickyDetails.Self.Activate();
        	note.StickyDetails.btnClose.Click();
        	note.MainForm.selectToday.Click();
        	
        }
        public void ValidateEventRemainderPopup()
        {
        	if(note.EventReminderForm.SelfInfo.Exists(70000))
        	{
        		note.EventReminderForm.btnIllBeThere.Click();
        	}
        }
       public void AppointmentOverlapPrompt()
       {
       	if(note.AppointmentOverlapDialog.SelfInfo.Exists(3000))
       	{
       		note.AppointmentOverlapDialog.ButtonOK.Click();
       	}
       }
        public void ConvertToAppointment()
        {
        	CreateNote();
        	cmn.SelectItemFromTableSingleClick(note.MainForm.NotesItemFolder.tblNotes,data,"Notes Table");
        	cmn.SelectItemDropdown(note.MainForm.panelLeft.cmbboxConvertTo,"Appointment","ConvertTo");
        	note.MainForm.panelLeft.btnConvert.Click();
        	Delay.Seconds(3);
        	note.EventDetailForm.PnlBase.txtStartTime.PressKeys(System.DateTime.Now.ToShortTimeString());
        	note.EventDetailForm.PnlBase.txtEndTime.PressKeys(System.DateTime.Now.AddHours(1).ToShortTimeString());
        	note.EventDetailForm.Toolbar.btnOK.Click();
        	Delay.Seconds(3);
        	AppointmentOverlapPrompt();
        	ValidateEventRemainderPopup();
        	calendar.MainForm.btnCalendar.Click();
        	calendar.MainForm.btnViewMenu.Click();
        	calendar.MainForm.menuListView.Click();
        	Delay.Seconds(3);
        	cmn.VerifyDataExistsInTable(calendar.MainForm.tblCalendar,data,"Calendar List");
        }
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            ConvertToAppointment();
            Common.ClosePrompt();
        }
    }
}
