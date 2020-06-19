/*
 * Created by Ranorex
 * User: kumar
 * Date: 5/28/2020
 * Time: 5:49 PM
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
    /// Description of tax_Calc_Tax_Not_tax_NotActivity_Codes.
    /// </summary>
    [TestModule("3E43F213-92C9-45A9-B6E6-EAED676972FE", ModuleType.UserCode, 1)]
    public class tax_Calc_Tax_Not_tax_NotActivity_Codes : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public tax_Calc_Tax_Not_tax_NotActivity_Codes()
        {
            // Do not delete - a parameterless constructor is required!
        }

        
        
          BillingClient bclient=BillingClient.Instance;
        BillingFile file = BillingFile.Instance;
        FirmSettings frm=FirmSettings.Instance;
        BillingTE te = BillingTE.Instance;
        Bill bill = Bill.Instance;
    	Common cmn=new Common();
        
    	string fileName="MultipleActivity_file"+System.DateTime.Now.ToString();
        string activityName1="Attend discovery";
        string activityName2="Attend trial";
        string activityName3="Brief witness";
        string sales_Tax1,sales_Tax2="";
        
        
        private void SalesTax_Settings()
        {
        	bclient.MainForm.Self.Activate();
        	bclient.MainForm.sideBILLING.Click();
        	frm.MainForm.btnOffice.Click();
        	frm.MainForm.View.Click();
        	frm.MainForm.FirmSettings1.Click();
        	
        	bclient.MainForm.lnkTaxSettings.Click();
        	
        	if(bclient.GeneralFirmSettingsXtraForm.SelfInfo.Exists(3000))
        	{
        		Report.Success("Tax Settings is opened successfully");
        		sales_Tax1=bclient.GeneralFirmSettingsXtraForm.PanelTax.txtSalesTax1.GetAttributeValue<String>("UIAutomationValueValue");
        		sales_Tax2=bclient.GeneralFirmSettingsXtraForm.PanelTax.txtSalesTax2.GetAttributeValue<String>("UIAutomationValueValue");
        		bclient.GeneralFirmSettingsXtraForm.Toolbar1.ButtonOK.Click();

       		 }
        }
        
        
        
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

        	file.PeopleSelectForm.listFirstValue.Click();
        	file.PeopleSelectForm.btnAddToRight.Click();
        	file.PeopleSelectForm.btnOK.Click();
        	
        	
        	file.NewFileForm.btnSaveOpen.Click();
        	
        	file.FileDetailForm.Admin.Click();
        	file.FileDetailForm.BillSettings.Click();
        	file.FileDetailForm.cbChargeSalesTax1.Check();
        	file.FileDetailForm.cbChargeSalesTax2.Check();
        	
        	file.var="Referred by...";
        	file.FileDetailForm.Accounting.Click();
        	file.FileDetailForm.cmbbxMatterCameToUs.Click();
        	file.DropDownForm.TreeItem.Click();
        	file.FileDetailForm.imgContact.Click();
        	
        	file.PeopleSelectForm.listFirstValue.DoubleClick();
        		
        	
        	
        	
        	
        	file.FileDetailForm.btnSaveClose.Click();
        	Report.Success("File Created successfully with Sales Tax 1 and Tax 2 enabled");
    	}
    	
    	private void createMultipleTimeEntry()
    	{
    		
    		te.MainForm.btnTimeFeesExpenses.Click();
        	te.MainForm.btnMenuItem.Click();
        	te.AmicusAttorneyXWin.MenuPopup.Click("58;21");
        	te.FileSelectForm.btnQuickFind.Click();
        	te.FindFilesForm.txtFind.TextValue = fileName;
        	te.FindFilesForm.btnOK.Click();
        	te.var=activityName1;
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
        	Report.Success("Time Entry 1 successfully created and posted .");
        	
        	
        	
        	te.MainForm.btnMenuItem.Click();
        	te.AmicusAttorneyXWin.MenuPopup.Click("58;21");
        	te.FileSelectForm.btnQuickFind.Click();
        	te.FindFilesForm.txtFind.TextValue = fileName;
        	te.FindFilesForm.btnOK.Click();
        	te.var=activityName2;
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
        	Report.Success("Time Entry 2 successfully created and posted .");
        	
        	
        	
			te.MainForm.btnMenuItem.Click();
        	te.AmicusAttorneyXWin.MenuPopup.Click("58;21");
        	te.FileSelectForm.btnQuickFind.Click();
        	te.FindFilesForm.txtFind.TextValue = fileName;
        	te.FindFilesForm.btnOK.Click();
        	te.var=activityName3;
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
        	Report.Success("Time Entry 3 successfully created and posted .");
        	
        	
        	
        	te.MainForm.btnMenuItem.Click();
        	te.AmicusAttorneyXWin.MenuPopup.Click("58;21");
        	te.FileSelectForm.btnQuickFind.Click();
        	te.FindFilesForm.txtFind.TextValue = fileName;
        	te.FindFilesForm.btnOK.Click();
        	te.FileSelectForm.listFirstFound.DoubleClick();
        	
        	te.var="Normal";
        	te.TimeEntryDetailsForm.cmbbxBillingRate.Click();
        	te.DropDownForm.TreeItem.Click();
        	
        	te.var="Bill";
        	te.TimeEntryDetailsForm.cmbbxBillBehavior.Click();
        	te.DropDownForm.TreeItem.Click();
        	
        	
        	
        	te.TimeEntryDetailsForm.btnPost.Click();
        	Report.Success("Time Entry 4 successfully created and posted .");
        	
    		
        	
        	
    		
    	}
    	private void CreateBillforMultipleTE()
    	{
    		int tax1,tax2,fees,tval,taxAmt=0;
    		bclient.MainForm.Self.Activate();
        	bclient.MainForm.sideBILLING.Click();
        	
        	file.MainForm.btnFiles.Click();
        	
        	cmn.OpenContextMenuItemFromTable(file.MainForm.FilesIndexForm.tblFiles,fileName,"Files Table");
        	
        	bill.ContextMenu.optionBill.Click();
        	Delay.Seconds(5);
        	bill.BillingDetailForm.btnSendToDraft.Click();
        	
        	tax1=Int32.Parse(sales_Tax1.Split('.')[0]);
        	tax2=Int32.Parse(sales_Tax2.Split('.')[0]);
        	fees=Int32.Parse(file.BillingDetailForm.txtDraftFees.TextValue.Split('.')[0]);
        	
        	taxAmt=(tax1+tax2)*fees/100 - ((tax1+tax2)*fees/200);
     		tval=fees+taxAmt;
     		Report.Success(string.Format("Sales Tax 1 value is {0} and is the correct calculated amount",tax1.ToString()));    		
     		Report.Success(string.Format("Sales Tax 2 value is {0} and is the correct calculated amount",tax2.ToString()));    		
 			Validate.AttributeContains(file.BillingDetailForm.txtDraftFeesInfo,"Text",fees.ToString(),string.Format("Fees value is {0} and is the correct calculated amount",fees.ToString()));    		
     		Validate.AttributeContains(file.BillingDetailForm.PnlDraftSummary.txtDraftTaxesInfo,"Text",taxAmt.ToString(),string.Format("Taxes value is {0} and is the correct calculated amount for 4 Time Entries and 2 TE with sales tax amount and 1 without any activity codes.",taxAmt.ToString()));
     		Validate.AttributeContains(file.BillingDetailForm.PnlDraftSummary.txtDraftTotalAmountInfo,"Text",tval.ToString(),string.Format("Total Amount value is {0} and is the correct calculated amount",tval.ToString()));
        	
     		bill.BillingDetailForm.btnSendtoFinal.Click();
     		bill.BillingDetailForm.btnPrintPost.Click();
     		
     		if(bill.InvoiceEmailForm.SelfInfo.Exists(3000))
     		{
     			bill.InvoiceEmailForm.cbSelectAll.Click();
     			bill.InvoiceEmailForm.btnProceed.Click();
     			Report.Success("Email Bills is displayed successfully");
     			if(bill.PromptForm.SelfInfo.Exists(5000))
     			{
     				bill.PromptForm.btnOk.Click();
     			}
     		}
     		
     		
     		if(bill.OutputPromptForm.SelfInfo.Exists(5000))
     		{
     			bill.OutputPromptForm.chkScreen.Check();
     			bill.OutputPromptForm.chkPrinter.Uncheck();
     			bill.OutputPromptForm.btnOk.Click();
     			Report.Success("Output Form is displayed successfully");
     		}
     		
     		if(bill.ReportViewerForm.SelfInfo.Exists(30000))
     		{
     			Report.Success("Report Viewer is displayed successfully");
     			bill.ReportViewerForm.btnClose.Click();
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
            SalesTax_Settings();
            AddFile();
            createMultipleTimeEntry();
            CreateBillforMultipleTE();
            cmn.ClosePrompt();
        }
    }
}
