/*
 * Created by Ranorex
 * User: kumar
 * Date: 3/12/2020
 * Time: 9:46 AM
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
using SmokeTest.Repositories.Premium;
using SmokeTest.Modules.Utilities;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of shareNotesBetweenFM.
    /// </summary>
    [TestModule("BF8B8482-A9D2-4CCE-9A81-8EBA45C66366", ModuleType.UserCode, 1)]
    public class shareNotesBetweenFM : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public shareNotesBetweenFM()
        {
            // Do not delete - a parameterless constructor is required!
        }
 		Common cmn=new Common();
 		Note note=Note.Instance;
 		string data = "Test Data Added for Notes "+System.DateTime.Now.ToString(); 
 		string curuser="";
        string user="";
 		private void noteSharedBetweenFM()
 		{
			
        	
        	
        	var datasource=Ranorex.DataSources.Get("LoginData");
        	datasource.Load();
        	curuser=datasource.Rows[0].Values[1].ToString();
        	user=datasource.Rows[1].Values[1].ToString();
        	cmn.switchUser(curuser);
 			note.MainForm.Self.Activate();
        	
        	//Open notes section and window
        	note.MainForm.btnNotes.Click();
        	note.MainForm.btnNewSticky.Click();
        	
        	//Fill data in notes
        	//note.PeopleSelectForm.listNameOne.DoubleClick();
        	
        	
        	
        	note.PeopleSelectForm.ComboBox.Click();
        	cmn.SelectItemDropdown(note.tblDpdwnList.Self,"All");
        	cmn.SelectItemFromTableSingleClick(note.PeopleSelectForm.Panel1.tbSelection,user,"People Selection Table");
        	note.PeopleSelectForm.btnAddToRight.Click();
        	cmn.SelectItemFromTableSingleClick(note.PeopleSelectForm.Panel1.tbSelection,curuser,"People Selection Table");
        	note.PeopleSelectForm.btnAddToRight.Click();
        	note.PeopleSelectForm.btnOK.Click();
        	
        	
        	note.StickyDetails.btnAddFile.Click();
        	note.FileSelectForm.fileListItemOne.DoubleClick();
        	Delay.Seconds(2);
        	
        	note.StickyDetails.txtNoteBox.PressKeys(data);
        	
        	note.StickyDetails.btnSend.Click();
        	Delay.Seconds(3);
        	
        	
        	note.StickyDetails.Self.Activate();
        	note.StickyDetails.btnClose.Click();
        	
        	
        	note.StickyDetails.Self.Activate();
        	note.StickyDetails.btnClose.Click();
        	
        	
        	note.MainForm.selectToday.Click();
        	Delay.Seconds(3);
        	cmn.VerifyDataExistsInTable(note.MainForm.NotesItemFolder.tblNotes,data,"Notes Detail Table");
        	
        	cmn.switchUser(user);
        	
        	
        	note.MainForm.Self.Activate();
        	
        	//Open notes section and window
        	note.MainForm.btnNotes.Click();
        	note.MainForm.selectToday.Click();
        	Delay.Seconds(3);
        	cmn.VerifyDataExistsInTable(note.MainForm.NotesItemFolder.tblNotes,data,"Notes Detail Table");
        	
 		}
 		
 		
 		
 		
 		
        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            noteSharedBetweenFM();
        }
    }
}
