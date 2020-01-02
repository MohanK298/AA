/*
 * Created by Ranorex
 * User: Kumar
 * Date: 2019-10-09
 * Time: 10:24 AM
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
    /// Description of noteCreationFileBradValidationTimeEntryCreation.
    /// </summary>
    [TestModule("C9F6287E-5780-4FCD-AA10-0ABFFC68ADF3", ModuleType.UserCode, 1)]
    public class noteCreationFileBradValidationTimeEntryCreation : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        
        Note note = Note.Instance;
        Files file = Files.Instance;
        Common cmn=new Common();
        public noteCreationFileBradValidationTimeEntryCreation()
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
        public void CreateStickyNote()
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
        	
        	
        	//Verify if note is created
        	note.MainForm.selectToday.Click();
        	Delay.Seconds(3);
        	cmn.VerifyDataExistsInTable(note.MainForm.NotesItemFolder.tblNotes,data,"Notes Detail Table");
       		
        	
        	Delay.Seconds(3);
        	file.MainForm.btnFiles.Click();
        	Delay.Seconds(2);
        	cmn.SelectItemDropdown(file.MainForm.cmbbxFileStatus,"All","File Status");
        	Delay.Seconds(1);
        	file.MainForm.FilesIndexForm.listFirstFile.DoubleClick();
        	file.FileDetailForm.Notes.Click();
        	file.FileDetailForm.MyNotes.Click();
        	cmn.VerifyDataExistsInTable(file.FileDetailForm.tblFileDetailsBrad,data,"File Detail Table");
        	cmn.SelectItemFromTableDblClick(file.FileDetailForm.tblFileDetailsBrad,data,"File Detail Table");
        	
        	note.NoteDetail.MenubarFillPanel.btnDoTimeEntry.Click();
        	note.TimeEntryDetailsForm.MenubarFillPanel.btnOK.Click();
        	ValidatePromptExists();
        	note.NoteDetail.MenubarFillPanel.btnOK.Click();
        	
        	file.FileDetailForm.TimeSpent.Click();
        	file.FileDetailForm.MyTime.Click();
        	cmn.VerifyDataExistsInTable(file.FileDetailForm.tblFileDetailsBrad,data,"My Time Table");
        	
        	file.FileDetailForm.btnSaveClose.Click();
        
        }
        
        public void ValidatePromptExists()
        {
        	if(note.PromptForm.SelfInfo.Exists())
        	{
        		note.PromptForm.btnNo.Click();
        		Report.Info("Time Entry Exists and combined.");
        	}
        }
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            CreateStickyNote();
            Common.ClosePrompt();
        }
    }
}
