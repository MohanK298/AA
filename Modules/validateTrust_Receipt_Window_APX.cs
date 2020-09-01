/*
 * Created by Ranorex
 * User: qa
 * Date: 7/9/2020
 * Time: 3:47 PM
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
using SmokeTest.Modules.Utilities;
using SmokeTest.Repositories;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of validateTrust_Receipt_Window_APX.
    /// </summary>
    [TestModule("DD3BA305-E2AD-4580-B2CF-F085AAF1E48B", ModuleType.UserCode, 1)]
    public class validateTrust_Receipt_Window_APX : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public validateTrust_Receipt_Window_APX()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        Common cmn=new Common();
        BillingClient bclient=BillingClient.Instance;
        BillingFile file = BillingFile.Instance;
        FirmSettings frm=FirmSettings.Instance;
        BillingTE te = BillingTE.Instance;
        Bill bill = Bill.Instance;
        People people = People.Instance;
        Trust trst=Trust.Instance;
        string fileName="ZZ_APX_TrustReceipt_Validate_"+System.DateTime.Now.ToString();
        string firstName="Ranorex";
        string lastName="Apx_TrustReceipt_Contact";
        string time=System.DateTime.Now.ToString();
        string fullName="";
        string lblmsg="Would you like to update all associated client files to automatically pay future charges by credit card / ACH?";
        string[] methodItems={"Check","Cash","Credit Card Payment (APX)","ACH Payment (APX)","Credit Card (Manual)","Electronic","Other"};
        string txtmsg="The amount on Credit Card Payment (APX) and ACH Payment (APX) must be positive.";
        string data="Retainer_APX_: "+System.DateTime.Now.ToString();
        string payMsg="A charge for $1.00 will now be run on the Visa card ending in 0086 belonging to ";
        string payDone="Payment Processed"+Environment.NewLine+Environment.NewLine+"Successful credit card transaction for $1.00.";
        string txtvoidPayment="Are you sure you wish to Void this $1.00 Credit Card transaction?";
        private void AddFile()
    	{
        	AddContact();
        
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
			file.PeopleSelectForm.btnQuickFind.Click();
        	file.FindContactsForm.txtFindContact.TextValue = lastName + time;
        	file.FindContactsForm.btnOK.Click();
        	
        	file.PeopleSelectForm.listFirstValue.Click();
        	file.PeopleSelectForm.btnAddToRight.Click();
        	file.PeopleSelectForm.btnOK.Click();
        	
        	
        	file.NewFileForm.btnSaveOpen.Click();
        	
      	
        	
        	file.FileDetailForm.btnSaveClose.Click();
        	Report.Success("File Created successfully.");
    	}

        
        	private void AddContact()
	        {
	        		people.MainForm.Attorney.Click();
	        	//Add a contact
	        	people.MainForm.btnPeople.Click();
	        	people.MainForm.btnPeople1.Click();
	            people.MainForm.btnNew.Click();
	            people.NewPersonForm.PanelBase.rdoNew.Select();
	            people.NewPersonForm.PanelBase.txtFirstName.TextValue = firstName;
	            people.NewPersonForm.PanelBase.txtLastName.TextValue = lastName + time;
	            
	            people.NewPersonForm.btnNext.Click();
	            
	            
	            Delay.Milliseconds(500);
	            people.PeopleDetailForm.lnkEdit.Click();
	        	Delay.Milliseconds(500);
	        	people.EditPeopleForm.btnNewAddress.Click();
	        	
	        	if(people.EditAddressForm.SelfInfo.Exists(3000))
	        	{
	        		people.EditAddressForm.PanelBase.txtStreet.PressKeys("1 Van Allan Road");
	        		people.EditAddressForm.PanelBase.txtCity.PressKeys("SanDeigo");
	        		people.EditAddressForm.PanelBase.txtState.PressKeys("CA");
	        		people.EditAddressForm.PanelBase.txtPostalCode.PressKeys("95231");
	        		people.EditAddressForm.PanelBase.txtCountry.PressKeys("United States");
	        		people.EditAddressForm.btnEditAddressFormOK.Click();
	        	}
	        	people.EditPeopleForm.Toolbar1.btnSave.Click();
	        	
	        	
	        	fullName=people.PeopleDetailForm.title.GetAttributeValue<String>("Text");
	            
	                   //Save and close
	            people.PeopleDetailForm.btnSaveClose.Click();
	            Report.Success("Contact Created successfully.");
	        }
        	
        	
        	
        	
        private void trustReceipt_APX()
        {
        	
    		AddFile();
        	bclient.MainForm.Self.Activate();
        	bclient.MainForm.sideBILLING.Click();
        	frm.MainForm.btnOffice.Click();
        	frm.MainForm.imgTrustReceipt.Click();
        	
        	if(trst.TrustDetailBaseForm.SelfInfo.Exists(3000))
        	{
        		Report.Success("Trust Receipt Form is displayed successfully");
        		//cmn.SelectItemDropdown(trst.TrustDetailBaseForm.PnlBase.cmbbxReceiptTo,"1 - Trust","Receipt to Dropdown");
        		Delay.Milliseconds(500);
        		Validate.AttributeContains(trst.TrustDetailBaseForm.PnlBase.cmbbxReceiptToInfo,"Text","1 - Trust (APX Enabled)","Receipt To Dropdown has the value 1 - Trust (APX Enabled) Selected");
        		Validate.AttributeContains(trst.TrustDetailBaseForm.PnlBase.txtDateInfo,"UIAutomationValueValue",System.DateTime.Now.ToString("M/d/yyyy"));
        		//,"Today's Date is set to Default");
        		Report.Success(String.Format("Receipt Id seen for the current Trust Receipt Form is: {0}",trst.TrustDetailBaseForm.PnlBase.txtReceiptId.GetAttributeValue<String>("UIAutomationValueValue")));
        		Validate.AttributeContains(trst.TrustDetailBaseForm.PnlBase.txtDescriptionInfo,"UIAutomationValueValue","Retainer",String.Format("Description for Trust Receipts is: {0}",trst.TrustDetailBaseForm.PnlBase.txtDescription.GetAttributeValue<String>("UIAutomationValueValue")));
        		trst.TrustDetailBaseForm.PnlBase.txtDescription.PressKeys(data);
        		trst.TrustDetailBaseForm.PnlBase.cmbbxMethod.Click();
        		for(int i=0;i<methodItems.Length;i++)
        		{
        			trst.var=methodItems[i];
        			Delay.Milliseconds(300);
        			Validate.Exists(trst.DropDownForm.treeItemInfo,String.Format("Item {0} is present in the Method Dropdown as expected",methodItems[i]));
        			
        		}
        		trst.TrustDetailBaseForm.PnlBase.cmbbxMethod.Click();
        		
        		Validate.AttributeContains(trst.TrustDetailBaseForm.PnlBase.cmbbxMethodInfo,"Text","Check","Method Dropdown has the value Check Selected as default");
        		
        		
        		trst.TrustDetailBaseForm.PnlBase.imgAddFile.Click();
        		if(trst.FileSelectForm.SelfInfo.Exists(3000))
        		{
        			trst.FileSelectForm.btnQuickFindFile.Click();
        			if(trst.FindFilesForm.SelfInfo.Exists(3000))
        			{
        				trst.FindFilesForm.searchTextInput.PressKeys(fileName);
        				trst.FindFilesForm.btnOK.Click();
        			}
        			trst.FileSelectForm.listFirstFound.DoubleClick();
        		}
        		
        		
        		
        		
        		trst.TrustDetailBaseForm.PnlBase.cmbbxMethod.Click();
        		Delay.Milliseconds(500);
        		trst.var="Credit Card Payment (APX)";
        		Delay.Milliseconds(500);
        		trst.DropDownForm.treeItem.Click();
        	
        		Validate.AttributeContains(trst.TrustDetailBaseForm.PnlBase.txtNoPaymentMethodInfo,"Text"," - No card on record - ","No Card on record is displayed successfully.");
        		add_Credit_Card();
        		
        		Validate.AttributeContains(trst.TrustDetailBaseForm.PnlBase.ccNumberInfo,"Text","Visa X0086 : "+fullName,"Credit Card addeds successfully into the File.");
        		
        		payTrust();
        		validateTrustPaymntOnFile();
        		
        		
        	}
        }
        
        
         private void validateTrustPaymntOnFile()
        {
        	bclient.MainForm.Self.Activate();
        	bclient.MainForm.sideBILLING.Click();
        	
        	
        	
        	file.MainForm.btnFiles.Click();
        	cmn.SelectItemFromTableDblClick(file.MainForm.FilesIndexForm.tblFiles,fileName,"File Details Table");
        	
        	file.FileDetailForm.Trust.Click();
        	cmn.VerifyCorrespondingDataExistsInTable(file.FileDetailForm.PanelRight.tblFileDetails,System.DateTime.Now.ToString("MMM dd/yy"),"1.00","File Details Table");
        	cmn.SelectItemFromTableDblClick(file.FileDetailForm.PanelRight.tblFileDetails,System.DateTime.Now.ToString("MMM dd/yy"),"File Details Table");
        	Report.Success(String.Format("Confirmation message of APX Payment with  -  {0} ",trst.TrustDetailBaseForm.PnlBase.txtConfirmationNo.GetAttributeValue<String>("Text")));
        	if(trst.TrustDetailBaseForm.btnVoidInfo.Exists(5000))
        	{
        	Validate.Exists(trst.TrustDetailBaseForm.btnVoidInfo,"Void Button exists as expected");
        	Delay.Seconds(5);
        	trst.TrustDetailBaseForm.btnVoid.Click();
        	Report.Success("Void Button is clicked");
        	if(bill.PromptForm.SelfInfo.Exists(10000))
               {
                   	
               	Validate.AttributeContains(bill.PromptForm.txtMsgPromptInfo,"Text",txtvoidPayment,String.Format("Prompt Message {0} is displayed successfully",txtvoidPayment));
               	Report.Success(bill.PromptForm.txtMsgPrompt.GetAttributeValue<String>("Text"));
               	bill.PromptForm.btnYes.Click();
						                   	
               } 
        	Delay.Seconds(2);
        	if(bill.PromptForm.SelfInfo.Exists(10000))
               {
                   	
//               	Validate.AttributeContains(bill.PromptForm.txtMsgPromptInfo,"Text",txtvoidPaymentConfirmation,String.Format("Prompt Message {0} is displayed successfully",txtvoidPaymentConfirmation));
			Report.Success(bill.PromptForm.txtMsgPrompt.GetAttributeValue<String>("Text"));
               	bill.PromptForm.btnOk.Click();
						                   	
               } 
        }
        	cmn.SelectItemFromTableDblClick(file.FileDetailForm.PanelRight.tblFileDetails,System.DateTime.Now.ToString("MMM dd/yy"),"File Details Table");
        	Report.Success(String.Format("Confirmation message of APX Trust Payment Voided  -  {0} ",trst.TrustDetailBaseForm.PnlBase.txtConfirmationNo.GetAttributeValue<String>("Text")));
        	if(trst.TrustDetailBaseForm.SelfInfo.Exists(3000))
        	{
        		if(trst.TrustDetailBaseForm.btnCloseInfo.Exists(3000))
        		{
        			trst.TrustDetailBaseForm.btnClose.Click();
        			Report.Success("APX Payment is voided as expected");
        		}
        		else
        		{
        			trst.TrustDetailBaseForm.btnSaveClose.Click();
        			Report.Info("APX Payment is not voided as expected");
        			
        		}
        		
        	}
        	bill.FileDetailForm.saveClose.Click();
        	
        	
        	
        		

        }
        
        
        private void payTrust()
        {
        	
        	trst.TrustDetailBaseForm.btnPayNow.Click();
        	 if(trst.PromptForm.SelfInfo.Exists(3000))
               {
                   	
               	Validate.AttributeContains(trst.PromptForm.txtMsgPromptInfo,"Text",txtmsg,String.Format("Prompt Message {0} is displayed successfully",txtmsg));
               	trst.PromptForm.btnOk.Click();
						                   	
               }
        	 
        	 	trst.TrustDetailBaseForm.PnlBase.txtInputAmt.PressKeys("1.00");
        		Report.Success("$1.00 added to the Amount Field");
 				trst.TrustDetailBaseForm.btnPayNow.Click();
				if(trst.PromptForm.SelfInfo.Exists(3000))
               {
                   	
               	Validate.AttributeContains(trst.PromptForm.txtMsgPromptInfo,"Text",payMsg,String.Format("Prompt Message {0} is displayed successfully",payMsg));
               	people.PromptForm.btnYes.Click();
						                   	
               }   		

				if(trst.PromptForm.SelfInfo.Exists(10000))
               {
                   	
               	Validate.AttributeContains(trst.PromptForm.txtMsgPromptInfo,"Text",payDone,String.Format("Prompt Message {0} is displayed successfully",payDone));
               	Report.Success(trst.PromptForm.txtMsgPrompt.GetAttributeValue<String>("Text"));
               	bill.PromptForm.btnOk.Click();
						                   	
               }  	
        
        }
        
        private void add_Credit_Card()
        {
        	trst.TrustDetailBaseForm.PnlBase.linkAdd.Click();
        	if(bill.PromptForm.SelfInfo.Exists(3000))
    		{
    			Validate.AttributeContains(bill.PromptForm.txtMsgPromptInfo,"Text","This Credit Card / ACH Information will be added to the primary client on this file."+Environment.NewLine+Environment.NewLine+"Do you want to proceed?","Message is displayed correctly as expected for Adding Credit Card");
    			bill.PromptForm.btnYes.Click();
    		}
        	
        	if(people.APXEditPaymentMethodForm.SelfInfo.Exists(5000))
        	{
        	
                Report.Success("APX Add Payment Window Form is displayed as expected");
                people.APXEditPaymentMethodForm.Self.Maximize();
        		Validate.AttributeContains(people.APXEditPaymentMethodForm.titleBarInfo,"Text",fullName,String.Format("APX Add Payment Window has the expected title of the Contact selected - {0}",fullName));
        		
        		people.APXEditPaymentMethodForm.rdoCreditCard.Click();
        		Report.Success("Credit Card Radio Button is selected as expected");
        		people.APXEditPaymentMethodForm.SomeDivTag.txtAccountOrCardNumber.PressKeys("4900000000000086");
        		people.APXEditPaymentMethodForm.SomeDivTag.dpdwnExpiryMonthSelect.Click();
        		Delay.Milliseconds(500);
        		people.dpdwnValue="12";
        		Delay.Milliseconds(500);
        		people.APXEditPaymentMethodForm.MenuName.dpdwnSelectValue.Click();
        		
        		
        		people.APXEditPaymentMethodForm.SomeDivTag.dpdwnExpiryYearSelectOrAccountType.Click();
        		Delay.Milliseconds(500);
        		people.dpdwnValue="2021";
        		Delay.Milliseconds(500);
        		people.APXEditPaymentMethodForm.MenuName.dpdwnSelectValue.Click();
        		
        			
                people.APXEditPaymentMethodForm.SomeDivTag.btnSubmit.Click();
                Report.Success("Submit Button is clicked in APX Window");
                
                if(people.PromptForm.SelfInfo.Exists(3000))
               {
                   	
               	Validate.AttributeContains(people.PromptForm.lblMsgInfo,"Text",lblmsg,String.Format("Prompt Message {0} is displayed successfully",lblmsg));
               	people.PromptForm.btnYes.Click();
						                   	
               }
        	
        	
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
            trustReceipt_APX();
            cmn.ClosePrompt();
        }
    }
}
