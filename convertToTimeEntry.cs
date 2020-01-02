/*
 * Created by Ranorex
 * User: Kumar
 * Date: 2019-10-09
 * Time: 3:25 PM
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
    /// Description of convertToTimeEntry.
    /// </summary>
    [TestModule("365C594C-9E3F-4817-97A7-415289FB464E", ModuleType.UserCode, 1)]
    public class convertToTimeEntry : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        Note note=Note.Instance;
        TimeSheets ts=TimeSheets.Instance;
        Common cmn=new Common();
        public convertToTimeEntry()
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
        	
        }
        public void ValidatePromptExists()
        {
        	if(note.PromptForm.SelfInfo.Exists())
        	{
        		note.PromptForm.btnNo.Click();
        		Report.Info("Time Entry Exists and combined.");
        	}
        }
   
        public void ConvertTimeEntry()
        {
        	CreateNote();
        	cmn.SelectItemFromTableDblClick(note.MainForm.NotesItemFolder.tblNotes,data,"Notes Table");
        	cmn.SelectItemDropdown(note.NoteDetail.MenubarFillPanel.cmbboxConvertTo,"Time Entry","Convert To");
        	note.NoteDetail.MenubarFillPanel.btnConvert.Click();
        	Delay.Seconds(3);
        	note.TimeEntryDetailsForm.MenubarFillPanel.btnOK.Click();
        	ValidatePromptExists();
        	ValidateInTimeEntryModuke();
        }
        public void ValidateInTimeEntryModuke()
        {
        	Delay.Seconds(3);
        	ts.MainForm.Self.Activate();
        	ts.MainForm.btnTimeSheets.Click();
        	Delay.Seconds(3);
        	cmn.VerifyDataExistsInTable(ts.MainForm.tblTimeSheet,data,"Time Entry Table");
        }
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            ConvertTimeEntry();
            Common.ClosePrompt();
        }
    }
}
