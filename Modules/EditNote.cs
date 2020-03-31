/*
 * Created by Ranorex
 * User: hpatel
 * Date: 7/27/2015
 * Time: 3:42 PM
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

using SmokeTest.Repositories;
using SmokeTest.Modules;

namespace SmokeTest.Modules
{
    [TestModule("513370D5-C548-4140-AC8D-C4E7882B5954", ModuleType.UserCode, 1)]
    public class EditNote : ITestModule
    {
    	//Repository variable
    	Note note = Note.Instance;
    	Common cmn=new Common();
    	
    	string _editSticky = "";
    	[TestVariable("49C4F4C6-BD04-40D8-A46A-C08F2900A223")]
    	public string editSticky
    	{
    		get { return _editSticky; }
    		set { _editSticky = value; }
    	}
    	
    	string _time = "";
    	[TestVariable("7D2B01EB-0188-4A61-A6B2-DD6C43D29EB6")]
    	public string time
    	{
    		get { return _time; }
    		set { _time = value; }
    	}
    	
        public EditNote()
        {
            // Do not delete - a parameterless constructor is required!
        }

        public void EditNoteData(){
        	//Open note to edit
        	note.MainForm.listNoteOne.DoubleClick();
        	
        	//Edit note
        	note.NoteDetail.MenubarFillPanel.txtNoteBoxEdit.Click();
        	Keyboard.Press(System.Windows.Forms.Keys.A | System.Windows.Forms.Keys.Control, 30, Keyboard.DefaultKeyPressTime, 1, true);
            note.NoteDetail.MenubarFillPanel.txtNoteBoxEdit.PressKeys("{Back}");
            note.NoteDetail.MenubarFillPanel.txtNoteBoxEdit.PressKeys(editSticky);
            note.NoteDetail.MenubarFillPanel.btnOK.Click();
            
            //Verify if note has been edited
            note.MainForm.listNoteOne.DoubleClick();
            Report.Success("Edit Note passed");
            Delay.Seconds(2);
            note.NoteDetail.MenubarFillPanel.btnOK.Click();
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            EditNoteData();
            cmn.ClosePrompt();
        }
    }
}
