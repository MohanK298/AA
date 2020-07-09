/*
 * Created by Ranorex
 * User: kumar
 * Date: 6/12/2020
 * Time: 12:25 PM
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
    /// Description of trust_transfer_Validation.
    /// </summary>
    [TestModule("EC09BDB3-1CA9-4702-96C9-435CABB4B80C", ModuleType.UserCode, 1)]
    public class trust_transfer_Validation : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public trust_transfer_Validation()
        {
            // Do not delete - a parameterless constructor is required!
        }

        
        
        Trust trst=Trust.Instance;
    	Common cmn=new Common();
    	string[] methodItems={"Check","Other"};
    	string data="Trust Transfer to AR: "+System.DateTime.Now.ToString();
    	string txtTrstBalance="";
    	private void trustTransfer_Validation()
    	{
    		trst.MainForm.Self.Activate();
        	trst.MainForm.BILLING.Click();
        	trst.MainForm.btnTrust.Click();
        	
        	
        	cmn.SelectItemFromTableDblClick(trst.MainForm.tblTrustDetails,"Trust Check Added","Trust Details Table");
        	txtTrstBalance=trst.TrustDetailBaseForm.PnlBase.txtNewBalance.GetAttributeValue<String>("Text");
        	trst.TrustDetailBaseForm.btnSaveClose.Click();
        	
        	trst.MainForm.Toolbar1.MenuItem.Click();
        	trst.MainForm.Toolbar1.TrustTransferToAR.Click();
        	
        	if(trst.TrustARTransferDetailForm.SelfInfo.Exists(3000))
        	{
        		Report.Success("Trust Transfer to AR Form is displayed successfully");
        		//cmn.SelectItemDropdown(trst.TrustDetailBaseForm.PnlBase.cmbbxReceiptTo,"1 - Trust","Receipt to Dropdown");
        		Delay.Milliseconds(500);
        		Validate.AttributeContains(trst.TrustARTransferDetailForm.PnlBase.cmbbxReceiptToInfo,"Text","1 - Trust","From Dropdown has the value 1 - Trust Selected");
        		Validate.AttributeContains(trst.TrustARTransferDetailForm.PnlBase.cmbbxGeneralInfo,"Text","1 - General","Transfer to Dropdown has the value 1 - General Selected");
        		Validate.AttributeContains(trst.TrustARTransferDetailForm.PnlBase.txtDateInfo,"UIAutomationValueValue",System.DateTime.Now.ToString("M/d/yyyy"),"Today's Date is set to Default");
        		Report.Success(String.Format("Check # seen for the current Trust Check Form is: {0}",trst.TrustARTransferDetailForm.PnlBase.txtCheckNumber.GetAttributeValue<String>("UIAutomationValueValue")));
        		Validate.AttributeContains(trst.TrustARTransferDetailForm.PnlBase.txtDescriptionInfo,"UIAutomationValueValue","Trust Transfer to AR",String.Format("Description for Trust Check is: '{0}'",trst.TrustARTransferDetailForm.PnlBase.txtDescription.GetAttributeValue<String>("UIAutomationValueValue")));
        		trst.TrustARTransferDetailForm.PnlBase.txtDescription.PressKeys(data);
        		trst.TrustARTransferDetailForm.PnlBase.cmbbxMethod.Click();
        		for(int i=0;i<methodItems.Length;i++)
        		{
        			trst.var=methodItems[i];
        			Delay.Milliseconds(300);
        			Validate.Exists(trst.DropDownForm.treeItemInfo,String.Format("Item {0} is present in the Method Dropdown as expected",methodItems[i]));
        			
        		}
        		trst.TrustARTransferDetailForm.PnlBase.cmbbxMethod.Click();
        		
        		Validate.AttributeContains(trst.TrustARTransferDetailForm.PnlBase.cmbbxMethodInfo,"Text","Check","Method Dropdown has the value Check Selected as default");
        		
//        		trst.TrustARTransferDetailForm.PnlBase.imgAddFile.Click();
//        		if(trst.PeopleSelectForm.SelfInfo.Exists(3000))
//        		{
//        			Report.Success("File Select Form is displayed successfully");
//        			trst.PeopleSelectForm.Toolbar1.btnCancel.Click();
//        		}
//        		
        		trst.TrustARTransferDetailForm.PnlBase.imgAddFile.Click();
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

        		string transferamt=trst.TrustARTransferDetailForm.PnlBase.txtTransferAmount.GetAttributeValue<String>("UIAutomationValueValue");
     
        		
        		Validate.AttributeContains(trst.TrustARTransferDetailForm.PnlBase.txtARBalanceInfo,"Text",transferamt,String.Format("Transfer Amount Field Value of {0} and AR Field Values are same.",transferamt));
        		Delay.Seconds(1);
        		if(trst.TrustARTransferDetailForm.PnlBase.txtTrustBalance.GetAttributeValue<String>("Text").Equals(txtTrstBalance))
        		
        		{
        			Report.Success(String.Format("Trust Balance is the same between Trust Check and Trust AR Transfer Form which is : {0}",txtTrstBalance));
//        			Report.Success(String.Format("Trust Balance for the current Trust transfer Form is: {0}",trst.TrustARTransferDetailForm.PnlBase.txtTrustBalance.GetAttributeValue<String>("Text")));
        		}
        		
        		cmn.SelectItemFromTableSingleClick(trst .TrustARTransferDetailForm.PnlBase.tblARTrustDetails,"Details","Trust AR Details Table");

        		if(trst.TrustARDistributionForm.SelfInfo.Exists(3000))
        		{
        			Report.Success("Trust to AR Distribution Details form is displayed successfully ");
        			string remainbal="";
        			string arAmt="";
        			arAmt=trst.TrustARDistributionForm.PnlBase.txtTotalDistributionAmount.GetAttributeValue<String>("Text");
        			remainbal=(Double.Parse(txtTrstBalance)-Double.Parse(arAmt)).ToString();
        			Report.Info(remainbal);
        			if(trst.TrustARDistributionForm.PnlBase.txtRemaingTrust.GetAttributeValue<String>("Text").Contains(remainbal))
        			{
        				Report.Success(String.Format("Remaining Trust Balance is the expected Value of : {0}",remainbal));
        			}
//        			
//					Validate.AttributeContains(trst.TrustARDistributionForm.PnlBase.txt.te

        			cmn.SelectItemFromTableSingleClick(trst.TrustARDistributionForm.PnlBase.tblTrustDistribution,"Details","Trust AR Distribution Details Table");
        		}
        		
        		if(trst.TrustARBillDistributionForm.SelfInfo.Exists(3000))
        		{
        			Report.Success("Payment Distribution form is displayed successfully ");
        			cmn.PrintTableData(trst.TrustARBillDistributionForm.tblBillDistribution,"Payment Distribution Table");
        			trst.TrustARBillDistributionForm.Toolbar1.btnOK.Click();
        			trst.TrustARDistributionForm.Toolbar1.btnOK.Click();
        			
        		}
 				trst.TrustARTransferDetailForm.btnSaveClose.Click();	
   		                           
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
            trustTransfer_Validation();
        }
    }
}
