/*
 * Created by Ranorex
 * User: qa
 * Date: 6/29/2020
 * Time: 5:16 PM
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
    /// Description of validateButtonsInAPXForm.
    /// </summary>
    [TestModule("8A53705E-62B3-489E-AA94-259043EF912D", ModuleType.UserCode, 1)]
    public class validateButtonsInAPXForm : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public validateButtonsInAPXForm()
        {
            // Do not delete - a parameterless constructor is required!
        }

        Common cmn=new Common();
        People people = People.Instance;
        
        string time=System.DateTime.Now.ToString();
        string contactDate=System.DateTime.Now.ToShortDateString();
        string fullName="";
        
        private void ValidateButtonsinAPX()
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
        	
                Report.Success("APX Add Payment Window Form is displayed as expected");
        		Validate.AttributeContains(people.APXEditPaymentMethodForm.titleBarInfo,"Text",fullName,String.Format("APX Add Payment Window has the expected title of the Contact selected - {0}",fullName));
              
                Validate.AttributeContains(people.APXEditPaymentMethodForm.SomeDivTag.btnSubmitInfo,"Enabled","True",String.Format("Submit button is enabled as expected"));             
                Validate.AttributeContains(people.APXEditPaymentMethodForm.btnCancelInfo,"Enabled","True",String.Format("Cancel Link is enabled as expected"));
                
      
                people.APXEditPaymentMethodForm.btnCancel.Click();
                Report.Success("Cancel Link is clicked in APX Window");
        		
        	}
        	if(people.APXPaymentMethodForm.SelfInfo.Exists(3000))
        	{
        		cmn.VerifyDataNotExistsInTable(people.APXPaymentMethodForm.tblAPXDetails,fullName,"APX Details Table");
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
            ValidateButtonsinAPX();
        }
    }
}
