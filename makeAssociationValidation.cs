/*
 * Created by Ranorex
 * User: Kumar
 * Date: 2019-10-08
 * Time: 4:44 PM
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
    /// Description of makeAssociationValidation.
    /// </summary>
    [TestModule("AF54E5FE-E07A-4A40-8E61-873C83DA518E", ModuleType.UserCode, 1)]
    public class makeAssociationValidation : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        	Note note = Note.Instance;  
        	Common cmn=new Common();
        public makeAssociationValidation()
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
        	note.MainForm.NotesItemFolder.txtNewNote.Click();
        	note.MainForm.NotesItemFolder.txtNewNote.PressKeys(data);
        	note.MainForm.NotesItemFolder.btnSave.Click();
        }   
        public void selectFile()
        {
        	note.MainForm.selectUnassociated.Click();
        	cmn.VerifyDataExistsInTable(note.MainForm.NotesItemFolder.tblNotes,data,"Notes Detail Table");
        	note.MainForm.panelLeft.iconFiles.Click();
        	note.FileSelectForm.fileListItemOne.DoubleClick();
        	note.MainForm.panelLeft.btnMakeAssociation.Click();
        	cmn.VerifyDataNotExistsInTable(note.MainForm.NotesItemFolder.tblNotes,data,"Notes Detail Table");
        }
        public void navigateToNotesModule()
        {
        	note.MainForm.Self.Activate();
       		note.MainForm.btnNotes.Click();
        }
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            navigateToNotesModule();
            createNote();
            selectFile();
        }
    }
}
