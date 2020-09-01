/*
 * Created by Ranorex
 * User: qa
 * Date: 6/30/2020
 * Time: 10:35 AM
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
    /// Description of addPaymentCreditCard.
    /// </summary>
    [TestModule("B5F7BEAA-8E2D-4618-86CA-1D5CE4DE0CB6", ModuleType.UserCode, 1)]
    public class addPaymentCreditCard : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public addPaymentCreditCard()
        {
            // Do not delete - a parameterless constructor is required!
        }

        
        
        
        Common cmn=new Common();
        People people = People.Instance;
        
        string time=System.DateTime.Now.ToString();
        string contactDate=System.DateTime.Now.ToShortDateString();
        string fullName="";
        string lblmsg="Would you like to update all associated client files to automatically pay future charges by credit card / ACH?";
        private void AddPaymentCCInAPX()
        {
        	people.MainForm.Self.Activate();
        	people.MainForm.Attorney.Click();
        	//Add a contact
        	people.MainForm.btnPeople.Click();
        	cmn.SelectItemFromTableDblClick(people.MainForm.PeopleIndexForm1.tblPeopleDetails,"Client PortalUser1","People Details Table");
        	Delay.Milliseconds(500);
        	
//        	people.PeopleDetailForm.lnkEdit.Click();
//        	Delay.Milliseconds(500);
//        	people.EditPeopleForm.btnNewAddress.Click();
//        	
//        	if(people.EditAddressForm.SelfInfo.Exists(3000))
//        	{
//        		people.EditAddressForm.PanelBase.txtStreet.PressKeys("1 Yonge Street");
//        		people.EditAddressForm.PanelBase.txtCity.PressKeys("SanDeigo");
//        		people.EditAddressForm.PanelBase.txtState.PressKeys("CA");
//        		people.EditAddressForm.PanelBase.txtPostalCode.PressKeys("95231");
//        		people.EditAddressForm.PanelBase.txtCountry.PressKeys("United States");
//        		people.EditAddressForm.btnEditAddressFormOK.Click();
//        	}
//        	people.EditPeopleForm.Toolbar1.btnSave.Click();
//        	
        	
        	fullName=people.PeopleDetailForm.title.GetAttributeValue<String>("Text");
        	people.PeopleDetailForm.Actions.Click();
        	Delay.Milliseconds(500); 
        	people.PeopleDetailForm.ManageAPXPaymentMethods.Click();
        	
        	if(people.APXPaymentMethodForm.SelfInfo.Exists(3000))
        	{
        		Report.Success("APX Payment Window Form is displayed as expected");
        		people.APXPaymentMethodForm.Toolbar1.btnAdd.Click();
        	}
        	
        	if(people.APXEditPaymentMethodForm.SelfInfo.Exists(5000))
        	{
        	
                Report.Success("APX Add Payment Window Form is displayed as expected");
        		Validate.AttributeContains(people.APXEditPaymentMethodForm.titleBarInfo,"Text",fullName,String.Format("APX Add Payment Window has the expected title of the Contact selected - {0}",fullName));
        		people.APXEditPaymentMethodForm.Self.Maximize();
        		people.APXEditPaymentMethodForm.rdoCreditCard.Click();
        		Report.Success("Credit Card Radio Button is selected as expected");
        		people.APXEditPaymentMethodForm.SomeDivTag.txtAccountOrCardNumber.PressKeys("4747474747474747");
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
        	if(people.APXPaymentMethodForm.SelfInfo.Exists(3000))
        	{
        		cmn.VerifyDataExistsInTable(people.APXPaymentMethodForm.tblAPXDetails,fullName,"APX Card Details Table");
        		people.APXPaymentMethodForm.Toolbar1.btnOK.Click();
        		
        	}
        	
        	people.PeopleDetailForm.btnSaveClose.Click();
        	
        	
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
            AddPaymentCCInAPX();
        }
    }
}
