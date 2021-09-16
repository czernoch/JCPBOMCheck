﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;


using Autodesk.Connectivity.Explorer.Extensibility;
using Autodesk.Connectivity.WebServices;
using Autodesk.Connectivity.WebServicesTools;
using VDF = Autodesk.DataManagement.Client.Framework;
using AWS = Autodesk.Connectivity.WebServices;

/* heslo klice 2JCPKey.pfx: +3aG[a>hGbf8,T)F */

[assembly: AssemblyCompany("Autodesk")]
[assembly: AssemblyProduct("JCPBOMCheckCommandExtension")]
[assembly: AssemblyDescription("Kontrola kusovníku")]

// This number gets incremented for each Vault release.
[assembly: Autodesk.Connectivity.Extensibility.Framework.ApiVersion("14.0")]

// The extension ID needs to be unique for each extension.  
// Make sure to generate your own ID when writing your own extension. 
[assembly: Autodesk.Connectivity.Extensibility.Framework.ExtensionId("89214E87-3553-4B7B-A1C9-F0CFD9469C05")]


namespace JCPBOMCheck
{



    /// <summary>
    /// This class implements the IExtension interface, which means it tells Vault Explorer what 
    /// commands and custom tabs are provided by this extension.
    /// </summary>
    public class JCPBOMCheckCommandExtension : IExplorerExtension
    {

        Dictionary<long, string> atributes = new Dictionary<long, string>()
        {
            {  8, "NazevSouboru" },
            { 79, "CisloSoucasti" },
            {165, "IndexSoucasti" },
            {158, "DelkaRozmerX" },
            {159, "DelkaRozmerY" },
            {173, "NazevMaterialu" },
            {168, "NastrojHraneni" },
            {169, "OperaceNaPolotovaru" },
            {160, "He_ID" },
            {161, "He_Kmen" },
            {162, "He_SkupZbo" },
            {197, "CharakterSestavy" },
            {172, "JakostMaterialu" },
            {166, "KrouzitNa" },
            { 71, "Popis" },
            { 20, "VizualizacePripojena" },
            { 27, "PripojenoKpolozce" },
            {  7, "DatumZarazeni" },
            {185, "FileExtension" }
        };



        /// <summary>
        /// This function tells Vault Explorer what custom commands this extension provides.
        /// Part of the IExtension interface.
        /// </summary>
        /// <returns>A collection of CommandSites, which are collections of custom commands.</returns>
        public IEnumerable<CommandSite> CommandSites()
        {
            //PropertyInfo[] prop;
            //prop = Properties.Resources.ResourceManager.GetObject("icon2JCP.bmp");


            // Create the Hello World command object.
            CommandItem CheckCmdItem = new CommandItem("JCPCommand", "Kontrola kusovníku...");
            CheckCmdItem.NavigationTypes = new SelectionTypeId[] { SelectionTypeId.File, SelectionTypeId.FileVersion };
            CheckCmdItem.MultiSelectEnabled = false;
            //CheckCmdItem.Image = Image.FromFile(@"c:\Programovani\JCPBOMCheck\icon2JCP.bmp");



            // The HelloWorldCommandHandler function is called when the custom command is executed.
            CheckCmdItem.Execute += BOMCheckCommandHandler;

            // Create a command site to hook the command to the Advanced toolbar
            CommandSite toolbarCmdSite = new CommandSite("JCPCommand.Toolbar", "2JCP")
            {
                Location = CommandSiteLocation.AdvancedToolbar,
                DeployAsPulldownMenu = false
            };
            toolbarCmdSite.AddCommand(CheckCmdItem);

            // Create another command site to hook the command to the right-click menu for Files.
            CommandSite fileContextCmdSite = new CommandSite("JCPCommand.FileContextMenu", "2JCP")
            {
                Location = CommandSiteLocation.FileContextMenu,
                DeployAsPulldownMenu = false
            };
            fileContextCmdSite.AddCommand(CheckCmdItem);

            // Now the custom command is available in 2 places.

            // Gather the sites in a List.
            List<CommandSite> sites = new List<CommandSite>();
            sites.Add(toolbarCmdSite);
            sites.Add(fileContextCmdSite);

            // Return the list of CommandSites.
            return sites;
        }


