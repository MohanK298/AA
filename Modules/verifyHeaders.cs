/*
 * Created by Ranorex
 * User: kumar
 * Date: 6/16/2020
 * Time: 10:39 AM
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
    /// Description of verifyHeaders.
    /// </summary>
    [TestModule("40DA07E4-C393-4DB2-A2D9-58C1B71DE227", ModuleType.UserCode, 1)]
    public class verifyHeaders : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public verifyHeaders()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        string[] headerCols={"Type","Date","Timekeeper","Client Matter ID","File","Description","Hours","Rate","Amount","Invoice #","Status"};
        BillingTE te=BillingTE.Instance;
        Common cmn=new Common();
        
        private void headerValidation()
        {
        	te.MainForm.btnTimeFeesExpenses.Click();
        	Delay.Seconds(1);
        	for(int i=0;i<headerCols.Length;i++)
        	{
        		te.colName=headerCols[i];
        		Delay.Seconds(1);
        		Validate.Exists(te.MainForm.colHeaderInfo,String.Format("The Column header {0} exists in the Billing Time Entry Fees & Expenses Table",headerCols[i]));
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
            headerValidation();
        }
    }
}
