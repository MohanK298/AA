﻿/*
 * Created by Ranorex
 * User: kumar
 * Date: 4/13/2020
 * Time: 7:00 PM
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
using SmokeTest.Modules;
using SmokeTest.Repositories;
using SmokeTest.Modules.Premium;
using SmokeTest.Modules.Utilities;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of advanceConflictCheck.
    /// </summary>
    [TestModule("5296F725-CA15-46A2-91C7-436AFFD94EB5", ModuleType.UserCode, 1)]
    public class advanceConflictCheck : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public advanceConflictCheck()
        {
            // Do not delete - a parameterless constructor is required!
        }

        Files files=Files.Instance;
        Common cmn=new Common();
        
        private void advanceConflictCheckValidate()
        {
        
			string search="Personal";
			int searchCount=0;
        	files.MainForm.Self.Activate();
        	files.MainForm.btnFiles1.Click();
        	
        	files.MainForm.Actions.Click();
        	Delay.Seconds(1);
        	files.MainForm.CheckConflicts.Click();
        	Delay.Seconds(1);
        
        	files.ConflictCheckForm.SelfInfo.WaitForExists(3000);
        	Validate.Exists(files.ConflictCheckForm.SelfInfo,"Conflict Check Form are displayed successfully");
        	
        	files.ConflictCheckForm.Search1.rdoAdvancedSearch.Select();
        	
        	files.ConflictCheckForm.PnlBase.txtAdvanceConflictSearch.TextValue=search;
        	Delay.Seconds(1);
        	
        	files.ConflictCheckForm.PnlBase.ContactFullName.Check();
        	files.ConflictCheckForm.PnlBase.ContactCompanyName.Check();
        	files.ConflictCheckForm.PnlBase.ContactStreetAddress.Check();
        	files.ConflictCheckForm.PnlBase.ContactMainNote.Check();
        	files.ConflictCheckForm.PnlBase.ContactCustomTextFields.Check();
        	files.ConflictCheckForm.PnlBase.ShowContactRelationships.Check();
        	files.ConflictCheckForm.PnlBase.FileMainNote.Check();
        	files.ConflictCheckForm.PnlBase.FileName.Check();
        	files.ConflictCheckForm.PnlBase.FileStatus.Check();
        	files.ConflictCheckForm.PnlBase.FileSummary.Check();
        	files.ConflictCheckForm.PnlBase.FileCustomTextFields.Check();
        	files.ConflictCheckForm.PnlBase.NoteRecords.Check();
        	files.ConflictCheckForm.PnlBase.EventTitleAndNotes.Check();
        	files.ConflictCheckForm.PnlBase.DocumentTitleAndSummary.Check();
        	files.ConflictCheckForm.PnlBase.TimeEntryDescriptions.Check();
        	files.ConflictCheckForm.PnlBase.CommunicationsNotesMessage.Check();
        	files.ConflictCheckForm.PnlBase.CommunicationsToFrom.Check();
        	
        	files.ConflictCheckForm.Toolbar1.CheckNow.Click();
        	files.ConflictCheckResult.SelfInfo.WaitForExists(3000);
        	Validate.Exists(files.ConflictCheckResult.SelfInfo,"Conflict Check Results Form are displayed successfully");
        	
        	files.ConflictCheckResult.txtConflitSearchResultInfo.WaitForAttributeEqual(3000,"Text",search);
        	Report.Success(String.Format("{0} are shown as matching",files.ConflictCheckResult.txttitleBar.Text));
        	searchCount=cmn.GetTableRowCount(files.ConflictCheckResult.tblConflictSearchResults,"Conflict Check Results Table");
        	Report.Success(String.Format("{0} Rows are shown as Conflict Check Match",searchCount));
        	
        	files.ConflictCheckResult.Toolbar1.btnPrint.Click();
        	
        	files.ConflictCheckPrint.SelfInfo.WaitForExists(3000);
        	Validate.Exists(files.ConflictCheckPrint.SelfInfo,"Conflict Check Print Form are displayed successfully");
        	
        	files.ConflictCheckPrint.txtConflictSearchResultInfo.WaitForAttributeEqual(3000,"Text",search);
        	files.ConflictCheckPrint.Toolbar1.btnCancel.Click();
        	files.ConflictCheckResult.Toolbar1.btnClose.Click();
   	
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
            advanceConflictCheckValidate();
        }
    }
}