        /// <summary>
        /// This function tells Vault Explorer what custom tabs this extension provides.
        /// Part of the IExtension interface.
        /// </summary>
        /// <returns>A collection of DetailTabs, each object represents a custom tab.</returns>
        public IEnumerable<DetailPaneTab> DetailTabs()
        {
            // Create a DetailPaneTab list to return from method
            List<DetailPaneTab> fileTabs = new List<DetailPaneTab>();

            // Create Selection Info tab for Files
            DetailPaneTab filePropertyTab = new DetailPaneTab("File.Tab.PropertyGrid",
                                                        "Selection Info",
                                                        SelectionTypeId.File,
                                                        typeof(MyCustomTabControl));

            // The propertyTab_SelectionChanged is called whenever our tab is active and the selection changes in the 
            // main grid.
            filePropertyTab.SelectionChanged += propertyTab_SelectionChanged;
            fileTabs.Add(filePropertyTab);

            // Create Selection Info tab for Folders
            DetailPaneTab folderPropertyTab = new DetailPaneTab("Folder.Tab.PropertyGrid",
                                                        "Selection Info",
                                                        SelectionTypeId.Folder,
                                                        typeof(MyCustomTabControl));
            folderPropertyTab.SelectionChanged += propertyTab_SelectionChanged;
            fileTabs.Add(folderPropertyTab);

            // Create Selection Info tab for Items
            DetailPaneTab itemPropertyTab = new DetailPaneTab("Item.Tab.PropertyGrid",
                                                        "Selection Info",
                                                        SelectionTypeId.Item,
                                                        typeof(MyCustomTabControl));
            itemPropertyTab.SelectionChanged += propertyTab_SelectionChanged;
            fileTabs.Add(itemPropertyTab);

            // Create Selection Info tab for Change Orders
            DetailPaneTab coPropertyTab = new DetailPaneTab("Co.Tab.PropertyGrid",
                                                        "Selection Info",
                                                        SelectionTypeId.ChangeOrder,
                                                        typeof(MyCustomTabControl));
            coPropertyTab.SelectionChanged += propertyTab_SelectionChanged;
            fileTabs.Add(coPropertyTab);

            // Return tabs
            return fileTabs;
        }




        /// <summary>
        /// This function is called after the user logs in to the Vault Server.
        /// Part of the IExtension interface.
        /// </summary>
        /// <param name="application">Provides information about the running application.</param>
        public void OnLogOn(IApplication application)
        {
        }

        /// <summary>
        /// This function is called after the user is logged out of the Vault Server.
        /// Part of the IExtension interface.
        /// </summary>
        /// <param name="application">Provides information about the running application.</param>
        public void OnLogOff(IApplication application)
        {
        }

        /// <summary>
        /// This function is called before the application is closed.
        /// Part of the IExtension interface.
        /// </summary>
        /// <param name="application">Provides information about the running application.</param>
        public void OnShutdown(IApplication application)
        {
            // Although this function is empty for this project, it's still needs to be defined 
            // because it's part of the IExtension interface.
        }

        /// <summary>
        /// This function is called after the application starts up.
        /// Part of the IExtension interface.
        /// </summary>
        /// <param name="application">Provides information about the running application.</param>
        public void OnStartup(IApplication application)
        {
            // Although this function is empty for this project, it's still needs to be defined 
            // because it's part of the IExtension interface.
        }

        /// <summary>
        /// This function tells Vault Exlorer which default commands should be hidden.
        /// Part of the IExtension interface.
        /// </summary>
        /// <returns>A collection of command names.</returns>
        public IEnumerable<string> HiddenCommands()
        {
            // This extension does not hide any commands.
            return null;
        }

        /// <summary>
        /// This function allows the extension to define special behavior for Custom Entity types.
        /// Part of the IExtension interface.
        /// </summary>
        /// <returns>A collection of CustomEntityHandler objects.  Each object defines special behavior
        /// for a specific Custom Entity type.</returns>
        public IEnumerable<CustomEntityHandler> CustomEntityHandlers()
        {
            // This extension does not provide special Custom Entity behavior.
            return null;
        }


