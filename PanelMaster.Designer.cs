
namespace JCPBOMCheck
{
    partial class PanelMaster
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelMaster));
            this.checkDXF = new System.Windows.Forms.CheckBox();
            this.checkIDW = new System.Windows.Forms.CheckBox();
            this.checkAll = new System.Windows.Forms.CheckBox();
            this.checkAtributy = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonSpustit = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.checkSestavy = new System.Windows.Forms.CheckBox();
            this.checkDatumy = new System.Windows.Forms.CheckBox();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkDXF
            // 
            this.checkDXF.AutoSize = true;
            this.checkDXF.Location = new System.Drawing.Point(6, 42);
            this.checkDXF.Name = "checkDXF";
            this.checkDXF.Size = new System.Drawing.Size(47, 17);
            this.checkDXF.TabIndex = 0;
            this.checkDXF.Text = "DXF";
            this.checkDXF.UseVisualStyleBackColor = true;
            this.checkDXF.CheckedChanged += new System.EventHandler(this.check_CheckedChanged);
            // 
            // checkIDW
            // 
            this.checkIDW.AutoSize = true;
            this.checkIDW.Location = new System.Drawing.Point(6, 65);
            this.checkIDW.Name = "checkIDW";
            this.checkIDW.Size = new System.Drawing.Size(88, 17);
            this.checkIDW.TabIndex = 1;
            this.checkIDW.Text = "Výkresy IDW";
            this.checkIDW.UseVisualStyleBackColor = true;
            this.checkIDW.CheckedChanged += new System.EventHandler(this.check_CheckedChanged);
            // 
            // checkAll
            // 
            this.checkAll.AutoSize = true;
            this.checkAll.Location = new System.Drawing.Point(3, 3);
            this.checkAll.Name = "checkAll";
            this.checkAll.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.checkAll.Size = new System.Drawing.Size(152, 16);
            this.checkAll.TabIndex = 2;
            this.checkAll.Text = "Zaškrtnout/odškrnout vše";
            this.checkAll.UseVisualStyleBackColor = true;
            this.checkAll.CheckedChanged += new System.EventHandler(this.checkAll_CheckedChanged);
            // 
            // checkAtributy
            // 
            this.checkAtributy.AutoSize = true;
            this.checkAtributy.Location = new System.Drawing.Point(6, 19);
            this.checkAtributy.Name = "checkAtributy";
            this.checkAtributy.Size = new System.Drawing.Size(115, 17);
            this.checkAtributy.TabIndex = 3;
            this.checkAtributy.Text = "Atributy kusovníku";
            this.checkAtributy.UseVisualStyleBackColor = true;
            this.checkAtributy.CheckedChanged += new System.EventHandler(this.check_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkDatumy);
            this.groupBox1.Controls.Add(this.checkSestavy);
            this.groupBox1.Controls.Add(this.checkBox8);
            this.groupBox1.Controls.Add(this.checkBox7);
            this.groupBox1.Controls.Add(this.checkBox6);
            this.groupBox1.Controls.Add(this.checkBox5);
            this.groupBox1.Controls.Add(this.checkDXF);
            this.groupBox1.Controls.Add(this.checkAtributy);
            this.groupBox1.Controls.Add(this.checkIDW);
            this.groupBox1.Location = new System.Drawing.Point(0, 22);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 229);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Enabled = false;
            this.checkBox8.Location = new System.Drawing.Point(6, 196);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(231, 17);
            this.checkBox8.TabIndex = 8;
            this.checkBox8.Text = "Kontrola He_ID vs. registrační číslo heliosu";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Enabled = false;
            this.checkBox7.Location = new System.Drawing.Point(6, 173);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(223, 17);
            this.checkBox7.TabIndex = 7;
            this.checkBox7.Text = "Kontrola název souboru vs. číslo součásti";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Enabled = false;
            this.checkBox6.Location = new System.Drawing.Point(6, 150);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(115, 17);
            this.checkBox6.TabIndex = 5;
            this.checkBox6.Text = "Kontrola He_Kmen";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Enabled = false;
            this.checkBox5.Location = new System.Drawing.Point(6, 127);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(124, 17);
            this.checkBox5.TabIndex = 4;
            this.checkBox5.Text = "Kontrola stylu plechu";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 440);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(984, 21);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(255, 3);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(726, 434);
            this.tabControl.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(718, 408);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(712, 402);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Sloupec1";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 80;
            // 
            // buttonSpustit
            // 
            this.buttonSpustit.Enabled = false;
            this.buttonSpustit.Location = new System.Drawing.Point(3, 256);
            this.buttonSpustit.Name = "buttonSpustit";
            this.buttonSpustit.Size = new System.Drawing.Size(117, 23);
            this.buttonSpustit.TabIndex = 8;
            this.buttonSpustit.Text = "Spustit kontrolu";
            this.buttonSpustit.UseVisualStyleBackColor = true;
            this.buttonSpustit.Click += new System.EventHandler(this.buttonSpustit_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 252F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 440);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.checkAll, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonSpustit, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 231F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(246, 434);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // checkSestavy
            // 
            this.checkSestavy.AutoSize = true;
            this.checkSestavy.Enabled = false;
            this.checkSestavy.Location = new System.Drawing.Point(30, 86);
            this.checkSestavy.Name = "checkSestavy";
            this.checkSestavy.Size = new System.Drawing.Size(119, 17);
            this.checkSestavy.TabIndex = 9;
            this.checkSestavy.Text = "Kontrolavat sestavy";
            this.checkSestavy.UseVisualStyleBackColor = true;
            // 
            // checkDatumy
            // 
            this.checkDatumy.AutoSize = true;
            this.checkDatumy.Enabled = false;
            this.checkDatumy.Location = new System.Drawing.Point(30, 104);
            this.checkDatumy.Name = "checkDatumy";
            this.checkDatumy.Size = new System.Drawing.Size(157, 17);
            this.checkDatumy.TabIndex = 10;
            this.checkDatumy.Text = "Kontrolovat datum zařazení";
            this.checkDatumy.UseVisualStyleBackColor = true;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 15);
            this.toolStripProgressBar1.Step = 1;
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(106, 16);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "Aplikace načtena...";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // PanelMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PanelMaster";
            this.Text = "Kontrola kusovníku";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkDXF;
        private System.Windows.Forms.CheckBox checkIDW;
        private System.Windows.Forms.CheckBox checkAll;
        private System.Windows.Forms.CheckBox checkAtributy;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Button buttonSpustit;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox checkDatumy;
        private System.Windows.Forms.CheckBox checkSestavy;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}