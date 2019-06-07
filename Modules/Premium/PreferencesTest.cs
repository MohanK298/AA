/*
 * Created by Ranorex
 * User: Het Patel
 * Date: 6/3/2016
 * Time: 10:56 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace SmokeTest.Modules.Premium
{
    [TestModule("3FFAFFEC-2DF1-419F-AF6F-3719FB0B48DB", ModuleType.UserCode, 1)]
    public class PreferencesTest : ITestModule
    {
        //Repository Variable
        static Repositories.Premium.Preferences pre = new SmokeTest.Repositories.Premium.Preferences();
        static Duration customWaitTime = new Duration(3000);

        public PreferencesTest()
        {
            // Do not delete - a parameterless constructor is required!
        }

        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            Action();

//            run2();
        }


        public void Action()
        {
        	pre.MainForm.Self.Activate();
        	pre.MainForm.OfficeModule.Click();
        	pre.MainForm.OfficeModuleHeaderInfo.WaitForExists(customWaitTime);
        	
//            int i = 0;
//            while (i < 5)
//            {
//                pre.MainForm.Preferences.Click();
//                i++;
//            }

			try {
				pre.MainForm.Preferences.Click();
				pre.MainForm.PreferencesForm.SelfInfo.WaitForExists(customWaitTime);
			} catch (Exception) {
				pre.MainForm.Preferences.Click();
			}
           
            foreach (var prefItem in pre.MainForm.PreferencesForm.SelfInfo.Children) {
            	Ranorex.Adapter itemAdapter = prefItem.CreateAdapter<Ranorex.Text>(true);
//            	pre.MainForm.PreferencesForm.MyProfile.ty
//            	Report.Log(ReportLevel.Info, "Pref Item Actions: " + itemAdapter.Element.Actions);
//            	Report.Log(ReportLevel.Info, "Pref Item: " + itemAdapter.GetPath());
//            	Report.Log(ReportLevel.Info, "Pref Item: " + itemAdapter.GetType());
            	
//            	pre.MainForm.PreferencesForm.Self.Focus();
            	try {
            		itemAdapter.Click();
            		pre.GeneralPreferencesForm.GeneralPreferencesFormInfo.WaitForExists(customWaitTime);
            	} catch (Exception) {
            		if (!pre.GeneralPreferencesForm.GeneralPreferencesFormInfo.Exists()) {
            			itemAdapter.Click();
            		} else {
            			Report.Log(ReportLevel.Failure, "Preference Item Click failed");
            		}
            		
            	}
            	
            	try {
//            		Report.Log(ReportLevel.Info, "Preference form active? " + pre.GeneralPreferencesForm.GeneralPreferencesForm.Active);
           			pre.GeneralPreferencesForm.ButtonOKInfo.WaitForExists(customWaitTime);
            		pre.GeneralPreferencesForm.ButtonOKInfo.WaitForAttributeEqual(customWaitTime, "Enabled", true);
	            	pre.GeneralPreferencesForm.ButtonOK.Click();
            		pre.GeneralPreferencesForm.GeneralPreferencesFormInfo.WaitForNotExists(customWaitTime);
            	} catch (Exception) {
            		if (pre.GeneralPreferencesForm.ButtonOKInfo.Exists()) {
            			pre.GeneralPreferencesForm.ButtonOK.Click();
            		} else {
            			Report.Log(ReportLevel.Failure, "Failed to click OK button to close the Preference form");
            		}
            	}
				
            } 
            
            //Email Preference Open and Close
            try {
            	pre.MainForm.Email.Click();
            	pre.EmailPreferencesForm.SelfInfo.WaitForExists(customWaitTime);
            } catch (Exception) {
            	if (!pre.EmailPreferencesForm.SelfInfo.Exists()) {
        			pre.MainForm.Email.Click();
        		}
            }
            
            try {
            	pre.EmailPreferencesForm.CloseInfo.WaitForExists(customWaitTime);
            	pre.EmailPreferencesForm.CloseInfo.WaitForAttributeEqual(customWaitTime, "Enabled", true);
            	pre.EmailPreferencesForm.Close.Click();
            	pre.EmailPreferencesForm.SelfInfo.WaitForNotExists(customWaitTime);
            } catch (Exception) {
            	
            	if (pre.EmailPreferencesForm.CloseInfo.Exists()) {
        			pre.EmailPreferencesForm.Close.Click();
        		}
            }
            
            try {
            	pre.MainForm.CalendarContacts.Click();
            	pre.GeneralPreferencesForm.GeneralPreferencesFormInfo.WaitForExists(customWaitTime);
            } catch (Exception) {
            	if (!pre.GeneralPreferencesForm.GeneralPreferencesFormInfo.Exists()) {
            		pre.MainForm.CalendarContacts.Click();
        		}
            }
            
            try {
//            		Report.Log(ReportLevel.Info, "Preference form active? " + pre.GeneralPreferencesForm.GeneralPreferencesForm.Active);
           			pre.GeneralPreferencesForm.ButtonOKInfo.WaitForExists(customWaitTime);
            		pre.GeneralPreferencesForm.ButtonOKInfo.WaitForAttributeEqual(customWaitTime, "Enabled", true);
	            	pre.GeneralPreferencesForm.ButtonOK.Click();
            		pre.GeneralPreferencesForm.GeneralPreferencesFormInfo.WaitForNotExists(customWaitTime);
            	} catch (Exception) {
            		if (pre.GeneralPreferencesForm.ButtonOKInfo.Exists()) {
            			pre.GeneralPreferencesForm.ButtonOK.Click();
            		} else {
            			Report.Log(ReportLevel.Failure, "Failed to click OK button to close the Preference form");
            		}
            	}

        }
    }
}