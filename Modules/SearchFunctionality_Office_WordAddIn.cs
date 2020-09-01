/*
 * Created by Ranorex
 * User: kumar
 * Date: 3/19/2020
 * Time: 12:16 PM
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
    /// Description of SearchFunctionality_Office_WordAddIn.
    /// </summary>
    [TestModule("7233F945-B61D-4620-8661-2F78B0F4152F", ModuleType.UserCode, 1)]
    public class SearchFunctionality_Office_WordAddIn : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public SearchFunctionality_Office_WordAddIn()
        {
            // Do not delete - a parameterless constructor is required!
        }
	 	string wordPath="C:\\Program Files (x86)\\Microsoft Office\\root\\Office16\\WINWORD.EXE";
        Common cmn=new Common();
        Word_app wapp=Word_app.Instance;
        Documents doc=new Documents();
        int querycount=0;
        
        private void OpenApp()
        {
        	Host.Local.RunApplication(wordPath);
        	//Delay.Seconds(5);
        	wapp.SplashWordInfo.WaitForNotExists(15000);
        	wapp.Word.BlankDocument.Click();
        	
        	Delay.Seconds(2);
        }
        private void searchFunctionality()
        {
        	if(wapp.WordDocument.tabAmicusTasksInfo.Exists(5000))
 				{
 					Report.Success("Amicus Tasks Toolbar successfully seen in the Word Document");
        			wapp.WordDocument.tabAmicusTasks.Click();
        		}
        	Delay.Seconds(2);
        	wapp.WordDocument.AmicusAttorneyTasks1.txtSearchText.PressKeys("Personal");
			wapp.WordDocument.AmicusAttorneyTasks1.btnSearchAmicus.Click();
			if(wapp.Search.SelfInfo.Exists(3000))
			{
				Report.Success("Search Window successfully seen in the Word Document");
				wapp.Search.btnFindNow.Click();
			}
			if(wapp.SearchResult.SelfInfo.Exists(3000))
			{
				Report.Success("Search Result Window successfully seen in the Word Document");
				querycount=cmn.GetTableRowCount(wapp.SearchResult.tblSearchResults,"Search Results Window");
			}
			if(querycount>0)
			{
				Report.Success(String.Format("Search Result Window successfully returned {0} Files for the query text",querycount));
			}
			else
			{
				Report.Success("Search Result Window successfully returned 0 Files  for the query text");
			}
			wapp.SearchResult.Toolbar1.btnClose.Click();
			wapp.Search.btnCancel.Click();
        		
        }
        private void AboutBox()
        {
        	wapp.WordDocument.tabAmicusTasks.Click();
        	wapp.WordDocument.AmicusAttorneyTasks1.btnAbout.Click();
        	if(wapp.AboutForm.SelfInfo.Exists(3000))
        	{
        		Report.Success("About Window opened successfully");
        		wapp.AboutForm.Self.Close();
        	}
        	wapp.WordDocument.Self.Close();
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
