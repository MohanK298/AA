/*
 * Created by Ranorex
 * User: qa
 * Date: 6/29/2020
 * Time: 9:50 AM
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
    /// Description of validateAddressDetailsinAPX.
    /// </summary>
    [TestModule("BD1F2BBD-3B69-44E8-B721-A180D592F78F", ModuleType.UserCode, 1)]
    public class validateAddressDetailsinAPX : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public validateAddressDetailsinAPX()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        
        
          Common cmn=new Common();
        People people = People.Instance;
        string contactDate=System.DateTime.Now.ToShortDateString();
        string fullName="";
        string street,city,state,zip,country="";
        string firstName="Ranorex";
        string lastName="BlankApxContact";
        string time=System.DateTime.Now.ToString();
        
        
        private void ValidateAddressDetailsinAPX()
        {
        	people.MainForm.Self.Activate();
        	people.MainForm.Attorney.Click();
        	//Add a contact
        	people.MainForm.btnPeople.Click();
        	cmn.SelectItemFromTableDblClick(people.MainForm.PeopleIndexForm1.tblPeopleDetails,contactDate,"People Details Table");
        	Delay.Milliseconds(500);
        	
        	people.PeopleDetailForm.lnkEdit.Click();
        	Delay.Milliseconds(500);
        	people.EditPeopleForm.firstRowAddress.DoubleClick();
        	
        	if(people.EditAddressForm.SelfInfo.Exists(3000))
        	{
        		street=people.EditAddressForm.PanelBase.txtStreetRead.GetAttributeValue<String>("Text");
        		city=people.EditAddressForm.PanelBase.txtCity.GetAttributeValue<String>("UIAutomationValueValue");
        		state=people.EditAddressForm.PanelBase.txtState.GetAttributeValue<String>("UIAutomationValueValue");
        		zip=people.EditAddressForm.PanelBase.txtPostalCode.GetAttributeValue<String>("UIAutomationValueValue");
        		country=people.EditAddressForm.PanelBase.txtCountry.GetAttributeValue<String>("UIAutomationValueValue");
        		people.EditAddressForm.btnEditAddressFormOK.Click();
        	}
        	people.EditPeopleForm.Toolbar1.btnCancel.Click();
        	
        	
        	
        	
        	
        	
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
                Validate.AttributeContains(people.APXEditPaymentMethodForm.SomeDivTag.txtNameOnCardInfo,"Value",fullName,String.Format("Name on Card for APX is auto populated as  - {0}",fullName));        		
                Validate.AttributeContains(people.APXEditPaymentMethodForm.SomeDivTag.txtBillingaddressInfo,"Value",street,String.Format("Billing Address is populated as expected from the People Details Form  - {0}",street)); 
                Validate.AttributeContains(people.APXEditPaymentMethodForm.SomeDivTag.txtCityInfo,"Value",city,String.Format("City is populated as expected from the People Details Form  - {0}",city)); 
                Validate.AttributeContains(people.APXEditPaymentMethodForm.SomeDivTag.txtZipCodeInfo,"Value",zip,String.Format("Zip Code is populated as expected from the People Details Form  - {0}",zip));
                Validate.AttributeContains(people.APXEditPaymentMethodForm.SomeDivTag.dpdwnStateSelectInfo,"InnerText",state,String.Format("State is populated as expected from the People Details Form  - {0}",state));             
                Validate.AttributeContains(people.APXEditPaymentMethodForm.SomeDivTag.dpdwnCountrySelectInfo,"InnerText",country,String.Format("Country is populated as expected from the People Details Form   - {0}",country));
                
      
                people.APXEditPaymentMethodForm.btnCancel.Click();
        		
        	}
        	if(people.APXPaymentMethodForm.SelfInfo.Exists(3000))
        	{
        		people.APXPaymentMethodForm.Toolbar1.btnOK.Click();
        	}
        	
        	people.PeopleDetailForm.btnSaveClose.Click();
        	
        	
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
            
                   //Save and close
            people.PeopleDetailForm.btnSaveClose.Click();
        }
        
         
        private void ValidateBlankAddressDetailsinAPX()
        {
         	string fullName=firstName+" "+lastName + time;
         	AddContact();
        	people.MainForm.Self.Activate();
        	people.MainForm.Attorney.Click();
        	//Add a contact
        	people.MainForm.btnPeople.Click();
        	cmn.SelectItemFromTableDblClick(people.MainForm.PeopleIndexForm1.tblPeopleDetails,fullName,"People Details Table");
        	Delay.Milliseconds(500);
        	
        	 
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
                Validate.AttributeContains(people.APXEditPaymentMethodForm.SomeDivTag.txtNameOnCardInfo,"Value",fullName,String.Format("Name on Card for APX is auto populated as  - {0}",fullName));        		
                Validate.AttributeContains(people.APXEditPaymentMethodForm.SomeDivTag.txtBillingaddressInfo,"Value","",String.Format("Billing Address is empty as expected from the People Details Form"));
                Validate.AttributeContains(people.APXEditPaymentMethodForm.SomeDivTag.txtCityInfo,"Value","",String.Format("City is empty as expected from the People Details Form"));
                Validate.AttributeContains(people.APXEditPaymentMethodForm.SomeDivTag.txtZipCodeInfo,"Value","",String.Format("Zip Code is empty as expected from the People Details Form"));
                Validate.AttributeContains(people.APXEditPaymentMethodForm.SomeDivTag.dpdwnCountrySelectInfo,"InnerText","United States",String.Format("Country is United States as default from the People Details Form"));
                
      
                people.APXEditPaymentMethodForm.btnCancel.Click();
        		
        	}
        	if(people.APXPaymentMethodForm.SelfInfo.Exists(3000))
        	{
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
            ValidateAddressDetailsinAPX();
            ValidateBlankAddressDetailsinAPX();
            cmn.ClosePrompt();
        }
    }
}
