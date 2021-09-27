using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;

using Autodesk.Connectivity.Explorer.Extensibility;
using Autodesk.Connectivity.WebServices;
using Autodesk.Connectivity.WebServicesTools;
using VDF = Autodesk.DataManagement.Client.Framework;

namespace JCPBOMCheck
{
    public partial class PanelMaster : Form
    {
        public File selectedFile;
        public Dictionary<long, Dictionary<string, string>> bomdata = new Dictionary<long, Dictionary<string, string>>();

        ColumnHeader colList1atr = ((ColumnHeader)(new ColumnHeader()));
        ColumnHeader colList2atr = ((ColumnHeader)(new ColumnHeader()));
        ColumnHeader colList3atr = ((ColumnHeader)(new ColumnHeader()));
        ColumnHeader colList4atr = ((ColumnHeader)(new ColumnHeader()));
        ColumnHeader colList5atr = ((ColumnHeader)(new ColumnHeader()));
        ColumnHeader colList6atr = ((ColumnHeader)(new ColumnHeader()));
        ColumnHeader colList7atr = ((ColumnHeader)(new ColumnHeader()));
        ColumnHeader colList8atr = ((ColumnHeader)(new ColumnHeader()));
        ColumnHeader colList9atr = ((ColumnHeader)(new ColumnHeader()));

        ColumnHeader colList1dxf = ((ColumnHeader)(new ColumnHeader()));
        ColumnHeader colList2dxf = ((ColumnHeader)(new ColumnHeader()));
        ColumnHeader colList3dxf = ((ColumnHeader)(new ColumnHeader()));
        ColumnHeader colList4dxf = ((ColumnHeader)(new ColumnHeader()));
        ColumnHeader colList5dxf = ((ColumnHeader)(new ColumnHeader()));
        ColumnHeader colList6dxf = ((ColumnHeader)(new ColumnHeader()));

        ColumnHeader colList1idw = ((ColumnHeader)(new ColumnHeader()));
        ColumnHeader colList2idw = ((ColumnHeader)(new ColumnHeader()));
        ColumnHeader colList3idw = ((ColumnHeader)(new ColumnHeader()));
        ColumnHeader colList4idw = ((ColumnHeader)(new ColumnHeader()));
        ColumnHeader colList5idw = ((ColumnHeader)(new ColumnHeader()));
        ColumnHeader colList6idw = ((ColumnHeader)(new ColumnHeader()));
        ColumnHeader colList7idw = ((ColumnHeader)(new ColumnHeader()));

        ColumnHeader colList1pol = ((ColumnHeader)(new ColumnHeader()));
        ColumnHeader colList2pol = ((ColumnHeader)(new ColumnHeader()));
        ColumnHeader colList3pol = ((ColumnHeader)(new ColumnHeader()));
        ColumnHeader colList4pol = ((ColumnHeader)(new ColumnHeader()));
        ColumnHeader colList5pol = ((ColumnHeader)(new ColumnHeader()));
        ColumnHeader colList6pol = ((ColumnHeader)(new ColumnHeader()));

        ListView listatr = new ListView();
        ListView listdxf = new ListView();
        ListView listidw = new ListView();
        ListView listpol = new ListView();

        public VDF.Vault.Currency.Connections.Connection connection;

        TabPage myTabPageATR = new TabPage();
        TabPage myTabPageDXF = new TabPage();
        TabPage myTabPageIDW = new TabPage();
        TabPage myTabPagePOL = new TabPage();

        public PanelMaster()
        {
            InitializeComponent();
            tabControl.TabPages.Clear(); // smazani vsech tabu

            listatr.Name = "Atributy";
            listatr.Dock = DockStyle.Fill;

            listatr.Columns.AddRange(new ColumnHeader[] { colList1atr, colList2atr, colList3atr, colList4atr, colList5atr, colList6atr, colList7atr, colList8atr, colList9atr });
            colList1atr.Text = "Číslo součásti"; colList1atr.Width = 100;
            colList2atr.Text = "Popis"; colList2atr.Width = 80; //colList2atr.TextAlign = HorizontalAlignment.Center;
            colList3atr.Text = "Materiál"; colList3atr.Width = 60; colList3atr.TextAlign = HorizontalAlignment.Center;
            colList4atr.Text = "Jakost"; colList4atr.Width = 60; colList4atr.TextAlign = HorizontalAlignment.Center;
            colList5atr.Text = "IS"; colList5atr.Width = 30; colList5atr.TextAlign = HorizontalAlignment.Center;
            colList6atr.Text = "Operace"; colList6atr.Width = 60;
            colList7atr.Text = "He_Kmen"; colList7atr.Width = 60;
            colList8atr.Text = "Charakter sestavy"; colList8atr.Width = 60;
            colList9atr.Text = "Chyba"; colList9atr.Width = 200;
        //    listatr.Location = new System.Drawing.Point(30, 30);
            listatr.GridLines = true;
            listatr.HideSelection = false;
            listatr.FullRowSelect = true;
            listatr.View = View.Details;
            listatr.UseCompatibleStateImageBehavior = false;
            listatr.Visible = true;
            listatr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView_KeyDown);
//            AutoSizeColumnList(listatr);

