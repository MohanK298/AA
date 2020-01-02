/*
 * Created by Ranorex
 * User: hpatel
 * Date: 7/27/2015
 * Time: 4:04 PM
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

using SmokeTest.Repositories;
using SmokeTest.Modules;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of DeleteNote.
    /// </summary>
    [TestModule("93AB64C6-5442-468E-B11B-7AFE7F820943", ModuleType.UserCode, 1)]
    public class DeleteNote : ITestModule
    {
    	//Repository variable
    	Note note = Note.Instance;
    	
    	
    	string _editSticky = "";
    	[TestVariable("ED3F882E-F0BB-4885-8AB2-D785C69897FC")]
    	public string editSticky
    	{
    		get { return _editSticky; }
    		set { _editSticky = value; }
    	}
    	
        public DeleteNote()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        public void DeleteNoteFromList(){
        	//Open note to delete
        	note.MainForm.listNoteOne.DoubleClick();
        	
        	//Delete note
        	note.NoteDetail.MenubarFillPanel.btnDelete.Click();
        	note.PromptForm.btnOK.Click();
        	Report.Success("Delete Note passed");
        	
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            DeleteNoteFromList();
            Utilities.Common.ClosePrompt();
        }
    }
}
