/*
 * Created By Asish
 * User: Administrator
 * Date: 2018-01-08
 * Time: 1:29 PM
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

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

using SmokeTest.Modules;
using SmokeTest.Repositories;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of CreateManyNotes.
    /// </summary>
    [TestModule("D755ECD2-7D36-4EAE-847C-4AA5215E0A34", ModuleType.UserCode, 1)]
    public class CreateManyNotes : ITestModule
    {
        //Repository variable
    	Note note = Note.Instance;
    	
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
        public CreateManyNotes()
        {
            // Do not delete - a parameterless constructor is required!
        }

         public void CreateStickyNote()
         {
        	//Create Many Notes
        	for (int value = 001; value <= 100; value++)
        	{
	         	//Open notes section and window
	        	note.MainForm.btnNotes.Click();
	        	note.MainForm.btnNewSticky.Click();
	        	
	        	//Fill data in notes
	        	note.PeopleSelectForm.listNameOne.DoubleClick();
	        	note.StickyDetails.btnAddFile.Click();
//	        	note.FileSelectForm.btnQuickFind.Click();
//	        	note.FindFilesForm.txtFindFile.PressKeys("Ranorex File " + String.Format("{0:000}", value));        	
//	        	note.FindFilesForm.btnOK.Click();
	        	note.FileSelectForm.fileListItemOne.DoubleClick();
	        	Delay.Seconds(2);
	        	note.StickyDetails.txtNoteBox.PressKeys(text);
	        	note.StickyDetails.btnSend.Click();
	        	Delay.Seconds(1);
	        	note.StickyDetails.btnClose.Click();
	        	
	        	
	        	//Verify if note is created
	        	note.MainForm.selectToday.Click();
	        	note.MainForm.listNoteOne.DoubleClick();
	        	Report.Success("Create Note passed");
	        	note.NoteDetail.MenubarFillPanel.btnCancel.Click();
        	}
        }
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            CreateStickyNote();
            
            Delay.Seconds(3);
        }
    }
}
