/*
 * Created by Ranorex
 * User: qa
 * Date: 9/18/2020
 * Time: 10:35 AM
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
using SmokeTest.Modules.Utilities;
using SmokeTest.Repositories;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using System.IO.Compression;

namespace SmokeTest.Modules
{
    /// <summary>
    /// Description of package_documents_save.
    /// </summary>
    [TestModule("450FEE2E-52AB-4157-A598-F72116C0F52A", ModuleType.UserCode, 1)]
    public class package_documents_save : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public package_documents_save()
        {
            // Do not delete - a parameterless constructor is required!
        }
        
        
        Files file=Files.Instance;
        Common cmn=new Common();
        private void Package_Document_Save_In_Folder()
        {
        	string fileName="";
        	string filePath="";
        	string folderName="";
        	string folderPath="";
        	int rowcount,filecount=0;
        	filePath="C:\\Qiao\\DataFiles";
        	folderPath="C:\\Qiao\\DataFiles";
        	file.MainForm.Self.Activate();
        	file.MainForm.btnFiles.Click();
        	file.MainForm.FilesIndexForm.listFirstFile.DoubleClick();
        	if(file.FileDetailForm.SelfInfo.Exists(3000))
        	{
        		Report.Success("File Details form is displayed successfully");
        		
        		file.FileDetailForm.Actions.Click();
        		Report.Success("Action Menu Item is clicked");
        		file.FileDetailForm.PackageDocuments.Click();
        		Report.Success("Package Documents is clicked successfully");
        		
        		if(file.DocumentSelectorXtra.SelfInfo.Exists(3000))
        		{
        			Report.Success("Select Document is seen as expected");
        			file.DocumentSelectorXtra.PnlBase.cmbbxShowDocuments.Click();
        			file.curListItem="All Documents";
        			Delay.Seconds(2);
        			Validate.Exists(file.DpdwnList.ListItemInfo,"List item exists as expected");
        			file.DpdwnList.ListItem.Click();
        			file.DocumentSelectorXtra.PnlBase.btnAddAll.Click();
        			Report.Success("Add All button is clicked");
        			Delay.Seconds(2);
        			rowcount=cmn.GetTableRowCount(file.DocumentSelectorXtra.PnlBase.tbDataSelected,"Selected Data Table");
        			Report.Success("RowCount for the Selected Table is : "+rowcount);
        			file.DocumentSelectorXtra.Toolbar1.btnOK.Click();
        			Report.Success("Ok Button is clicked");
        			
        			
        			if(file.SaveAs.SelfInfo.Exists(3000))
        			{
        				Report.Success("Save As Window is opened as expected");
        				fileName=file.SaveAs.txtFileName.GetAttributeValue<String>("Text");
        				Report.Success(String.Format("Zip File Name to be saved is - {0}",fileName));
        				file.SaveAs.btnSave.Click();
        				Report.Success("Save Button is clicked");
        				
        				
        			}
        			if(file.PromptForm.SelfInfo.Exists(10000))
        			{
        				Report.Success("Prompt form is displayed successfully.");
        				Report.Success(file.PromptForm.txtMsg.GetAttributeValue<String>("Text"));
        				file.PromptForm.ButtonOK.Click();
        				Report.Success("Ok Button is clicked");
        			}
        			filePath+="\\"+fileName;
        			Report.Info(filePath);
        			if(System.IO.File.Exists(filePath))
        			{
        				Report.Success(String.Format("Zip File Packaged Document is created successfully for the file name - {0} in file path - {1}.",fileName,filePath));
        				folderName=fileName.Substring(0,fileName.Length-4);
        				Report.Info(folderName);
        				folderPath+="\\"+folderName;
        				ZipFile.ExtractToDirectory(filePath,folderPath);
        				Report.Info(folderPath);
        				
        				if(System.IO.Directory.Exists(folderPath))
        				{
        					Report.Success(String.Format("Folder created successfully for the file name - {0} in Folder path - {1}.",fileName,folderPath));
        					filecount=System.IO.Directory.GetFiles(folderPath).Length;
        					Report.Success("File Count for the Folder is : "+filecount);
        					if(rowcount==filecount)
        					{
        						Report.Success(String.Format("Package Document Count - {0} is same as extracted file Count {1} in the folder Path - {2}.",rowcount,filecount,folderPath));
        					}
        					else
        					{
        						Report.Failure(String.Format("Package Document Count - {0} is not same as extracted file Count {1} in the folder Path - {2}.",rowcount,filecount,folderPath));
        					}
        				}
        			}
        			else
        			{
        				Report.Failure(String.Format("Zip File Packaged Document is not created successfully for the file name - {0} in file path - {1}.",fileName,filePath));
        			}
        		}
        		file.FileDetailForm.btnSaveClose.Click();
        		Report.Success("File Closed successfully");
        		
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
            Package_Document_Save_In_Folder();
        }
    }
}
