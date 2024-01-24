namespace BasicFacebookFeatures
{
    partial class FormFindMatch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFindMatch));
            this.roundPictureBox = new BasicFacebookFeatures.RoundPictureBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.labelAbout = new System.Windows.Forms.Label();
            this.listBoxMatchFriendsNames = new System.Windows.Forms.ListBox();
            this.labelFindMatchResults = new System.Windows.Forms.Label();
            this.listBoxAbout = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.roundPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // roundPictureBox
            // 
            this.roundPictureBox.Location = new System.Drawing.Point(163, 41);
            this.roundPictureBox.Name = "roundPictureBox";
            this.roundPictureBox.Size = new System.Drawing.Size(125, 125);
            this.roundPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.roundPictureBox.TabIndex = 18;
            this.roundPictureBox.TabStop = false;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(122, 298);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(8, 4);
            this.checkedListBox1.TabIndex = 16;
            // 
            // labelAbout
            // 
            this.labelAbout.AutoSize = true;
            this.labelAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelAbout.Location = new System.Drawing.Point(62, 175);
            this.labelAbout.Name = "labelAbout";
            this.labelAbout.Size = new System.Drawing.Size(62, 22);
            this.labelAbout.TabIndex = 14;
            this.labelAbout.Text = "About:";
            // 
            // listBoxMatchFriendsNames
            // 
            this.listBoxMatchFriendsNames.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.listBoxMatchFriendsNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.listBoxMatchFriendsNames.FormattingEnabled = true;
            this.listBoxMatchFriendsNames.ItemHeight = 22;
            this.listBoxMatchFriendsNames.Location = new System.Drawing.Point(66, 321);
            this.listBoxMatchFriendsNames.Name = "listBoxMatchFriendsNames";
            this.listBoxMatchFriendsNames.Size = new System.Drawing.Size(353, 312);
            this.listBoxMatchFriendsNames.TabIndex = 12;
            this.listBoxMatchFriendsNames.SelectedIndexChanged += new System.EventHandler(this.listBoxCollectionItemsNames_SelectedIndexChanged);
            // 
            // labelFindMatchResults
            // 
            this.labelFindMatchResults.AutoSize = true;
            this.labelFindMatchResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelFindMatchResults.Location = new System.Drawing.Point(117, 9);
            this.labelFindMatchResults.Name = "labelFindMatchResults";
            this.labelFindMatchResults.Size = new System.Drawing.Size(235, 29);
            this.labelFindMatchResults.TabIndex = 19;
            this.labelFindMatchResults.Text = "Find Match Results";
            // 
            // listBoxAbout
            // 
            this.listBoxAbout.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.listBoxAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.listBoxAbout.FormattingEnabled = true;
            this.listBoxAbout.ItemHeight = 22;
            this.listBoxAbout.Location = new System.Drawing.Point(66, 200);
            this.listBoxAbout.Name = "listBoxAbout";
            this.listBoxAbout.Size = new System.Drawing.Size(353, 92);
            this.listBoxAbout.TabIndex = 20;
            // 
            // FormFindMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 669);
            this.Controls.Add(this.listBoxAbout);
            this.Controls.Add(this.labelFindMatchResults);
            this.Controls.Add(this.roundPictureBox);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.labelAbout);
            this.Controls.Add(this.listBoxMatchFriendsNames);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormFindMatch";
            this.Text = "Find Match";
            ((System.ComponentModel.ISupportInitialize)(this.roundPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundPictureBox roundPictureBox;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label labelAbout;
        private System.Windows.Forms.ListBox listBoxMatchFriendsNames;
        private System.Windows.Forms.Label labelFindMatchResults;
        private System.Windows.Forms.ListBox listBoxAbout;
    }
}