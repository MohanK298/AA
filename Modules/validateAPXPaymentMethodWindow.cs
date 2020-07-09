/*
 * Created by Ranorex
 * User: qa
 * Date: 6/25/2020
 * Time: 5:25 PM
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
    /// Description of validateAPXPaymentMethodWindow.
    /// </summary>
    [TestModule("48AA8199-DA27-4E38-92E8-7195258F053B", ModuleType.UserCode, 1)]
    public class validateAPXPaymentMethodWindow : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public validateAPXPaymentMethodWindow()
        {
            // Do not delete - a parameterless constructor is required!
        }

        Common cmn=new Common();
        People people = People.Instance;
        string firstName="Ranorex";
        string lastName="ApxContact";
        string time=System.DateTime.Now.ToString();
        string[] colHeaders={"Type","Account","Account Name","Expiry","Default"};
        
        
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
            
            //Add Communication Details
            people.PeopleDetailForm.txtCommunicationDetails.DoubleClick();
            if(people.EditCommunicationForm.radiobtnPhone.Checked != true){
            	people.EditCommunicationForm.radiobtnPhone.Click();
            }
            
            //people.EditCommunicationForm.ComboBoxSelectContactLabel.SelectedItem.Select("Business 2");
            Delay.Seconds(5);
            people.EditCommunicationForm.txtLocalNumber.TextValue = "7459652301";
            people.EditCommunicationForm.btnEditCommunicationOK.Click();
            Delay.Seconds(2);
            
            //Add Address Details
            people.PeopleDetailForm.txtAddressDetails.DoubleClick();
            //people.EditAddressForm.PanelBase.ComboBoxSelectAddressType.SelectedItem.Selected = "Home";
			Delay.Seconds(2);
            people.EditAddressForm.PanelBase.txtStreet.TextValue = "1 Yonge Street";
            people.EditAddressForm.PanelBase.txtCity.TextValue = "SanDiego";
            people.EditAddressForm.PanelBase.txtState.TextValue = "CA";
            people.EditAddressForm.PanelBase.txtPostalCode.TextValue = "95231";
            people.EditAddressForm.PanelBase.txtCountry.TextValue = "United States";
            people.EditAddressForm.btnEditAddressFormOK.Click();
            Delay.Seconds(1);
           
          
            
            //Validation
            Validate.Exists(people.PeopleDetailForm.AddressDetails,"Address Details exists as expected ");
            Delay.Seconds(1);
            
            //Save and close
            people.PeopleDetailForm.btnSaveClose.Click();
        }
        
        
        private void validateAPXPaymentWindow()
        {
        	string fullName=firstName+" "+lastName + time;
        	people.MainForm.Self.Activate();
        	people.MainForm.Attorney.Click();
        	//Add a contact
        	people.MainForm.btnPeople.Click();
        	cmn.SelectItemFromTableDblClick(people.MainForm.PeopleIndexForm1.tblPeopleDetails,fullName,"People Details Table");
        	people.PeopleDetailForm.Actions.Click();
        	Delay.Milliseconds(500);
        	people.PeopleDetailForm.ManageAPXPaymentMethods.Click();
        	
        	if(people.APXPaymentMethodForm.SelfInfo.Exists(3000))
        	{
        		Report.Success("APX Payment Window Form is displayed as expected");
        		Validate.AttributeContains(people.APXPaymentMethodForm.titleBarInfo,"Text",fullName,String.Format("APX Payment Window Form has the expected title of the Contact selected {0}",fullName));
        		for(int i=0;i<colHeaders.Length;i++)
        		{
        			people.colName=colHeaders[i];
        			Delay.Seconds(1);
        			Validate.Exists(people.APXPaymentMethodForm.rowHeadersInfo,String.Format("Row Header {0} for the APX Payment Window Form is displayed as expected ",colHeaders[i]));
        		}
        		Validate.AttributeContains(people.APXPaymentMethodForm.Toolbar1.btnAddInfo,"Enabled","True","Add button is enabled in APX Payment Window Form by default.");
        		Validate.AttributeContains(people.APXPaymentMethodForm.Toolbar1.btnOKInfo,"Enabled","True","OK button is enabled in APX Payment Window Form by default.");
        		Validate.AttributeContains(people.APXPaymentMethodForm.Toolbar1.btnDeleteInfo,"Enabled","False","Delete button is disabled in APX Payment Window Form by default.");
        		Validate.AttributeContains(people.APXPaymentMethodForm.Toolbar1.btnSetDefaultInfo,"Enabled","False","Set Default button is disabled in APX Payment Window Form by default.");
        		
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
            AddContact();
            validateAPXPaymentWindow();
        }
    }
}
