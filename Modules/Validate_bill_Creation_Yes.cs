/*
 * Created by Ranorex
 * User: qa
 * Date: 8/4/2020
 * Time: 12:52 PM
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
    /// Description of Validate_bill_Creation_Yes.
    /// </summary>
    [TestModule("B25FB5B4-5DC7-43AE-8B49-91B5F7086C29", ModuleType.UserCode, 1)]
    public class Validate_bill_Creation_Yes : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public Validate_bill_Creation_Yes()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        BillingClient bclient=BillingClient.Instance;
        BillingFile file = BillingFile.Instance;
        FirmSettings frm=FirmSettings.Instance;
        Bill bill = Bill.Instance;
        BillingTE te = BillingTE.Instance;
        People people=People.Instance;
        
        Common cmn=new Common();
        string emailId="";
    	string fileName="File-EmailBill_"+System.DateTime.Now.ToString();
        string activityName="Attend discovery";
        
        private void AddFile()
    	{
    		bclient.MainForm.Self.Activate();
        	bclient.MainForm.sideBILLING.Click();
        	
        	
        	
        	file.MainForm.btnFiles.Click();
        	file.MainForm.FilesIndexForm.btnNewFile.Click();
        	
        	if(file.PromptForm.SelfInfo.Exists(3000))
        	   {
        	   	file.PromptForm.btnNo.Click();
        	   }
        	
        	//Type the file name and other variables
        	file.NewFileForm.txtFileName.TextValue = fileName;
        	file.NewFileForm.btnAddContact.Click();

        	if(file.PeopleSelectForm.SelfInfo.Exists(3000))
        	{
        		file.PeopleSelectForm.btnQuickFind.Click();
        		
        		file.FindContactsForm.txtFindContact.PressKeys("PortalUser");
        		file.FindContactsForm.btnOK.Click();
        		file.PeopleSelectForm.listFirstValue.Click();
        		file.PeopleSelectForm.btnAddToRight.Click();
        		file.PeopleSelectForm.btnOK.Click();
        	
        	}
        	
        	
        	file.NewFileForm.btnSaveOpen.Click();
        	
        	file.FileDetailForm.Admin.Click();
        	file.FileDetailForm.BillSettings.Click();
        	Validate.Exists(file.FileDetailForm.PanelRight.cbEmailBillsToInfo," Email bills to checkbox is displayed as expected");
        	if(file.FileDetailForm.PanelRight.cbEmailBillsTo.Checked)
        	{Validate.AttributeContains(file.FileDetailForm.PanelRight.cbEmailBillsToInfo,"Checked","True","Email bills to checkbox is checked by default");}
        	else
        	{
        		file.FileDetailForm.PanelRight.cbEmailBillsTo.Check();
        		Delay.Seconds(1);
        		Validate.AttributeContains(file.FileDetailForm.PanelRight.cbEmailBillsToInfo,"Checked","True","Email bills to checkbox is checked by Automation");
        	}
        	if(file.FileDetailForm.PanelRight.cbIncludeAPXRequestForPaymentWithEM.Checked)
        	{Validate.AttributeContains(file.FileDetailForm.PanelRight.cbIncludeAPXRequestForPaymentWithEMInfo,"Checked","True","Include APX Request for Payment checkbox is checked by default");}
        	else
        	{
        		file.FileDetailForm.PanelRight.cbIncludeAPXRequestForPaymentWithEM.Check();
        		Delay.Seconds(1);
        		Validate.AttributeContains(file.FileDetailForm.PanelRight.cbIncludeAPXRequestForPaymentWithEMInfo,"Checked","True","Include APX Request for Payment checkbox is checked by Automation");
        		
        	}
        	
        	emailId=file.FileDetailForm.PanelRight.txtPrimaryEmailIdBilling.GetAttributeValue<String>("Text");
        	Validate.AttributeContains(file.FileDetailForm.PanelRight.rdoEmailBillsPrimaryClientInfo,"Checked","True","Email Bills Primary Radio Button is selected by default");
        	Report.Success(String.Format("Primary Client Email Id  is: '{0}' as expected ",emailId));
        	
        	Validate.AttributeContains(file.FileDetailForm.PanelRight.rdoEmailBillsAlternateAddressInfo,"Checked","False","Email Bills Alternate Radio Button is not selected by default");
        	
        	file.FileDetailForm.btnSaveClose.Click();
        	
    	}
    	
    	private void createTimeEntry()
    	{
    		
    		te.MainForm.btnTimeFeesExpenses.Click();
        	te.MainForm.btnMenuItem.Click();
        	te.AmicusAttorneyXWin.MenuPopup.Click("58;21");
        	te.FileSelectForm.btnQuickFind.Click();
        	te.FindFilesForm.txtFind.TextValue = fileName;
        	te.FindFilesForm.btnOK.Click();
        	te.var=activityName;
        	te.FileSelectForm.listFirstFound.DoubleClick();
        	
        	te.TimeEntryDetailsForm.cmbbxActivityCodes.Click();
        	te.DropDownForm.TreeItem.Click();
        	
        	te.var="Normal";
        	te.TimeEntryDetailsForm.cmbbxBillingRate.Click();
        	te.DropDownForm.TreeItem.Click();
        	       	
        	te.var="Bill";
        	te.TimeEntryDetailsForm.cmbbxBillBehavior.Click();
        	te.DropDownForm.TreeItem.Click();
        	        	
        	
        	te.TimeEntryDetailsForm.btnPost.Click();
        	Report.Success("Time Entry successfully created and posted .");
    		
    	}
    	
    	private void CreateBillforTE()
    	{
    		bclient.MainForm.Self.Activate();
        	bclient.MainForm.sideBILLING.Click();
        	
        	file.MainForm.btnFiles.Click();
        	
        	cmn.OpenContextMenuItemFromTable(file.MainForm.FilesIndexForm.tblFiles,fileName,"Files Table");
        	
        	bill.ContextMenu.optionBill.Click();
        	Delay.Seconds(2);
        	bill.BillingDetailForm.btnSendToDraft.Click();
        	bill.BillingDetailForm.btnSendtoFinal.Click();
     		bill.BillingDetailForm.btnPrintPost.Click();
     		
     		if(bill.InvoiceEmailForm.SelfInfo.Exists(3000))
     		{
     			//cmn.VerifyDataExistsInTable(bill.InvoiceEmailForm.tblInvoiceForm,emailId,"Invoice Form Table");
     		//	bill.InvoiceEmailForm.cbSelectAll.Click();
     		//	bill.InvoiceEmailForm.cbAPXPayment.Click();
     			bill.InvoiceEmailForm.btnProceed.Click();
     			Report.Success("Email Bills is displayed successfully");
     			
     			
     		}
     	
     		if(bill.OutputPromptForm.SelfInfo.Exists(5000))
     		{
     			bill.OutputPromptForm.chkScreen.Check();
     			bill.OutputPromptForm.chkPrinter.Uncheck();
     			bill.OutputPromptForm.btnOk.Click();
     			Report.Success("Output Form is displayed successfully");
     		}
     		
     		if(bill.PromptForm.SelfInfo.Exists(5000))
     			{
     				Report.Success(String.Format("Prompt form displayed is: {0}",file.PromptForm.txtMessage.GetAttributeValue<String>("Text")));
     				file.PromptForm.ButtonYes.Click();
     				
     			}
     		
     	
     		if(bill.ReportViewerForm.SelfInfo.Exists(30000))
     		{
     			Report.Success("Report Viewer is displayed successfully");
     			bill.ReportViewerForm.btnClose.Click();
     		}
     		
     		if(bill.OutputPromptForm.SelfInfo.Exists(5000))
     		{
     			Report.Success("Email Bills is displayed successfully after clicking No Option");
     		}
     	
     		if(bill.BillingDetailForm.SelfInfo.Exists(3000))
     		{
     			bill.BillingDetailForm.btnClose.Click();
     			Report.Success("Billing Details Form is closed successfully");
     		}
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
            AddFile();
            createTimeEntry();
            CreateBillforTE();
            cmn.ClosePrompt();
        }
    }
}
