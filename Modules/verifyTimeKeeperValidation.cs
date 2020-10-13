/*
 * Created by Ranorex
 * User: kumar
 * Date: 6/17/2020
 * Time: 11:00 AM
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
using SmokeTest.Repositories.Premium;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of verifyTimeKeeperValidation.
    /// </summary>
    [TestModule("90EBBBEB-A728-4AA4-B796-98681BF262AE", ModuleType.UserCode, 1)]
    public class verifyTimeKeeperValidation : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public verifyTimeKeeperValidation()
        {
            // Do not delete - a parameterless constructor is required!
        }

        
        BillingTE te=BillingTE.Instance;
        Preferences pref=Preferences.Instance;
        Common cmn=new Common();
        string[] txt;
        string curuser,curUser="";
		
        
        private void TimeKeeperValidation()
        {
        	
        	var datasource=Ranorex.DataSources.Get("LoginData");
        	datasource.Load();
        	curuser=datasource.Rows[0].Values[1].ToString();
        	
        	
        	
        	te.MainForm.btnTimeFeesExpenses.Click();
        	
        	te.MainForm.rdbtnTimeFees.Select();
        	Report.Success("Time Entries Radio button is selected");
        	
        	te.MainForm.LeftPanel.btnTimeKeeper.Click();
        	Report.Success("Time Keeper Button is selected");
        	
        	if(te.PeopleSelectForm.SelfInfo.Exists(3000))
        	{
        		Report.Success("People Select Form is selected");
        		
        		string currentuser="Logged in as "+curuser;
        		
        		Report.Info(curuser);
        		pref.loginuser=currentuser;
        		
        		
        		
        		txt=pref.txtStatusBar.TextValue.Split(' ');
        		Report.Success(pref.txtStatusBar.TextValue);
        		curUser=txt[3]+" "+txt[4];
        		Report.Success(curUser);
        		cmn.SelectItemFromTableSingleClick(te.PeopleSelectForm.Panel1.tbSelection,curUser,"People to be selected Table");
        		te.PeopleSelectForm.btnAddToRight.Click();
        		cmn.VerifyDataExistsInTable(te.PeopleSelectForm.Panel1.tbSelected,curUser,"People selected Table");
        		te.PeopleSelectForm.btnOK.Click();
        	}
        	
        	cmn.VerifyDataExistsInTable(te.MainForm.tblTimeEntry,curUser,"Time Entry Table");
        	
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
            TimeKeeperValidation();
            cmn.ClosePrompt();
            
        }
    }
}
