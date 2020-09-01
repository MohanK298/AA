/*
 * Created by Ranorex
 * User: qa
 * Date: 8/7/2020
 * Time: 12:54 PM
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
    /// Description of paymentOnBill_PaymentURL.
    /// </summary>
    [TestModule("5019A0EB-A4B6-420D-A7FF-0012EEF1779D", ModuleType.UserCode, 1)]
    public class paymentOnBill_PaymentURL : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public paymentOnBill_PaymentURL()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        
        BillingClient bclient=BillingClient.Instance;
        BillingFile file = BillingFile.Instance;
        FirmSettings frm=FirmSettings.Instance;
        Bill bill = Bill.Instance;
        BillingTE te = BillingTE.Instance;
        People people=People.Instance;
        Outlook_AddIn outlook=Outlook_AddIn.Instance;

    	Common cmn=new Common();
        string emailId="";
    	string fileName="File-PaymentReq_"+System.DateTime.Now.ToString();
        string activityName="Attend discovery";
    	string outlookPath="C:\\Program Files (x86)\\Microsoft Office\\root\\Office16\\OUTLOOK.EXE";
    	string txt="";
    	int indx1,indx2=0;
    	string txt2="";
    	string clientid,matterid="";
    	string clientName="";
    	string paySummary="";
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
        	
        	
        	file.FileDetailForm.Accounting.Click();
        	Delay.Milliseconds(500);
        	clientid=file.FileDetailForm.clientID.GetAttributeValue<String>("UIAutomationValueValue");
        	matterid=file.FileDetailForm.matterID.GetAttributeValue<String>("UIAutomationValueValue");
        	clientName=file.FileDetailForm.lnkClientName.GetAttributeValue<String>("Text");
        	
        	
        	
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
     			bill.InvoiceEmailForm.cbAPXPayment.Click();
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
     				bill.PromptForm.btnOk.Click();
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
    	
    	
    	private void OpenApp()
        {
        	Host.Local.RunApplication(outlookPath);
        	Delay.Seconds(5);
        	outlook.OutlookSplash.SelfInfo.WaitForNotExists(60000);
        	
        }
    	
    	
    	private void validateOutlookDraft()
    	{
    		OpenApp();
    		
    		if(outlook.Outlook.TreeItemGmailInfo.Exists(3000))
        	{
        		outlook.Outlook.TreeItemGmail.DoubleClick();
        	}
        	if(outlook.Outlook.MailFolders.DraftsInfo.Exists(3000))
        	{
        		outlook.Outlook.MailFolders.Drafts.Click();
        		Report.Success("Drafts Folders is opened successfully");
    		
    		
    	    }
    	}
    	
    	private void create_PaymentReqeust()
    	{
    		int rowCount=0;
    		string clientName=clientid+"/"+matterid;
    		bill.MainForm.Self.Activate();
    		bill.MainForm.BILLING.Click();
    		bill.MainForm.btnBilling.Click();
    		Report.Success("Sample-----"+clientName);
    		rowCount=cmn.GetRowNumberFromTable(bill.MainForm.tblBilling,clientName,"Billing Table");
    		Report.Success("Row Count-----"+rowCount.ToString());
    		bill.rowNo=(rowCount).ToString();
    		Delay.Milliseconds(500);
    		
    		if(!bill.MainForm.cbRowSelect.Checked)
        	{
        		bill.MainForm.cbRowSelect.Click();
        		Delay.Seconds(1);
        		bill.MainForm.cbRowSelect.Click();
        		Delay.Seconds(1);
        		bill.MainForm.cbRowSelect.Click();
        	}
        	else
        	{
        		bill.MainForm.cbRowSelect.Click();
        		Delay.Seconds(1);
        		bill.MainForm.cbRowSelect.Click();
        	}
    		
    		if(bill.MainForm.Toolbar.btnAddPaymentRequestInfo.Exists(10000))
    		{
    			Report.Success("Add Payment Request Button is seen as expected for Bill without Payment Request Set");
    			bill.MainForm.Toolbar.btnAddPaymentRequest.Click();
    		}
    		else
    		{
    			Report.Failure("Add Payment Request Button is not seen as expected for Bill without Payment Request Set");
    		}
    		
    		if(bill.PromptForm.SelfInfo.Exists(5000))
 			{
 				Report.Success(String.Format("Prompt form displayed is: {0}",file.PromptForm.txtMessage.GetAttributeValue<String>("Text")));
 				bill.PromptForm.btnOk.Click();
 			}
    		
    		
    		
    		
    	}
    	
    	private void validateDraftMailWithAPX()
    	{
    		txt=outlook.Outlook.DraftsFirstMail.Element.GetAttributeValueText("Name");
			indx1=txt.IndexOf("Subject ")+8;
			indx2=txt.IndexOf(", Sent");
			txt2=txt.Substring(indx1,indx2-indx1);
			Report.Success(String.Format("Mail Subject - {0} opened successfully",txt2));
			
			if(txt2.Length>91)
			{
				txt2=txt2.Substring(0,15);
			}

			outlook.mailSub=txt2;
        	outlook.Outlook.DraftsFirstMail.DoubleClick();
        	Delay.Seconds(3);
        	if(outlook.DetailedView.SelfInfo.Exists(5000))
        	{
        		
        		Report.Success(String.Format("Outlook detailed view is opened successfully"));
        		Report.Success(String.Format("Outlook Text Body is - {0}",outlook.DetailedView.txtBody.GetAttributeValue<String>("Text")));
        		Validate.Exists(outlook.DetailedView.lnkPayNowInfo,"APX Paynow link is seen as expected");
        		Keyboard.Press("{ControlKey down}");
        		outlook.DetailedView.lnkPayNow.Click();
        		Keyboard.Press("{ControlKey up}");
        		Delay.Seconds(5);
        		Validate.Exists(bill.APXPayment.Jss107Jss128.ViewBillInfo,"View Bill Link is seen as expected");
        		Validate.Exists(bill.APXPayment.Jss107Jss128.btnPayNowInfo,"Pay Now Button is seen as expected");
        		Report.Success(String.Format("Due Amount for file selected is - {0}.",bill.APXPayment.Jss107Jss128.lblDueAmt.GetAttributeValue<String>("InnerText")));
        		bill.APXPayment.Jss107Jss128.txtNameoncard.PressKeys(clientName);
        		bill.APXPayment.Jss107Jss128.txtCcnumber.PressKeys("4747474747474747");
        		bill.APXPayment.Jss107Jss128.dpdwnExpiryMonth.Click();
        		Delay.Milliseconds(500);
        		bill.dpValue="12";
        		Delay.Milliseconds(500);
        		bill.APXPayment.dpdwnListItem.Click();
        		

				bill.APXPayment.Jss107Jss128.dpdwnYear.Click();
        		Delay.Milliseconds(500);
        		bill.dpValue="2021";
        		Delay.Milliseconds(500);
        		bill.APXPayment.dpdwnListItem.Click();        		
        		
        		bill.APXPayment.Jss107Jss128.dpdwnCountry.Click();
        		Delay.Milliseconds(500);
        		bill.dpValue="United States of America";
        		Delay.Milliseconds(500);
        		bill.APXPayment.dpdwnListItem.Click();  
        		
        		
        		bill.APXPayment.Jss107Jss128.dpdwnState.Click();
        		Delay.Milliseconds(500);
        		bill.dpValue="CA";
        		Delay.Milliseconds(500);
        		bill.APXPayment.dpdwnListItem.Click();  
        		bill.APXPayment.Jss107Jss128.btnPayNow.Click();
        		Delay.Seconds(5);
        		Validate.Exists(bill.APXPayment.Jss107Jss128.lblPaymentSuccessfulInfo,"Successfull Payment msg is displayed as expected");
        		Report.Success(String.Format("Payment Information - {0}",bill.APXPayment.Jss107Jss128.lblInfoTable.GetAttributeValue<String>("InnerText")));
        		bill.APXPayment.Jss107Jss128.lnkViewReceipt.Click();
        		Delay.Seconds(2);
        		paySummary=cmn.getWebTableDetails(bill.APXPayment.tbPaymentSummary);
        		Report.Success("Payment Summary Table Details"+Environment.NewLine+paySummary);
        		cmn.PrintWebTableDetails(paySummary);
        		bill.APXPayment.Self.Close();
     

        		outlook.DetailedView.Self.Close();
        		Report.Success(String.Format("Outlook detailed view is closed successfully"));
        	}
        	outlook.Outlook.DraftsFirstMail.Click();
        	Keyboard.Press("{Delete}");
        	Report.Success(String.Format("First Draft Mail deleted"));
        	outlook.Outlook.Self.Close();
        	Report.Success(String.Format("Outlook Application is closed successfully"));
        	
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
            create_PaymentReqeust();
            validateOutlookDraft();
            validateDraftMailWithAPX();
        }
    }
}
