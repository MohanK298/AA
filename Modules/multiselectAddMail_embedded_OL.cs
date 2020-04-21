/*
 * Created by Ranorex
 * User: kumar
 * Date: 4/14/2020
 * Time: 1:04 PM
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
    /// Description of multiselectAddMail_embedded_OL.
    /// </summary>
    [TestModule("BFD71079-9BFA-467F-854B-CDC561C50B94", ModuleType.UserCode, 1)]
    public class multiselectAddMail_embedded_OL : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public multiselectAddMail_embedded_OL()
        {
            // Do not delete - a parameterless constructor is required!
        }

        
        Common cmn=new Common();
        Communications comm=Communications.Instance;
        Files file=Files.Instance;
        People ppl=People.Instance;
        
        
        
        private void ValidateAddtoFileButton_MultiSelectMails()
        {
        	
        	string mailsub="";
        	string peopleName="";
        	comm.MainForm.Self.Activate();
        	Delay.Seconds(2);

        	if(comm.MainForm.btnCommunications1Info.Exists(3000))
        	{comm.MainForm.btnCommunications1.Click();}
        	else
        	{
        		comm.MainForm.btnCommunications.Click();
        	}

        	comm.MainForm.txtOutlook.Click();
        	Delay.Seconds(2);
        	
        	mailsub=cmn.MultiSelectEmail(comm.MainForm.OutlookMail,3,true);
        	
        	comm.MainForm.Toolbar1.btnSaveAssociate.Click();
        	
        	
        	if(comm.SelectFilePeopleForm.SelfInfo.Exists(3000))
        	{
        		comm.SelectFilePeopleForm.btnAddFiles.Click();
        		comm.FileSelectForm.listFirstFoundFile.DoubleClick();
        		Report.Success("File Added Successfully for the E-Mail");
        		comm.SelectFilePeopleForm.btnAddPeople.Click();
        		//comm.PeopleSelectForm.cmbbxPeopleSelection.Click();
        		comm.PeopleSelectForm.cmbxWhoAre.Click();
        		cmn.SelectItemDropdown(comm.tblDpdwnList.Self,"All My Contacts");
		     	
        		//cmn.SelectItemDropdown(comm.PeopleSelectForm.
        		comm.PeopleSelectForm.listContact.DoubleClick();
        		Report.Success("People Added Successfully for the E-Mail");
        		peopleName=comm.SelectFilePeopleForm.txtPeople.GetAttributeValue<String>("Text");
        		comm.SelectFilePeopleForm.Toolbar1.btnOK.Click();
        		
        	}
   			Report.Info(mailsub);
   			//outlook.Outlook.Self.Close();
   			ValidateMailsInFile(mailsub);
   			ValidateMailsinPeople(peopleName,mailsub);
   			
        }
        
        private void ValidateMailsInFile(string sub)
        {
        	file.MainForm.Self.Activate();
        	file.MainForm.btnFiles1.Click();
        	Delay.Seconds(3);
        	file.MainForm.FilesIndexForm.listFirstFile.DoubleClick();
        	Delay.Seconds(1);
        	file.FileDetailForm.Communications.Click();
        	Delay.Seconds(3);
        	file.FileDetailForm.MyEMails.Click();
        	Delay.Seconds(3);
        	cmn.VerifyDataExistsInTable(file.FileDetailForm.tblFileDetailsBrad,sub.Split('~')[0],"File Brad Communications Table");
        	cmn.VerifyDataExistsInTable(file.FileDetailForm.tblFileDetailsBrad,sub.Split('~')[1],"File Brad Communications Table");
        	cmn.VerifyDataExistsInTable(file.FileDetailForm.tblFileDetailsBrad,sub.Split('~')[2],"File Brad Communications Table");
        	file.FileDetailForm.btnSaveClose.Click();
        	
        }
        
        
        private void ValidateMailsinPeople(string pplName,string sub)
        {
        	
        	ppl.MainForm.Self.Activate();
        	ppl.MainForm.btnPeople1.Click();
        	Delay.Seconds(2);
        	cmn.SelectItemFromTableDblClick(ppl.MainForm.PeopleIndexForm1.tblPeopleDetails,pplName,"People Table Details");
        	ppl.PeopleDetailForm.Communications.Click();
        	Delay.Seconds(2);
        	ppl.PeopleDetailForm.MyEMails.Click();
        	Delay.Seconds(3);
        	cmn.VerifyDataExistsInTable(ppl.PeopleDetailForm.tblPeople,sub.Split('~')[0],"People Communications Table");
        	cmn.VerifyDataExistsInTable(ppl.PeopleDetailForm.tblPeople,sub.Split('~')[1],"People Communications Table");
        	cmn.VerifyDataExistsInTable(ppl.PeopleDetailForm.tblPeople,sub.Split('~')[2],"People Communications Table");
        	ppl.PeopleDetailForm.btnSaveClose.Click();
       	
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
            ValidateAddtoFileButton_MultiSelectMails();
        }
    }
}
