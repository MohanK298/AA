/*
 * Created by Ranorex
 * User: Kumar
 * Date: 2019-10-09
 * Time: 3:09 PM
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
    /// Description of replyNotesValidation.
    /// </summary>
    [TestModule("352B74A1-47C0-4293-A18F-73DE09BB364A", ModuleType.UserCode, 1)]
    public class replyNotesValidation : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        Note note=Note.Instance;
        public replyNotesValidation()
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
        public void ReplyNote()
        {
        	string reply = "Reply Note";
        	note.StickyDetails.Self.Activate();
        	note.StickyDetails.btnReply.Click();
        	Delay.Seconds(2);
        	note.StickyDetails.txtNoteBox.PressKeys(reply);
        	note.StickyDetails.btnSend.Click();
        	Delay.Seconds(2);
        	note.StickyDetails.Self.Activate();
        	Validate.AttributeContains(note.StickyDetails.txtNotesInfo,"Text",reply);
        	Validate.AttributeContains(note.StickyDetails.txtNotesInfo,"Text",data);
        	
        	note.StickyDetails.btnClose.Click();
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            CreateNote();
            ReplyNote();
        }
    }
}
