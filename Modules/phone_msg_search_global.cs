/*
 * Created by Ranorex
 * User: qa
 * Date: 9/23/2020
 * Time: 4:38 PM
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
	/// Description of phone_msg_search_global.
	/// </summary>
	[TestModule("BD1FFA01-23BE-4D3D-A44C-7D00C1E92D1A", ModuleType.UserCode, 1)]
	public class phone_msg_search_global : ITestModule
	{
		/// <summary>
		/// Constructs a new instance.
		/// </summary>
		public phone_msg_search_global()
		{
			// Do not delete - a parameterless constructor is required!
		}

		
		
		Communications comm=Communications.Instance;
		Common cmn=new Common();
		string inSearch="Frequently-used text";
		string type="Phone Messages";
		int count=0;
		
		private void phonemsg_search()
		{
			comm.MainForm.Self.Activate();
			comm.MainForm.btnCommunications.Click();
			Delay.Seconds(2);
			comm.MainForm.Tools.Click();
			Report.Success("Tools Menu is clicked");
			Delay.Milliseconds(500);
			comm.MainForm.Search.Click();
			Report.Success("Search Menu is clicked");
			
			if(comm.Search.SelfInfo.Exists(3000))
			{
				Report.Success("Search Window is opened");	
				
				comm.Search.PnlBase.btnType.Click();
				comm.var=type;
				Delay.Milliseconds(500);
				comm.DropDownForm.TreeItem.Click();
				
				
				comm.Search.PnlBase.txtSearch.PressKeys("Test");
				comm.Search.PnlBase.btnIn.Click();
				comm.var=inSearch;
				Delay.Milliseconds(500);
				comm.DropDownForm.TreeItem.Click();
				
				comm.Search.Toolbar1.btnFindNow.Click();
				
				if(comm.SearchResult.SelfInfo.Exists(10000))
				{
					Report.Success("Search Result Window is opened");
					Validate.Attribute(comm.SearchResult.PnlBase.txtShowingFieldInfo,"Text",type,"Showing Fields is displayed correctly");
					Validate.Attribute(comm.SearchResult.PnlBase.txtRestrictedToInfo,"Text","Amicus User","Restricted To Field is displayed correctly");
					Validate.AttributeContains(comm.SearchResult.PnlBase.txtWhereTermsInfo,"Text",inSearch,"Where Terms Fields is displayed correctly");
					count=cmn.GetTableRowCount(comm.SearchResult.PnlBase.tblSearchResult,"Search Results Table");
					Report.Success("Row Count for Search Result is : "+count);
					comm.SearchResult.Toolbar1.btnClose.Click();
					
					
					
					
				}
				
				
				
				
				
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
			phonemsg_search();
			cmn.ClosePrompt();
		}
	}
}
