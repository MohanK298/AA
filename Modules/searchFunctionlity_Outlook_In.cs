/*
 * Created by Ranorex
 * User: kumar
 * Date: 4/1/2020
 * Time: 10:47 AM
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
    /// Description of searchFunctionlity_Outlook_In.
    /// </summary>
    [TestModule("991F9FED-1914-4311-B4B4-5FEF9C264082", ModuleType.UserCode, 1)]
    public class searchFunctionlity_Outlook_In : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public searchFunctionlity_Outlook_In()
        {
            // Do not delete - a parameterless constructor is required!
        }

        string outlookPath="C:\\Program Files (x86)\\Microsoft Office\\root\\Office16\\OUTLOOK.EXE";
        int querycount=0;
        Common cmn=new Common();
        FirmSettings frm=FirmSettings.Instance;
        Communications comm=Communications.Instance;
        Outlook_AddIn outlook=Outlook_AddIn.Instance;
        	
         private void OpenApp()
        {
        	Host.Local.RunApplication(outlookPath);
        	Delay.Seconds(5);
        	outlook.OutlookSplash.SelfInfo.WaitForNotExists(60000);
        	
        }
         
          private void searchFunctionality()
        {
          	
        	if(outlook.Outlook.tabAmicusTasksInfo.Exists(5000))
 				{
 					Report.Success("Amicus Tasks Toolbar successfully seen in the Outlook");
        			outlook.Outlook.tabAmicusTasks.Click();
        		}
        	Delay.Seconds(2);
        	outlook.Outlook.AmicusAttorneyTasks1.txtSearchText.PressKeys("Amicus");
			outlook.Outlook.AmicusAttorneyTasks1.btnSearchAmicus.Click();
			if(outlook.Search.SelfInfo.Exists(3000))
			{
				Report.Success("Search Window successfully seen in the Outlook");
				outlook.Search.btnFindNow.Click();
			}
			if(outlook.SearchResult.SelfInfo.Exists(3000))
			{
				Report.Success("Search Result Window successfully seen in the Outlook");
				querycount=cmn.GetTableRowCount(outlook.SearchResult.tblSearchResults,"Search Results Window");
			}
			if(querycount>0)
			{
				Report.Success(String.Format("Search Result Window successfully returned {0} Contacts for the query text",querycount));
			}
			else
			{
				Report.Success("Search Result Window successfully returned 0 Contacts  for the query text");
			}
			outlook.SearchResult.Toolbar1.btnClose.Click();
			outlook.Search.btnCancel.Click();
        		
        }
        private void AboutBox()
        {
        	outlook.Outlook.tabAmicusTasks.Click();
        	outlook.Outlook.AmicusAttorneyTasks1.btnAbout.Click();
        	if(outlook.AboutForm.SelfInfo.Exists(3000))
        	{
        		Report.Success("About Window opened successfully");
        		outlook.AboutForm.Self.Close();
        	}
        	outlook.Outlook.Self.Close();
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
            OpenApp();
            searchFunctionality();
            AboutBox();
        }
    }
}
