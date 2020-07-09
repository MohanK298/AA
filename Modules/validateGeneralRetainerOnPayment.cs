/*
 * Created by Ranorex
 * User: qa
 * Date: 7/8/2020
 * Time: 8:52 PM
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
    /// Description of validateGeneralRetainerOnPayment.
    /// </summary>
    [TestModule("2709653E-6432-40A0-A20A-D32C8BF87027", ModuleType.UserCode, 1)]
    public class validateGeneralRetainerOnPayment : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public validateGeneralRetainerOnPayment()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        
        
        Common cmn=new Common();
        BillingClient bclient=BillingClient.Instance;
        BillingFile file = BillingFile.Instance;
        FirmSettings frm=FirmSettings.Instance;
        BillingTE te = BillingTE.Instance;
        Bill bill = Bill.Instance;
        People people = People.Instance;
        string txtvoidPayment="Are you sure you wish to Void this $1.00 Credit Card transaction?";
        string txtvoidPaymentConfirmation="The payment has now been voided."+Environment.NewLine+Environment.NewLine+"Confirmation #:";
        
        private void validateGeneralRetainer()
        {
        	bclient.MainForm.Self.Activate();
        	bclient.MainForm.sideBILLING.Click();
        	
        	
        	
        	file.MainForm.btnFiles.Click();
        	cmn.SelectItemFromTableDblClick(file.MainForm.FilesIndexForm.tblFiles,"Ranorex_General_Retainment_"+System.DateTime.Now.ToShortDateString(),"File Details Table");
        	
        	file.FileDetailForm.GeneralRetainers.Click();
        	cmn.VerifyCorrespondingDataExistsInTable(file.FileDetailForm.PanelRight.tblFileDetails,System.DateTime.Now.ToString("MMM dd/yy"),"1.00","File Details Table");
        	cmn.SelectItemFromTableDblClick(file.FileDetailForm.PanelRight.tblFileDetails,System.DateTime.Now.ToString("MMM dd/yy"),"File Details Table");
        	Report.Success(String.Format("Confirmation message of APX Payment with  -  {0} ",bill.ReceivePaymentForm.PnlBase.txtConfirmationNo.GetAttributeValue<String>("Text")));
        	if(bill.ReceivePaymentForm.btnVoidInfo.Exists(5000))
        	{
        	Validate.Exists(bill.ReceivePaymentForm.btnVoidInfo,"Void Button exists as expected");
        	Delay.Seconds(2);
        	bill.ReceivePaymentForm.btnVoid.Click();
        	
        	if(bill.PromptForm.SelfInfo.Exists(10000))
               {
                   	
               	Validate.AttributeContains(bill.PromptForm.txtMsgPromptInfo,"Text",txtvoidPayment,String.Format("Prompt Message {0} is displayed successfully",txtvoidPayment));
               	Report.Success(bill.PromptForm.txtMsgPrompt.GetAttributeValue<String>("Text"));
               	bill.PromptForm.btnYes.Click();
						                   	
               } 
        	Delay.Seconds(2);
        	if(bill.PromptForm.SelfInfo.Exists(10000))
               {
                   	
//               	Validate.AttributeContains(bill.PromptForm.txtMsgPromptInfo,"Text",txtvoidPaymentConfirmation,String.Format("Prompt Message {0} is displayed successfully",txtvoidPaymentConfirmation));
			Report.Success(bill.PromptForm.txtMsgPrompt.GetAttributeValue<String>("Text"));
               	bill.PromptForm.btnOk.Click();
						                   	
               } 
        }
        	cmn.SelectItemFromTableDblClick(file.FileDetailForm.PanelRight.tblFileDetails,System.DateTime.Now.ToString("MMM dd/yy"),"File Details Table");
        	Report.Success(String.Format("Confirmation message of APX Payment Voided  -  {0} ",bill.ReceivePaymentForm.PnlBase.txtConfirmationNo.GetAttributeValue<String>("Text")));
        	bill.ReceivePaymentForm.Toolbar1.btnClose.Click();
        	bill.FileDetailForm.saveClose.Click();
        	
        	
        	
        		

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
            validateGeneralRetainer();
        }
    }
}

