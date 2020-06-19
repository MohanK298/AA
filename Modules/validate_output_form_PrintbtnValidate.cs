/*
 * Created by Ranorex
 * User: qa
 * Date: 6/9/2020
 * Time: 4:09 PM
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
    /// Description of validate_output_form_PrintbtnValidate.
    /// </summary>
    [TestModule("26092CD7-E5D7-4F5A-B7F2-EF0C1E638AB3", ModuleType.UserCode, 1)]
    public class validate_output_form_PrintbtnValidate : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public validate_output_form_PrintbtnValidate()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        
         Bill bill=Bill.Instance;
         BillingFile bfile=BillingFile.Instance;
         Common cmn=new Common();
         string retrievefileName,final_filename,txtInvoice,txt_finalInvoice="";	
        private void output_form_Validate()
        {
        	bill.MainForm.Self.Activate();
        	bill.MainForm.BILLING.Click();
        	bill.MainForm.btnBilling.Click();
        	
        	bill.MainForm.cbFirstRow.Check();
        	Delay.Seconds(2);
        	bill.MainForm.btnReprintBills.Click();
        	
        	if(bill.OutputPromptForm.SelfInfo.Exists(3000))
        	{
        		Report.Success("Output form is displayed as expected");
        		Validate.Exists(bill.OutputPromptForm.chkPrinterInfo,"Printer Checkbox is displayed as expected");
        		Validate.Exists(bill.OutputPromptForm.chkScreenInfo,"Screen Chekbox is displayed as expected");
        		Validate.Exists(bill.OutputPromptForm.btnOkInfo,"Ok Button is displayed as expected");
        		Validate.Exists(bill.OutputPromptForm.btnCancelInfo,"Cancel Button is displayed as expected");
        		bill.OutputPromptForm.btnOk.Click();
        	}
        	
        	
        	if(bill.ReportViewerForm.SelfInfo.Exists(30000))
     		{
     			Report.Success("Report Viewer is displayed successfully");
     			retrievefileName=bill.ReportViewerForm.txtFileName.GetAttributeValue<String>("Text");
     			txtInvoice=bill.ReportViewerForm.txtInvoice.GetAttributeValue<String>("Text");
     			final_filename=retrievefileName.Substring(5);
     			txt_finalInvoice=txtInvoice.Substring(txtInvoice.Length-4);
     			Report.Success(String.Format("Bill is displayed for the following file name {0}.",final_filename));
     			Report.Success(String.Format("Invoice is displayed for the following Bill {0}.",txt_finalInvoice));
     			Delay.Seconds(3);
     			bill.ReportViewerForm.btnClose.Click();
     		}
        	if(bill.PromptForm.SelfInfo.Exists(3000))
        	{
        		bill.PromptForm.Self.Close();
        	}
        	
        	bfile.MainForm.btnFiles.Click();
        	cmn.SelectItemFromTableDblClick(bfile.MainForm.FilesIndexForm.tblFiles,final_filename,"Files Table");
        	bfile.FileDetailForm.BillImages.Click();
        	Delay.Seconds(1);
        	cmn.VerifyDataExistsInTable(bfile.FileDetailForm.tblFileDetail,txt_finalInvoice,"File Details Table");
        	bfile.FileDetailForm.btnSaveClose.Click();
        	
        
        	
        	
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
            output_form_Validate();
            cmn.ClosePrompt();
        }
    }
}
