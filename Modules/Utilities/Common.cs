/*
 * Created by Ranorex
 * User: qa
 * Date: 6/5/2019
 * Time: 9:26 AM
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest.Modules.Utilities
{
    /// <summary>
    /// Creates a Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class Common
    {
        // You can use the "Insert New User Code Method" functionality from the context menu,
        // to add a new method with the attribute [UserCodeMethod].
        
        /// <summary>
        /// This is a placeholder text. Please describe the purpose of the
        /// user code method here. The method is published to the user code library
        /// within a user code collection.
        /// </summary>
        [UserCodeMethod]
        public static string CreateLocalTextFile(string fileName)
        {
        	string tempPath = Path.GetTempPath();
        	string localFileName = String.Format("{0}{1}.txt", tempPath, fileName);
        	Report.Log(ReportLevel.Info, "Creating text file in temp folder with name " + localFileName);
			try  
			{  
			    // Check if file already exists. If yes, delete it.   
			    if (File.Exists(localFileName))  
			    {  
			        File.Delete(localFileName);  
			    }  
			  
			    // Create a new file   
			    using (FileStream fs = File.Create(localFileName))   
			    {  
			        // Add some text to file  
			        Byte[] title = new UTF8Encoding(true).GetBytes("Ranorex automation test upload document at " + System.DateTime.Now);  
			        fs.Write(title, 0, title.Length);  
			        byte[] author = new UTF8Encoding(true).GetBytes(" By Ranorex automation");  
			        fs.Write(author, 0, author.Length);  
			    }  
			}  
			catch (Exception Ex)  
			{  
				Report.Log(ReportLevel.Failure, "Failed to create local file in %temp%");
			}	
			return localFileName;			
        }
    }
}
