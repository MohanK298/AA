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
using SmokeTest.Repositories;
using SmokeTest.Repositories.Premium;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using System.Globalization;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
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
        Documents doc=Documents.Instance;
        Preferences pref=Preferences.Instance;
        FirmSettings fm=new FirmSettings();
        SmokeTestRepository str = SmokeTestRepository.Instance;
        Outlook_AddIn outlook=Outlook_AddIn.Instance;
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
				Report.Log(ReportLevel.Failure, String.Format("Failed to create local file in %temp% due to {0}",Ex));
			}	
			return localFileName;			
        }
        [UserCodeMethod]
        public void ClosePrompt()
        {
        	string controlName="";
        	List<Element> all = (List<Element>)Host.Local.Find(new RxPath("/form"));
			foreach(Element e in all)
			{
				Form f = new Form(e);
				controlName=f.GetAttributeValue<String>("ControlName");
			//	Report.Info(f.Title);
			//	Report.Info(f.FlavorName);
			if(f.FlavorName.Equals("winforms"))
				if(f.Title!="Amicus Attorney" && controlName!="Main Form")
				   {
						Report.Info(String.Format("{0} Prompt/Dialog Closed",controlName));
				   	f.Close();
				   }
			
					
			}
			
			if(fm.PromptForm.SelfInfo.Exists(3000))
			{
				if(fm.PromptForm.btnShowDetailsInfo.Exists(3000))
				{
					fm.PromptForm.btnShowDetails.Click();
					Report.Failure(String.Format("The Test Case failed with the following error message - {0}",fm.PromptForm.txtErrorMessage.TextValue));
				}
				fm.PromptForm.Self.Close();
			}
        	
        }
        
        
        [UserCodeMethod]
        public void VerifyDataExistsInTable(Ranorex.Adapter tbldata,string data,string tblName)
        {
        	int k=0;
        	var tadapter = tbldata.As <Ranorex.Table>();
        	foreach(var myrow in tadapter.Rows)
        	{
        		foreach(var cell in myrow.Cells)
        		{
        			if(cell.Text.Contains(data))
        			{
        				Report.Success(String.Format("Value \"{0}\" Present as expected in \"{1}\"",data,tblName));
        				k++;
        				break;
        			}
        		}
        		if(k>0)
        			break;
        	}
        	if(k==0)
        	{
        				Report.Failure(String.Format("Value \"{0}\" not present in \"{1}\"",data,tblName));
        	}
        }
        
        
        
        
        public bool ValidateDatainTable(Ranorex.Adapter tbldata,string data,string tblName)
        {
        	int k=0;
        	bool status=false;
        	var tadapter = tbldata.As <Ranorex.Table>();
        	foreach(var myrow in tadapter.Rows)
        	{
        		foreach(var cell in myrow.Cells)
        		{
        			if(cell.Text.Contains(data))
        			{
        				//Report.Success(String.Format("Value \"{0}\" Present as expected in \"{1}\"",data,tblName));
        				k++;
        				status=true;
        				break;
        				
        			}
        		}
        		if(k>0)
        			break;
        	}
        	if(k==0)
        	{
        				//Report.Failure(String.Format("Value \"{0}\" not present in \"{1}\"",data,tblName));
        				status=false;
        	}
        	return status;
        }
        
        
        
        
        
        public void VerifyDataExistsInTable(Ranorex.Adapter tbldata,string[] data,string tblName)
        {
        	int k=0;
        	var tadapter = tbldata.As <Ranorex.Table>();
        	string d="";
        	foreach(var myrow in tadapter.Rows)
        	{
        		foreach(var cell in myrow.Cells)
        		{
        			foreach(string txt in data)
        			{
        				
        			if(cell.Text.Contains(txt))
        			{
        				Report.Success(String.Format("Value \"{0}\" Present as expected in \"{1}\"",txt,tblName));
        				k++;
        				d=txt;
        				break;
        			}
        			}
        		}
        	}
        	if(k==0)
        	{
        				Report.Failure(String.Format("Value \"{0}\" not present in \"{1}\"",d,tblName));
        	}
        }
        
        
        
        
        public int GetTableRowCount(Ranorex.Adapter tbldata,string tblName)
        {
        	var tadapter = tbldata.As <Ranorex.Table>();
        	return tadapter.Rows.Count;
        }
        
        
         public void VerifyCorrespondingDataExistsInTable(Ranorex.Adapter tbldata,string data,string correspondData,string tblName)
        {
        	int k=0;
        	var tadapter = tbldata.As <Ranorex.Table>();
        	for(int i=0;i<tadapter.Rows.Count;i++)
        	{
        		for(int j=0;j<tadapter.Rows[i].Cells.Count;j++)
        		{
     				if(tadapter.Rows[i].Cells[j].As<Ranorex.Cell>().Text.Contains(data))
        			{
        				for(int x=0;x<tadapter.Rows[i].Cells.Count;x++)
        				{
        					if(tadapter.Rows[i].Cells[x].As<Ranorex.Cell>().Text.Contains(correspondData))
        					{
        						Report.Success(String.Format("Corresponding Value \"{0}\" Present as expected for {1} in \"{2}\"",correspondData,data,tblName));
        					    k++;
        						break;
        					}
        				}
        				}

        			}
        		}
        	
        	if(k==0)
        	{
        				Report.Failure(String.Format("Corresponding Value \"{0}\" not present as expected for {1} in \"{2}\"",correspondData,data,tblName));
        	}
        }
         
         public void VerifyCorrespondingDataExistsInTable(Ranorex.Adapter tbldata,string data,string[] correspondData,string tblName)
        {
        	int k=0;
        	var tadapter = tbldata.As <Ranorex.Table>();
        	for(int i=0;i<tadapter.Rows.Count;i++)
        	{
        		for(int j=0;j<tadapter.Rows[i].Cells.Count;j++)
        		{
     				if(tadapter.Rows[i].Cells[j].As<Ranorex.Cell>().Text.Contains(data))
        			{
        				for(int x=0;x<tadapter.Rows[i].Cells.Count;x++)
        				{
        					for(int m=0;m<correspondData.Length;m++)
        					{
        						if(tadapter.Rows[i].Cells[x].As<Ranorex.Cell>().Text.Contains(correspondData[m]))
        					{
        							Report.Success(String.Format("Corresponding Value \"{0}\" Present as expected for {1} in \"{2}\"",correspondData[m],data,tblName));
        					   		k++;
        						//break;
        					}
        					}
        				}
        				}

        			}
        		}
        	
        	if(k==0)
        	{
        		Report.Failure(String.Format("Corresponding Value \"{0}\" not present as expected for {1} in \"{2}\"",correspondData.ToString(),data,tblName));
        	}
        }
         
        
    	[UserCodeMethod]
        public void VerifyDataNotExistsInTable(Ranorex.Adapter tbldata,string data,string tblname)
        {
        	int k=0;
        	var tadapter = tbldata.As <Ranorex.Table>();
        	foreach(var myrow in tadapter.Rows)
        	{
        		foreach(var cell in myrow.Cells)
        		{
        			if(cell.Text.Contains(data))
        			{
        				Report.Failure(String.Format("Value \"{0}\" Present in \"{1}\"",data,tblname));
        				k++;
        				break;
        			}
        		}
        	}
        	if(k==0)
        	{
        				Report.Success(String.Format("Value \"{0}\" not present as expected in \"{1}\"",data,tblname));
        	}
        }
        [UserCodeMethod]
        public void SelectItemFromTableDblClick(Ranorex.Adapter tbldata,string data,string tblName)
        {
        	int k=0;
        	var tadapter = tbldata.As <Ranorex.Table>();
        	for(int i=0;i<tadapter.Rows.Count;i++)
        	{
        		
        		for(int j=0;j<tadapter.Rows[i].Cells.Count;j++)
        		{
        		
        			if(tadapter.Rows[i].Cells[j].As<Ranorex.Cell>().Text.Contains(data))
        			{
        				
        				if(j+1<tadapter.Rows[i].Cells.Count)
        				{
        					tadapter.Rows[i].Cells[j+1].As<Ranorex.Cell>().Focus();
        					//tadapter.Rows[i].Cells[j+1].As<Ranorex.Cell>().MoveTo();
	        				tadapter.Rows[i].Cells[j+1].As<Ranorex.Cell>().DoubleClick();
	        				Report.Success(String.Format("Value \"{0}\" Selected as expected in \"{1}\"",data,tblName));
	        				k++;
	        				break;
        				}
        				else
        				{
        					tadapter.Rows[i].Cells[j].As<Ranorex.Cell>().Focus();
        					//tadapter.Rows[i].Cells[j].As<Ranorex.Cell>().MoveTo();
	        				tadapter.Rows[i].Cells[j].As<Ranorex.Cell>().DoubleClick();
	        				Report.Success(String.Format("Value \"{0}\" Selected as expected in \"{1}\"",data,tblName));
	        				k++;
	        				break;
        				}
        				
        			}
        		}
        		if(k>0)
        			break;
        	}
        	if(k==0)
        	{
        				Report.Failure(String.Format("Value \"{0}\" not present for selection in \"{1}\"",data,tblName));
        	}
        } 
        
        public void SelectItemFromTableDblClick(Ranorex.Adapter tbldata,string itemValue)
        {
        	int k=0;
        	var tadapter = tbldata.As <Ranorex.Table>();
        	for(int i=0;i<tadapter.Rows.Count;i++)
        	{
        			if(tadapter.Rows[i].Cells[0].As<Ranorex.Cell>().Text.Contains(itemValue))
        			{
        				tadapter.Rows[i].Cells[0].As<Ranorex.Cell>().DoubleClick();
        				Report.Success(String.Format("Value \"{0}\" Selected as expected",itemValue));
        				k++;
        				break;
        		    }
        	}
        	if(k==0)
        	{
        				Report.Info(String.Format("Value \"{0}\" not present for selection/Value already selected ",itemValue));
        	}
        }
        
        public void SelectItemFromTableDblClick(Ranorex.Adapter tbldata,int rowno)
        {
        	int k=0;
        	var tadapter = tbldata.As <Ranorex.Table>();
        	var rowcount=tadapter.Rows.Count;
        	//Report.Info(rowcount);
        	for(int i=0;i<rowcount;i++)
        	{
        			if(tadapter.Rows[i].Cells[0].As<Ranorex.Cell>().RowIndex==rowno)
        			{
        				tadapter.Rows[i].Cells[0].As<Ranorex.Cell>().DoubleClick();
        				Report.Success(String.Format("Value  Selected as expected"));
        				k++;
        				break;
        		    }
        	}
        	if(k==0)
        	{
        		Report.Info(String.Format("Value  not present for selection/Value already selected "));
        	}
        }
        
        public int GetWeekOfYear(System.DateTime time)
		{
		    DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
		    if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
		    {
		        time = time.AddDays(3);
		    }
		
		 
		    return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
		} 
	        
        public void SelectItemFromTableSingleClick(Ranorex.Adapter tbldata,string data,string tblName)
        {
        	int k=0;
        	var tadapter = tbldata.As <Ranorex.Table>();
        	for(int i=0;i<tadapter.Rows.Count;i++)
        	{
        		
        		for(int j=0;j<tadapter.Rows[i].Cells.Count;j++)
        		{
        		
        			if(tadapter.Rows[i].Cells[j].As<Ranorex.Cell>().Text.Equals(data))
        			{
        				if(j<tadapter.Rows[i].Cells.Count-1)
        				{
        					tadapter.Rows[i].Cells[j+1].As<Ranorex.Cell>().Focus();
        					tadapter.Rows[i].Cells[j+1].As<Ranorex.Cell>().Click();
        					Report.Success(String.Format("Value \"{0}\" Selected as expected in \"{1}\"",data,tblName));
        					k++;
        					break;
        				}
        				else
        				{tadapter.Rows[i].Cells[j].As<Ranorex.Cell>().Click();
        				Report.Success(String.Format("Value \"{0}\" Selected as expected in \"{1}\"",data,tblName));
        				k++;
        				break;
        				}
        			}
        		}
        		if(k>0)
        			break;
        	}
        	if(k==0)
        	{
        				Report.Failure(String.Format("Value \"{0}\" not present for selection in \"{1}\"",data,tblName));
        	}
        }        
        public void OpenContextMenuItemFromTable(Ranorex.Adapter tbldata,string data,string tblName)
        {
        	int k=0;
        	var tadapter = tbldata.As <Ranorex.Table>();
        	for(int i=0;i<tadapter.Rows.Count;i++)
        	{
        		
        		for(int j=0;j<tadapter.Rows[i].Cells.Count;j++)
        		{
        		
        			if(tadapter.Rows[i].Cells[j].As<Ranorex.Cell>().Text.Contains(data))
        			{
        				
        				if(j<tadapter.Columns.Count)
        				{
        					tadapter.Rows[i].Cells[j+1].As<Ranorex.Cell>().Focus();
        					Mouse.Click(tadapter.Rows[i].Cells[j+1].As<Ranorex.Cell>(),WinForms.MouseButtons.Right);
        				}
        				else
        				{
        					tadapter.Rows[i].Cells[j].As<Ranorex.Cell>().Focus();
        					Mouse.Click(tadapter.Rows[i].Cells[j].As<Ranorex.Cell>(),WinForms.MouseButtons.Right);
        				}
        				Report.Success(String.Format("Value \"{0}\" Context Clicked as expected in \"{1}\"",data,tblName));
        				k++;
        				break;
        			}
        		}
        		if(k>0)
        			break;
        	}
        	if(k==0)
        	{
        				Report.Failure(String.Format("Value \"{0}\" not present for selection in \"{1}\"",data,tblName));
        	}
        } 
        public void SelectItemDropdown(Ranorex.Adapter dpdwnData,string itemValue,string dpdwnName)
        {
        	int k=0;
        	dpdwnData.Click();
        	var cmbbxData = dpdwnData.As <Ranorex.ComboBox>();
        	//cmbbxData.Click();
        	IList<Ranorex.ListItem> listitems = cmbbxData.Items;
        	foreach(Ranorex.ListItem item in listitems)
        	{
        		if(item.Text.Equals(itemValue))
        		{
        			item.Click();
        			Report.Success(String.Format("Value \"{0}\" Selected as expected in \"{1}\" dropdown",itemValue,dpdwnName));
        			k++;
        			break;
        		}
        	}
        	if(k==0)
        	{
        				Report.Failure(String.Format("Value \"{0}\" not present for selection in \"{1}\" dropdown",itemValue,dpdwnName));
        	}
        }
        
        
        public void VerifyListItemDropdown(Ranorex.Adapter dpdwnData,string[] itemValues,string dpdwnName)
        {
        	int k=0;
        	dpdwnData.Click();
        	var cmbbxData = dpdwnData.As <Ranorex.ComboBox>();
        	//cmbbxData.Click();
        	IList<Ranorex.ListItem> listitems = cmbbxData.Items;
        	foreach(string item in itemValues)
        	{
        		
        		foreach(Ranorex.ListItem val in listitems)
	        	{
        			Report.Info(val.Text.ToString());
	        		if(val.Text.Contains(item))
	        		{
	        			//item.Click();
	        			Report.Success(String.Format("Value \"{0}\" Present as expected in \"{1}\" dropdown",item,dpdwnName));
	        			k++;
	        			//break;
	        		}
	        	}
        	}
        	if(k==itemValues.Length)
        	{
        		Report.Success(String.Format("{0} Values present for selection in \"{1}\" dropdown as expected",itemValues.Length,dpdwnName));
        	}
        	else
        	{
        		Report.Failure(String.Format("{0} Values not present for selection in \"{1}\" dropdown as expected",itemValues.Length,dpdwnName));
        	}
        	dpdwnData.Click();
        	
        }
        
        
        
        
        
         public void SelectItemDropdown(Ranorex.Adapter tbldata,string itemValue)
        {
        	int k=0;
        	var tadapter = tbldata.As <Ranorex.Table>();
        	for(int i=0;i<tadapter.Rows.Count;i++)
        	{
        		//Report.Info(tadapter.Rows[i].Cells[0].As<Ranorex.Cell>().Text.ToString());
        			if(tadapter.Rows[i].Cells[0].As<Ranorex.Cell>().Text.Contains(itemValue))
        			{
        				tadapter.Rows[i].Cells[0].As<Ranorex.Cell>().Click();
        				Report.Success(String.Format("Value \"{0}\" Selected as expected",itemValue));
        				k++;
        				break;
        			
        		}
        	}
        	if(k==0)
        	{
        				Report.Failure(String.Format("Value \"{0}\" not present for selection ",itemValue));
        	}
			
        }
        
        public string createLocalFile()
        {
        	string fileName="RanorexTestFile"+System.DateTime.Now.ToString().Replace(":","").Replace("/","").Replace(" ","");
        	string localFileName;
        	//localFileName = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName +"\\DataFiles\\"+ fileName+ ".txt";
        	localFileName="C:\\Qiao\\DataFiles\\"+fileName+".txt";
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
			        byte[] author = new UTF8Encoding(true).GetBytes("By Ranorex automation");  
			        fs.Write(author, 0, author.Length);  
			    }  
			}  
			catch (Exception Ex)  
			{  
				Report.Log(ReportLevel.Failure, String.Format("Failed to create local file in %temp% due to {0}",Ex));
			} 
			return localFileName;				
        }
        
        public string createLocalFile(string currentTime)
        {
        	string fileName="RanorexTestFile"+System.DateTime.Now.ToString().Replace(":","").Replace("/","").Replace(" ","");
        	string localFileName;
        	//localFileName = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName +"\\DataFiles\\"+ fileName+ ".txt";
        		//@"C:\Qiao\RanorexTestFile.txt";
        		localFileName="C:\\Qiao\\DataFiles\\"+fileName+".txt";
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
			        Byte[] title = new UTF8Encoding(true).GetBytes("Ranorex automation test upload document at " + currentTime);  
			        fs.Write(title, 0, title.Length);  
			        byte[] author = new UTF8Encoding(true).GetBytes(" By Ranorex automation");  
			        fs.Write(author, 0, author.Length);  
			    }  
			}  
			catch (Exception Ex)  
			{  
				Report.Log(ReportLevel.Failure, String.Format("Failed to create local file in %temp% due to {0}",Ex));
			} 
			return localFileName;				
        }
        
        public void MultiplePeopleSelection(Ranorex.Adapter item,int noOfItems)
        {
        	int i=0;
        	string down="";
			var tadapter = item.As <Ranorex.Table>();
			if(tadapter.Rows.Count>1)
				i=1;
			tadapter.Rows[i].Cells[0].As<Ranorex.Cell>().Click();
			for(int k=0;k<noOfItems;k++)
			{
				down+="{Down}";
			}
			Keyboard.Press("{LShiftKey down}"+down+"{LShiftKey up}");
			Report.Success("Multiple Selection performed for People");
		}
        
        public void MultipleDocSelection(Ranorex.Adapter item,int noOfItems)
        {
        	int i=0;
        	string down="";
			var tadapter = item.As <Ranorex.Table>();
			if(tadapter.Rows.Count>1)
				i=0;
			tadapter.Rows[i].Cells[0].As<Ranorex.Cell>().Click();
			for(int k=0;k<noOfItems;k++)
			{
				down+="{Down}";
			}
			Keyboard.Press("{LShiftKey down}"+down+"{LShiftKey up}");
			
			Report.Success("Multiple Selection performed for Documents");
		}
        
        public void MultipleSelection(Ranorex.Adapter item,string[] data)
        {
        	int i,j,k=0;
			var tadapter = item.As <Ranorex.Table>();
			for(i=0;i<tadapter.Rows.Count;i++)
        	{
				if(k>=data.Length)
					break;
				for(j=0;j<tadapter.Rows[i].Cells.Count;j++)
        		{
    				if(tadapter.Rows[i].Cells[j].As<Ranorex.Cell>().Text.Equals(data[k]))
        			{
    					tadapter.Rows[i].Cells[j].As<Ranorex.Cell>().Focus();
    					tadapter.Rows[i].Cells[j].As<Ranorex.Cell>().Click();
						Keyboard.Press("{LControlKey down}");
	       				k++;
//	       				i=0;
        				break;
        			}
        		}
				
			}
			Keyboard.Press("{LControlKey up}");
        }
        
        public string MultiSelectEmail(Ranorex.Adapter item,int mailCount,bool getValues=false)
        {
        	int l=0;
        	string mailsubject="";
        	string txt="";
        	int indx1,indx2=0;
        	string txt2="";
        	IList<Ranorex.Container> containers = item.FindChildren<Ranorex.Container>(); 
        	for(int i=0;i<mailCount;i++)
        	{
        		if(l>=mailCount)
					break;
        		for(int j=1;j<containers.Count;j++)
        		{
        			//containers[2].Click();
        			Delay.Seconds(1);
        			Report.Info(containers[j].GetAttributeValue<String>("Name"));
        			IList<Ranorex.Unknown> elements=containers[j].FindChildren<Ranorex.Unknown>();
        			for(int k=0;k<elements.Count;k++)
        			{
        				if(l>=mailCount)
	       				{
	       					break;
	       				}
        				elements[k].Focus();
        				elements[k].Click();
        				Keyboard.Press("{LControlKey down}");
	       				
        				if(getValues==true)
        				{
        					
        					txt=elements[k].Element.GetAttributeValueText("Name");
							indx1=txt.IndexOf("Subject ")+8;
							indx2=txt.IndexOf(", Received");
							txt2=txt.Substring(indx1,indx2-indx1);
							if(txt2.Length>10)
							{
								txt2=txt2.Substring(0,10);
							}
							mailsubject+=txt2+"~";
        				}
        				l++;
        			}
        			if(l>=mailCount)
       				{
       					break;
       				}
        			
        		}
        	}
        	Keyboard.Press("{LControlKey up}");	
        	if(getValues==true)
        	{
        		return mailsubject;
        	}
        	else
        	{
        		return null;	
        	}
        	
        }
        
        
        
        public string RetrieveCurrentSelectionFromTable(Ranorex.Adapter item)
        {
        	string data="";
        	var tadapter = item.As <Ranorex.Table>();
        	for(int i=0;i<tadapter.Rows.Count-1;i++)
        	{
        				data+=tadapter.Rows[i].Cells[0].As<Ranorex.Cell>().Text+",";
        	}
        	data+=tadapter.Rows[tadapter.Rows.Count-1].Cells[0].As<Ranorex.Cell>().Text;
        	if(data=="")
        	{
        				Report.Failure(String.Format("Current Selection is empty in \"{0}\"",item));
        	}
        	return data;
        }
        
 		public string RetrieveCurrentSelectionFromTable(Ranorex.Adapter tbldata,string colname,string tblName)
        {
        	int m=0;
        	string details="";
        	var tadapter = tbldata.As <Ranorex.Table>();
        	for(int i=0;i<tadapter.Rows.Count;i++)
        	{
        		
        		for(int j=0;j<tadapter.Rows[i].Cells.Count;j++)
        		{
        		
        			if(tadapter.Rows[i].Cells[j].As<Ranorex.Cell>().Text.Equals(colname))
        			{
        				for(int k=i+1;k<tadapter.Rows.Count;k++)
        				{
        					details+=tadapter.Rows[k].Cells[j].As<Ranorex.Cell>().Text;
        					m++;
        				}

        			}
        		}
        		if(m>0)
        			break;
        	}
        	if(m==0)
        	{
        				Report.Failure(String.Format("Data \"{0}\" not present for retrieval in \"{1}\"",colname,tblName));
        	}
        	return details;
        } 
 		
 		
 		public string RetrieveCurrentSelectionFromTable(Ranorex.Adapter tbldata,int colnumber,string tblName)
        {
        	int m=0;
        	string details="";
        	var tadapter = tbldata.As <Ranorex.Table>();
        	for(int i=0;i<tadapter.Rows.Count-1;i++)
        	{
        	
				details+=tadapter.Rows[i].Cells[colnumber].As<Ranorex.Cell>().Text+"~"; 
				m++;		
        	}
        		details+=tadapter.Rows[tadapter.Rows.Count-1].Cells[colnumber].As<Ranorex.Cell>().Text; 
        	if(m==0)
        	{
        				Report.Failure(String.Format("Column index \"{0}\" values not present for retrieval in \"{1}\"",colnumber,tblName));
        	}
        	return details;
        } 
 		
 		public void PrintTableData(Ranorex.Adapter tbldata,string tblName)
 		{
        	string rowData="";
        	var tadapter = tbldata.As <Ranorex.Table>();
        	for(int i=0;i<tadapter.Rows.Count;i++)
        	{
        		rowData="";
        		for(int j=0;j<tadapter.Rows[i].Cells.Count;j++)
        		{
        		
        			rowData+=tadapter.Rows[i].Cells[j].As<Ranorex.Cell>().Text+"--";
        			
        		}
        		Report.Success(String.Format("Row {0} Data is {1}: ",i+1,rowData));
        		
        	}
 		}
        
        
        
        
		private void CloseAnnoncementForm()
        {
			str.MainForm.Self.Activate();
        	str.MainForm.menuItemFile.Select();
        	str.AmicusAttorneyXWin.CloseAllDetails.Click();
        
        	if(str.AnnouncementForm.SelfInfo.Exists(3000))
        	{
        		str.AnnouncementForm.Self.Activate();
        		str.AnnouncementForm.SelfInfo.WaitForExists(3000);
        		str.AnnouncementForm.ToolbarToolbarBaseDesigner1.btnOKInfo.WaitForExists(3000);
        		
        		
        		
        			str.AnnouncementForm.AmicusCheckBox1.Check();   	
        			str.AnnouncementForm.ToolbarToolbarBaseDesigner1.btnOK.Click();
        		   }
        		
        	
        }
		
		
		public void SendEmail(string[] toMail,string data)
		{
		    try {  
		        MailMessage message = new MailMessage();  
		        SmtpClient smtp = new SmtpClient();  
		        message.From = new MailAddress("amicustestmk1@gmail.com");  
		        
		        foreach (var m in toMail) 
		        { 
		        	message.To.Add(new MailAddress(m)); 
		        }
		        message.Subject = data;  
		        message.IsBodyHtml = true; //to make message body as html  
		        message.Body = data;  
		        smtp.Port = 587;  
		        smtp.Host = "smtp.gmail.com"; //for gmail host  
		        smtp.EnableSsl = true;  
		        smtp.UseDefaultCredentials = false;  
		        smtp.Credentials = new NetworkCredential("amicustestmk1@gmail.com", "0nXTeam123$$");  
		        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;  
		        smtp.Send(message);  
		        Report.Info("Message Sent");
		    } catch (Exception e) 
			{
				Report.Failure(String.Format("Mail not sent due to {0}",e.Message));
			}
		}


		public void SendEmailWithAttachments(string toMail,string data,int noofAttachments) 
		{
			string filename="";
		    try 
		    {
				
				
		        MailMessage message = new MailMessage();  
		        SmtpClient smtp = new SmtpClient();  
		        message.From = new MailAddress("amicustestmk1@gmail.com");  
		        message.To.Add(new MailAddress(toMail));  
		        message.Subject = data;  
		        message.IsBodyHtml = true; //to make message body as html  
		        message.Body = data;  
		        smtp.Port = 587;  
		        smtp.Host = "smtp.gmail.com"; //for gmail host  
		        
		        for(int i=0;i<noofAttachments;i++)
		        {
		        	filename=createLocalFile();
		        	Delay.Seconds(3);
		        	message.Attachments.Add(new Attachment(filename.ToString()));
		        	filename="";                
		        }
		        
		        
		        smtp.EnableSsl = true;
		        smtp.UseDefaultCredentials = false;  
		        smtp.Credentials = new NetworkCredential("amicustestmk1@gmail.com", "0nXTeam123$$");  
		        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;  
		        smtp.Send(message);  
		        Report.Info("Message Sent");
		    } catch (Exception) {}  
		}

		public System.DateTime AddBusinessDays(System.DateTime date, int days)
		{
//			var sign = Math.Sign(days);
//	        var unsignedDays = Math.Abs(days);
//	        for (var i = 0; i < unsignedDays; i++)
//	        {
//	            do
//	            {
//	                current = current.AddDays(sign);
//	            }
//	            while (current.DayOfWeek == DayOfWeek.Saturday ||
//	                current.DayOfWeek == DayOfWeek.Sunday);
//	        }
//	        return current;
			
			if (days < 0)
		    {
		        throw new ArgumentException("days cannot be negative", "days");
		    }
		
		    if (days == 0) return date;
		
		    if (date.DayOfWeek == DayOfWeek.Saturday)
		    {
		        date = date.AddDays(2);
		        days -= 1;
		    }
		    else if (date.DayOfWeek == DayOfWeek.Sunday)
		    {
		        date = date.AddDays(1);
		        days -= 1;
		    }
		
		    date = date.AddDays(days / 5 * 7);
		    int extraDays = days % 5;
		
		    if ((int)date.DayOfWeek + extraDays > 5)
		    {
		        extraDays += 2;
		    }
		
		    return date.AddDays(extraDays);
			
			
		}
		
		
		
		
	public static String[] units = { "Zero", "One", "Two", "Three",  
    "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven",  
    "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",  
    "Seventeen", "Eighteen", "Nineteen" };  
    public static String[] tens = { "", "", "Twenty", "Thirty", "Forty",  
    "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };  
  
    public String ConvertAmount(double amount)  
    {  
        try  
        {  
            Int64 amount_int = (Int64)amount;  
            Int64 amount_dec = (Int64)Math.Round((amount - (double)(amount_int)) * 100);  
            if (amount_dec == 0)  
            {  
                return Convert(amount_int) + " Dollars";  
            }  
            else  
            {  
                return Convert(amount_int) + " Point " + Convert(amount_dec) + " Only.";  
            }  
        }  
        catch (Exception e)  
        {  
            // TODO: handle exception  
        }  
        return "";  
    }  
  
    public String Convert(Int64 i)  
    {  
        if (i < 20)  
        {  
            return units[i];  
        }  
        if (i < 100)  
        {  
            return tens[i / 10] + ((i % 10 > 0) ? "-" + Convert(i % 10) : "");  
        }  
        if (i < 1000)  
        {  
            return units[i / 100] + " Hundred"  
                    + ((i % 100 > 0) ? " And " + Convert(i % 100) : "");  
        }  
        if (i < 100000)  
        {           return Convert(i / 1000) + " Thousand "  
                    + ((i % 1000 > 0) ? " " + Convert(i % 1000) : "");  
        }  
        if (i < 10000000)  
        {  
            return Convert(i / 100000) + " Lakh "  
                    + ((i % 100000 > 0) ? " " + Convert(i % 100000) : "");  
        }  
        if (i < 1000000000)  
        {  
            return Convert(i / 10000000) + " Crore "  
                    + ((i % 10000000 > 0) ? " " + Convert(i % 10000000) : "");  
        }  
        return Convert(i / 1000000000) + " Arab "  
                + ((i % 1000000000 > 0) ? " " + Convert(i % 1000000000) : "");  
    } 
		
		
		
		
		
		
		
		
        public void switchUser(string user)
        {
        	string currentuser="Logged in as "+user;
        	pref.loginuser=currentuser;
        	
        	CloseAnnoncementForm();
        	if(pref.MainForm.SbMainform.Visible==true && pref.txtStatusBar.TextValue.Contains(currentuser))
        	{
//        		Report.Info(pref.txtStatusBar.TextValue);
        		if(pref.txtStatusBarInfo.Exists(3000))
        		   {
        			
        			//pref.MainForm.Self.EnsureVisible();
        			pref.txtStatusBar.EnsureVisible();
        			pref.txtStatusBar.Focus();
        			pref.txtStatusBar.Parent.Focus();
        		   	Report.Info(string.Format("Application switched to Login User 1- {0}",user));
        		   		CloseAnnoncementForm();
        		   }

        	}
        	else
        	{
				pref.MainForm.OfficeModule.Click();
        		pref.MainForm.View.Click();
				Delay.Seconds(2);
				pref.MainForm.StatusBar.Click();
				Delay.Seconds(2);
				Report.Info(pref.txtStatusBar.TextValue);
				if(pref.txtStatusBarInfo.Exists(3000))
        		{
				   	//pref.MainForm.Self.Activate();
			//	   	pref.MainForm.Self.EnsureVisible();
				   	pref.txtStatusBar.EnsureVisible();
				   	pref.txtStatusBar.Focus();
				   	pref.txtStatusBar.Parent.Focus();
					Report.Info(string.Format("Application switched to Login User 2- {0}",user));
						CloseAnnoncementForm();
		     	}
        	}
			
        }
        
    }
}

