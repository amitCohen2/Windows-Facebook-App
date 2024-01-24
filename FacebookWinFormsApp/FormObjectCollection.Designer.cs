namespace BasicFacebookFeatures
{
    partial class FormObjectCollection<T>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormObjectCollection<T>));
            this.listBoxCollectionItemsNames = new System.Windows.Forms.ListBox();
            this.textBoxSearchByName = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.buttonShowPictures = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.roundPictureBox = new BasicFacebookFeatures.RoundPictureBox();
            this.labelName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.roundPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxCollectionItemsNames
            // 
            this.listBoxCollectionItemsNames.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.listBoxCollectionItemsNames.FormattingEnabled = true;
            this.listBoxCollectionItemsNames.ItemHeight = 16;
            this.listBoxCollectionItemsNames.Location = new System.Drawing.Point(84, 355);
            this.listBoxCollectionItemsNames.Name = "listBoxCollectionItemsNames";
            this.listBoxCollectionItemsNames.Size = new System.Drawing.Size(353, 308);
            this.listBoxCollectionItemsNames.TabIndex = 1;
            this.listBoxCollectionItemsNames.SelectedIndexChanged += new System.EventHandler(this.listBoxCollectionItemsNames_SelectedIndexChanged);
            // 
            // textBoxSearchByName
            // 
            this.textBoxSearchByName.AccessibleDescription = "";
            this.textBoxSearchByName.AccessibleName = "";
            this.textBoxSearchByName.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.textBoxSearchByName.Location = new System.Drawing.Point(84, 327);
            this.textBoxSearchByName.Name = "textBoxSearchByName";
            this.textBoxSearchByName.Size = new System.Drawing.Size(353, 22);
            this.textBoxSearchByName.TabIndex = 4;
            this.textBoxSearchByName.Text = "search";
            this.textBoxSearchByName.TextChanged += new System.EventHandler(this.textBoxSearchByName_TextChanged);
            this.textBoxSearchByName.Enter += new System.EventHandler(this.textBoxSearchByName_Enter);
            this.textBoxSearchByName.Leave += new System.EventHandler(this.textBoxSearchByName_Leave);
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(81, 213);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(78, 16);
            this.labelDescription.TabIndex = 5;
            this.labelDescription.Text = "Description:";
            // 
            // buttonShowPictures
            // 
            this.buttonShowPictures.BackColor = System.Drawing.Color.Lavender;
            this.buttonShowPictures.Location = new System.Drawing.Point(165, 186);
            this.buttonShowPictures.Name = "buttonShowPictures";
            this.buttonShowPictures.Size = new System.Drawing.Size(191, 31);
            this.buttonShowPictures.TabIndex = 6;
            this.buttonShowPictures.Text = "Show all pictures in album";
            this.buttonShowPictures.UseVisualStyleBackColor = false;
            this.buttonShowPictures.Click += new System.EventHandler(this.buttonShowPictures_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(141, 380);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(8, 4);
            this.checkedListBox1.TabIndex = 8;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.AccessibleDescription = "";
            this.textBoxDescription.AccessibleName = "";
            this.textBoxDescription.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.textBoxDescription.Location = new System.Drawing.Point(84, 232);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDescription.Size = new System.Drawing.Size(353, 69);
            this.textBoxDescription.TabIndex = 10;
            // 
            // roundPictureBox
            // 
            this.roundPictureBox.Location = new System.Drawing.Point(195, 12);
            this.roundPictureBox.Name = "roundPictureBox";
            this.roundPictureBox.Size = new System.Drawing.Size(125, 125);
            this.roundPictureBox.TabIndex = 11;
            this.roundPictureBox.TabStop = false;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelName.Location = new System.Drawing.Point(79, 154);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(0, 22);
            this.labelName.TabIndex = 12;
            // 
            // FormObjectCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 691);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.roundPictureBox);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.buttonShowPictures);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.textBoxSearchByName);
            this.Controls.Add(this.listBoxCollectionItemsNames);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormObjectCollection";
            this.Text = "Form Collection Item";
            this.Load += new System.EventHandler(this.FormCollectionItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.roundPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxCollectionItemsNames;
        private System.Windows.Forms.TextBox textBoxSearchByName;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Button buttonShowPictures;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.TextBox textBoxDescription;
        private RoundPictureBox roundPictureBox;
        private System.Windows.Forms.Label labelName;
    }
}