        /// <summary>
        /// This is the function that is called whenever the custom command is executed.
        /// </summary>
        /// <param name="s">The sender object.  Usually not used.</param>
        /// <param name="e">The event args.  Provides additional information about the environment.</param>
        void BOMCheckCommandHandler(object s, CommandItemEventArgs e)
        {
            /* try
             {*/
            VDF.Vault.Currency.Connections.Connection connection = e.Context.Application.Connection;

            // The Context part of the event args tells us information about what is selected.
            // Run some checks to make sure that the selection is valid.
            if (e.Context.CurrentSelectionSet.Count() == 0)
            {
                MessageBox.Show("Vyberte soubor");
                return;
            }
            if (e.Context.CurrentSelectionSet.Count() > 1)
            {
                MessageBox.Show("Tato funkce nefunguje při výběru více souborů");
                return;
            }

            // we only have one item selected, which is the expected behavior
            ISelection selection = e.Context.CurrentSelectionSet.First();

            // Look of the File object.  How we do this depends on what is selected.
            File selectedFile = null;

            if (selection.TypeId == SelectionTypeId.File)
            {
                // our ISelection.Id is really a File.MasterId
                selectedFile = connection.WebServiceManager.DocumentService.GetLatestFileByMasterId(selection.Id);
            }
            else if (selection.TypeId == SelectionTypeId.FileVersion)
            {
                // our ISelection.Id is really a File.Id
                selectedFile = connection.WebServiceManager.DocumentService.GetFileById(selection.Id);
            }

            if (selectedFile == null)
            {
                MessageBox.Show("Výběr není soubor.");
                return;
            }

            LoadingForm load = new LoadingForm();

            load.Start();
            try
            {

                string vystup = string.Empty; // jenom promenna do messageboxu na testovani

                // vytahnuti atributu ipt/iam
                /*
                PropDef[] pdefs = connection.WebServiceManager.PropertyService.GetPropertyDefinitionsByEntityClassId("FILE");
                foreach (PropDef xx in pdefs)
                {
                    vystup += xx.DispName + " :: " + xx.Id + "\n";
                }

                Clipboard.SetText(vystup);
                MessageBox.Show(vystup);
                return;
                */

                // kusovnik na strane vaultu
                BOM bom = connection.WebServiceManager.DocumentService.GetBOMByFileId(selectedFile.Id);

                load.progressBar1.Maximum = bom.CompArray.Length;
                load.progressBar1.Step = 1;

                File extid;
                File[] masterid;
                PropInst[] propdata;

                Dictionary<int, Dictionary<string,string>> bomdata = new Dictionary<int, Dictionary<string, string>>();
                Dictionary<string, string> xx = new Dictionary<string, string>();
                Dictionary<long, bool> duplicita = new Dictionary<long, bool>();

                int x = 0;
                foreach (BOMComp bomitem in bom.CompArray)
                {
                    xx.Clear();
                    load.progressBar1.PerformStep();

                    if (bomitem.Id > 1 && duplicita.ContainsKey(bomitem.XRefId)) continue;
                    duplicita.Add(bomitem.XRefId, true);

//                    if (bomitem.XRefId > 0) extid = connection.WebServiceManager.DocumentService.GetFileById(bomitem.XRefId);
                    if (bomitem.Id > 1) extid = connection.WebServiceManager.DocumentService.GetFileById(bomitem.XRefId);
                    else extid = connection.WebServiceManager.DocumentService.GetFileById(selectedFile.Id);

                    //if (bomitem.XRefId > 0) masterid = connection.WebServiceManager.DocumentService.FindFilesByIds(new long[] { bomitem.XRefId });
                    //else masterid = connection.WebServiceManager.DocumentService.FindFilesByIds(new long[] { selectedFile.Id });

                    //extid = connection.WebServiceManager.DocumentService.GetLatestFileByMasterId(masterid[0].MasterId);

                    // preskocim duplicity
                    //if (bomitem.Id == 1 && duplicita.ContainsKey(extid.Id)) continue;
                    //if (bomitem.Id > 1 && duplicita.ContainsKey(extid.Id)) continue;

                    
                  //       if (duplicita.ContainsKey(extid.Id)) continue;
//                    duplicita.Add(extid.Id, true);

                    propdata = connection.WebServiceManager.PropertyService.GetProperties("FILE", new long[] { extid.Id }, atributes.Keys.ToArray());

                    foreach (PropInst xy in propdata)
                    {
                        xx.Add(atributes[xy.PropDefId], (xy.Val ?? "") + "");
                    }

                    xx.Add("BaseQty", bomitem.BaseQty.ToString());
                    xx.Add("CompTyp", bomitem.CompTyp.ToString());
                    xx.Add("BOMStruct", bomitem.BOMStruct.ToString());
                    xx.Add("UniqueId", bomitem.UniqueId.ToString());
                    xx.Add("XRefTyp", bomitem.XRefTyp.ToString());
                    xx.Add("ID", extid.Id.ToString());
                    xx.Add("MasterID", extid.MasterId.ToString());
                    xx.Add("BaseUOM", bomitem.BaseUOM);

                    
                    if (bomitem.Id == 5)
                    {
                        string vys = "";
                        foreach (var tat in xx)
                        {
                            vys += tat.Key + ": " + tat.Value + "\n";
                        }
                        MessageBox.Show(vys);
                        break;
                    }
                    

                    bomdata.Add(x, xx);
                    x++;
                }

                load.Stop();

                MessageBox.Show("celkem: " + bom.CompArray.Length.ToString() + ", načteno: " + bomdata.Count.ToString()); 

                PanelMaster panel = new PanelMaster();
                panel.selectedFile = selectedFile;
                panel.bomdata = bomdata;
                panel.connection = connection;
                panel.ShowDialog();

            }
            catch (Exception ex)
            {
                load.Stop();
                MessageBox.Show("No reference files found. " + ex.Message);
            }

        }

        /// <summary>
        /// This function is called whenever our custom tab is active and the selection has changed in the main grid.
        /// </summary>
        /// <param name="sender">The sender object.  Usually not used.</param>
        /// <param name="e">The event args.  Provides additional information about the environment.</param>
        void propertyTab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // The event args has our custom tab object.  We need to cast it to our type.
                MyCustomTabControl tabControl = e.Context.UserControl as MyCustomTabControl;

                // Send selection to the tab so that it can display the object.
                tabControl.SetSelectedObject(e.Context.SelectedObject);
            }
            catch (Exception ex)
            {
                // If something goes wrong, we don't want the exception to bubble up to Vault Explorer.
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
