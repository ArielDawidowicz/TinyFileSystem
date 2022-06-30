namespace TinyMemFSGUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sortTxt = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.addFileBtn = new System.Windows.Forms.Button();
            this.removeFileBtn = new System.Windows.Forms.Button();
            this.renameFileBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFileSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFileSystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EncryptFileBtn = new System.Windows.Forms.Button();
            this.CopyFileBtn = new System.Windows.Forms.Button();
            this.DecryptFileBtn = new System.Windows.Forms.Button();
            this.totalSizeTxt = new System.Windows.Forms.Label();
            this.sizeTxt = new System.Windows.Forms.Label();
            this.exportBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(14, 23);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(521, 440);
            this.dataGridView1.TabIndex = 0;
            // 
            // sortTxt
            // 
            this.sortTxt.AutoSize = true;
            this.sortTxt.BackColor = System.Drawing.Color.Transparent;
            this.sortTxt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sortTxt.Location = new System.Drawing.Point(14, 473);
            this.sortTxt.Name = "sortTxt";
            this.sortTxt.Size = new System.Drawing.Size(47, 15);
            this.sortTxt.TabIndex = 1;
            this.sortTxt.Text = "Sort by:";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.Black;
            this.comboBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.comboBox1.Items.AddRange(new object[] {
            "Name",
            "Date",
            "Size"});
            this.comboBox1.Location = new System.Drawing.Point(67, 470);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(84, 23);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_TextUpdate);
            // 
            // addFileBtn
            // 
            this.addFileBtn.BackColor = System.Drawing.Color.Transparent;
            this.addFileBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addFileBtn.BackgroundImage")));
            this.addFileBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addFileBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addFileBtn.FlatAppearance.BorderSize = 0;
            this.addFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addFileBtn.ForeColor = System.Drawing.Color.White;
            this.addFileBtn.Location = new System.Drawing.Point(451, 469);
            this.addFileBtn.Margin = new System.Windows.Forms.Padding(0);
            this.addFileBtn.Name = "addFileBtn";
            this.addFileBtn.Size = new System.Drawing.Size(84, 23);
            this.addFileBtn.TabIndex = 3;
            this.addFileBtn.Text = "Add file";
            this.addFileBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.addFileBtn.UseVisualStyleBackColor = false;
            this.addFileBtn.Click += new System.EventHandler(this.addFileBtn_Click);
            // 
            // removeFileBtn
            // 
            this.removeFileBtn.BackColor = System.Drawing.Color.Transparent;
            this.removeFileBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("removeFileBtn.BackgroundImage")));
            this.removeFileBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.removeFileBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.removeFileBtn.FlatAppearance.BorderSize = 0;
            this.removeFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeFileBtn.ForeColor = System.Drawing.Color.White;
            this.removeFileBtn.Location = new System.Drawing.Point(361, 469);
            this.removeFileBtn.Margin = new System.Windows.Forms.Padding(0);
            this.removeFileBtn.Name = "removeFileBtn";
            this.removeFileBtn.Size = new System.Drawing.Size(84, 23);
            this.removeFileBtn.TabIndex = 4;
            this.removeFileBtn.Text = "Remove file";
            this.removeFileBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.removeFileBtn.UseVisualStyleBackColor = false;
            this.removeFileBtn.Click += new System.EventHandler(this.removeFileBtn_Click);
            // 
            // renameFileBtn
            // 
            this.renameFileBtn.BackColor = System.Drawing.Color.Transparent;
            this.renameFileBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("renameFileBtn.BackgroundImage")));
            this.renameFileBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.renameFileBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.renameFileBtn.FlatAppearance.BorderSize = 0;
            this.renameFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.renameFileBtn.ForeColor = System.Drawing.Color.White;
            this.renameFileBtn.Location = new System.Drawing.Point(451, 498);
            this.renameFileBtn.Margin = new System.Windows.Forms.Padding(0);
            this.renameFileBtn.Name = "renameFileBtn";
            this.renameFileBtn.Size = new System.Drawing.Size(84, 23);
            this.renameFileBtn.TabIndex = 5;
            this.renameFileBtn.Text = "Rename file";
            this.renameFileBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.renameFileBtn.UseVisualStyleBackColor = false;
            this.renameFileBtn.Click += new System.EventHandler(this.renameFileBtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(549, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFileSystemToolStripMenuItem,
            this.saveFileSystemToolStripMenuItem,
            this.loadFileSystemToolStripMenuItem,
            this.saveListToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newFileSystemToolStripMenuItem
            // 
            this.newFileSystemToolStripMenuItem.Name = "newFileSystemToolStripMenuItem";
            this.newFileSystemToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.newFileSystemToolStripMenuItem.Text = "New file system";
            this.newFileSystemToolStripMenuItem.Click += new System.EventHandler(this.newFileSystemToolStripMenuItem_Click);
            // 
            // saveFileSystemToolStripMenuItem
            // 
            this.saveFileSystemToolStripMenuItem.Name = "saveFileSystemToolStripMenuItem";
            this.saveFileSystemToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.saveFileSystemToolStripMenuItem.Text = "Save file system";
            this.saveFileSystemToolStripMenuItem.Click += new System.EventHandler(this.saveFileSystemToolStripMenuItem_Click);
            // 
            // loadFileSystemToolStripMenuItem
            // 
            this.loadFileSystemToolStripMenuItem.Name = "loadFileSystemToolStripMenuItem";
            this.loadFileSystemToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.loadFileSystemToolStripMenuItem.Text = "Load file system";
            this.loadFileSystemToolStripMenuItem.Click += new System.EventHandler(this.loadFileSystemToolStripMenuItem_Click);
            // 
            // saveListToolStripMenuItem
            // 
            this.saveListToolStripMenuItem.Name = "saveListToolStripMenuItem";
            this.saveListToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.saveListToolStripMenuItem.Text = "Save list of files";
            this.saveListToolStripMenuItem.Click += new System.EventHandler(this.saveListToolStripMenuItem_Click);
            // 
            // EncryptFileBtn
            // 
            this.EncryptFileBtn.BackColor = System.Drawing.Color.Transparent;
            this.EncryptFileBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EncryptFileBtn.BackgroundImage")));
            this.EncryptFileBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EncryptFileBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EncryptFileBtn.FlatAppearance.BorderSize = 0;
            this.EncryptFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EncryptFileBtn.ForeColor = System.Drawing.Color.White;
            this.EncryptFileBtn.Location = new System.Drawing.Point(271, 469);
            this.EncryptFileBtn.Margin = new System.Windows.Forms.Padding(0);
            this.EncryptFileBtn.Name = "EncryptFileBtn";
            this.EncryptFileBtn.Size = new System.Drawing.Size(84, 23);
            this.EncryptFileBtn.TabIndex = 9;
            this.EncryptFileBtn.Text = "Encrypt list";
            this.EncryptFileBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.EncryptFileBtn.UseVisualStyleBackColor = false;
            this.EncryptFileBtn.Click += new System.EventHandler(this.EncryptFileBtn_Click);
            // 
            // CopyFileBtn
            // 
            this.CopyFileBtn.BackColor = System.Drawing.Color.Transparent;
            this.CopyFileBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CopyFileBtn.BackgroundImage")));
            this.CopyFileBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CopyFileBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CopyFileBtn.FlatAppearance.BorderSize = 0;
            this.CopyFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CopyFileBtn.ForeColor = System.Drawing.Color.White;
            this.CopyFileBtn.Location = new System.Drawing.Point(361, 498);
            this.CopyFileBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CopyFileBtn.Name = "CopyFileBtn";
            this.CopyFileBtn.Size = new System.Drawing.Size(84, 23);
            this.CopyFileBtn.TabIndex = 8;
            this.CopyFileBtn.Text = "Copy file";
            this.CopyFileBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.CopyFileBtn.UseVisualStyleBackColor = false;
            this.CopyFileBtn.Click += new System.EventHandler(this.CopyFileBtn_Click);
            // 
            // DecryptFileBtn
            // 
            this.DecryptFileBtn.BackColor = System.Drawing.Color.Transparent;
            this.DecryptFileBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DecryptFileBtn.BackgroundImage")));
            this.DecryptFileBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DecryptFileBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DecryptFileBtn.FlatAppearance.BorderSize = 0;
            this.DecryptFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DecryptFileBtn.ForeColor = System.Drawing.Color.White;
            this.DecryptFileBtn.Location = new System.Drawing.Point(271, 498);
            this.DecryptFileBtn.Margin = new System.Windows.Forms.Padding(0);
            this.DecryptFileBtn.Name = "DecryptFileBtn";
            this.DecryptFileBtn.Size = new System.Drawing.Size(84, 23);
            this.DecryptFileBtn.TabIndex = 7;
            this.DecryptFileBtn.Text = "Decrypt list";
            this.DecryptFileBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.DecryptFileBtn.UseVisualStyleBackColor = false;
            this.DecryptFileBtn.Click += new System.EventHandler(this.DecryptFileBtn_Click);
            // 
            // totalSizeTxt
            // 
            this.totalSizeTxt.AutoSize = true;
            this.totalSizeTxt.BackColor = System.Drawing.Color.Transparent;
            this.totalSizeTxt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.totalSizeTxt.Location = new System.Drawing.Point(14, 502);
            this.totalSizeTxt.Name = "totalSizeTxt";
            this.totalSizeTxt.Size = new System.Drawing.Size(60, 15);
            this.totalSizeTxt.TabIndex = 10;
            this.totalSizeTxt.Text = "Total size: ";
            // 
            // sizeTxt
            // 
            this.sizeTxt.AutoSize = true;
            this.sizeTxt.BackColor = System.Drawing.Color.Transparent;
            this.sizeTxt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.sizeTxt.Location = new System.Drawing.Point(80, 502);
            this.sizeTxt.Name = "sizeTxt";
            this.sizeTxt.Size = new System.Drawing.Size(34, 15);
            this.sizeTxt.TabIndex = 11;
            this.sizeTxt.Text = "0 Mb";
            // 
            // exportBtn
            // 
            this.exportBtn.BackColor = System.Drawing.Color.Transparent;
            this.exportBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("exportBtn.BackgroundImage")));
            this.exportBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exportBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exportBtn.FlatAppearance.BorderSize = 0;
            this.exportBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportBtn.ForeColor = System.Drawing.Color.White;
            this.exportBtn.Location = new System.Drawing.Point(181, 470);
            this.exportBtn.Margin = new System.Windows.Forms.Padding(0);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(84, 51);
            this.exportBtn.TabIndex = 12;
            this.exportBtn.Text = "Export file";
            this.exportBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.exportBtn.UseVisualStyleBackColor = false;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(549, 530);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.sizeTxt);
            this.Controls.Add(this.totalSizeTxt);
            this.Controls.Add(this.EncryptFileBtn);
            this.Controls.Add(this.CopyFileBtn);
            this.Controls.Add(this.DecryptFileBtn);
            this.Controls.Add(this.renameFileBtn);
            this.Controls.Add(this.removeFileBtn);
            this.Controls.Add(this.addFileBtn);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.sortTxt);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "File system";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridView1;
        private Label sortTxt;
        private ComboBox comboBox1;
        private Button addFileBtn;
        private Button removeFileBtn;
        private Button renameFileBtn;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newFileSystemToolStripMenuItem;
        private ToolStripMenuItem saveFileSystemToolStripMenuItem;
        private ToolStripMenuItem loadFileSystemToolStripMenuItem;
        private ToolStripMenuItem saveListToolStripMenuItem;
        private Button EncryptFileBtn;
        private Button CopyFileBtn;
        private Button DecryptFileBtn;
        private Label totalSizeTxt;
        private Label sizeTxt;
        private Button exportBtn;
    }
}