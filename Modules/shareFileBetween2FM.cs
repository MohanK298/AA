/*
 * Created by Ranorex
 * User: kumar
 * Date: 2/6/2020
 * Time: 2:56 PM
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
using SmokeTest.Repositories.Premium;
using SmokeTest.Modules.Utilities;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of shareFileBetween2FM.
    /// </summary>
    [TestModule("8F8FDD24-E40F-48E8-81A2-D47A071D5215", ModuleType.UserCode, 1)]
    public class shareFileBetween2FM : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public shareFileBetween2FM()
        {
            // Do not delete - a parameterless constructor is required!
        }

        
        Files files=Files.Instance;
        Common cmn=new Common();
        string curuser="";
        	string user="";
        	string fileName="";
        
        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        
        private void shareFileBetweenFM()
        {
        	
        	
        	var datasource=Ranorex.DataSources.Get("LoginData");
        	datasource.Load();
        	curuser=datasource.Rows[0].Values[1].ToString();
        	user=datasource.Rows[1].Values[1].ToString();
        	cmn.switchUser(curuser);
        	
        	files.MainForm.Self.Activate();
        	files.MainForm.btnFiles1.Click();
        	files.MainForm.FilesIndexForm.listFirstFile.DoubleClick();
        	Delay.Seconds(2);
        	fileName=files.FileDetailForm.titlebarFileDetail.Text;

        	//Select Firm Members Radio Button
        	files.FileDetailForm.rdoFirmMembers.Select();
        	files.FileDetailForm.btnAddPeople.Click();
        	
        	
        	files.PeopleSelectForm.ComboBox.Click();
        	cmn.SelectItemDropdown(files.tblDpdwnList.Self,"All");
        	
        	cmn.SelectItemFromTableSingleClick(files.PeopleSelectForm.Panel1.tbSelection,user,"People Selection Table");
        	files.PeopleSelectForm.btnAddToRight.Click();
        	files.PeopleSelectForm.btnOK.Click();
        	
        	cmn.VerifyDataExistsInTable(files.FileDetailForm.tblSelectedPeople,user,"File Detail Table");
        	files.FileDetailForm.btnSaveClose.Click();
        	cmn.switchUser(user);
        	
        	//files.MainForm.Self.Activate();
        	files.MainForm.btnFiles1.Click();
        	Delay.Seconds(2);
        	cmn.SelectItemDropdown(files.MainForm.cmbbxFileStatus,"All","File Status");
        	cmn.VerifyDataExistsInTable(files.MainForm.FilesIndexForm.tblFilesList,fileName,"File List Table");
        	
        	
        	
        	
        	
        }
        
        
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            shareFileBetweenFM();
        }
    }
}
