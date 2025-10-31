namespace LastMileAPP
{
    partial class MainApp
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
            components = new System.ComponentModel.Container();
            splitContainer1 = new SplitContainer();
            nameSplit = new SplitContainer();
            btnSettings = new Button();
            filterLabel = new Label();
            txtSearch = new TextBox();
            splitter1 = new Splitter();
            splitContainer3 = new SplitContainer();
            dataGridDatabase = new DataGridView();
            panel2 = new Panel();
            BasketVsetko = new Button();
            EZSBasketButton = new Button();
            CCTVBasketButton = new Button();
            SKBasketButton = new Button();
            btnToggleSlide = new Button();
            splitContainer2 = new SplitContainer();
            dataGridBasket = new DataGridView();
            panel1 = new Panel();
            btnExport = new Button();
            panel3 = new Panel();
            treeViewCategories = new TreeView();
            sliderTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nameSplit).BeginInit();
            nameSplit.Panel1.SuspendLayout();
            nameSplit.Panel2.SuspendLayout();
            nameSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridDatabase).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridBasket).BeginInit();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(161, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(nameSplit);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(1188, 609);
            splitContainer1.SplitterDistance = 323;
            splitContainer1.TabIndex = 0;
            splitContainer1.SplitterMoved += splitContainer1_SplitterMoved;
            // 
            // nameSplit
            // 
            nameSplit.Dock = DockStyle.Fill;
            nameSplit.Location = new Point(0, 0);
            nameSplit.Name = "nameSplit";
            nameSplit.Orientation = Orientation.Horizontal;
            // 
            // nameSplit.Panel1
            // 
            nameSplit.Panel1.Controls.Add(btnSettings);
            nameSplit.Panel1.Controls.Add(filterLabel);
            nameSplit.Panel1.Controls.Add(txtSearch);
            nameSplit.Panel1.Controls.Add(splitter1);
            // 
            // nameSplit.Panel2
            // 
            nameSplit.Panel2.Controls.Add(splitContainer3);
            nameSplit.Size = new Size(1188, 323);
            nameSplit.SplitterDistance = 40;
            nameSplit.TabIndex = 1;
            // 
            // btnSettings
            // 
            btnSettings.Location = new Point(1156, 5);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(32, 23);
            btnSettings.TabIndex = 3;
            btnSettings.Text = "⚙";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // filterLabel
            // 
            filterLabel.AutoSize = true;
            filterLabel.Location = new Point(12, 9);
            filterLabel.Name = "filterLabel";
            filterLabel.Size = new Size(33, 15);
            filterLabel.TabIndex = 2;
            filterLabel.Text = "Filter";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(68, 7);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(184, 23);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged_1;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(0, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(3, 40);
            splitter1.TabIndex = 0;
            splitter1.TabStop = false;
            // 
            // splitContainer3
            // 
            splitContainer3.Dock = DockStyle.Fill;
            splitContainer3.Location = new Point(0, 0);
            splitContainer3.Name = "splitContainer3";
            splitContainer3.Orientation = Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(dataGridDatabase);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.Controls.Add(panel2);
            splitContainer3.Size = new Size(1188, 279);
            splitContainer3.SplitterDistance = 239;
            splitContainer3.TabIndex = 1;
            // 
            // dataGridDatabase
            // 
            dataGridDatabase.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridDatabase.Dock = DockStyle.Fill;
            dataGridDatabase.Location = new Point(0, 0);
            dataGridDatabase.Margin = new Padding(20);
            dataGridDatabase.Name = "dataGridDatabase";
            dataGridDatabase.Size = new Size(1188, 239);
            dataGridDatabase.TabIndex = 0;
            dataGridDatabase.CellDoubleClick += dataGridDatabase_CellDoubleClick;
            // 
            // panel2
            // 
            panel2.Controls.Add(BasketVsetko);
            panel2.Controls.Add(EZSBasketButton);
            panel2.Controls.Add(CCTVBasketButton);
            panel2.Controls.Add(SKBasketButton);
            panel2.Controls.Add(btnToggleSlide);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1188, 36);
            panel2.TabIndex = 0;
            // 
            // BasketVsetko
            // 
            BasketVsetko.Location = new Point(39, -1);
            BasketVsetko.Name = "BasketVsetko";
            BasketVsetko.Size = new Size(75, 23);
            BasketVsetko.TabIndex = 4;
            BasketVsetko.Text = "Vsetko";
            BasketVsetko.UseVisualStyleBackColor = true;
            BasketVsetko.Click += BasketVsetko_Click;
            // 
            // EZSBasketButton
            // 
            EZSBasketButton.Location = new Point(282, -1);
            EZSBasketButton.Name = "EZSBasketButton";
            EZSBasketButton.Size = new Size(75, 23);
            EZSBasketButton.TabIndex = 3;
            EZSBasketButton.Text = "EZS";
            EZSBasketButton.UseVisualStyleBackColor = true;
            EZSBasketButton.Click += EZSBasketButton_Click;
            // 
            // CCTVBasketButton
            // 
            CCTVBasketButton.Location = new Point(201, -1);
            CCTVBasketButton.Name = "CCTVBasketButton";
            CCTVBasketButton.Size = new Size(75, 23);
            CCTVBasketButton.TabIndex = 2;
            CCTVBasketButton.Text = "CCTV";
            CCTVBasketButton.UseVisualStyleBackColor = true;
            CCTVBasketButton.Click += CCTVBasketButton_Click;
            // 
            // SKBasketButton
            // 
            SKBasketButton.Location = new Point(120, -1);
            SKBasketButton.Name = "SKBasketButton";
            SKBasketButton.Size = new Size(75, 23);
            SKBasketButton.TabIndex = 1;
            SKBasketButton.Text = "SK";
            SKBasketButton.UseVisualStyleBackColor = true;
            SKBasketButton.Click += SKBasketButton_Click;
            // 
            // btnToggleSlide
            // 
            btnToggleSlide.Location = new Point(0, -1);
            btnToggleSlide.Name = "btnToggleSlide";
            btnToggleSlide.Size = new Size(33, 23);
            btnToggleSlide.TabIndex = 0;
            btnToggleSlide.Text = ">>";
            btnToggleSlide.UseVisualStyleBackColor = true;
            btnToggleSlide.Click += btnToggleSlide_Click;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(dataGridBasket);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(panel1);
            splitContainer2.Size = new Size(1188, 282);
            splitContainer2.SplitterDistance = 228;
            splitContainer2.TabIndex = 1;
            // 
            // dataGridBasket
            // 
            dataGridBasket.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridBasket.Dock = DockStyle.Fill;
            dataGridBasket.Location = new Point(0, 0);
            dataGridBasket.Name = "dataGridBasket";
            dataGridBasket.Size = new Size(1188, 228);
            dataGridBasket.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnExport);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1188, 50);
            panel1.TabIndex = 0;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(32, 3);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(75, 23);
            btnExport.TabIndex = 0;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(treeViewCategories);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(161, 609);
            panel3.TabIndex = 2;
            // 
            // treeViewCategories
            // 
            treeViewCategories.CheckBoxes = true;
            treeViewCategories.Dock = DockStyle.Fill;
            treeViewCategories.Location = new Point(0, 0);
            treeViewCategories.Name = "treeViewCategories";
            treeViewCategories.Size = new Size(161, 609);
            treeViewCategories.TabIndex = 0;
            treeViewCategories.AfterCheck += treeViewCategories_AfterCheck;
            // 
            // sliderTimer
            // 
            sliderTimer.Interval = 15;
            sliderTimer.Tick += sliderTimer_Tick;
            // 
            // MainApp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1349, 609);
            Controls.Add(splitContainer1);
            Controls.Add(panel3);
            Name = "MainApp";
            Text = "MainApp";
            WindowState = FormWindowState.Maximized;
            Load += MainApp_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            nameSplit.Panel1.ResumeLayout(false);
            nameSplit.Panel1.PerformLayout();
            nameSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nameSplit).EndInit();
            nameSplit.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridDatabase).EndInit();
            panel2.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridBasket).EndInit();
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private DataGridView dataGridDatabase;
        private DataGridView dataGridBasket;
        private SplitContainer nameSplit;
        private Splitter splitter1;
        private TextBox txtSearch;
        private SplitContainer splitContainer2;
        private Label filterLabel;
        private Panel panel1;
        private Button btnExport;
        private SplitContainer splitContainer3;
        private Panel panel2;
        private Button btnToggleSlide;
        private Panel panel3;
        private System.Windows.Forms.Timer sliderTimer;
        private TreeView treeViewCategories;
        private Button EZSBasketButton;
        private Button CCTVBasketButton;
        private Button SKBasketButton;
        private Button BasketVsetko;
        private Button btnSettings;
    }
}