/*
 * Created by Ranorex
 * User: Kumar
 * Date: 2019-10-10
 * Time: 1:49 PM
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
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using SmokeTest.Modules.Utilities;
namespace SmokeTest
{
    /// <summary>
    /// Description of changePrefIncludeChronology.
    /// </summary>
    [TestModule("4397348B-1E9F-4326-B0FB-0CBD4A73DF59", ModuleType.UserCode, 1)]
    public class changePrefIncludeChronology : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        Note note=Note.Instance;
        Preferences pref=Preferences.Instance;
        Files file=Files.Instance;
        Common cmn=new Common();
        string data = "Test Data Added "+System.DateTime.Now.ToString(); 
        
        public changePrefIncludeChronology()
        {
            // Do not delete - a parameterless constructor is required!
        }

        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        
        public void CreateStickyNote()
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
        }
		
        public void ValidateNotesInChronology()
        {
        	file.chrontxt=data;   
	       	Delay.Seconds(3);
        	file.MainForm.btnFiles.Click();
        	file.MainForm.FilesIndexForm.listFirstFile.DoubleClick();
        	file.FileDetailForm.Notes.Click();
        	file.FileDetailForm.MyNotes.Click();
        	cmn.VerifyDataExistsInTable(file.FileDetailForm.tblFileDetailsBrad,data,"File Details Table");
        	file.FileDetailForm.Chronology.Click();
        	Delay.Seconds(15);
        	//file.FileDetailForm.LblLoadingInfo.WaitForAttributeContains(15000,"Visible","False");
        	
        	//string path=String.Format(".//text[@accessiblevalue='{0}']",data);
        	//if(found == true)    file.FileDetailForm.containerChronology.TryFindSingle(new RxPath(path),10000,out txtValue)
        	
        	if(file.FileDetailForm.chronologyTextInfo.Exists())
        	{
        		Report.Success(String.Format("Value \"{0}\" Present as expected",data));
        	}
        	else
        	{
        		Report.Failure(String.Format("Value \"{0}\" not present",data));
        	}
        	file.FileDetailForm.btnSaveClose.Click();
        }
		        
        public void ChangePrefIncludeChronology(bool cbValue)
        {
        	pref.MainForm.Self.Activate();
        	pref.MainForm.OfficeModule.Click();
        	Delay.Seconds(3);
        	pref.MainForm.Preferences.Click();
        	Delay.Seconds(3);
        	pref.MainForm.PreferencesForm.General.Click();
        	if(cbValue == true)
        	{
        		pref.GeneralPreferencesForm.cbIncludeDateTimeNotes.Check();
        		pref.GeneralPreferencesForm.cbIncludeNoteChronology.Check();
        	}
        	else
        	{
        		pref.GeneralPreferencesForm.cbIncludeDateTimeNotes.Uncheck();
        		pref.GeneralPreferencesForm.cbIncludeNoteChronology.Uncheck();
        	}
        	pref.GeneralPreferencesForm.ButtonOK.Click();
        }
        
        
        
  
        public void ChangePrefandValidateNoteChronology()
        {
        	ChangePrefIncludeChronology(true);
        	CreateStickyNote();
        	ValidateNotesInChronology();
        	ChangePrefIncludeChronology(false);
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            ChangePrefandValidateNoteChronology();
        }
    }
}
