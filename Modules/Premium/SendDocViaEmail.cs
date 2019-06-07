/*
 * Created by Ranorex
 * User: qa
 * Date: 6/4/2019
 * Time: 2:32 PM
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

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

using SmokeTest.Repositories.Premium;

namespace SmokeTest.Modules.Premium
{
    /// <summary>
    /// Description of SendDocViaEmail.
    /// </summary>
    [TestModule("DDE438C8-C90A-4D45-84E7-A8A56AD30054", ModuleType.UserCode, 1)]
    public class SendDocViaEmail : ITestModule
    {
    	Communications comm = Communications.Instance;
    	Outlook ol = Outlook.Instance;
    	string filePath;
    	string testTime = System.DateTime.Now.ToString();
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SendDocViaEmail()
        {
            // Do not delete - a parameterless constructor is required!
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
            
//            Utilities.Common.CreateLocalTextFile("qctest");
            comm.MainForm.AttorneyOrBilling.Attorney.Click();
            CreateNewEmail();
            ol.AttachmentName = "Ranorex Email Test Doc";
            Validate.Exists(ol.NewEmail.AttachmentTextInfo);
            Validate.IsTrue(ol.NewEmail.TextTo.TextValue.Contains("qaabacusnext@gmail.com"));
            ol.NewEmail.Send.Click();
        }
        
        private void CreateNewEmail()
        {
        	comm.MainForm.LeftPanel.Comminucations.Click();
        	Keyboard.Press("{ControlKey down}{ShiftKey down}{AKey}{ControlKey up}{ShiftKey up}"); //Keyboard shortcut to create new email
        	comm.NewEmailForm.ScToPeople.PeopleSelectorBtn.Click();
        	CreateNewContact();
        	comm.PeopleSelectForm.Ok.Click();
        	comm.NewEmailForm.ScFiles.FileSelectorBtn.Click();
        	CreateNewMatter();
        	AddDocumentToMatter();
        	comm.FileDetailForm.SaveClose.Click();
        	comm.FileSelectForm.OkBtn.Click();
        	SelectDocument();
        	comm.NewEmailForm.OpenBtn.Click();
        }
        
        private void CreateNewContact()
        {
        	comm.PeopleSelectForm.New.Click();
        	comm.NewPersonForm.PanelPeopleDetails.FirstName.PressKeys("Ranorex");
        	comm.NewPersonForm.PanelPeopleDetails.Middle.PressKeys("Test");
        	comm.NewPersonForm.PanelPeopleDetails.LastName.PressKeys("Email" + testTime);
        	comm.NewPersonForm.NextBtn.Click();
        	
        	comm.PeopleDetailForm.QuickEdit.Focus();
        	comm.PeopleDetailForm.QuickEdit.PressKeys("qaabacusnext@gmail.com");
        	comm.PeopleDetailForm.Apply.Click();
        	comm.PeopleDetailForm.SaveCloseBtn.Click();
        }
        
        private void CreateNewMatter()
        {
        	comm.FileSelectForm.New.Click();
        	comm.NewFileForm.MatterName.PressKeys("Ranorex Email Matter with doc" + testTime);
        	comm.NewFileForm.ClientSelector.Click();
        	comm.PeopleSelectForm.SecondaryFilter.DropdownBtn.Click();
        	comm.DropDownForm.All_My_Contacts.Click();
        	comm.ContactFullName = "Ranorex Test Email" + testTime;
        	comm.PeopleSelectForm.Contact.DoubleClick();
        	comm.NewFileForm.SaveOpen.Click();
        }
        
        private void AddDocumentToMatter()
        {
        	comm.FileDetailForm.File_Facts.Document.Click();
        	comm.FileDetailForm.PanelRight.NewBtn.Click();
        	comm.DocumentDetail.Title.PressKeys("Ranorex Email Test Doc");
        	filePath = Utilities.Common.CreateLocalTextFile("Ranorex Email Test Doc");
        	comm.DocumentDetail.AtbLocationPath.PressKeys(filePath);
        	comm.DocumentDetail.OkBtn.Click();
        }
        
        private void SelectDocument()
        {
        	comm.NewEmailForm.ScDocument.DocumentSelectorBrn.Click();
        	comm.DocumentName = "Ranorex Email Test Doc";
        	comm.DocumentSelector.Title.Click();
        	comm.DocumentSelector.AddBtn.Click();
        	comm.DocumentSelector.OkBtn.Click();
        }
    }
}
