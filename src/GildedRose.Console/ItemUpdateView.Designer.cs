namespace GildedRose.Console
{
    partial class ItemUpdateView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ItemGridView = new System.Windows.Forms.DataGridView();
            this.UpdateItemsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ItemGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ItemGridView
            // 
            this.ItemGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ItemGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ItemGridView.Location = new System.Drawing.Point(0, 0);
            this.ItemGridView.Name = "ItemGridView";
            this.ItemGridView.Size = new System.Drawing.Size(552, 235);
            this.ItemGridView.TabIndex = 0;
            // 
            // UpdateItemsButton
            // 
            this.UpdateItemsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateItemsButton.Location = new System.Drawing.Point(421, 251);
            this.UpdateItemsButton.Name = "UpdateItemsButton";
            this.UpdateItemsButton.Size = new System.Drawing.Size(95, 27);
            this.UpdateItemsButton.TabIndex = 1;
            this.UpdateItemsButton.Text = "Update";
            this.UpdateItemsButton.UseVisualStyleBackColor = true;
            this.UpdateItemsButton.Click += new System.EventHandler(this.UpdateClick);
            // 
            // ItemUpdateView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UpdateItemsButton);
            this.Controls.Add(this.ItemGridView);
            this.Name = "ItemUpdateView";
            this.Size = new System.Drawing.Size(552, 289);
            this.Load += new System.EventHandler(this.ViewLoaded);
            ((System.ComponentModel.ISupportInitialize)(this.ItemGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ItemGridView;
        private System.Windows.Forms.Button UpdateItemsButton;
    }
}
