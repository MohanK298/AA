/*
 * Created By Asish
 * User: Administrator
 * Date: 2018-01-15
 * Time: 10:46 AM
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
    /// Description of BillContactAPX.
    /// </summary>
    [TestModule("7F6F4771-7DF2-4F29-BB04-8B5FDAAD0106", ModuleType.UserCode, 1)]
    public class BillContactAPX : ITestModule
    {
        BillingClient client = BillingClient.Instance;
    	
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
        public BillContactAPX()
        {
            // Do not delete - a parameterless constructor is required!
        }
        public void Perform()
        {
        	//Add a contact
        	client.MainForm.sideBILLING.Click();
        	
        	client.MainForm.btnClients1.Click();
            client.MainForm.btnNew.Click();
            client.NewPersonForm.txtFirstName.TextValue = firstName;
            client.NewPersonForm.txtLastName.TextValue = lastName + time;
            
            client.NewPersonForm.btnNext.Click();
            
            client.PeopleDetailForm.listCommunicationDetails.DoubleClick();
            Delay.Seconds(1);
            client.EditCommunicationForm.txtLocalNumber.TextValue = localNumber;
            client.EditCommunicationForm.btnOK.Click();
            Delay.Seconds(1);
            
            //Add Address Details
            client.PeopleDetailForm.listAddressDetails.DoubleClick();
            //people.EditAddressForm.PanelBase.ComboBoxSelectAddressType.SelectedItem.Selected = "Home";
			Delay.Seconds(2);
            client.EditAddressForm.PanelBase.txtStreet.TextValue = street;
            client.EditAddressForm.PanelBase.txtCity.TextValue = city;
            client.EditAddressForm.PanelBase.txtState.TextValue = state;
            client.EditAddressForm.PanelBase.txtPostalCode.TextValue = postalCode;
            client.EditAddressForm.PanelBase.txtCountry.TextValue = country;
            client.EditAddressForm.btnOK.Click();
            Delay.Seconds(3);
            
            //Validation
            Validate.Exists(client.PeopleDetailForm.listAddressDetails);
            Delay.Seconds(5);
            
            //Save and close
            client.PeopleDetailForm.btnSaveClose.Click();	
        }
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            Perform();
        }
    }
}
