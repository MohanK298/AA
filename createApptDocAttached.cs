/*
 * Created by Ranorex
 * User: Kumar
 * Date: 2019-10-23
 * Time: 12:37 PM
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

namespace SmokeTest
{
    /// <summary>
    /// Description of createApptDocAttached.
    /// </summary>
    [TestModule("10A89633-7144-4480-9F9E-1743B2C122C9", ModuleType.UserCode, 1)]
    public class createApptDocAttached : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        Calendar calendar=Calendar.Instance;
        Common cmn=new Common();
        Documents doc=Documents.Instance;
        Files file=Files.Instance;
        string localFileName;
		static string rndData=System.DateTime.Now.ToString();
		string data=String.Format("Test Data Added {0}",rndData);
		string fileName=String.Format("RanorexTestFile {0}",rndData);
		string parentfolder =System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName +"\\DataFiles\\";
		string shrtFileName="";
        public createApptDocAttached()
        {
            // Do not delete - a parameterless constructor is required!
        }

        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        private void GenerateDocument()
        {
        	doc.MainForm.Self.Activate();
        	Keyboard.Press(System.Windows.Forms.Keys.X | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Control, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
        	Keyboard.Press(System.Windows.Forms.Keys.N | System.Windows.Forms.Keys.Control, Keyboard.DefaultScanCode, Keyboard.DefaultKeyPressTime, 1, true);
        	Validate.Exists(doc.DocumentDetail.SelfInfo,"Document Detail Form Opened");
        }
		
        private void FillDocument()
        {
			
        	localFileName=cmn.createLocalFile();
        	//localFileName="C:\\Users\\Kumar\\Downloads\\RanorexAutomation\\AA Enhanced\\DataFiles\\RanorexTestFile2019-10-23 44026 PM.txt";
        	doc.DocumentDetail.Self.Activate();
        	doc.DocumentDetail.PnlBase.txtDocumentTitle.PressKeys(fileName);
        	//doc.DocumentDetail.PnlBase.btnDropdownType.Click();
        	//cmn.SelectItemDropdown(doc.tblDpdwnList.Self,"Other");
        	Report.Info(localFileName);
        	doc.DocumentDetail.PnlBase.btnLocation.Click();
        	doc.Open.txtFilePath.PressKeys(localFileName);
        	doc.Open.btnOpen.Click();
        	//doc.DocumentDetail.PnlBase.fileLocationPathText.Element.SetAttributeValue("Text", localFileName);
        	
        	doc.DocumentDetail.MenubarFillPanel.txtDocumentSummary.PressKeys(data);
        	
        	doc.DocumentDetail.PnlBase.btnFilesAndPeople.Click();
        	
        	doc.DocumentDetail.PnlBase.btnAddFile.Click();
        	
        	doc.FileSelectForm.listFirstFoundFile.DoubleClick();
        	
        	doc.DocumentDetail.MenubarFillPanel.btnOK.Click();

        }
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
        private void CreateApptWithDocument()
        {
			//calendar.MainForm.Self.Activate();
			GenerateDocument();
			FillDocument();
        	calendar.MainForm.btnCalendar.Click();
        	calendar.MainForm.btnNewAppointment.Click();
        	Delay.Seconds(1);
        	calendar.EventDetailForm.PnlBase.txtAppointmentTitle.PressKeys(data);
			calendar.EventDetailForm.PnlBase.txtStartTime.PressKeys(System.DateTime.Now.ToShortTimeString());
        	calendar.EventDetailForm.PnlBase.txtEndTime.PressKeys(System.DateTime.Now.AddHours(1).ToShortTimeString());
        	calendar.EventDetailForm.PnlBase.DocumentsEMail.Click();
        	calendar.EventDetailForm.PnlBase.btnDoc.Click();
        	calendar.FileSelectForm.listFirstFoundFile.DoubleClick();
        	cmn.SelectItemFromTableDblClick(calendar.DocumentSelectorForm.PnlBase.tbCurrSelection,fileName,"Document Selector Table");
        	calendar.EventDetailForm.btnOK.Click();
        	Delay.Seconds(3);
        	AppointmentOverlapPrompt();
        	ValidateEventRemainderPopup();
        	calendar.MainForm.btnCalendar.Click();
        	calendar.MainForm.btnViewMenu.Click();
        	calendar.MainForm.menuListView.Click();
        	Delay.Seconds(3);
        	cmn.VerifyDataExistsInTable(calendar.MainForm.tblCalendar,data,"Calendar List");
        }
        private void ValidateApptInDocument()
        {
        	CreateApptWithDocument();
        	shrtFileName=localFileName.Substring(parentfolder.Length,(localFileName.Length-parentfolder.Length-4));
        	Delay.Seconds(3);
        	file.MainForm.btnFiles.Click();
        	file.MainForm.FilesIndexForm.listFirstFile.DoubleClick();	
        	Delay.Seconds(2);
        	file.FileDetailForm.Documents.Click();
        	Delay.Seconds(2);
        	file.fileName=shrtFileName;
        	Delay.Seconds(2);
        	file.FileDetailForm.lstItemAmicusFile.DoubleClick();
        	file.DocumentDetail.PnlBase.lnkEvents.Click();
        	file.DocumentDetail.PnlBase.btnEventSelection.Click();
        	cmn.VerifyDataExistsInTable(file.EventSelectForm.Panel1.tblSelectedEvents,data,"Events Selected Table");
        	file.EventSelectForm.Toolbar1.btnCancel.Click();
        	file.DocumentDetail.Toolbar1.btnCancel.Click();
        	file.FileDetailForm.btnSaveClose.Click();
        	
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            ValidateApptInDocument();
        }
    }
}
