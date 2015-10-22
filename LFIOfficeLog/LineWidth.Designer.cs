namespace Logger
{
    partial class LineWidth
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
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.widthUpDown = new System.Windows.Forms.NumericUpDown();
            this.promptWidth = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.widthUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(308, 46);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(227, 46);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // widthUpDown
            // 
            this.widthUpDown.Location = new System.Drawing.Point(74, 33);
            this.widthUpDown.Name = "widthUpDown";
            this.widthUpDown.Size = new System.Drawing.Size(120, 22);
            this.widthUpDown.TabIndex = 2;
            // 
            // promptWidth
            // 
            this.promptWidth.AutoSize = true;
            this.promptWidth.Location = new System.Drawing.Point(12, 9);
            this.promptWidth.Name = "promptWidth";
            this.promptWidth.Size = new System.Drawing.Size(83, 17);
            this.promptWidth.TabIndex = 3;
            this.promptWidth.Text = "Line Width: ";
            // 
            // LineWidth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 81);
            this.Controls.Add(this.promptWidth);
            this.Controls.Add(this.widthUpDown);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "LineWidth";
            this.Text = "LineWidth";
            ((System.ComponentModel.ISupportInitialize)(this.widthUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.NumericUpDown widthUpDown;
        private System.Windows.Forms.Label promptWidth;
    }
}