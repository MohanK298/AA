/*
 * Created by Ranorex
 * User: Kumar
 * Date: 2019-10-10
 * Time: 11:33 AM
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
    /// Description of convertToPhoneCallFromControlPanel.
    /// </summary>
    [TestModule("D01CCD96-97FD-4A24-BD5F-A4202960D1D0", ModuleType.UserCode, 1)]
    public class convertToPhoneCallFromControlPanel : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        Note note=Note.Instance;
        Communications phoneCall = Communications.Instance;
        Common cmn=new Common();
        public convertToPhoneCallFromControlPanel()
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
        	note.MainForm.selectToday.Click();
        	
        }
        public void ConvertToPhoneCall()
        {
        	CreateNote();
        	cmn.SelectItemFromTableSingleClick(note.MainForm.NotesItemFolder.tblNotes,data,"Notes Table");
        	cmn.SelectItemDropdown(note.MainForm.panelLeft.cmbboxConvertTo,"Phone Call","Convert To");
        	note.MainForm.panelLeft.btnConvert.Click();
        	Delay.Seconds(3);
        	note.PhoneDetailForm.MenubarFillPanel.btnOK.Click();
        	phoneCall.MainForm.btnCommunications.Click();
        	phoneCall.MainForm.btnShowAllFiles.Click();
        	cmn.VerifyDataExistsInTable(phoneCall.MainForm.tblCommunications,data,"Communications Table");
        }
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            ConvertToPhoneCall();
            Common.ClosePrompt();
        }
    }
}
