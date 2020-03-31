/*
 * Created by Ranorex
 * User: Kumar
 * Date: 2019-10-09
 * Time: 2:18 PM
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
    /// Description of forwardNotesValidation.
    /// </summary>
    [TestModule("1A287EE6-CF30-4FD4-8B65-15A4D2333AAE", ModuleType.UserCode, 1)]
    public class forwardNotesValidation : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        Note note=Note.Instance;
        Common cmn=new Common();
        public forwardNotesValidation()
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
        	
        	//note.StickyDetails.btnClose.Click();
        }
        public void ForwardNote()
        {
        	string fwd = "Forward Note";
        	note.StickyDetails.Self.Activate();
        	note.StickyDetails.btnForward.Click();
        	note.PeopleSelectForm.listNameOne.DoubleClick();
        	Delay.Seconds(2);
        	//note.StickyDetails.txtNoteBox.Click();
        	note.StickyDetails.txtNoteBox.PressKeys(fwd);
        	note.StickyDetails.btnSend.Click();
        	Delay.Seconds(2);
        	note.StickyDetails.Self.Activate();
        	Validate.AttributeContains(note.StickyDetails.txtNotesInfo,"Text",fwd);
        	Validate.AttributeContains(note.StickyDetails.txtNotesInfo,"Text",data);
        	
        	note.StickyDetails.btnClose.Click();
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            CreateNote();
            ForwardNote();
            cmn.ClosePrompt();
        }
    }
}
