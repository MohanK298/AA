/*
 * Created by Ranorex
 * User: kumar
 * Date: 1/13/2020
 * Time: 3:41 PM
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

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of timeAssistant_RightClickOptions.
    /// </summary>
    [TestModule("7831DF50-10F4-434F-BA8D-EA6C90789454", ModuleType.UserCode, 1)]
    public class timeAssistant_RightClickOptions : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public timeAssistant_RightClickOptions()
        {
            // Do not delete - a parameterless constructor is required!
        }
		TimeSheets ts=TimeSheets.Instance;
        Common cmn=new Common();
        Note note = Note.Instance;
        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        static string rndData=System.DateTime.Now.ToString("M/dd/yyyy");
		string data=String.Format("Test Data Added {0}",rndData);
        
        private void timeassist()
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
        	
        	//TimeSheets - Time Assistant
        	
        	ts.MainForm.Self.Activate();
        	Delay.Seconds(1);
        	ts.MainForm.btnTimeSheets.Click();
        	Delay.Seconds(5);
        	ts.MainForm.Toolbar.btnTimeEntryAssistant.Click();
        	ts.TimeEntryAssistantForm.SelfInfo.WaitForExists(3000);
        	ts.TimeEntryAssistantForm.PnlBase.cbNotes.Uncheck();
        	Delay.Seconds(1);
        	cmn.OpenContextMenuItemFromTable(ts.TimeEntryAssistantForm.PnlBase.tbTimeEntryAssistant,data,"Time Entry Assistant Table");
        	Delay.Seconds(1);
        	Validate.Exists(ts.contextmenu.TimeEntryInfo,"Time Entry Option Exists in ContextClick Option");
        	Validate.Exists(ts.contextmenu.TimeSaverInfo,"Time Saver Option Exists in ContextClick Option");
        	Validate.Exists(ts.contextmenu.OpenItemInfo,"Open Item Option Exists in ContextClick Option");
        	Validate.Exists(ts.contextmenu.IgnoreItemInfo,"Ignore Item Option Exists in ContextClick Option");
        	Validate.Exists(ts.contextmenu.AddToFileInfo,"Add to File Option Exists in ContextClick Option");
        	Validate.Exists(ts.contextmenu.PrintInfo,"Print Option Exists in ContextClick Option");
        	ts.TimeEntryAssistantForm.Toolbar1.btnClose.Click();

        	
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            timeassist();
            Utilities.Common.ClosePrompt();
        }
    }
}
