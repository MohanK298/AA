/*
 * Created by Ranorex
 * User: kumar
 * Date: 5/8/2020
 * Time: 3:19 PM
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
    /// Description of enableTaxSettingsInFirm.
    /// </summary>
    [TestModule("6C4C34BC-24CF-4DCC-A5AA-BD557DECDFB1", ModuleType.UserCode, 1)]
    public class enableTaxSettingsInFirm : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public enableTaxSettingsInFirm()
        {
            // Do not delete - a parameterless constructor is required!
        }

        BillingClient bclient=BillingClient.Instance;
        FirmSettings frm=FirmSettings.Instance;
        Common cmn=new Common();
        string [] dpdwnItems={"Fees & Expenses","Fees","Expenses"};
        private void enableTaxSet()
        {
        	bclient.MainForm.Self.Activate();
        	bclient.MainForm.sideBILLING.Click();
        	frm.MainForm.View.Click();
        	frm.MainForm.FirmSettings1.Click();
        	
        	bclient.MainForm.lnkTaxSettings.Click();
        	
        	if(bclient.GeneralFirmSettingsXtraForm.SelfInfo.Exists(3000))
        	{
        		Report.Success("Tax Settings is opened successfully");
        		bclient.GeneralFirmSettingsXtraForm.PanelTax.txtRegisteredName.PressKeys("QA Toronto 10");
        		bclient.GeneralFirmSettingsXtraForm.PanelTax.cbApplySalesTax1.Check();
        		bclient.GeneralFirmSettingsXtraForm.PanelTax.txtTax1.PressKeys("Sales Tax1");
        		bclient.GeneralFirmSettingsXtraForm.PanelTax.txtReg1.PressKeys("Reg1");
        		bclient.GeneralFirmSettingsXtraForm.PanelTax.btnEdit1.Click();
        		if(bclient.TaxEditXtraForm.SelfInfo.Exists(3000))
        		{
        			bclient.TaxEditXtraForm.PnlBase.btnEdit.Click();
        			Delay.Seconds(2);
        			bclient.TaxEditXtraForm.PnlBase.txtDate.PressKeys(System.DateTime.Now.ToShortDateString());
        			bclient.TaxEditXtraForm.PnlBase.txtRate.PressKeys("5");
        			bclient.TaxEditXtraForm.PnlBase.btnApply.Click();
        			bclient.TaxEditXtraForm.Toolbar1.btnOK.Click();
        		}
        		cmn.VerifyListItemDropdown(bclient.GeneralFirmSettingsXtraForm.PanelTax.cmbxTax1Change,dpdwnItems,"Taxable Charges Dropdown 1");
        		//cmn.SelectItemDropdown(bclient.GeneralFirmSettingsXtraForm.PanelTax.cmbxTax1Change,"Expenses","Taxable Charges Dropdown 1");
        		
        		bclient.GeneralFirmSettingsXtraForm.PanelTax.cbApplySalesTax2.Check();
        		bclient.GeneralFirmSettingsXtraForm.PanelTax.txtTax2.PressKeys("Sales Tax2");
        		bclient.GeneralFirmSettingsXtraForm.PanelTax.txtReg2.PressKeys("Reg2");
        		bclient.GeneralFirmSettingsXtraForm.PanelTax.btnEdit2.Click();
        		if(bclient.TaxEditXtraForm.SelfInfo.Exists(3000))
        		{
        			bclient.TaxEditXtraForm.PnlBase.btnEdit.Click();
        			Delay.Seconds(2);
        			bclient.TaxEditXtraForm.PnlBase.txtDate.PressKeys(System.DateTime.Now.ToShortDateString());
        			bclient.TaxEditXtraForm.PnlBase.txtRate.PressKeys("10");
        			bclient.TaxEditXtraForm.PnlBase.btnApply.Click();
        			bclient.TaxEditXtraForm.Toolbar1.btnOK.Click();
        			
        				
        		}
        		cmn.VerifyListItemDropdown(bclient.GeneralFirmSettingsXtraForm.PanelTax.cmbxTax2Change,dpdwnItems,"Taxable Charges Dropdown 2");
        		//cmn.SelectItemDropdown(bclient.GeneralFirmSettingsXtraForm.PanelTax.cmbxTax2Change,"Expenses","Taxable Charges Dropdown 2");
        		
        		
        		bclient.GeneralFirmSettingsXtraForm.PanelTax.cbUseActivityCodeSettingsForTaxesOn.Check();
        		bclient.GeneralFirmSettingsXtraForm.Toolbar1.ButtonOK.Click();
        		bclient.GeneralFirmSettingsXtraForm.Toolbar1.ButtonOK.Click();
        		
        	}
        	
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
            enableTaxSet();
        }
    }
}