            //TabPage myTabPageATR = new TabPage(listatr.Name);
            myTabPageATR.Name = listatr.Name;
            myTabPageATR.Text = listatr.Name;
            myTabPageATR.Controls.Add(listatr);
            tabControl.TabPages.Add(myTabPageATR);


            listdxf.Name = "DXF";
            listdxf.Dock = DockStyle.Fill;
            listdxf.Columns.AddRange(new ColumnHeader[] { colList1dxf, colList2dxf, colList3dxf, colList4dxf, colList5dxf, colList6dxf });
            colList1dxf.Text = "Číslo součásti"; colList1dxf.Width = 100;
            colList2dxf.Text = "Stav"; colList2dxf.Width = 80; colList2dxf.TextAlign = HorizontalAlignment.Center;
            colList3dxf.Text = "Materiál"; colList3dxf.Width = 60; colList3dxf.TextAlign = HorizontalAlignment.Center;
            colList4dxf.Text = "IS"; colList4dxf.Width = 30; colList4dxf.TextAlign = HorizontalAlignment.Center;
            colList5dxf.Text = "Operace"; colList5dxf.Width = 60;
            colList6dxf.Text = "Chyba"; colList6dxf.Width = 200;

            //listdxf.Location = new System.Drawing.Point(30, 30);
            listdxf.GridLines = true;
            listdxf.HideSelection = false;
            listdxf.FullRowSelect = true;
            listdxf.View = View.Details;
            listdxf.UseCompatibleStateImageBehavior = false;
            listdxf.Visible = true;
            listdxf.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView_KeyDown);
            listatr.Sorting = SortOrder.Ascending;

            myTabPageDXF.Name = listdxf.Name;
            myTabPageDXF.Text = listdxf.Name;
            myTabPageDXF.Controls.Add(listdxf);
            tabControl.TabPages.Add(myTabPageDXF);


            listidw.Name = "IDW";
            listidw.Dock = DockStyle.Fill;

            listidw.Columns.AddRange(new ColumnHeader[] { colList1idw, colList2idw, colList3idw, colList4idw, colList5idw, colList6idw, colList7idw });
            colList1idw.Text = "Číslo součásti"; colList1idw.Width = 100;
            colList2idw.Text = "Popis"; colList2idw.Width = 150; //colList2idw.TextAlign = HorizontalAlignment.Center;
            colList3idw.Text = "Materiál"; colList3idw.Width = 60; colList3idw.TextAlign = HorizontalAlignment.Center;
            colList4idw.Text = "IS"; colList4idw.Width = 30; colList4idw.TextAlign = HorizontalAlignment.Center;
            colList5idw.Text = "Operace"; colList5idw.Width = 60;
            colList6idw.Text = "Charakter sestavy"; colList5idw.Width = 80;
            colList7idw.Text = "Chyba"; colList6idw.Width = 200;

