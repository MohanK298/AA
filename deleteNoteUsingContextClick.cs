/*
 * Created by Ranorex
 * User: Kumar
 * Date: 2019-10-09
 * Time: 1:29 PM
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
    /// Description of deleteNoteUsingContextClick.
    /// </summary>
    [TestModule("CAAC4D69-C8F9-4648-AE07-251CF0792EE9", ModuleType.UserCode, 1)]
    public class deleteNoteUsingContextClick : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        Note note=Note.Instance;
        Common cmn=new Common();
        public deleteNoteUsingContextClick()
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
        public void createNote()
        {
        	note.MainForm.Self.Activate();
        	note.MainForm.btnNotes.Click();
        	note.MainForm.NotesItemFolder.txtNewNote.Click();
        	note.MainForm.NotesItemFolder.txtNewNote.PressKeys(data);
        	note.MainForm.NotesItemFolder.btnSave.Click();
        	note.MainForm.selectToday.Click();
        }  

           public void DeleteNote()
           {
           	createNote();
           	cmn.OpenContextMenuItemFromTable(note.MainForm.NotesItemFolder.tblNotes,data,"Notes Table");
           	DeletePrompt();
           	Delay.Seconds(2);
           	cmn.VerifyDataNotExistsInTable(note.MainForm.NotesItemFolder.tblNotes,data,"Notes Table");
           	
           }
           public void DeletePrompt()
           {
           	note.contextMenu.Delete.Click();
           	note.PromptForm.btnYes.Click();
           	Report.Success(String.Format("Note \"{0}\" deleted.",data));
           }
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            DeleteNote();
        }
    }
}
