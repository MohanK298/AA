/*
 * Created by Ranorex
 * User: qa
 * Date: 6/30/2020
 * Time: 12:33 PM
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
    /// Description of addPayment_EcheckACH.
    /// </summary>
    [TestModule("F81C6E0F-0995-465E-827D-587278EF12C6", ModuleType.UserCode, 1)]
    public class addPayment_EcheckACH : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public addPayment_EcheckACH()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        
        Common cmn=new Common();
        People people = People.Instance;
        
        string time=System.DateTime.Now.ToString();
        string contactDate=System.DateTime.Now.ToShortDateString();
        string fullName="";
        string lblmsg="Would you like to update all associated client files to automatically pay future charges by credit card / ACH?";
        string[] dpdwnAcctType={"Checking","Saving"};
        int rowNo=0;
        private void AddPaymentEcheckInAPX()
        {
        	people.MainForm.Self.Activate();
        	people.MainForm.Attorney.Click();
        	//Add a contact
        	people.MainForm.btnPeople.Click();
        	cmn.SelectItemFromTableDblClick(people.MainForm.PeopleIndexForm1.tblPeopleDetails,"Client PortalUser1","People Details Table");
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
        		
        		people.APXEditPaymentMethodForm.rdoACH.Click();
        		Report.Success("E-Check/ACH Radio Button is selected as expected");
        		people.APXEditPaymentMethodForm.SomeDivTag.txtAccountOrCardNumber.PressKeys("0021012345678");
        		people.APXEditPaymentMethodForm.SomeDivTag.txtRoutingNumber.PressKeys("021000021");
				people.APXEditPaymentMethodForm.SomeDivTag.dpdwnExpiryYearSelectOrAccountType.Click();
				for(int i=0;i<dpdwnAcctType.Length;i++)
				{
	        		Delay.Milliseconds(500);
	        		people.dpdwnValue=dpdwnAcctType[i];
	        		Delay.Milliseconds(500);
	        		Validate.Exists(people.APXEditPaymentMethodForm.MenuName.dpdwnSelectValueInfo,String.Format("Account Type has the drop down value {0} present in its list",dpdwnAcctType[i]));
        		}
				people.dpdwnValue=dpdwnAcctType[0];
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
        		cmn.VerifyCorrespondingDataExistsInTable(people.APXPaymentMethodForm.tblAPXDetails,dpdwnAcctType[0],fullName,"APX Card Details Table");
        		cmn.SelectItemFromTableSingleClick(people.APXPaymentMethodForm.tblAPXDetails,dpdwnAcctType[0],"APX Card Details Table");
        		people.APXPaymentMethodForm.Toolbar1.btnSetDefault.Click();
        		rowNo=cmn.GetRowNumberFromTable(people.APXPaymentMethodForm.tblAPXDetails,dpdwnAcctType[0],"APX Card Details Table");
	       		people.rowNo=rowNo.ToString();
        		Delay.Milliseconds(500);
        		Validate.AttributeContains(people.APXPaymentMethodForm.cbDefaultRowInfo,"Enabled","True",String.Format("Set Default Set to {0} ",fullName));
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
            AddPaymentEcheckInAPX();
        }
    }
}