            listidw.GridLines = true;
            listidw.HideSelection = false;
            listidw.FullRowSelect = true;
            listidw.View = View.Details;
            listidw.UseCompatibleStateImageBehavior = false;
            listidw.Visible = true;
            listidw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView_KeyDown);
            listidw.Sorting = SortOrder.Ascending;

            myTabPageIDW.Name = listidw.Name;
            myTabPageIDW.Text = listidw.Name;
            myTabPageIDW.Controls.Add(listidw);
            tabControl.TabPages.Add(myTabPageIDW);


            listpol.Name = "Položky";
            listpol.Dock = DockStyle.Fill;

            listpol.Columns.AddRange(new ColumnHeader[] { colList1pol, colList2pol, colList3pol, colList4pol, colList5pol, colList6pol });
            colList1pol.Text = "Číslo položky"; colList1pol.Width = 110;
            colList2pol.Text = "He_Kmen"; colList2pol.Width = 110;
            colList3pol.Text = "SkupZbo"; colList3pol.Width = 60; colList3pol.TextAlign = HorizontalAlignment.Center;
            colList4pol.Text = "Číslo součásti"; colList4pol.Width = 110;
            colList5pol.Text = "Název souboru"; colList5pol.Width = 110; 
            colList6pol.Text = "Chyba"; colList6pol.Width = 200;

            listpol.GridLines = true;
            listpol.HideSelection = false;
            listpol.FullRowSelect = true;
            listpol.View = View.Details;
            listpol.UseCompatibleStateImageBehavior = false;
            listpol.Visible = true;
            listpol.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView_KeyDown);
            listpol.Sorting = SortOrder.Ascending;

            myTabPagePOL.Name = listpol.Name;
            myTabPagePOL.Text = listpol.Name;
            myTabPagePOL.Controls.Add(listpol);
            tabControl.TabPages.Add(myTabPagePOL);

        }

        private void buttonSpustit_Click(object sender, EventArgs e)
        {
            buttonSpustit.Enabled = false;

            // smazani nastaveni sloupcu a dat
            listatr.Items.Clear();
            listdxf.Items.Clear();
            listidw.Items.Clear();
            listpol.Items.Clear();

            //    listatr.BeginUpdate();
            //    listdxf.BeginUpdate();
            //    listidw.BeginUpdate();

            myTabPageATR.Text = listatr.Name + " (N/A)";
            myTabPageDXF.Text = listdxf.Name + " (N/A)";
            myTabPageIDW.Text = listidw.Name + " (N/A)";
            myTabPagePOL.Text = listpol.Name + " (N/A)";

            #region Panel Kontrola kusovníku

            if (checkAtributy.Checked == true)
            {
                //   listatr.Refresh();

                toolStripProgressBar1.Maximum = bomdata.Values.Count();
                toolStripProgressBar1.Step = 1;
                toolStripStatusLabel1.Text = "Vyhledávání atributů kusovníku.";

                foreach (var bomitem in bomdata)
                {

                    toolStripProgressBar1.PerformStep();

                    //          listatr.BeginUpdate();
                    StringBuilder er = new StringBuilder();

                    try
                    { 
                        // chybí index součásti
                        if (bomitem.Value["IndexSoucasti"].Length == 0) er.Append("Chybí index součásti. ");

                        // číslo součásti je jiné než název souboru
                        if (bomitem.Value["CisloSoucasti"] != bomitem.Value["NazevSouboru"].Substring(0, bomitem.Value["NazevSouboru"].Length - 4))
                            er.Append("Název souboru se liší " + bomitem.Value["NazevSouboru"] + " od čísla součásti. ");

                        // číslo součásti je jiné než název souboru
                        if (bomitem.Value["CisloSoucasti"].Length > 30)
                            er.Append("Název součásti je delší ("+ bomitem.Value["CisloSoucasti"].Length+") než 30 znaků. ");

                        // chybí název materiálu
                        if ((bomitem.Value["IndexSoucasti"] == "V" || bomitem.Value["IndexSoucasti"] == "D") && bomitem.Value["NazevMaterialu"].Length == 0)
                            er.Append("Není vyplněn název materiálu. ");

                        if (bomitem.Value["NazevMaterialu"].Length > 50)
                            er.Append("Název materiálu je delší jak 50 znaků. ");

                        // he_kmen je jiný než číslo součásti
                        if ((bomitem.Value["He_SkupZbo"] + "-" + bomitem.Value["CisloSoucasti"]) != bomitem.Value["He_Kmen"])
                            er.Append("He_Kmen neodpovídá číslu součásti a skupině zboží. ");

                        if (bomitem.Value["He_SkupZbo"].Length > 3)
                            er.Append("He_SkupZbo je delší jak 3 znaky. ");

                        // chybí jakost materiálu
                        if ((bomitem.Value["IndexSoucasti"] == "V" || bomitem.Value["IndexSoucasti"] == "D") && bomitem.Value["JakostMaterialu"].Length == 0)
                            er.Append("Není vyplněna jakost materiálu. ");

                        // u sestav chybí charakter sestavy
                        if (bomitem.Value["IndexSoucasti"] == "A" && bomitem.Value["CharakterSestavy"].Length == 0)
                            er.Append("Chybí charakter sestavy. ");

                        // charakter sestavy se jmenuje jinak
                        if (bomitem.Value["IndexSoucasti"] == "A" && bomitem.Value["CharakterSestavy"].Length > 0)
                        {
                            switch (bomitem.Value["CharakterSestavy"])
                            {
                                case "Svařená černá":
                                case "Svařená nerez":
                                case "Montovaná":
                                case "Balící":
                                    break;

                                default:
                                    er.Append("Charakter sestavy nemá správný název. ");
                                    break;
                            }

                        }

                        // popis je delsi jak 100 znaků
                        if (bomitem.Value["Popis"].Length > 100) er.Append("Popis je delší jak 100 znaků. ");

                        if (er.Length > 0)
                        {
                            // zapsani chyby
                            listatr.Items.Add(new ListViewItem(new[] {
                                bomitem.Value["CisloSoucasti"],
                                bomitem.Value["Popis"],
                                bomitem.Value["NazevMaterialu"],
                                bomitem.Value["JakostMaterialu"],
                                bomitem.Value["IndexSoucasti"],
                                bomitem.Value["OperaceNaPolotovaru"],
                                bomitem.Value["He_Kmen"],
                                bomitem.Value["CharakterSestavy"],
                                er.ToString() }));

                 //           listatr.EndUpdate();
                //            listatr.Refresh();
                        }
                    }
                    catch
                    {
                        listatr.Items.Add(new ListViewItem(new[] { bomitem.Value["NazevSouboru"], "", "", "", "", "", "", "", "Neznámá chyba. Chybí data." }));
           //             listatr.EndUpdate();
            //            listatr.Refresh();
                    }
                }

                myTabPageATR.Text = listatr.Name + " (" + listatr.Items.Count + ")";
                toolStripStatusLabel1.Text = "Hledání atributů kusovníku dokončeno.";

                if (listatr.Items.Count > 0)
                {
                    
                    listatr.Sort();
           //         listatr.EndUpdate();
           //         listatr.Refresh();
          //          listatr.Show();
                    AutoSizeColumnList(listatr);
                }
            }

            #endregion

            #region Panel DXF

            if (checkDXF.Checked == true)
            {
                toolStripProgressBar1.Maximum = bomdata.Values.Count();
                toolStripProgressBar1.Step = 1;
                toolStripStatusLabel1.Text = "Vyhledávání DXF.";

                foreach (var bomitem in bomdata)
                {
                    toolStripProgressBar1.PerformStep();

                    try
                    {
                        if (bomitem.Value["IndexSoucasti"] == "V")
                        {
                            string er = "Soubor nenalezen.";
                            string stav = "";
                    //        listdxf.BeginUpdate();

                            // vyhledani DXF
                            File[] fileout = getVaultFile(bomitem.Value["CisloSoucasti"] + ".dxf");

                            foreach (File f in fileout)
                            {
                                if (f.Name == bomitem.Value["CisloSoucasti"] + ".dxf" || f.Name == bomitem.Value["CisloSoucasti"] + ".DXF")
                                {
                                    stav = f.FileLfCyc.LfCycStateName;

                                    switch (stav)
                                    {
                                        case "Schváleno":
                                        case "Released":
                                            er = "OK";
                                            continue;

                                        default:
                                            er = "Chybný životní cyklus.";
                                            continue;
                                    }
                                }
                            }

                            if (er == "OK") continue; // vyskocim dal pokud dxf existuje

                            if (bomitem.Value["CisloSoucasti"] != bomitem.Value["NazevSouboru"].Substring(0, bomitem.Value["NazevSouboru"].Length - 4))
                                er = "Číslo součásti je jiné než název souboru " + bomitem.Value["NazevSouboru"];

                            // zapsani chyby
                            listdxf.Items.Add(new ListViewItem(new[] {
                                bomitem.Value["CisloSoucasti"],
                                stav,
                                bomitem.Value["NazevMaterialu"],
                                bomitem.Value["IndexSoucasti"],
                                bomitem.Value["OperaceNaPolotovaru"],
                                er }));

               //             listdxf.EndUpdate();
               //             listdxf.Refresh();
                        }
                    }
                    catch
                    {
                        listdxf.Items.Add(new ListViewItem(new[] { bomitem.Value["NazevSouboru"], "", "", "", "", "Neznámá chyba. Chybí data." }));
//                        listdxf.EndUpdate();
                      //  listdxf.Refresh();
                        
                    }
                }

                myTabPageDXF.Text = listdxf.Name + " (" + listdxf.Items.Count + ")";

                if (listdxf.Items.Count > 0)
                {
                    //listdxf.Sorting = SortOrder.Ascending;
                    listdxf.Sort();
                    //listdxf.Show();
                    AutoSizeColumnList(listdxf);
                }

                toolStripStatusLabel1.Text = "Hledání DXF dokončeno.";

            }
            #endregion

            #region Panel IDW

            if (checkIDW.Checked == true)
            {

                toolStripProgressBar1.Maximum = bomdata.Values.Count();
                toolStripProgressBar1.Step = 1;
                toolStripStatusLabel1.Text = "Vyhledávání výkresů.";

                //    listidw.Refresh();

                foreach (var bomitem in bomdata)
                {
                    //         listidw.BeginUpdate();

                    toolStripProgressBar1.PerformStep();

                    try
                    {
                        
                        if (bomitem.Value["OperaceNaPolotovaru"].Length > 0 || (bomitem.Value["IndexSoucasti"] == "A" && checkSestavy.Checked == true)) // jestli existuje nejaka operace
                        {
                            string er = "Výkres nenalezen.";

                            // vyhledani IDW
                            File[] fileout = getVaultFile(bomitem.Value["CisloSoucasti"] + ".idw");
                            toolStripStatusLabel1.Text = "Hledám " + bomitem.Value["CisloSoucasti"] + ".idw";

                            foreach (File f in fileout)
                            {

                                if (checkDatumy.Checked && f.ModDate < DateTime.Parse(bomitem.Value["DatumZarazeni"]) && (f.Name == bomitem.Value["CisloSoucasti"] + ".idw" || f.Name == bomitem.Value["CisloSoucasti"] + ".IDW"))
                                {
                                    er = "Výkres je staršího data než " + (bomitem.Value["FileExtension"] == "iam" ? "sestava" : "součást") + ".";
                                    continue;
                                }

                                if (f.Name == bomitem.Value["CisloSoucasti"] + ".idw" || f.Name == bomitem.Value["CisloSoucasti"] + ".IDW")
                                {
                                    er = "OK";
                                    continue;
                                }
                            }

                            if (er == "OK") continue; // vyskocim dal pokud dxf existuje


                            if (bomitem.Value["CisloSoucasti"] != bomitem.Value["NazevSouboru"].Substring(0, bomitem.Value["NazevSouboru"].Length - 4))
                                er = "Číslo součásti je jiné než název souboru " + bomitem.Value["NazevSouboru"];
                        
                        // zapsani chyby

                     //   listidw.Items.Add(new ListViewItem(new[] { bomitem }));

                            
                            listidw.Items.Add(new ListViewItem(new[] {
                                bomitem.Value["CisloSoucasti"],
                                bomitem.Value["Popis"],
                                bomitem.Value["NazevMaterialu"],
                                bomitem.Value["IndexSoucasti"],
                                bomitem.Value["OperaceNaPolotovaru"],
                                bomitem.Value["CharakterSestavy"],
                                er }));
                            
                            //         listidw.EndUpdate();
                            //         listidw.Refresh();

                        }
                    }
                    catch
                    {
                        listidw.Items.Add(new ListViewItem(new[] { bomitem.Value["NazevSouboru"], "", "", "", "", "", "Neznámá chyba. Chybí data." }));
                    }
                }

                
                myTabPageIDW.Text = listidw.Name + " (" + listidw.Items.Count + ")";

                if (listidw.Items.Count > 0)
                {
                    AutoSizeColumnList(listidw);
                    listidw.Sort();
                    //listidw.EndUpdate();
                }

                toolStripStatusLabel1.Text = "Hledání výkresů dokončeno.";

            }

            #endregion

            #region Panel Polozky

            if (checkPolozky.Checked == true)
            {

                toolStripProgressBar1.Maximum = bomdata.Values.Count();
                toolStripProgressBar1.Step = 1;
                toolStripStatusLabel1.Text = "Vyhledávání položek.";

                //    listidw.Refresh();

                foreach (var bomitem in bomdata)
                {
                    //         listidw.BeginUpdate();

                    toolStripProgressBar1.PerformStep();
                    StringBuilder er = new StringBuilder();

                    try
                    {
                        string number = "";

                        // zjistim nazev polozky
                        Item[] propdata;
                        propdata = connection.WebServiceManager.ItemService.GetItemsByFileId(Convert.ToInt64(bomitem.Value["ID"]));
                        if (propdata.Length > 0) number = propdata[0].ItemNum;
                        else number = "";

                        string hekmen = bomitem.Value["He_SkupZbo"] + "-" + bomitem.Value["CisloSoucasti"];

                        // číslo součásti neodpovídá názvu souboru
                        if (bomitem.Value["CisloSoucasti"] != bomitem.Value["NazevSouboru"].Substring(0, bomitem.Value["NazevSouboru"].Length - 4))
                            er.Append("Název souboru se liší od čísla součásti. ");

                        // he_kmen neodpovídá skupině zboží + číslu součásti
                        if (bomitem.Value["He_Kmen"] != hekmen)
                            er.Append("He_Kmen není složením ze skupiny zboží a čísla součásti. ");

                        // he_kmen neodpovídá číslu položky (number)
                        if (number.Length > 0 && bomitem.Value["He_Kmen"] != number)
                            er.Append("Číslo položky (Number) se liší od He_Kmen. ");

                        // kontrola number jestli je 3 znaky na prvním místě, pak pomlčka a zbytek
                        Regex regex = new Regex("^([0-9][0-9][0-9])([-])(.*)$");
                        Match match = regex.Match(number);
                        if (number.Length > 0 && (match.Groups[1].Value.Length != 3 || match.Groups[2].Value != "-"))
                            er.Append("Číslo položky (number) neodpovídá správnému zápisu. ");

                        // skupina zboží + číslo součásti neodpovídá číslu položky (number)
                        //if (number.Length > 0 && number != hekmen && bomitem.Value["He_Kmen"] == number)
                        //    er.Append("Číslo položky (Number) se liší od 'Skupina zboží - Číslo součásti'. ");

                            // součást nemá ještě vytvořenu položku
                            if (number == "")
                            er.Append("Položka ještě nebyla vytvořena. ");

                        if (er.Length > 0)
                        {
                            listpol.Items.Add(new ListViewItem(new[] {
                                number,
                                bomitem.Value["He_Kmen"],
                                bomitem.Value["He_SkupZbo"],
                                bomitem.Value["CisloSoucasti"],
                                bomitem.Value["NazevSouboru"],
                                er.ToString() }));
                        }

                            //         listidw.EndUpdate();
                            //         listidw.Refresh();

                    }
                    catch
                    {
                        listpol.Items.Add(new ListViewItem(new[] { "", "","", bomitem.Value["NazevSouboru"], "Neznámá chyba. Chybí data." }));
                    }
                }


                myTabPagePOL.Text = listpol.Name + " (" + listpol.Items.Count + ")";

                if (listpol.Items.Count > 0)
                {
                    AutoSizeColumnList(listpol);
                    listpol.Sort();
                    //listidw.EndUpdate();
                }

                toolStripStatusLabel1.Text = "Hledání položek dokončeno.";

            }

            #endregion
            
            buttonSpustit.Enabled = true;
        }

        public Autodesk.Connectivity.WebServices.File[] getVaultFile(string retezec)
        {
            // vyhledávání
            string bookmark = String.Empty;
            SrchStatus searchStatus = null;

            SrchCond searchCondition = new SrchCond();
            searchCondition.SrchTxt = retezec;
            searchCondition.PropTyp = PropertySearchType.AllProperties;
            searchCondition.SrchOper = 1;
            searchCondition.SrchRule = SearchRuleType.Must;

            PropDef[] filePropDefs = connection.WebServiceManager.PropertyService.GetPropertyDefinitionsByEntityClassId("FILE");
            PropDef projectPropDef = filePropDefs.Single(n => n.SysName == "Extension");
            SrchCond searchConditionNot = new SrchCond();
            searchConditionNot.PropDefId = projectPropDef.Id;
            searchConditionNot.SrchTxt = "dwf";
            searchConditionNot.PropTyp = PropertySearchType.SingleProperty;
            searchConditionNot.SrchOper = 2;
            searchConditionNot.SrchRule = SearchRuleType.Must;

            Autodesk.Connectivity.WebServices.File[] result = connection.WebServiceManager.DocumentService.FindFilesBySearchConditions(new SrchCond[] { searchCondition, searchConditionNot }, null, null, true, true, ref bookmark, out searchStatus);

            if (result != null) return result;
            else return new File[0];
        }

        private void AutoSizeColumnList(ListView listView)
        {
            //Prevents flickering
            listView.BeginUpdate();

            Dictionary<int, int> columnSize = new Dictionary<int, int>();

            //Auto size using header
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            //Grab column size based on header
            foreach (ColumnHeader colHeader in listView.Columns)
                columnSize.Add(colHeader.Index, colHeader.Width);

            //Auto size using data
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            //Grab comumn size based on data and set max width
            foreach (ColumnHeader colHeader in listView.Columns)
            {
                int nColWidth;
                if (columnSize.TryGetValue(colHeader.Index, out nColWidth))
                    colHeader.Width = Math.Max(nColWidth, colHeader.Width);
                else
                    //Default to 50
                    colHeader.Width = Math.Max(50, colHeader.Width);
            }

            listView.EndUpdate();
        }
        
        private void listView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                // musim zjistit nad jakym listview jsem, jaky je aktivnni tabControl
                switch(tabControl.SelectedTab.Name)
                {
                    case "DXF":  CopyListBox(listdxf); break;
                    case "IDW": CopyListBox(listidw); break;
                    case "Atributy": CopyListBox(listatr); break;
                    case "Položky": CopyListBox(listpol); break;
                }
            }
            if (e.Control && e.KeyCode == Keys.A)
            {

                // musim zjistit nad jakym listview jsem, jaky je aktivnni tabControl
                switch (tabControl.SelectedTab.Name)
                {
                    case "DXF": foreach (ListViewItem item in listdxf.Items) item.Selected = true; break;
                    case "IDW": foreach (ListViewItem item in listidw.Items) item.Selected = true; break;
                    case "Atributy": foreach (ListViewItem item in listatr.Items) item.Selected = true; break;
                    case "Položky": foreach (ListViewItem item in listpol.Items) item.Selected = true; break;
                }
            }
        }

        public void CopyListBox(ListView list)
        {
            StringBuilder sb = new StringBuilder();
            if (list.SelectedItems.Count > 1)
            {
                // do schránky zkopíruju názvy sloupců (nefunguje)
                /*
                foreach (ListViewItem clmn in list.Columns)
                {
                    sb.Append(clmn.SubItems[0].Text);
                    sb.AppendLine();
                }
                */
                foreach (var item in list.SelectedItems)
                {
                    ListViewItem l = item as ListViewItem;
                    if (l != null)
                    {
                        if (sb.Length > 0) sb.AppendLine();
                        for (int x = 0; x < l.SubItems.Count; x++)
                            sb.Append((x > 0 ? "\t" : "") + l.SubItems[x].Text); //.Text.Substring(0, l.SubItems[0].Text.Length - 4));
                    }
                }
            }
            else if (list.SelectedItems.Count == 1)
            {
                sb.Append(list.SelectedItems[0].SubItems[0].Text);
            }

            Clipboard.SetDataObject(sb.ToString());
        }

        private void checkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAll.Checked)
            {
                checkDXF.Checked = true;
                checkIDW.Checked = true;
                checkAtributy.Checked = true;
                checkSestavy.Checked = true;
                checkDatumy.Checked = true;
                checkSestavy.Enabled = true;
                checkDatumy.Enabled = true;
                checkPolozky.Checked = true;
            }
            else
            {
                checkDXF.Checked = false;
                checkIDW.Checked = false;
                checkAtributy.Checked = false;
                checkSestavy.Checked = false;
                checkDatumy.Checked = false;
                checkSestavy.Enabled = false;
                checkDatumy.Enabled = false;
                checkPolozky.Checked = false;
            }
        }

        private void check_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDXF.Checked || checkIDW.Checked || checkAtributy.Checked || checkPolozky.Checked)
            {
                buttonSpustit.Enabled = true;
            }
            else buttonSpustit.Enabled = false;

            if (checkIDW.Checked)
            {
                checkSestavy.Enabled = true;
                checkDatumy.Enabled = true;
            }
            else
            {
                checkSestavy.Enabled = false;
                checkDatumy.Enabled = false;
            }
            /*
            if (checkDXF.Checked == false || !checkIDW.Checked ||
                !checkAtributy.Checked ||
                !checkSestavy.Checked ||
                !checkDatumy.Checked ||
                !checkPolozky.Checked)
                    checkAll.Checked = false;
            */

        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
