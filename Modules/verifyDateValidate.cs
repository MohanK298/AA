/*
 * Created by Ranorex
 * User: kumar
 * Date: 6/16/2020
 * Time: 3:49 PM
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
    /// Description of verifyDateValidate.
    /// </summary>
    [TestModule("CEAC4403-B3A1-4B8C-944C-902901C5D343", ModuleType.UserCode, 1)]
    public class verifyDateValidate : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public verifyDateValidate()
        {
            // Do not delete - a parameterless constructor is required!
        }

        
        
        BillingTE te=BillingTE.Instance;
        Common cmn=new Common();
        string[] dateFilter={"Exactly","Since","Before","Between","This week","This month","This quarter","This year"};
        
        System.DateTime date=System.DateTime.Now;
        System.DateTime frmdate1;
        System.DateTime todate1;
        String fromDate,toDate="";
        
//			System.DateTime(date.Year, date.Month, 1);
//		System.DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
        
        
        private void dateValidation()
        {
        
        	
        	te.MainForm.btnTimeFeesExpenses.Click();
        	
        	te.MainForm.rdbtnTimeFees.Select();
        	Report.Success("Time Entries Radio button is selected");
        	
        	cmn.VerifyListItemDropdown(te.MainForm.LeftPanel.cmbbxInterval,dateFilter,"Date Filter Combo box");
        
        	cmn.SelectItemDropdown(te.MainForm.LeftPanel.cmbbxInterval,"Exactly","Date Filter Combox box");
        	Validate.Attribute(te.MainForm.LeftPanel.cmbbxFromDateInfo,"Visible","True","From Date Combobox is displayed as expected");
        	Validate.Attribute(te.MainForm.LeftPanel.cmbbxToDateInfo,"Visible","False","To Date Combobox is not displayed as expected");
        	
        	
        	cmn.SelectItemDropdown(te.MainForm.LeftPanel.cmbbxInterval,"Since","Date Filter Combox box");
        	Validate.Attribute(te.MainForm.LeftPanel.cmbbxFromDateInfo,"Visible","True","From Date Combobox is displayed as expected");
        	Validate.Attribute(te.MainForm.LeftPanel.cmbbxToDateInfo,"Visible","False","To Date Combobox is not displayed as expected");
        	
        	
        	cmn.SelectItemDropdown(te.MainForm.LeftPanel.cmbbxInterval,"Before","Date Filter Combox box");
        	Validate.Attribute(te.MainForm.LeftPanel.cmbbxFromDateInfo,"Visible","True","From Date Combobox is displayed as expected");
        	Validate.Attribute(te.MainForm.LeftPanel.cmbbxToDateInfo,"Visible","False","To Date Combobox is not displayed as expected");
        	
        	cmn.SelectItemDropdown(te.MainForm.LeftPanel.cmbbxInterval,"Between","Date Filter Combox box");
        	Validate.Attribute(te.MainForm.LeftPanel.cmbbxFromDateInfo,"Visible","True","From Date Combobox is displayed as expected");
        	Validate.Attribute(te.MainForm.LeftPanel.cmbbxToDateInfo,"Visible","True","To Date Combobox is displayed as expected");
        	
        	cmn.SelectItemDropdown(te.MainForm.LeftPanel.cmbbxInterval,"This week","Date Filter Combox box");
        	Validate.Attribute(te.MainForm.LeftPanel.cmbbxFromDateInfo,"Visible","True","From Date Combobox is displayed as expected");
        	Validate.Attribute(te.MainForm.LeftPanel.cmbbxToDateInfo,"Visible","True","To Date Combobox is displayed as expected");
        	
        	cmn.SelectItemDropdown(te.MainForm.LeftPanel.cmbbxInterval,"This month","Date Filter Combox box");
        	Validate.Attribute(te.MainForm.LeftPanel.cmbbxFromDateInfo,"Visible","True","From Date Combobox is displayed as expected");
        	Validate.Attribute(te.MainForm.LeftPanel.cmbbxToDateInfo,"Visible","True","To Date Combobox is displayed as expected");
        	
        	frmdate1=new System.DateTime(date.Year, date.Month, 1);
        	todate1 = frmdate1.AddMonths(1).AddDays(-1);
        	
        	
        	fromDate=frmdate1.ToShortDateString();
        	toDate=todate1.ToShortDateString();
        	
        	
        	Validate.Attribute(te.MainForm.LeftPanel.cmbbxFromDateInfo,"Text",fromDate,String.Format("From Date Combobox has the value of {0} form This month Dropdown selected",fromDate));
        	Validate.Attribute(te.MainForm.LeftPanel.cmbbxToDateInfo,"AccessibleName",toDate,String.Format("To Date Combobox has the value of {0} form This month Dropdown selected",toDate));
        		
        		
        	cmn.SelectItemDropdown(te.MainForm.LeftPanel.cmbbxInterval,"This quarter","Date Filter Combox box");
        	Validate.Attribute(te.MainForm.LeftPanel.cmbbxFromDateInfo,"Visible","True","From Date Combobox is displayed as expected");
        	Validate.Attribute(te.MainForm.LeftPanel.cmbbxToDateInfo,"Visible","True","To Date Combobox is displayed as expected");
        	
        	
        	
        	int quarterNumber = (date.Month-1)/3+1;
			frmdate1 = new System.DateTime(date.Year, (quarterNumber-1)*3+1,1);
			todate1 = frmdate1.AddMonths(3).AddDays(-1);
        	
        	fromDate=frmdate1.ToShortDateString();
        	toDate=todate1.ToShortDateString();

        	
        	Validate.Attribute(te.MainForm.LeftPanel.cmbbxFromDateInfo,"Text",fromDate,String.Format("From Date Combobox has the value of {0} form This quarter Dropdown selected",fromDate));
        	Validate.Attribute(te.MainForm.LeftPanel.cmbbxToDateInfo,"AccessibleName",toDate,String.Format("To Date Combobox has the value of {0} form This quarter Dropdown selected",toDate));
        	
        	
        	
        	cmn.SelectItemDropdown(te.MainForm.LeftPanel.cmbbxInterval,"This year","Date Filter Combox box");
        	Validate.Attribute(te.MainForm.LeftPanel.cmbbxFromDateInfo,"Visible","True","From Date Combobox is displayed as expected");
        	Validate.Attribute(te.MainForm.LeftPanel.cmbbxToDateInfo,"Visible","True","To Date Combobox is displayed as expected");
        	
        	
        	frmdate1=new System.DateTime(date.Year, 1, 1);
        	todate1 = new System.DateTime(date.Year, 12, 31);
        	
        	
        	fromDate=frmdate1.ToShortDateString();
        	toDate=todate1.ToShortDateString();
        	
        	
        	Validate.Attribute(te.MainForm.LeftPanel.cmbbxFromDateInfo,"Text",fromDate,String.Format("From Date Combobox has the value of {0} form This year Dropdown selected",fromDate));
        	Validate.Attribute(te.MainForm.LeftPanel.cmbbxToDateInfo,"AccessibleName",toDate,String.Format("To Date Combobox has the value of {0} form This year Dropdown selected",toDate));
        	
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
            dateValidation();
        }
    }
}
