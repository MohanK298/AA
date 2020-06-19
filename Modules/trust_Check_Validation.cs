/*
 * Created by Ranorex
 * User: kumar
 * Date: 6/12/2020
 * Time: 9:27 AM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using WinForms = System.Windows.Forms;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using SmokeTest.Modules.Utilities;
using SmokeTest.Repositories;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of trust_Check_Validation.
    /// </summary>
    [TestModule("EF5BED40-BA5C-4AE1-AD8B-0E526F0F1BCE", ModuleType.UserCode, 1)]
    public class trust_Check_Validation : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public trust_Check_Validation()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        
        
        Trust trst=Trust.Instance;
    	Common cmn=new Common();
    	string[] methodItems={"Check","Other"};
    	string data="Trust Check Added: "+System.DateTime.Now.ToString();
    	string amtinWords="";
    	private void trustchk_Validation()
    	{
    		trst.MainForm.Self.Activate();
        	trst.MainForm.BILLING.Click();
        	trst.MainForm.btnTrust.Click();
        	
        	trst.MainForm.Toolbar1.MenuItem.Click();
        	trst.MainForm.Toolbar1.TrustCheck.Click();
        	
        	if(trst.TrustDetailBaseForm.SelfInfo.Exists(3000))
        	{
        		Report.Success("Trust Check Form is displayed successfully");
        		//cmn.SelectItemDropdown(trst.TrustDetailBaseForm.PnlBase.cmbbxReceiptTo,"1 - Trust","Receipt to Dropdown");
        		Delay.Milliseconds(500);
        		Validate.AttributeContains(trst.TrustDetailBaseForm.PnlBase.cmbbxReceiptToInfo,"Text","1 - Trust","From Dropdown has the value 1 - Trust Selected");
        		Validate.AttributeContains(trst.TrustDetailBaseForm.PnlBase.txtDateInfo,"UIAutomationValueValue",System.DateTime.Now.ToString("M/dd/yyyy"),"Today's Date is set to Default");
        		Report.Success(String.Format("Check # seen for the current Trust Check Form is: {0}",trst.TrustDetailBaseForm.PnlBase.txtCheckNumber.GetAttributeValue<String>("UIAutomationValueValue")));
        		Validate.AttributeContains(trst.TrustDetailBaseForm.PnlBase.txtDescriptionInfo,"UIAutomationValueValue","",String.Format("Description for Trust Check is: '{0}' - empty",trst.TrustDetailBaseForm.PnlBase.txtDescription.GetAttributeValue<String>("UIAutomationValueValue")));
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
        		
       		
        		trst.TrustDetailBaseForm.btnSaveClose.Click();
        		if(trst.PromptForm.SelfInfo.Exists(3000))
        		{
        			Validate.AttributeContains(trst.PromptForm.txtMsgPromptInfo,"Text","The following Field(s) need to be filled in before you can save this entry:"+Environment.NewLine+"- To"+Environment.NewLine+"- Amount","Error Message is displayed correctly as expected for Amount not filled");
        			trst.PromptForm.btnOk.Click();
        		}
        		
        		trst.TrustDetailBaseForm.PnlBase.txtAmount.PressKeys("400.00");
        		
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
        		
        		
        		
        		
        		Delay.Seconds(2);
        		CultureInfo us = new CultureInfo("en-US");
        		string strAmt=trst.TrustDetailBaseForm.PnlBase.txtAmount.GetAttributeValue<String>("UIAutomationValueValue");
        		int amtstart=Int32.Parse(strAmt.Split('.')[0]);
        		string amt=amtstart.ToString("N", us);
        		amtinWords=cmn.ConvertAmount(Convert.ToDouble(amt));
      		
        		Validate.AttributeContains(trst.TrustDetailBaseForm.PnlBase.txtAllocationInfo,"Text",amt,String.Format("Amount Field Value of {0} and Allocation Field Values are same.",amt));
        		Delay.Seconds(1);
        		Validate.AttributeContains(trst.TrustDetailBaseForm.PnlBase.txtCheckAmountInfo,"Text",amtinWords,String.Format("Check Field Value of {0} is in Word Format.",amtinWords));
        		
        		trst.TrustDetailBaseForm.PnlBase.btnAddContact.Click();
        		if(trst.PeopleSelectForm.SelfInfo.Exists(3000))
        		{
        			trst.PeopleSelectForm.listFirstFound.DoubleClick();
        			Report.Success("Contact Added successfully for Trust Check.");
        		}
        		
        		
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
            trustchk_Validation();
            
        }
    }
}
