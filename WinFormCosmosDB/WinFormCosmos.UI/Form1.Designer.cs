namespace WinFormCosmos.UI
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
            this.importBtn = new System.Windows.Forms.Button();
            this.cheaperBtn = new System.Windows.Forms.Button();
            this.supplierIdBtn = new System.Windows.Forms.Button();
            this.nameBtn = new System.Windows.Forms.Button();
            this.cheaperTxtBox = new System.Windows.Forms.TextBox();
            this.nameTxtBox = new System.Windows.Forms.TextBox();
            this.supplierIdTxtBox = new System.Windows.Forms.TextBox();
            this.productsGridView = new System.Windows.Forms.DataGridView();
            this.allBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.productsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // importBtn
            // 
            this.importBtn.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.importBtn.Location = new System.Drawing.Point(36, 52);
            this.importBtn.Name = "importBtn";
            this.importBtn.Size = new System.Drawing.Size(444, 29);
            this.importBtn.TabIndex = 0;
            this.importBtn.Text = "Import products from northwind";
            this.importBtn.UseVisualStyleBackColor = false;
            this.importBtn.Click += new System.EventHandler(this.importBtn_Click);
            // 
            // cheaperBtn
            // 
            this.cheaperBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.cheaperBtn.Location = new System.Drawing.Point(50, 278);
            this.cheaperBtn.Name = "cheaperBtn";
            this.cheaperBtn.Size = new System.Drawing.Size(267, 29);
            this.cheaperBtn.TabIndex = 1;
            this.cheaperBtn.Text = "Select products that cheaper than";
            this.cheaperBtn.UseVisualStyleBackColor = false;
            this.cheaperBtn.Click += new System.EventHandler(this.cheaperBtn_Click);
            // 
            // supplierIdBtn
            // 
            this.supplierIdBtn.BackColor = System.Drawing.SystemColors.Info;
            this.supplierIdBtn.Location = new System.Drawing.Point(50, 379);
            this.supplierIdBtn.Name = "supplierIdBtn";
            this.supplierIdBtn.Size = new System.Drawing.Size(267, 29);
            this.supplierIdBtn.TabIndex = 2;
            this.supplierIdBtn.Text = "Select products for supplierId";
            this.supplierIdBtn.UseVisualStyleBackColor = false;
            this.supplierIdBtn.Click += new System.EventHandler(this.supplierIdBtn_Click);
            // 
            // nameBtn
            // 
            this.nameBtn.BackColor = System.Drawing.SystemColors.Highlight;
            this.nameBtn.Location = new System.Drawing.Point(50, 475);
            this.nameBtn.Name = "nameBtn";
            this.nameBtn.Size = new System.Drawing.Size(267, 29);
            this.nameBtn.TabIndex = 3;
            this.nameBtn.Text = "Select products that name starts with";
            this.nameBtn.UseVisualStyleBackColor = false;
            this.nameBtn.Click += new System.EventHandler(this.nameBtn_Click);
            // 
            // cheaperTxtBox
            // 
            this.cheaperTxtBox.Location = new System.Drawing.Point(369, 278);
            this.cheaperTxtBox.Name = "cheaperTxtBox";
            this.cheaperTxtBox.Size = new System.Drawing.Size(125, 27);
            this.cheaperTxtBox.TabIndex = 4;
            // 
            // nameTxtBox
            // 
            this.nameTxtBox.Location = new System.Drawing.Point(369, 475);
            this.nameTxtBox.Name = "nameTxtBox";
            this.nameTxtBox.Size = new System.Drawing.Size(125, 27);
            this.nameTxtBox.TabIndex = 5;
            // 
            // supplierIdTxtBox
            // 
            this.supplierIdTxtBox.Location = new System.Drawing.Point(369, 379);
            this.supplierIdTxtBox.Name = "supplierIdTxtBox";
            this.supplierIdTxtBox.Size = new System.Drawing.Size(125, 27);
            this.supplierIdTxtBox.TabIndex = 6;
            // 
            // productsGridView
            // 
            this.productsGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.productsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productsGridView.Location = new System.Drawing.Point(564, 102);
            this.productsGridView.Name = "productsGridView";
            this.productsGridView.RowHeadersWidth = 51;
            this.productsGridView.RowTemplate.Height = 29;
            this.productsGridView.Size = new System.Drawing.Size(514, 489);
            this.productsGridView.TabIndex = 7;
            // 
            // allBtn
            // 
            this.allBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.allBtn.Location = new System.Drawing.Point(50, 185);
            this.allBtn.Name = "allBtn";
            this.allBtn.Size = new System.Drawing.Size(267, 29);
            this.allBtn.TabIndex = 8;
            this.allBtn.Text = "Select all products";
            this.allBtn.UseVisualStyleBackColor = false;
            this.allBtn.Click += new System.EventHandler(this.allBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 715);
            this.Controls.Add(this.allBtn);
            this.Controls.Add(this.productsGridView);
            this.Controls.Add(this.supplierIdTxtBox);
            this.Controls.Add(this.nameTxtBox);
            this.Controls.Add(this.cheaperTxtBox);
            this.Controls.Add(this.nameBtn);
            this.Controls.Add(this.supplierIdBtn);
            this.Controls.Add(this.cheaperBtn);
            this.Controls.Add(this.importBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.productsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button importBtn;
        private Button cheaperBtn;
        private Button supplierIdBtn;
        private Button nameBtn;
        private TextBox cheaperTxtBox;
        private TextBox nameTxtBox;
        private TextBox supplierIdTxtBox;
        private DataGridView productsGridView;
        private Button allBtn;
    }
}