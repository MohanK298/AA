/*
 * Created by Ranorex
 * User: Kumar
 * Date: 2019-10-08
 * Time: 2:08 PM
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
using SmokeTest.Modules.Utilities;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest.Modules.Attorney_FileDetails
{
    /// <summary>
    /// Description of basicValidation.
    /// </summary>
    [TestModule("078E3302-FFDD-467B-9D40-945D43EA0AFA", ModuleType.UserCode, 1)]
    public class basicValidation : ITestModule
    {
    	
    	Note note = Note.Instance;
    	Common cmn=new Common();
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public basicValidation()
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
        public void saveButtonValidation()
        {
        	note.MainForm.NotesItemFolder.btnSave.Click();
        	Validate.Exists(note.PromptForm.pnlmessage);
        	note.PromptForm.btnOK.Click();
        }
        
        public void DetailsButtonValidation()
        {
        	
        	note.MainForm.NotesItemFolder.txtNewNote.PressKeys(data);
        	note.MainForm.NotesItemFolder.btnDetails.Click();
        	Validate.Exists(note.NoteDetail.MenubarFillPanel.btnOK);
        	Validate.Attribute(note.NoteDetail.MenubarFillPanel.txtNoteBoxEditInfo,"Text",data);
        	note.NoteDetail.MenubarFillPanel.btnCancel.Click();
        }
        
        public void clearButtonValidation()
        {
        	
        	note.MainForm.NotesItemFolder.txtNewNote.PressKeys(data);
        	Validate.Attribute(note.MainForm.NotesItemFolder.txtNewNoteInfo,"Text",data);
        	note.MainForm.NotesItemFolder.btnCancel.Click();
        	Validate.Attribute(note.MainForm.NotesItemFolder.txtNewNoteInfo,"Text","");
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
            saveButtonValidation();
            DetailsButtonValidation();
            clearButtonValidation();
            cmn.ClosePrompt();
            
        }
    }
}
