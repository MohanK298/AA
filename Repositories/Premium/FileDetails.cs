﻿///////////////////////////////////////////////////////////////////////////////
//
// This file was automatically generated by RANOREX.
// DO NOT MODIFY THIS FILE! It is regenerated by the designer.
// All your modifications will be lost!
// http://www.ranorex.com
//
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Repository;
using Ranorex.Core.Testing;

namespace SmokeTest.Repositories.Premium
{
#pragma warning disable 0436 //(CS0436) The type 'type' in 'assembly' conflicts with the imported type 'type2' in 'assembly'. Using the type defined in 'assembly'.
    /// <summary>
    /// The class representing the FileDetails element repository.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", global::Ranorex.Core.Constants.CodeGenVersion)]
    [RepositoryFolder("958100b6-b1f5-4da1-9cd7-3a81df36f7c4")]
    public partial class FileDetails : RepoGenBaseFolder
    {
        static FileDetails instance = new FileDetails();
        FileDetailsFolders.FileDetailFormAppFolder _filedetailform;

        /// <summary>
        /// Gets the singleton class instance representing the FileDetails element repository.
        /// </summary>
        [RepositoryFolder("958100b6-b1f5-4da1-9cd7-3a81df36f7c4")]
        public static FileDetails Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Repository class constructor.
        /// </summary>
        public FileDetails() 
            : base("FileDetails", "/", null, 0, false, "958100b6-b1f5-4da1-9cd7-3a81df36f7c4", ".\\RepositoryImages\\FileDetails958100b6.rximgres")
        {
            _filedetailform = new FileDetailsFolders.FileDetailFormAppFolder(this);
        }

#region Variables

        string _EventTitle = "AppointmentTime123454";

        /// <summary>
        /// Gets or sets the value of variable EventTitle.
        /// </summary>
        [TestVariable("2da3c8e0-3d65-452a-8db6-6243af472e84")]
        public string EventTitle
        {
            get { return _EventTitle; }
            set { _EventTitle = value; }
        }

#endregion

        /// <summary>
        /// The Self item info.
        /// </summary>
        [RepositoryItemInfo("958100b6-b1f5-4da1-9cd7-3a81df36f7c4")]
        public virtual RepoItemInfo SelfInfo
        {
            get
            {
                return _selfInfo;
            }
        }

        /// <summary>
        /// The FileDetailForm folder.
        /// </summary>
        [RepositoryFolder("9d53a73c-157d-420f-89f0-b2d1c7cbde86")]
        public virtual FileDetailsFolders.FileDetailFormAppFolder FileDetailForm
        {
            get { return _filedetailform; }
        }
    }

    /// <summary>
    /// Inner folder classes.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("Ranorex", global::Ranorex.Core.Constants.CodeGenVersion)]
    public partial class FileDetailsFolders
    {
        /// <summary>
        /// The FileDetailFormAppFolder folder.
        /// </summary>
        [RepositoryFolder("9d53a73c-157d-420f-89f0-b2d1c7cbde86")]
        public partial class FileDetailFormAppFolder : RepoGenBaseFolder
        {
            FileDetailsFolders.File_FactsFolder _file_facts;
            FileDetailsFolders.PanelRightFolder _panelright;
            FileDetailsFolders.PanelDetailsFolder _paneldetails;
            RepoItemInfo _savecloseInfo;

