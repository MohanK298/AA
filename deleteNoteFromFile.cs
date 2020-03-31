/*
 * Created by Ranorex
 * User: Kumar
 * Date: 2019-10-10
 * Time: 1:07 PM
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
    /// Description of deleteNoteFromFile.
    /// </summary>
    [TestModule("51667991-2F83-4A73-A830-7748C7D473C9", ModuleType.UserCode, 1)]
    public class deleteNoteFromFile : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        Note note = Note.Instance;
        Files file = Files.Instance;
        Common cmn=new Common();
        public deleteNoteFromFile()
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
        public void DeleteNoteFromFile()
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
        	cmn.VerifyDataExistsInTable(note.MainForm.NotesItemFolder.tblNotes,data,"Notes Table");
       		
        	
        	Delay.Seconds(3);
        	file.MainForm.btnFiles.Click();
        	file.MainForm.FilesIndexForm.listFirstFile.DoubleClick();
        	file.FileDetailForm.Notes.Click();
        	file.FileDetailForm.MyNotes.Click();
        	cmn.VerifyDataExistsInTable(file.FileDetailForm.tblFileDetailsBrad,data,"File Details Table");
        	cmn.SelectItemFromTableSingleClick(file.FileDetailForm.tblFileDetailsBrad,data,"File Details Table");
        	file.FileDetailForm.btnDelete.Click();
        	file.PromptForm.ButtonYes.Click();
        	cmn.VerifyDataNotExistsInTable(file.FileDetailForm.tblFileDetailsBrad,data,"File Details Table");
        	file.FileDetailForm.btnSaveClose.Click();
        
        }
       
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            DeleteNoteFromFile();
            cmn.ClosePrompt();
        }
    }
}
