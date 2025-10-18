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
            dataGridDatabase = new DataGridView();
            dataGridBasket = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridDatabase).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridBasket).BeginInit();
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
            splitContainer1.Panel1.Controls.Add(dataGridDatabase);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dataGridBasket);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 239;
            splitContainer1.TabIndex = 0;
            splitContainer1.SplitterMoved += splitContainer1_SplitterMoved;
            // 
            // dataGridDatabase
            // 
            dataGridDatabase.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridDatabase.Dock = DockStyle.Fill;
            dataGridDatabase.Location = new Point(0, 0);
            dataGridDatabase.Name = "dataGridDatabase";
            dataGridDatabase.Size = new Size(800, 239);
            dataGridDatabase.TabIndex = 0;
            // 
            // dataGridBasket
            // 
            dataGridBasket.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridBasket.Dock = DockStyle.Fill;
            dataGridBasket.Location = new Point(0, 0);
            dataGridBasket.Name = "dataGridBasket";
            dataGridBasket.Size = new Size(800, 207);
            dataGridBasket.TabIndex = 0;
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
            ((System.ComponentModel.ISupportInitialize)dataGridDatabase).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridBasket).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private DataGridView dataGridDatabase;
        private DataGridView dataGridBasket;
    }
}