            /// <summary>
            /// Creates a new FileDetailForm  folder.
            /// </summary>
            public FileDetailFormAppFolder(RepoGenBaseFolder parentFolder) :
                    base("FileDetailForm", "/form[@controlname='FileDetailForm']", parentFolder, 30000, null, true, "9d53a73c-157d-420f-89f0-b2d1c7cbde86", "")
            {
                _file_facts = new FileDetailsFolders.File_FactsFolder(this);
                _panelright = new FileDetailsFolders.PanelRightFolder(this);
                _paneldetails = new FileDetailsFolders.PanelDetailsFolder(this);
                _savecloseInfo = new RepoItemInfo(this, "SaveClose", ".//button[@name='Save & Close']", 30000, null, "512b38e7-8c24-49f5-ba14-5136d277c6f2");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("9d53a73c-157d-420f-89f0-b2d1c7cbde86")]
            public virtual Ranorex.Form Self
            {
                get
                {
                    return _selfInfo.CreateAdapter<Ranorex.Form>(true);
                }
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("9d53a73c-157d-420f-89f0-b2d1c7cbde86")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The SaveClose item.
            /// </summary>
            [RepositoryItem("512b38e7-8c24-49f5-ba14-5136d277c6f2")]
            public virtual Ranorex.Button SaveClose
            {
                get
                {
                    return _savecloseInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The SaveClose item info.
            /// </summary>
            [RepositoryItemInfo("512b38e7-8c24-49f5-ba14-5136d277c6f2")]
            public virtual RepoItemInfo SaveCloseInfo
            {
                get
                {
                    return _savecloseInfo;
                }
            }

            /// <summary>
            /// The File_Facts folder.
            /// </summary>
            [RepositoryFolder("50ce4a27-95f5-4104-a6b2-82b8776a8178")]
            public virtual FileDetailsFolders.File_FactsFolder File_Facts
            {
                get { return _file_facts; }
            }

            /// <summary>
            /// The PanelRight folder.
            /// </summary>
            [RepositoryFolder("138abf1d-3336-4e2c-b375-73d4aa2b3d83")]
            public virtual FileDetailsFolders.PanelRightFolder PanelRight
            {
                get { return _panelright; }
            }

            /// <summary>
            /// The PanelDetails folder.
            /// </summary>
            [RepositoryFolder("fa35632d-e84f-478d-b12f-0e5912a8c140")]
            public virtual FileDetailsFolders.PanelDetailsFolder PanelDetails
            {
                get { return _paneldetails; }
            }
        }

        /// <summary>
        /// The File_FactsFolder folder.
        /// </summary>
        [RepositoryFolder("50ce4a27-95f5-4104-a6b2-82b8776a8178")]
        public partial class File_FactsFolder : RepoGenBaseFolder
        {
            RepoItemInfo _summaryInfo;
            RepoItemInfo _status_reportInfo;
            RepoItemInfo _notesInfo;
            RepoItemInfo _related_filesInfo;
            RepoItemInfo _eventsInfo;
            RepoItemInfo _time_spentInfo;
            RepoItemInfo _communicationsInfo;
            RepoItemInfo _documentsInfo;
            RepoItemInfo _researchInfo;
            RepoItemInfo _chronologyInfo;
            RepoItemInfo _custom_pagesInfo;
            RepoItemInfo _custom_recordsInfo;
            RepoItemInfo _shared_with_clientsInfo;
            RepoItemInfo _adminInfo;

            /// <summary>
            /// Creates a new File_Facts  folder.
            /// </summary>
            public File_FactsFolder(RepoGenBaseFolder parentFolder) :
                    base("File_Facts", "container[@controlname='panelLeftBase']//tree[@accessiblerole='Outline']", parentFolder, 30000, null, false, "50ce4a27-95f5-4104-a6b2-82b8776a8178", "")
            {
                _summaryInfo = new RepoItemInfo(this, "Summary", "treeitem[@text='Summary']", 30000, null, "4d4be7e6-64eb-440c-bc2f-f169c579d59d");
                _status_reportInfo = new RepoItemInfo(this, "Status_Report", "treeitem[@text='Status Report']", 30000, null, "cfbd8691-4b9f-4f01-bc82-66a4627685a2");
                _notesInfo = new RepoItemInfo(this, "Notes", "treeitem[@text='Notes']", 30000, null, "48682dec-ade6-42a8-a0b8-af13606f34f2");
                _related_filesInfo = new RepoItemInfo(this, "Related_Files", "treeitem[@text='Related Files']", 30000, null, "730dec91-feb9-4d45-ae2b-b5d435ab173a");
                _eventsInfo = new RepoItemInfo(this, "Events", "treeitem[@text='Events']", 30000, null, "732f442c-3ef2-45cd-9147-8b3188cc4524");
                _time_spentInfo = new RepoItemInfo(this, "Time_Spent", "treeitem[@text='Time Spent']", 30000, null, "0c1194f1-3b62-4cb4-955d-e18fe54712ee");
                _communicationsInfo = new RepoItemInfo(this, "Communications", "treeitem[@text='Communications']", 30000, null, "027dd09d-a9bc-4526-8b0e-330087c6a1e1");
                _documentsInfo = new RepoItemInfo(this, "Documents", "treeitem[@text='Documents']", 30000, null, "919b2ee5-d179-42d3-8213-8a6c5e002103");
                _researchInfo = new RepoItemInfo(this, "Research", "treeitem[@text='Research']", 30000, null, "8fd345d9-86bb-49bd-a4af-1e4e358b154f");
                _chronologyInfo = new RepoItemInfo(this, "Chronology", "treeitem[@text='Chronology']", 30000, null, "2bfd7eba-5f79-4939-a800-2edc48567420");
                _custom_pagesInfo = new RepoItemInfo(this, "Custom_Pages", "treeitem[@text='Custom Pages']", 30000, null, "5c8c872c-7505-43fb-ab69-c2763fd4fa60");
                _custom_recordsInfo = new RepoItemInfo(this, "Custom_Records", "treeitem[@text='Custom Records']", 30000, null, "1cb833db-dc9c-4709-8d06-3473607f0d1d");
                _shared_with_clientsInfo = new RepoItemInfo(this, "Shared_with_Clients", "treeitem[@text='Shared with Clients']", 30000, null, "dfc090f0-29ba-41ae-96fb-1e974a297b53");
                _adminInfo = new RepoItemInfo(this, "Admin", "treeitem[@text='Admin']", 30000, null, "cb9214f7-4731-43f8-9a18-e7629b55f2f9");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("50ce4a27-95f5-4104-a6b2-82b8776a8178")]
            public virtual Ranorex.Tree Self
            {
                get
                {
                    return _selfInfo.CreateAdapter<Ranorex.Tree>(true);
                }
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("50ce4a27-95f5-4104-a6b2-82b8776a8178")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The Summary item.
            /// </summary>
            [RepositoryItem("4d4be7e6-64eb-440c-bc2f-f169c579d59d")]
            public virtual Ranorex.TreeItem Summary
            {
                get
                {
                    return _summaryInfo.CreateAdapter<Ranorex.TreeItem>(true);
                }
            }

            /// <summary>
            /// The Summary item info.
            /// </summary>
            [RepositoryItemInfo("4d4be7e6-64eb-440c-bc2f-f169c579d59d")]
            public virtual RepoItemInfo SummaryInfo
            {
                get
                {
                    return _summaryInfo;
                }
            }

            /// <summary>
            /// The Status_Report item.
            /// </summary>
            [RepositoryItem("cfbd8691-4b9f-4f01-bc82-66a4627685a2")]
            public virtual Ranorex.TreeItem Status_Report
            {
                get
                {
                    return _status_reportInfo.CreateAdapter<Ranorex.TreeItem>(true);
                }
            }

            /// <summary>
            /// The Status_Report item info.
            /// </summary>
            [RepositoryItemInfo("cfbd8691-4b9f-4f01-bc82-66a4627685a2")]
            public virtual RepoItemInfo Status_ReportInfo
            {
                get
                {
                    return _status_reportInfo;
                }
            }

            /// <summary>
            /// The Notes item.
            /// </summary>
            [RepositoryItem("48682dec-ade6-42a8-a0b8-af13606f34f2")]
            public virtual Ranorex.TreeItem Notes
            {
                get
                {
                    return _notesInfo.CreateAdapter<Ranorex.TreeItem>(true);
                }
            }

            /// <summary>
            /// The Notes item info.
            /// </summary>
            [RepositoryItemInfo("48682dec-ade6-42a8-a0b8-af13606f34f2")]
            public virtual RepoItemInfo NotesInfo
            {
                get
                {
                    return _notesInfo;
                }
            }

            /// <summary>
            /// The Related_Files item.
            /// </summary>
            [RepositoryItem("730dec91-feb9-4d45-ae2b-b5d435ab173a")]
            public virtual Ranorex.TreeItem Related_Files
            {
                get
                {
                    return _related_filesInfo.CreateAdapter<Ranorex.TreeItem>(true);
                }
            }

            /// <summary>
            /// The Related_Files item info.
            /// </summary>
            [RepositoryItemInfo("730dec91-feb9-4d45-ae2b-b5d435ab173a")]
            public virtual RepoItemInfo Related_FilesInfo
            {
                get
                {
                    return _related_filesInfo;
                }
            }

            /// <summary>
            /// The Events item.
            /// </summary>
            [RepositoryItem("732f442c-3ef2-45cd-9147-8b3188cc4524")]
            public virtual Ranorex.TreeItem Events
            {
                get
                {
                    return _eventsInfo.CreateAdapter<Ranorex.TreeItem>(true);
                }
            }

            /// <summary>
            /// The Events item info.
            /// </summary>
            [RepositoryItemInfo("732f442c-3ef2-45cd-9147-8b3188cc4524")]
            public virtual RepoItemInfo EventsInfo
            {
                get
                {
                    return _eventsInfo;
                }
            }

            /// <summary>
            /// The Time_Spent item.
            /// </summary>
            [RepositoryItem("0c1194f1-3b62-4cb4-955d-e18fe54712ee")]
            public virtual Ranorex.TreeItem Time_Spent
            {
                get
                {
                    return _time_spentInfo.CreateAdapter<Ranorex.TreeItem>(true);
                }
            }

            /// <summary>
            /// The Time_Spent item info.
            /// </summary>
            [RepositoryItemInfo("0c1194f1-3b62-4cb4-955d-e18fe54712ee")]
            public virtual RepoItemInfo Time_SpentInfo
            {
                get
                {
                    return _time_spentInfo;
                }
            }

            /// <summary>
            /// The Communications item.
            /// </summary>
            [RepositoryItem("027dd09d-a9bc-4526-8b0e-330087c6a1e1")]
            public virtual Ranorex.TreeItem Communications
            {
                get
                {
                    return _communicationsInfo.CreateAdapter<Ranorex.TreeItem>(true);
                }
            }

            /// <summary>
            /// The Communications item info.
            /// </summary>
            [RepositoryItemInfo("027dd09d-a9bc-4526-8b0e-330087c6a1e1")]
            public virtual RepoItemInfo CommunicationsInfo
            {
                get
                {
                    return _communicationsInfo;
                }
            }

            /// <summary>
            /// The Documents item.
            /// </summary>
            [RepositoryItem("919b2ee5-d179-42d3-8213-8a6c5e002103")]
            public virtual Ranorex.TreeItem Documents
            {
                get
                {
                    return _documentsInfo.CreateAdapter<Ranorex.TreeItem>(true);
                }
            }

            /// <summary>
            /// The Documents item info.
            /// </summary>
            [RepositoryItemInfo("919b2ee5-d179-42d3-8213-8a6c5e002103")]
            public virtual RepoItemInfo DocumentsInfo
            {
                get
                {
                    return _documentsInfo;
                }
            }

            /// <summary>
            /// The Research item.
            /// </summary>
            [RepositoryItem("8fd345d9-86bb-49bd-a4af-1e4e358b154f")]
            public virtual Ranorex.TreeItem Research
            {
                get
                {
                    return _researchInfo.CreateAdapter<Ranorex.TreeItem>(true);
                }
            }

            /// <summary>
            /// The Research item info.
            /// </summary>
            [RepositoryItemInfo("8fd345d9-86bb-49bd-a4af-1e4e358b154f")]
            public virtual RepoItemInfo ResearchInfo
            {
                get
                {
                    return _researchInfo;
                }
            }

            /// <summary>
            /// The Chronology item.
            /// </summary>
            [RepositoryItem("2bfd7eba-5f79-4939-a800-2edc48567420")]
            public virtual Ranorex.TreeItem Chronology
            {
                get
                {
                    return _chronologyInfo.CreateAdapter<Ranorex.TreeItem>(true);
                }
            }

            /// <summary>
            /// The Chronology item info.
            /// </summary>
            [RepositoryItemInfo("2bfd7eba-5f79-4939-a800-2edc48567420")]
            public virtual RepoItemInfo ChronologyInfo
            {
                get
                {
                    return _chronologyInfo;
                }
            }

            /// <summary>
            /// The Custom_Pages item.
            /// </summary>
            [RepositoryItem("5c8c872c-7505-43fb-ab69-c2763fd4fa60")]
            public virtual Ranorex.TreeItem Custom_Pages
            {
                get
                {
                    return _custom_pagesInfo.CreateAdapter<Ranorex.TreeItem>(true);
                }
            }

            /// <summary>
            /// The Custom_Pages item info.
            /// </summary>
            [RepositoryItemInfo("5c8c872c-7505-43fb-ab69-c2763fd4fa60")]
            public virtual RepoItemInfo Custom_PagesInfo
            {
                get
                {
                    return _custom_pagesInfo;
                }
            }

            /// <summary>
            /// The Custom_Records item.
            /// </summary>
            [RepositoryItem("1cb833db-dc9c-4709-8d06-3473607f0d1d")]
            public virtual Ranorex.TreeItem Custom_Records
            {
                get
                {
                    return _custom_recordsInfo.CreateAdapter<Ranorex.TreeItem>(true);
                }
            }

            /// <summary>
            /// The Custom_Records item info.
            /// </summary>
            [RepositoryItemInfo("1cb833db-dc9c-4709-8d06-3473607f0d1d")]
            public virtual RepoItemInfo Custom_RecordsInfo
            {
                get
                {
                    return _custom_recordsInfo;
                }
            }

            /// <summary>
            /// The Shared_with_Clients item.
            /// </summary>
            [RepositoryItem("dfc090f0-29ba-41ae-96fb-1e974a297b53")]
            public virtual Ranorex.TreeItem Shared_with_Clients
            {
                get
                {
                    return _shared_with_clientsInfo.CreateAdapter<Ranorex.TreeItem>(true);
                }
            }

            /// <summary>
            /// The Shared_with_Clients item info.
            /// </summary>
            [RepositoryItemInfo("dfc090f0-29ba-41ae-96fb-1e974a297b53")]
            public virtual RepoItemInfo Shared_with_ClientsInfo
            {
                get
                {
                    return _shared_with_clientsInfo;
                }
            }

            /// <summary>
            /// The Admin item.
            /// </summary>
            [RepositoryItem("cb9214f7-4731-43f8-9a18-e7629b55f2f9")]
            public virtual Ranorex.TreeItem Admin
            {
                get
                {
                    return _adminInfo.CreateAdapter<Ranorex.TreeItem>(true);
                }
            }

            /// <summary>
            /// The Admin item info.
            /// </summary>
            [RepositoryItemInfo("cb9214f7-4731-43f8-9a18-e7629b55f2f9")]
            public virtual RepoItemInfo AdminInfo
            {
                get
                {
                    return _adminInfo;
                }
            }
        }

        /// <summary>
        /// The PanelRightFolder folder.
        /// </summary>
        [RepositoryFolder("138abf1d-3336-4e2c-b375-73d4aa2b3d83")]
        public partial class PanelRightFolder : RepoGenBaseFolder
        {
            FileDetailsFolders.EventsFolder _events;
            RepoItemInfo _newbtnInfo;
            RepoItemInfo _textInfo;
            RepoItemInfo _titleInfo;

            /// <summary>
            /// Creates a new PanelRight  folder.
            /// </summary>
            public PanelRightFolder(RepoGenBaseFolder parentFolder) :
                    base("PanelRight", ".//container[@controlname='panelRight']", parentFolder, 30000, null, false, "138abf1d-3336-4e2c-b375-73d4aa2b3d83", "")
            {
                _events = new FileDetailsFolders.EventsFolder(this);
                _newbtnInfo = new RepoItemInfo(this, "NewBtn", ".//button[@accessiblename='New']", 30000, null, "f6d6207b-51e1-4ca3-825d-dd16a9f6fbdd");
                _textInfo = new RepoItemInfo(this, "Text", ".//text[@accessiblerole='Text']", 30000, null, "d4090e28-2f48-4301-a4d1-0e7429c3ab6a");
                _titleInfo = new RepoItemInfo(this, "Title", ".//element[@controltypename='AmicusLabel']/text", 30000, null, "fad78093-c6a5-4fec-b12e-5d3c1668c5e6");
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("138abf1d-3336-4e2c-b375-73d4aa2b3d83")]
            public virtual Ranorex.Container Self
            {
                get
                {
                    return _selfInfo.CreateAdapter<Ranorex.Container>(true);
                }
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("138abf1d-3336-4e2c-b375-73d4aa2b3d83")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The NewBtn item.
            /// </summary>
            [RepositoryItem("f6d6207b-51e1-4ca3-825d-dd16a9f6fbdd")]
            public virtual Ranorex.Button NewBtn
            {
                get
                {
                    return _newbtnInfo.CreateAdapter<Ranorex.Button>(true);
                }
            }

            /// <summary>
            /// The NewBtn item info.
            /// </summary>
            [RepositoryItemInfo("f6d6207b-51e1-4ca3-825d-dd16a9f6fbdd")]
            public virtual RepoItemInfo NewBtnInfo
            {
                get
                {
                    return _newbtnInfo;
                }
            }

            /// <summary>
            /// The Text item.
            /// </summary>
            [RepositoryItem("d4090e28-2f48-4301-a4d1-0e7429c3ab6a")]
            public virtual Ranorex.Text Text
            {
                get
                {
                    return _textInfo.CreateAdapter<Ranorex.Text>(true);
                }
            }

            /// <summary>
            /// The Text item info.
            /// </summary>
            [RepositoryItemInfo("d4090e28-2f48-4301-a4d1-0e7429c3ab6a")]
            public virtual RepoItemInfo TextInfo
            {
                get
                {
                    return _textInfo;
                }
            }

            /// <summary>
            /// The Title item.
            /// </summary>
            [RepositoryItem("fad78093-c6a5-4fec-b12e-5d3c1668c5e6")]
            public virtual Ranorex.Text Title
            {
                get
                {
                    return _titleInfo.CreateAdapter<Ranorex.Text>(true);
                }
            }

            /// <summary>
            /// The Title item info.
            /// </summary>
            [RepositoryItemInfo("fad78093-c6a5-4fec-b12e-5d3c1668c5e6")]
            public virtual RepoItemInfo TitleInfo
            {
                get
                {
                    return _titleInfo;
                }
            }

            /// <summary>
            /// The Events folder.
            /// </summary>
            [RepositoryFolder("490bc84d-fddf-417e-b7ce-0c27865e0468")]
            public virtual FileDetailsFolders.EventsFolder Events
            {
                get { return _events; }
            }
        }

        /// <summary>
        /// The EventsFolder folder.
        /// </summary>
        [RepositoryFolder("490bc84d-fddf-417e-b7ce-0c27865e0468")]
        public partial class EventsFolder : RepoGenBaseFolder
        {
            RepoItemInfo _eventbytitleInfo;

            /// <summary>
            /// Creates a new Events  folder.
            /// </summary>
            public EventsFolder(RepoGenBaseFolder parentFolder) :
                    base("Events", "", parentFolder, 0, null, false, "490bc84d-fddf-417e-b7ce-0c27865e0468", "")
            {
                _eventbytitleInfo = new RepoItemInfo(this, "EventByTitle", ".//text[@uiautomationvaluevalue=$EventTitle]/parent::treeitem", 30000, null, "f2bb0fea-44fc-4c64-849a-863394b01f8a");
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("490bc84d-fddf-417e-b7ce-0c27865e0468")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }

            /// <summary>
            /// The EventByTitle item.
            /// </summary>
            [RepositoryItem("f2bb0fea-44fc-4c64-849a-863394b01f8a")]
            public virtual Ranorex.TreeItem EventByTitle
            {
                get
                {
                    return _eventbytitleInfo.CreateAdapter<Ranorex.TreeItem>(true);
                }
            }

            /// <summary>
            /// The EventByTitle item info.
            /// </summary>
            [RepositoryItemInfo("f2bb0fea-44fc-4c64-849a-863394b01f8a")]
            public virtual RepoItemInfo EventByTitleInfo
            {
                get
                {
                    return _eventbytitleInfo;
                }
            }
        }

        /// <summary>
        /// The PanelDetailsFolder folder.
        /// </summary>
        [RepositoryFolder("fa35632d-e84f-478d-b12f-0e5912a8c140")]
        public partial class PanelDetailsFolder : RepoGenBaseFolder
        {

            /// <summary>
            /// Creates a new PanelDetails  folder.
            /// </summary>
            public PanelDetailsFolder(RepoGenBaseFolder parentFolder) :
                    base("PanelDetails", ".//container[@controlname='panelDetails']", parentFolder, 30000, null, false, "fa35632d-e84f-478d-b12f-0e5912a8c140", "")
            {
            }

            /// <summary>
            /// The Self item.
            /// </summary>
            [RepositoryItem("fa35632d-e84f-478d-b12f-0e5912a8c140")]
            public virtual Ranorex.Container Self
            {
                get
                {
                    return _selfInfo.CreateAdapter<Ranorex.Container>(true);
                }
            }

            /// <summary>
            /// The Self item info.
            /// </summary>
            [RepositoryItemInfo("fa35632d-e84f-478d-b12f-0e5912a8c140")]
            public virtual RepoItemInfo SelfInfo
            {
                get
                {
                    return _selfInfo;
                }
            }
        }

    }
#pragma warning restore 0436
}
