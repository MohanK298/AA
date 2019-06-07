/*
 * Created By Asish
 * User: Administrator
 * Date: 2018-01-09
 * Time: 10:22 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
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

using SmokeTest.Repositories;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of AddContactAPX.
    /// </summary>
    [TestModule("6E757CB4-BF7C-4EFF-AB75-0E4532A306F5", ModuleType.UserCode, 1)]
    public class AddContactAPX : ITestModule
    {
       //Repository Variable
    	People people = People.Instance;
    	
    	
    	string _time = "";
    	[TestVariable("B1EA9EEA-A648-4FEE-9045-B21AF52419E0")]
    	public string time
    	{
    		set { 
    			_time = " " + System.DateTime.Now.ToString(); 
    			_time = _time.Replace("/", string.Empty);
    			_time = _time.Replace(":", string.Empty);
    			_time = _time.Replace(" ", string.Empty);
    		}
    		get { return _time; }	
    	}
    	
    	string _country = "";
    	[TestVariable("0AF87A5B-ABC2-4FF9-BD2B-EF74D1929F88")]
    	public string country
    	{
    		get { return _country; }
    		set { _country = value; }
    	}
    	
    	string _postalCode = "";
        [TestVariable("CA072413-3D23-4C82-A59D-3031FA9E838B")]
        public string postalCode
        {
        	get { return _postalCode; }
        	set { _postalCode = value; }
        }
        
    	string _state = "";
    	[TestVariable("0B12E082-366C-4A05-AAF6-46196305C61D")]
    	public string state
    	{
    		get { return _state; }
    		set { _state = value; }
    	}
    	
    	string _city = "";
    	[TestVariable("DFC0E097-690F-488B-BAD2-F52246959EFE")]
    	public string city
    	{
    		get { return _city; }
    		set { _city = value; }
    	}
    	
    	
    	string _street = "";
    	[TestVariable("5936C360-EDFC-43C3-9D48-106B9D7A214D")]
    	public string street
    	{
    		get { return _street; }
    		set { _street = value; }
    	}
    	
    	string _localNumber = "";
    	[TestVariable("B9FACA39-46B4-4E6D-9EC5-B397F777DB32")]
    	public string localNumber
    	{
    		get { return _localNumber; }
    		set { _localNumber = value; }
    	}
    	
    	string _lastName = "";
    	[TestVariable("5AD7F1EC-8C95-4CDC-A57D-47C6033E0376")]
    	public string lastName
    	{
    		get { return _lastName; }
    		set { _lastName = value; }
    	}
    	
    	string _firstName = "";
    	[TestVariable("83BE006F-C03C-462C-99FC-F76FCC20CE2A")]
    	public string firstName
    	{
    		get { return _firstName; }
    		set { _firstName = value; }
    	}
    	
    	
    	string _ccNumber = "";
    	[TestVariable("01334ab6-c51d-4597-97f8-9bbb150c6159")]
    	public string ccNumber
    	{
    		get { return _ccNumber; }
    		set { _ccNumber = value; }
    	}
    	
    	
    	string _ccCVV = "";
    	[TestVariable("52f432c6-757f-4b1c-aa6a-8211f83ddcb3")]
    	public string ccCVV
    	{
    		get { return _ccCVV; }
    		set { _ccCVV = value; }
    	}
    	
    	
    	
        public AddContactAPX()
        {
            // Do not delete - a parameterless constructor is required!
        }

         public void CreateContact(){
        	//Select Attorney Module
	       	people.MainForm.Attorney.Click();
        	//Add a contact
        	people.MainForm.btnPeople.Click();
        	people.MainForm.btnPeople1.Click();
            people.MainForm.btnNew.Click();
            people.NewPersonForm.PanelBase.txtFirstName.TextValue = firstName;
            people.NewPersonForm.PanelBase.txtLastName.TextValue = lastName + time;
            
            people.NewPersonForm.btnNext.Click();
            
            //Add Communication Details
            people.PeopleDetailForm.txtCommunicationDetails.DoubleClick();
            if(people.EditCommunicationForm.radiobtnPhone.Checked != true){
            	people.EditCommunicationForm.radiobtnPhone.Click();
            }
            
            //people.EditCommunicationForm.ComboBoxSelectContactLabel.SelectedItem.Select("Business 2");
            Delay.Seconds(5);
            people.EditCommunicationForm.txtLocalNumber.TextValue = localNumber;
            people.EditCommunicationForm.btnEditCommunicationOK.Click();
            Delay.Seconds(5);
            
            //Add Address Details
            people.PeopleDetailForm.txtAddressDetails.DoubleClick();
            //people.EditAddressForm.PanelBase.ComboBoxSelectAddressType.SelectedItem.Selected = "Home";
			Delay.Seconds(2);
            people.EditAddressForm.PanelBase.txtStreet.TextValue = street;
            people.EditAddressForm.PanelBase.txtCity.TextValue = city;
            people.EditAddressForm.PanelBase.txtState.TextValue = state;
            people.EditAddressForm.PanelBase.txtPostalCode.TextValue = postalCode;
            people.EditAddressForm.PanelBase.txtCountry.TextValue = country;
            people.EditAddressForm.btnEditAddressFormOK.Click();
            Delay.Seconds(3);
           
            people.PeopleDetailForm.ActionBtn.Click();
            people.PeopleDetailForm.ActionBtn.Select();
            Report.Log(ReportLevel.Info, "Manage APX menu item exists?  " + people.PeopleDetailForm.ManageAPXPaymentMethodsInfo.Exists());
            people.PeopleDetailForm.ManageAPXPaymentMethods.Click();
            Report.Log(ReportLevel.Info, "After select the Manage APX, APX form focused? " + people.APXPaymentMethodForm.Self.HasFocus);
            people.APXPaymentMethodForm.Self.Activate();
            Report.Log(ReportLevel.Info, "After select the Manage APX, APX form shows? " + people.APXPaymentMethodForm.SelfInfo.Exists());
            Report.Log(ReportLevel.Info, "Add payment method button exists? " + people.APXPaymentMethodForm.btnAddInfo.Exists());
            people.APXPaymentMethodForm.btnAdd.Click();
            people.apxtestabacusnext.ccNumber.PressKeys("375987654321004");
        	people.apxtestabacusnext.selectMonth.Click();
        	people.apxtestabacusnext.MonthValue.Click();
			people.apxtestabacusnext.selectYear.Click();
            people.apxtestabacusnext.YearValue.Click();
            people.apxtestabacusnext.selectState.Click();
            people.apxtestabacusnext.StateValue.Click();
//            people.apxtestabacusnext.billingAddress.PressKeys("1 Yonge St");
//            people.apxtestabacusnext.city.PressKeys("Toronto");
//            people.apxtestabacusnext.txtZip.PressKeys("12345");
            people.apxtestabacusnext.btnSubmit.Click();
//            Validate.Exists(bill.ReceivePaymentForm.ccAMEXInfo);
//            bill.ReceivePaymentForm.enterAmount.PressKeys("2.30");
//        	bill.ReceivePaymentForm.PayNow.Click();
//        	Validate.Exists(bill.PromptForm.AmountTxtInfo);
//        	bill.PromptForm.btnYes1.Click();
			people.PromptForm.btnYes.Click();
            Validate.Exists(people.APXPaymentMethodForm.ccTypeInfo);
            people.APXPaymentMethodForm.btnOk.Click();
            
            //Validation
            Validate.Exists(people.PeopleDetailForm.AddressDetails);
            Delay.Seconds(5);
            
            //Save and close
            people.PeopleDetailForm.btnSaveClose.Click();
        }
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            CreateContact();
        }
    }
}
