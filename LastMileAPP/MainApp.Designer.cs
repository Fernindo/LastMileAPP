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
            splitContainer1 = new SplitContainer();
            nameSplit = new SplitContainer();
            filterLabel = new Label();
            txtSearch = new TextBox();
            splitter1 = new Splitter();
            dataGridDatabase = new DataGridView();
            splitContainer2 = new SplitContainer();
            dataGridBasket = new DataGridView();
            panel1 = new Panel();
            btnExport = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nameSplit).BeginInit();
            nameSplit.Panel1.SuspendLayout();
            nameSplit.Panel2.SuspendLayout();
            nameSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridDatabase).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridBasket).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
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
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 239;
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
            nameSplit.Panel1.Controls.Add(filterLabel);
            nameSplit.Panel1.Controls.Add(txtSearch);
            nameSplit.Panel1.Controls.Add(splitter1);
            // 
            // nameSplit.Panel2
            // 
            nameSplit.Panel2.Controls.Add(dataGridDatabase);
            nameSplit.Size = new Size(800, 239);
            nameSplit.SplitterDistance = 30;
            nameSplit.TabIndex = 1;
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
            splitter1.Size = new Size(3, 30);
            splitter1.TabIndex = 0;
            splitter1.TabStop = false;
            // 
            // dataGridDatabase
            // 
            dataGridDatabase.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridDatabase.Dock = DockStyle.Fill;
            dataGridDatabase.Location = new Point(0, 0);
            dataGridDatabase.Margin = new Padding(20);
            dataGridDatabase.Name = "dataGridDatabase";
            dataGridDatabase.Size = new Size(800, 205);
            dataGridDatabase.TabIndex = 0;
            dataGridDatabase.CellDoubleClick += dataGridDatabase_CellDoubleClick;
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
            splitContainer2.Size = new Size(800, 207);
            splitContainer2.SplitterDistance = 168;
            splitContainer2.TabIndex = 1;
            // 
            // dataGridBasket
            // 
            dataGridBasket.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridBasket.Dock = DockStyle.Fill;
            dataGridBasket.Location = new Point(0, 0);
            dataGridBasket.Name = "dataGridBasket";
            dataGridBasket.Size = new Size(800, 168);
            dataGridBasket.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnExport);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 35);
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
            // MainApp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
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
            ((System.ComponentModel.ISupportInitialize)dataGridDatabase).EndInit();
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridBasket).EndInit();
            panel1.ResumeLayout(false);
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
    }
}