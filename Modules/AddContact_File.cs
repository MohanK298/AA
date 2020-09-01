/*
 * Created by Ranorex
 * User: qa
 * Date: 8/25/2020
 * Time: 10:48 AM
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
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of AddContact_File.
    /// </summary>
    [TestModule("8FB2511F-A0C5-4D32-A6EA-1D32F3365DC0", ModuleType.UserCode, 1)]
    public class AddContact_File : ITestModule
    {
    	
    	//Repository Variable
    	People people = People.Instance;
    	
    	
    	string _time = "";
    	[TestVariable("173126d2-febc-463d-a0c9-624063c70389")]
    	public string time
    	{
    		get { return _time; }
    		set { _time = value+"10"; }
    	}
    	
    	string _country = "";
    	[TestVariable("f6933bfd-251d-4d11-b2a2-5d5215ac1b54")]
    	public string country
    	{
    		get { return _country; }
    		set { _country = value; }
    	}
    	
    	
    	string _postalCode = "";
    	[TestVariable("dd22e2cc-a6a9-473b-8297-62418e066427")]
    	public string postalCode
    	{
    		get { return _postalCode; }
    		set { _postalCode = value; }
    	}
    	
    	string _state = "";
    	[TestVariable("3537288c-741a-4bfc-ad82-2fc4211f13ad")]
    	public string state
    	{
    		get { return _state; }
    		set { _state = value; }
    	}
    	
    	string _city = "";
    	[TestVariable("bab7a86d-7619-4353-862d-49bf8b825cd6")]
    	public string city
    	{
    		get { return _city; }
    		set { _city = value; }
    	}
    	
    	string _street = "";
    	[TestVariable("e165f4e6-3ed1-471c-8b4e-759d0e75fd42")]
    	public string street
    	{
    		get { return _street; }
    		set { _street = value; }
    	}
    	
    	string _localNumber = "";
    	[TestVariable("c1e8f858-50e6-44c5-9189-06d0a7f38b54")]
    	public string localNumber
    	{
    		get { return _localNumber; }
    		set { _localNumber = value; }
    	}
    	
    	string _lastName = "";
    	[TestVariable("fec5ac3e-d5e2-4f46-bbaf-d90eb8ec67c4")]
    	public string lastName
    	{
    		get { return _lastName; }
    		set { _lastName = value; }
    	}
    	
    	string _firstName = "";
    	[TestVariable("9adce538-23e2-43ed-803b-522d2e6049a1")]
    	public string firstName
    	{
    		get { return _firstName; }
    		set { _firstName = value; }
    	}
    	
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public AddContact_File()
        {
            // Do not delete - a parameterless constructor is required!
        }

        
        public void CreateContact_File(){
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
            if(people.PeopleDetailForm.txtCommunicationDetailsInfo.Exists(15000))
               {
               	people.PeopleDetailForm.txtCommunicationDetails.DoubleClick();
               }
            if(people.EditCommunicationForm.radiobtnPhone.Checked != true){
            	people.EditCommunicationForm.radiobtnPhone.Click();
            }
            
            //people.EditCommunicationForm.ComboBoxSelectContactLabel.SelectedItem.Select("Business 2");
            Delay.Seconds(5);
            people.EditCommunicationForm.txtLocalNumber.TextValue = localNumber;
//            people.EditCommunicationForm.radioEmail.Select();
//            people.EditCommunicationForm.txtEmailAddress.TextValue="amicustestmk1@gmail.com";
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
            CreateContact_File();
            
        }
    }
}
