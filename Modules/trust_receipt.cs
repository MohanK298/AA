/*
 * Created by Ranorex
 * User: kumar
 * Date: 6/11/2020
 * Time: 5:28 PM
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
using SmokeTest.Modules.Utilities;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of trust_receipt.
    /// </summary>
    [TestModule("23A42106-19F4-416C-A11C-906DEB1016AB", ModuleType.UserCode, 1)]
    public class trust_receipt : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public trust_receipt()
        {
            // Do not delete - a parameterless constructor is required!
        }

        
        Trust trst=Trust.Instance;
    	Common cmn=new Common();
    	string[] methodItems={"Check","Cash","Credit Card (Manual)","Electronic","Other"};
    	string data="Retainer: "+System.DateTime.Now.ToString();
    	private void trustReceipt_Validation()
    	{
    		trst.MainForm.Self.Activate();
        	trst.MainForm.BILLING.Click();
        	trst.MainForm.btnTrust.Click();
        	
        	trst.MainForm.Toolbar1.MenuItem.Click();
        	trst.MainForm.Toolbar1.TrustReceipt.Click();
        	
        	if(trst.TrustDetailBaseForm.SelfInfo.Exists(3000))
        	{
        		Report.Success("Trust Receipt Form is displayed successfully");
        		//cmn.SelectItemDropdown(trst.TrustDetailBaseForm.PnlBase.cmbbxReceiptTo,"1 - Trust","Receipt to Dropdown");
        		Delay.Milliseconds(500);
        		Validate.AttributeContains(trst.TrustDetailBaseForm.PnlBase.cmbbxReceiptToInfo,"Text","1 - Trust","Receipt To Dropdown has the value 1 - Trust Selected");
        		Validate.AttributeContains(trst.TrustDetailBaseForm.PnlBase.txtDateInfo,"UIAutomationValueValue",System.DateTime.Now.ToString("M/dd/yyyy"),"Today's Date is set to Default");
        		Report.Success(String.Format("Receipt Id seen for the current Trust Receipt Form is: {0}",trst.TrustDetailBaseForm.PnlBase.txtReceiptId.GetAttributeValue<String>("UIAutomationValueValue")));
        		Validate.AttributeContains(trst.TrustDetailBaseForm.PnlBase.txtDescriptionInfo,"UIAutomationValueValue","Retainer",String.Format("Description for Trust Receipts is: {0}",trst.TrustDetailBaseForm.PnlBase.txtDescription.GetAttributeValue<String>("UIAutomationValueValue")));
        		trst.TrustDetailBaseForm.PnlBase.txtDescription.PressKeys(data);
        		trst.TrustDetailBaseForm.PnlBase.cmbbxMethod.Click();
        		for(int i=0;i<methodItems.Length;i++)
        		{
        			trst.var=methodItems[i];
        			Delay.Milliseconds(300);
        			Validate.Exists(trst.DropDownForm.treeItemInfo,String.Format("Item {0} is present in the Method Dropdown as expected",methodItems[i]));
        			
        		}
        		trst.TrustDetailBaseForm.PnlBase.cmbbxMethod.Click();
        		
        		Validate.AttributeContains(trst.TrustDetailBaseForm.PnlBase.cmbbxMethodInfo,"Text","Check","Method Dropdown has the value Check Selected as default");
        		
        		trst.TrustDetailBaseForm.PnlBase.imgAddFile.Click();
        		if(trst.PeopleSelectForm.SelfInfo.Exists(3000))
        		{
        			Report.Success("People Select Form is displayed successfully");
        			trst.PeopleSelectForm.Toolbar1.btnCancel.Click();
        		}
        		
        		trst.TrustDetailBaseForm.PnlBase.imgAddFile.Click();
        		if(trst.FileSelectForm.SelfInfo.Exists(3000))
        		{
        			trst.FileSelectForm.btnQuickFindFile.Click();
        			if(trst.FindFilesForm.SelfInfo.Exists(3000))
        			{
        				trst.FindFilesForm.searchTextInput.PressKeys(System.DateTime.Now.ToShortDateString());
        				trst.FindFilesForm.btnOK.Click();
        			}
        			trst.FileSelectForm.listFirstFound.DoubleClick();
        		}
        		trst.TrustDetailBaseForm.btnSaveClose.Click();
        		if(trst.PromptForm.SelfInfo.Exists(3000))
        		{
        			Validate.AttributeContains(trst.PromptForm.txtMsgPromptInfo,"Text","The following Field(s) need to be filled in before you can save this entry:"+Environment.NewLine+"- Amount","Error Message is displayed correctly as expected for Amount not filled");
        			trst.PromptForm.btnOk.Click();
        		}
        		
        		trst.TrustDetailBaseForm.PnlBase.txtAmount.PressKeys("1000.00");
        		Delay.Seconds(2);
        		string amt=trst.TrustDetailBaseForm.PnlBase.txtAmount.GetAttributeValue<Int32>("UIAutomationValueValue").ToString("N");
        		Validate.AttributeContains(trst.TrustDetailBaseForm.PnlBase.txtAllocationInfo,"Text",amt,String.Format("Amount Field Value of {0} and Allocation Field Values are same.",amt));
        		trst.TrustDetailBaseForm.btnSaveClose.Click();	
   		                           
        	}
        	cmn.VerifyDataExistsInTable(trst.MainForm.tblTrustDetails,data,"Trust Details Table");
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
            trustReceipt_Validation();
        }
    }
}
