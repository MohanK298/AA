/*
 * Created by Ranorex
 * User: kumar
 * Date: 1/14/2020
 * Time: 9:20 AM
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
    /// Description of create_TE_ValidateDateRange_ExcludeOptions_TAssist.
    /// </summary>
    [TestModule("9DA1D9CD-18F3-4A3C-84FF-267BC14E169D", ModuleType.UserCode, 1)]
    public class create_TE_ValidateDateRange_ExcludeOptions_TAssist : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public create_TE_ValidateDateRange_ExcludeOptions_TAssist()
        {
            // Do not delete - a parameterless constructor is required!
        }
		TimeSheets ts=TimeSheets.Instance;
        Common cmn=new Common();
        Calendar calendar=Calendar.Instance;
        Communications phoneCall = Communications.Instance;
        Documents doc=Documents.Instance;
        Note note = Note.Instance;
        
        static string rndData=System.DateTime.Now.ToString("M/dd/yyyy");
		string data=String.Format("Test Data Added {0}",rndData);
		string curdata=String.Format("Test Data Added for Exclusion of Items {0}",rndData);
		int[] date_since =new int[]{1,3,7,14,31,60};
		
        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        
        public void ValidateEventRemainderPopup()
        {
        	if(calendar.EventReminderForm.SelfInfo.Exists(70000))
        	{
        		calendar.EventReminderForm.btnIllBeThere.Click();
        	}
        }
       public void AppointmentOverlapPrompt()
       {
       	if(calendar.AppointmentOverlapDialog.SelfInfo.Exists(3000))
       	{
       		calendar.AppointmentOverlapDialog.btnOk.Click();
       	}
       }
        
        
        private void create_Appointment()
        {

			
			for(int i=0;i<date_since.Length;i++)
			{
				calendar.MainForm.Self.Activate();
	        	calendar.MainForm.btnCalendar.Click();
	        	calendar.MainForm.btnNewAppointment.Click();
	        	Delay.Seconds(1);
	        	calendar.EventDetailForm.PnlBase.txtAppointmentTitle.PressKeys(data);
	        	calendar.EventDetailForm.PnlBase.txtStartDate.PressKeys(System.DateTime.Now.AddDays(-date_since[i]).ToShortDateString());
	        	calendar.EventDetailForm.PnlBase.txtStartTime.PressKeys(System.DateTime.Now.ToShortTimeString());
	        	calendar.EventDetailForm.PnlBase.txtEndTime.PressKeys(System.DateTime.Now.AddHours(1).ToShortTimeString());
	        	calendar.EventDetailForm.PnlBase.FilesAndPeople.Click();
	        	calendar.EventDetailForm.PnlBase.btnAddFile.Click();
	        	calendar.FileSelectForm.listFirstFoundFile.DoubleClick();
	        	calendar.EventDetailForm.btnOK.Click();
	        	AppointmentOverlapPrompt();
	        	if(i==0)
	        	{ValidateEventRemainderPopup();}
	        	Report.Success(String.Format("Appoitnment Created for {0}",data));
			}
        }
			private void timeentryAssist()
			{
			int initial_count=0;		
        	ts.MainForm.Self.Activate();
        	Delay.Seconds(1);
        	ts.MainForm.btnTimeSheets.Click();
        	Delay.Seconds(5);
        	ts.MainForm.Toolbar.btnTimeEntryAssistant.Click();
        	ts.TimeEntryAssistantForm.SelfInfo.WaitForExists(3000);
        	initial_count=cmn.GetTableRowCount(ts.TimeEntryAssistantForm.PnlBase.tbTimeEntryAssistant,"Time Entry Assistant Table");
        	Report.Success(String.Format("Time Entry Assistant has {0} records since {1} days",initial_count,date_since[0]));
        	for(int i=1;i<date_since.Length;i++)
        	{
        		ts.TimeEntryAssistantForm.PnlBase.cmbbxDay.Click();
        		cmn.SelectItemDropdown(ts.DropDownForm.tblDropdown,date_since[i]+" days");
        		Delay.Seconds(2);
        		ts.TimeEntryAssistantForm.PnlBase.tbTimeEntryAssistantInfo.WaitForExists(3000);
        		if(cmn.GetTableRowCount(ts.TimeEntryAssistantForm.PnlBase.tbTimeEntryAssistant,"Time Entry Assistant Table")>initial_count)
        		{
        			initial_count=cmn.GetTableRowCount(ts.TimeEntryAssistantForm.PnlBase.tbTimeEntryAssistant,"Time Entry Assistant Table");
        			Report.Success(String.Format("Time Entry Assistant has {0} records since {1} days",initial_count,date_since[i]));
        		}
        	}
        	
        		ts.TimeEntryAssistantForm.PnlBase.cmbbxDay.Click();
        		cmn.SelectItemDropdown(ts.DropDownForm.tblDropdown,"All");
        		Delay.Seconds(2);
        		initial_count=cmn.GetTableRowCount(ts.TimeEntryAssistantForm.PnlBase.tbTimeEntryAssistant,"Time Entry Assistant Table");
        		Report.Success(String.Format("Time Entry Assistant has {0} records for All day entries",initial_count));
        	
        	ts.TimeEntryAssistantForm.Toolbar1.btnClose.Click();
        	
        	
			}
        	
			private void createdata()
			{
				
				string localFileName;
				string fileName=String.Format("RanorexTestFile {0}",rndData);
				//Create appointment with no file
				calendar.MainForm.Self.Activate();
	        	calendar.MainForm.btnCalendar.Click();
	        	calendar.MainForm.btnNewAppointment.Click();
	        	Delay.Seconds(1);
	        	calendar.EventDetailForm.PnlBase.txtAppointmentTitle.PressKeys(curdata);
	        	calendar.EventDetailForm.PnlBase.txtStartDate.PressKeys(System.DateTime.Now.ToShortDateString());
	        	calendar.EventDetailForm.PnlBase.txtStartTime.PressKeys(System.DateTime.Now.ToShortTimeString());
	        	calendar.EventDetailForm.PnlBase.txtEndTime.PressKeys(System.DateTime.Now.AddHours(1).ToShortTimeString());
				calendar.EventDetailForm.btnOK.Click();
	        	AppointmentOverlapPrompt();
	        	ValidateEventRemainderPopup();
	        	
	        	//Create Outstanding phone call
	        	phoneCall.MainForm.Self.Activate();
	        	phoneCall.MainForm.btnCommunications.Click();
	        	Keyboard.Press(System.Windows.Forms.Keys.P | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
	        	phoneCall.PhoneDetailForm.MenubarFillPanel.btnAddFile.Click();
	        	phoneCall.FileSelectForm.listFirstFoundFile.DoubleClick();
	        	phoneCall.PhoneDetailForm.MenubarFillPanel.rdoOutstanding.Select();
	        	phoneCall.PhoneDetailForm.MenubarFillPanel.txtPhoneCallNote.PressKeys(curdata);
	        	phoneCall.PhoneDetailForm.MenubarFillPanel.btnOK.Click();
	        	
	        	
	        	//Create notes
		        note.MainForm.Self.Activate();
	        	note.MainForm.btnNotes.Click();
	        	note.MainForm.btnNewSticky.Click();
	        	note.PeopleSelectForm.listNameOne.DoubleClick();
	        	note.StickyDetails.btnAddFile.Click();
	        	note.FileSelectForm.fileListItemOne.DoubleClick();
	        	Delay.Seconds(2);
	        	note.StickyDetails.txtNoteBox.PressKeys(curdata);
	        	note.StickyDetails.btnSend.Click();
	        	Delay.Seconds(3);
	        	note.StickyDetails.Self.Activate();
	        	note.StickyDetails.btnClose.Click();
	        	
	        	//Create Document
	        	doc.MainForm.Self.Activate();
	        	Keyboard.Press(System.Windows.Forms.Keys.X | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
	        	Keyboard.Press(System.Windows.Forms.Keys.N | System.Windows.Forms.Keys.Control, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
	        	
	        	localFileName=cmn.createLocalFile();
	        	doc.DocumentDetail.Self.Activate();
	        	doc.DocumentDetail.PnlBase.txtDocumentTitle.PressKeys(fileName);
	        	//doc.DocumentDetail.PnlBase.fileLocationPathText.Element.SetAttributeValue("Text", localFileName);
	        	doc.DocumentDetail.PnlBase.btnLocation.Click();
        		doc.Open.txtFilePath.Element.SetAttributeValue("Text", localFileName);
        		doc.Open.btnOpen.Click();
	        	doc.DocumentDetail.MenubarFillPanel.txtDocumentSummary.PressKeys(curdata);
	        	doc.DocumentDetail.PnlBase.btnFilesAndPeople.Click();
	        	doc.DocumentDetail.PnlBase.btnAddFile.Click();
	        	doc.FileSelectForm.listFirstFoundFile.DoubleClick();
	        	doc.DocumentDetail.MenubarFillPanel.btnOK.Click();

			}
			
			private void excludecheckTimeEntry()
			{
				int initial_count=0;	
				ts.MainForm.Self.Activate();
	        	Delay.Seconds(1);
	        	ts.MainForm.btnTimeSheets.Click();
	        	Delay.Seconds(5);
	        	ts.MainForm.Toolbar.btnTimeEntryAssistant.Click();
	        	ts.TimeEntryAssistantForm.SelfInfo.WaitForExists(3000);
	        	
	        	//Check ffor Records with item with no file
	        	ts.TimeEntryAssistantForm.PnlBase.cbItemsWithNoFile.Uncheck();
	        	initial_count=cmn.GetTableRowCount(ts.TimeEntryAssistantForm.PnlBase.tbTimeEntryAssistant,"Time Entry Assistant Table");
	        	Report.Success(String.Format("Time Entry Assistant has {0} records for {1}",initial_count,ts.TimeEntryAssistantForm.PnlBase.cbItemsWithNoFile.Text));
				ts.TimeEntryAssistantForm.PnlBase.cbItemsWithNoFile.Check();
				
				//Check ffor Records with item with outgoing phone calls
				ts.TimeEntryAssistantForm.PnlBase.cbOutstandingPhoneCallsEMails.Uncheck();
	        	initial_count=cmn.GetTableRowCount(ts.TimeEntryAssistantForm.PnlBase.tbTimeEntryAssistant,"Time Entry Assistant Table");
	        	Report.Success(String.Format("Time Entry Assistant has {0} records for {1}",initial_count,ts.TimeEntryAssistantForm.PnlBase.cbOutstandingPhoneCallsEMails.Text));
				ts.TimeEntryAssistantForm.PnlBase.cbOutstandingPhoneCallsEMails.Check();
				
				//Check ffor Records with item with notes
				ts.TimeEntryAssistantForm.PnlBase.cbNotes.Uncheck();
	        	initial_count=cmn.GetTableRowCount(ts.TimeEntryAssistantForm.PnlBase.tbTimeEntryAssistant,"Time Entry Assistant Table");
	        	Report.Success(String.Format("Time Entry Assistant has {0} records for {1}",initial_count,ts.TimeEntryAssistantForm.PnlBase.cbNotes.Text));
				ts.TimeEntryAssistantForm.PnlBase.cbNotes.Check();
				
				//Check ffor Records with item with documents
				ts.TimeEntryAssistantForm.PnlBase.cbDocuments.Uncheck();
	        	initial_count=cmn.GetTableRowCount(ts.TimeEntryAssistantForm.PnlBase.tbTimeEntryAssistant,"Time Entry Assistant Table");
	        	Report.Success(String.Format("Time Entry Assistant has {0} records for {1}",initial_count,ts.TimeEntryAssistantForm.PnlBase.cbDocuments.Text));
				ts.TimeEntryAssistantForm.PnlBase.cbDocuments.Check();
				ts.TimeEntryAssistantForm.Toolbar1.btnClose.Click();
			
			}
			
		
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            create_Appointment();
            timeentryAssist();
            createdata();
            excludecheckTimeEntry();
            cmn.ClosePrompt();
        }
    }
}
