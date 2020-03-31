/*
 * Created by Ranorex
 * User: hpatel
 * Date: 7/27/2015
 * Time: 2:02 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;
using SmokeTest.Modules.Utilities;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

using SmokeTest.Modules;
using SmokeTest.Repositories;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of CreateNote.
    /// </summary>
    [TestModule("1F75DD7D-A10F-48D2-B78D-D41EC9B9CC69", ModuleType.UserCode, 1)]
    public class CreateNote : ITestModule
    {
    	//Repository variable
    	Note note = Note.Instance;
    	Common cmn=new Common();
    	CreateAppointment appointment = new CreateAppointment();
    	
    	string _text = "";
    	[TestVariable("6040AC8C-D3EB-465A-8B90-29CC8F188EB4")]
    	public string text
    	{
    		get { return _text; }
    		set { _text = value; }
    	}
    	
    	string _time = "";
    	[TestVariable("380FDA56-AD9F-40B9-BD35-B328A43A6C45")]
    	public string time
    	{
    		get { return _time; }
    		set { _time = value; }
    	}
    	
    	string _fileName = "";
    	[TestVariable("A0A1BEC7-9371-4AA6-A1F1-282B78E475BF")]
    	public string fileName
    	{
    		get { return _fileName; }
    		set { _fileName = value; }
    	}
    	
        public CreateNote()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void CreateStickyNote(){
        	note.MainForm.Self.Activate();
        	AfterFirstLogin.CloseAllDetails();
        	
        	//Open notes section and window
        	note.MainForm.btnNotes.Click();
        	note.MainForm.btnNewSticky.Click();
        	
        	//Fill data in notes
        	note.PeopleSelectForm.listNameOne.DoubleClick();
        	note.StickyDetails.btnAddFile.Click();
        	note.FileSelectForm.btnQuickFind.Click();
        	note.FindFilesForm.txtFindFile.TextValue = fileName + time;        	
        	note.FindFilesForm.btnOK.Click();
        	note.FileSelectForm.fileListItemOne.DoubleClick();
        	Delay.Seconds(2);
        	note.StickyDetails.txtNoteBox.PressKeys(text);
        	note.StickyDetails.btnSend.Click();
        	Delay.Seconds(3);
        	note.StickyDetails.Self.Activate();
        	note.StickyDetails.btnClose.Click();
        	
        	
        	//Verify if note is created
        	note.MainForm.selectToday.Click();
        	note.MainForm.listNoteOne.DoubleClick();
        	Report.Success("Create Note passed");
        	note.NoteDetail.MenubarFillPanel.btnCancel.Click();
        }
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            CreateStickyNote();
            
            Delay.Seconds(3);
            cmn.ClosePrompt();
        }
    }
}
