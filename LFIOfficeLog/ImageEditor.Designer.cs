namespace Logger
{
    partial class ImageEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageEditor));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eDITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineWidthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.selectButton = new System.Windows.Forms.ToolStripButton();
            this.shapeButton = new System.Windows.Forms.ToolStripButton();
            this.textButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox.Location = new System.Drawing.Point(56, 28);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(994, 635);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem,
            this.eDITToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1050, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fILEToolStripMenuItem
            // 
            this.fILEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
            this.fILEToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.fILEToolStripMenuItem.Text = "&FILE";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.saveAsToolStripMenuItem.Text = "Save &as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
            this.quitToolStripMenuItem.Text = "&Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // eDITToolStripMenuItem
            // 
            this.eDITToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineWidthToolStripMenuItem,
            this.lineColorToolStripMenuItem,
            this.fontToolStripMenuItem,
            this.fontColorToolStripMenuItem});
            this.eDITToolStripMenuItem.Name = "eDITToolStripMenuItem";
            this.eDITToolStripMenuItem.Size = new System.Drawing.Size(52, 24);
            this.eDITToolStripMenuItem.Text = "&EDIT";
            // 
            // lineWidthToolStripMenuItem
            // 
            this.lineWidthToolStripMenuItem.Name = "lineWidthToolStripMenuItem";
            this.lineWidthToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.lineWidthToolStripMenuItem.Text = "&Line width";
            this.lineWidthToolStripMenuItem.Click += new System.EventHandler(this.lineWidthToolStripMenuItem_Click);
            // 
            // lineColorToolStripMenuItem
            // 
            this.lineColorToolStripMenuItem.Name = "lineColorToolStripMenuItem";
            this.lineColorToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.lineColorToolStripMenuItem.Text = "Line &color";
            this.lineColorToolStripMenuItem.Click += new System.EventHandler(this.lineColorToolStripMenuItem_Click);
            // 
            // fontToolStripMenuItem
            // 
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.fontToolStripMenuItem.Text = "&Font";
            this.fontToolStripMenuItem.Click += new System.EventHandler(this.fontToolStripMenuItem_Click);
            // 
            // fontColorToolStripMenuItem
            // 
            this.fontColorToolStripMenuItem.Name = "fontColorToolStripMenuItem";
            this.fontColorToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.fontColorToolStripMenuItem.Text = "Fon&t color";
            this.fontColorToolStripMenuItem.Click += new System.EventHandler(this.fontColorToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectButton,
            this.shapeButton,
            this.textButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 28);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(57, 635);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip";
            this.toolStrip.UseWaitCursor = true;
            // 
            // selectButton
            // 
            this.selectButton.AutoSize = false;
            this.selectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.selectButton.Image = ((System.Drawing.Image)(resources.GetObject("selectButton.Image")));
            this.selectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectButton.Name = "selectButton";
            this.selectButton.Padding = new System.Windows.Forms.Padding(5);
            this.selectButton.Size = new System.Drawing.Size(56, 56);
            this.selectButton.Text = "selectButton";
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // shapeButton
            // 
            this.shapeButton.AutoSize = false;
            this.shapeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.shapeButton.Image = ((System.Drawing.Image)(resources.GetObject("shapeButton.Image")));
            this.shapeButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.shapeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.shapeButton.Margin = new System.Windows.Forms.Padding(0);
            this.shapeButton.Name = "shapeButton";
            this.shapeButton.Padding = new System.Windows.Forms.Padding(5);
            this.shapeButton.Size = new System.Drawing.Size(56, 56);
            this.shapeButton.Text = "drawButton";
            this.shapeButton.Click += new System.EventHandler(this.shapeButton_Click);
            // 
            // textButton
            // 
            this.textButton.AutoSize = false;
            this.textButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.textButton.Image = ((System.Drawing.Image)(resources.GetObject("textButton.Image")));
            this.textButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.textButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.textButton.Name = "textButton";
            this.textButton.Padding = new System.Windows.Forms.Padding(10);
            this.textButton.Size = new System.Drawing.Size(56, 56);
            this.textButton.Click += new System.EventHandler(this.textButton_Click);
            // 
            // ImageEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 663);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ImageEditor";
            this.Text = "ImageEditor";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton selectButton;
        private System.Windows.Forms.ToolStripButton shapeButton;
        private System.Windows.Forms.ToolStripButton textButton;
        private System.Windows.Forms.ToolStripMenuItem eDITToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineWidthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontColorToolStripMenuItem;
    }
}