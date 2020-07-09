/*
 * Created by Ranorex
 * User: hpatel
 * Date: 7/24/2015
 * Time: 9:27 AM
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
    /// Description of AddContact.
    /// </summary>
    [TestModule("DDA35EBD-1890-4F5F-B289-6DE2D6689430", ModuleType.UserCode, 1)]
    public class AddContact : ITestModule
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
    	
        // Constructs a new instance.
        public AddContact()
        {
            // Do not delete - a parameterless constructor is required!
        }
		
        public void CreateContact(){
        	//Select Attorney Module
        	people.MainForm.Self.Activate();
        	people.MainForm.Attorney.Click();
        	//Add a contact
        	//people.MainForm.btnPeople.Click();
        	people.MainForm.btnPeople1.Click();
            people.MainForm.btnNew.Click();
            people.NewPersonForm.PanelBase.rdoNew.Select();
            people.NewPersonForm.PanelBase.txtFirstName.PressKeys(firstName);
            people.NewPersonForm.PanelBase.txtLastName.PressKeys(lastName + time);
            
            people.NewPersonForm.btnNext.Click();
            Delay.Seconds(3);
            //Add Communication Details
            if(people.PeopleDetailForm.txtCommunicationDetailsInfo.Exists(5000))
               {
               	people.PeopleDetailForm.txtCommunicationDetails.DoubleClick();
               }
            if(people.EditCommunicationForm.radiobtnPhone.Checked != true){
            	people.EditCommunicationForm.radiobtnPhone.Click();
            }
            
            //people.EditCommunicationForm.ComboBoxSelectContactLabel.SelectedItem.Select("Business 2");
            Delay.Seconds(5);
            people.EditCommunicationForm.txtLocalNumber.TextValue = localNumber;
            people.EditCommunicationForm.radioEmail.Select();
            people.EditCommunicationForm.txtEmailAddress.TextValue="amicustestmk1@gmail.com";
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
            
            //Validation
            Validate.Exists(people.PeopleDetailForm.AddressDetails);
            Delay.Seconds(10);
            
            //Save and close
            people.PeopleDetailForm.btnSaveClose.Click();
        }
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 500;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            CreateContact();
         //   Utilities.Common.ClosePrompt();
        }
    }
}
