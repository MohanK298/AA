/*
 * Created by Ranorex
 * User: qa
 * Date: 6/26/2020
 * Time: 7:06 PM
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
    /// Description of validatePaymentWindowForm.
    /// </summary>
    [TestModule("4B673AFA-66C9-42AB-AAFE-0DA757C41C92", ModuleType.UserCode, 1)]
    public class validatePaymentWindowForm : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public validatePaymentWindowForm()
        {
            // Do not delete - a parameterless constructor is required!
        }

        
        Common cmn=new Common();
        People people = People.Instance;
        string contactDate=System.DateTime.Now.ToShortDateString();
        string fullName="";
        
        private void APXManagePaymentMethod()
        {
        	people.MainForm.Self.Activate();
        	people.MainForm.Attorney.Click();
        	//Add a contact
        	people.MainForm.btnPeople.Click();
        	cmn.SelectItemFromTableDblClick(people.MainForm.PeopleIndexForm1.tblPeopleDetails,contactDate,"People Details Table");
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
        		people.APXEditPaymentMethodForm.Self.Maximize();
                Report.Success("APX Add Payment Window Form is displayed as expected");
        		Validate.AttributeContains(people.APXEditPaymentMethodForm.titleBarInfo,"Text",fullName,String.Format("APX Add Payment Window has the expected title of the Contact selected - {0}",fullName));
                Validate.AttributeContains(people.APXEditPaymentMethodForm.SomeDivTag.txtNameOnCardInfo,"Value",fullName,String.Format("Name on Card for APX is auto populated as  - {0}",fullName));        		
                
                people.APXEditPaymentMethodForm.Self.Close();
        		
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
            APXManagePaymentMethod();
        }
    }
}
