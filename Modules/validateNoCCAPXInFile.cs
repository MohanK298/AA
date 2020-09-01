/*
 * Created by Ranorex
 * User: qa
 * Date: 7/6/2020
 * Time: 2:55 PM
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
    /// Description of validateNoCCAPXInFile.
    /// </summary>
    [TestModule("17D21928-3854-4B3D-9688-157BA02FA70F", ModuleType.UserCode, 1)]
    public class validateNoCCAPXInFile : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public validateNoCCAPXInFile()
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
        string fileName="ZZ_APX_Card_Validate_"+System.DateTime.Now.ToString();
        string firstName="Ranorex";
        string lastName="Apx_CC_Contact";
        string time=System.DateTime.Now.ToString();
        string fullName="";
        string lblmsg="Would you like to update all associated client files to automatically pay future charges by credit card / ACH?";
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
        	
//        	file.FileDetailForm.Admin.Click();
//        	file.FileDetailForm.BillSettings.Click();
//        	file.FileDetailForm.cbChargeSalesTax1.Check();
//        	file.FileDetailForm.cbChargeSalesTax2.Check();
//        	file.var="Cold call";
//        	file.FileDetailForm.Accounting.Click();
//        	file.FileDetailForm.cmbbxMatterCameToUs.Click();
//        	file.DropDownForm.TreeItem.Click();
//        	
        	
        	
        	
        	file.FileDetailForm.btnSaveClose.Click();
        	Report.Success("File Created successfully.");
    	}
        
        private void SelectPayment()
        {
        	
    		AddFile();
        	bclient.MainForm.Self.Activate();
        	bclient.MainForm.sideBILLING.Click();
        	frm.MainForm.btnOffice.Click();
        	frm.MainForm.imgReceivePayment.Click();
        	if(bill.ReceivePaymentForm.SelfInfo.Exists(3000))
        	{
        		Report.Success("Receive Payment Window Form is displayed successfully.");
        		
        		bill.ReceivePaymentForm.PnlBase.rdoFile.Click();
        		Report.Success("File Radio Button is selected successfully.");
        		bill.ReceivePaymentForm.btnSelectFile.Click();
        		
        		if(bill.FileSelectForm.SelfInfo.Exists(3000))
        		{
        			bill.FileSelectForm.btnQuickFindFile.Click();
        			
        			if(bill.FindFilesForm.SelfInfo.Exists(3000))
        			{
        				bill.FindFilesForm.searchTextInput.PressKeys(fileName);
        				
        				bill.FindFilesForm.btnOK.Click();
        			}
        			if(bill.FileSelectForm.firstRowSelectedInfo.Exists(3000))
        			{
        				bill.FileSelectForm.firstRowSelected.Click();
        				bill.FileSelectForm.btnRemoveFile.Click();
        				Report.Info("Already existing file allocation is removed in File Select Form.");
        				Delay.Seconds(1);
        			}
        			bill.FileSelectForm.listFirstFound.DoubleClick();
        		}
        		
        		bill.ReceivePaymentForm.cmbbxType.Click();
        		bill.lstdpdwnType="Credit Card Payment (APX)";
        		Delay.Milliseconds(300);
        		bill.listDropdwn.Self.Click();
        		Validate.AttributeContains(bill.ReceivePaymentForm.PnlBase.txtNoPaymentMethodInfo,"Text"," - No card on record - ","No Card on record is displayed successfully.");
        		add_Credit_Card();
        		
        		Validate.AttributeContains(bill.ReceivePaymentForm.ccNumberInfo,"Text","Visa X0086 : "+fullName,"Credit Card addeds successfully into the File.");
        		
        	}
        }
        
        private void add_Credit_Card()
        {
        	bill.ReceivePaymentForm.linkAdd.Click();
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
        		Delay.Seconds(1);
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
            SelectPayment();
            cmn.ClosePrompt();
            cmn.closeAPXPaymentForm();
        }
    }
}
