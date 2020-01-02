/*
 * Created by Ranorex
 * User: Kumar
 * Date: 2019-10-08
 * Time: 2:50 PM
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

namespace SmokeTest
{
    /// <summary>
    /// Description of selectNoteValidateAssociatedButtons.
    /// </summary>
    [TestModule("3F0F8556-291D-4EEE-B977-CFC47B6CAD9A", ModuleType.UserCode, 1)]
    public class selectNoteValidateAssociatedButtons : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        
		Note note = Note.Instance;        
        
        public selectNoteValidateAssociatedButtons()
        {
            // Do not delete - a parameterless constructor is required!
        }

        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
		public void createNote()
        {
        	string data = "Test Data Added "+System.DateTime.Now.ToString();
        	note.MainForm.NotesItemFolder.txtNewNote.Click();
        	note.MainForm.NotesItemFolder.txtNewNote.PressKeys(data);
        	note.MainForm.NotesItemFolder.btnSave.Click();
        }    
		public void selectExistingNote()
		{
			note.MainForm.selectToday.Click();
        	note.MainForm.listNoteOne.DoubleClick();
		}
		public void validateAssociatedButtons()
		{
			Validate.Exists(note.NoteDetail.MenubarFillPanel.SelfInfo,"Note Detail exists as expected");
			//Validate File Association Button 
			note.NoteDetail.MenubarFillPanel.btnFiles.Click();
			Validate.Exists(note.FileSelectForm.SelfInfo,"File Select Form exists as expected");
			note.FileSelectForm.btnCancel.Click();
			
			//Validate People Association Button
			note.NoteDetail.MenubarFillPanel.btnPeople.Click();
			Validate.Exists(note.PeopleSelectForm.SelfInfo,"People Select Form exists as expected");
			note.PeopleSelectForm.btnCancel.Click();
			
			//Validate Event Association Button
			note.NoteDetail.MenubarFillPanel.btnEvents.Click();
			Validate.Exists(note.EventSelectForm.SelfInfo,"Event Select Form exists as expected");
			note.EventSelectForm.Toolbar1.Cancel.Click();
		
			
			//Validate Library Association Button
			
			note.NoteDetail.MenubarFillPanel.btnLibrary.Click();
			Validate.Exists(note.LibrarySelectForm.SelfInfo,"Library Select Form exists as expected");
			note.LibrarySelectForm.btnCancel.Click();
			
			//Validate Document Association Button
			
			note.NoteDetail.MenubarFillPanel.btnDocuments.Click();
			Validate.Exists(note.FileSelectForm.SelfInfo,"Document Select Form exists as expected");
			note.FileSelectForm.btnCancel.Click();
			
			note.NoteDetail.MenubarFillPanel.btnCancel.Click();
			
		}
		public void NavigateToNotesModule()
        {
       		note.MainForm.btnNotes.Click();
        }
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            NavigateToNotesModule();
            createNote();
            selectExistingNote();
            validateAssociatedButtons();
            SmokeTest.Modules.Utilities.Common.ClosePrompt();
            
        }
    }
}
