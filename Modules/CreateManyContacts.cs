/*
 * Created By Asish
 * User: Administrator
 * Date: 2018-01-08
 * Time: 11:32 AM
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
    /// Description of CreateManyContacts.
    /// </summary>
    [TestModule("F27FCFB2-F813-4FDC-938D-951354FF5ED6", ModuleType.UserCode, 1)]
    public class CreateManyContacts : ITestModule
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
        public CreateManyContacts()
        {
            // Do not delete - a parameterless constructor is required!
        }
		 void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            Action();
        }
        public void Action()
        {
        	//Create many Contacts
        	for (int value = 001; value <= 500; value++)
        	{
		 	
			 	//Select Attorney Module
	        	people.MainForm.Attorney.Click();
	        	//Add a contact
	        	people.MainForm.btnPeople.Click();
	        	people.MainForm.btnPeople1.Click();
	            people.MainForm.btnNew.Click();
	            people.NewPersonForm.PanelBase.txtFirstName.PressKeys("Contact");
	            //people.NewPersonForm.PanelBase.txtFirstName.TextValue = firstName;
	            people.NewPersonForm.PanelBase.txtLastName.PressKeys("Ranorex " + String.Format("{0:000}", value));
	            //people.NewPersonForm.PanelBase.txtLastName.TextValue = lastName + time;
	            
	            people.NewPersonForm.btnNext.Click();
	            
	            //Add Communication Details
	            people.PeopleDetailForm.txtCommunicationDetails.DoubleClick();
	            if(people.EditCommunicationForm.radiobtnPhone.Checked != true){
	            	people.EditCommunicationForm.radiobtnPhone.Click();
	            }
	            
	            //people.EditCommunicationForm.ComboBoxSelectContactLabel.SelectedItem.Select("Business 2");
	            Delay.Seconds(5);
	            people.EditCommunicationForm.txtLocalNumber.PressKeys("(123) 456-7890");
	            people.EditCommunicationForm.btnEditCommunicationOK.Click();
	            Delay.Seconds(5);
	            
	            //Add Address Details
	            people.PeopleDetailForm.txtAddressDetails.DoubleClick();
	            //people.EditAddressForm.PanelBase.ComboBoxSelectAddressType.SelectedItem.Selected = "Home";
				Delay.Seconds(2);
	            people.EditAddressForm.PanelBase.txtStreet.PressKeys("ABC Street");
	            people.EditAddressForm.PanelBase.txtCity.PressKeys("Toronto");
	            people.EditAddressForm.PanelBase.txtState.PressKeys("ON");
	            people.EditAddressForm.PanelBase.txtPostalCode.PressKeys("A1B 2C3");
	            people.EditAddressForm.PanelBase.txtCountry.PressKeys("Canada");
	            people.EditAddressForm.btnEditAddressFormOK.Click();
	            Delay.Seconds(3);
	            
	            //Validation
	            Validate.Exists(people.PeopleDetailForm.AddressDetails);
	            Delay.Seconds(5);
	            
	            //Save and close
	            people.PeopleDetailForm.btnSaveClose.Click();
        	}
        	
        }
        
     }
    
}
