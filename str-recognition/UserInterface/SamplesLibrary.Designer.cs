namespace str_recognition
{
    partial class frmSamplesLibrary
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
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.txFileName = new System.Windows.Forms.TextBox();
            this.bnLoadFromFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.txSymbols = new System.Windows.Forms.TextBox();
            this.bnSelectFont = new System.Windows.Forms.Button();
            this.bnAddEnglish = new System.Windows.Forms.Button();
            this.bnAddRussian = new System.Windows.Forms.Button();
            this.bnAddNumbers = new System.Windows.Forms.Button();
            this.bnGenerateSamples = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txHeightManual = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bnEditSampleLib1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txSamplesNumberManual = new System.Windows.Forms.TextBox();
            this.bnCreateAndEdit = new System.Windows.Forms.Button();
            this.bnSaveSampleLib1 = new System.Windows.Forms.Button();
            this.bnEditSampleLib2 = new System.Windows.Forms.Button();
            this.bnSaveSampleLib2 = new System.Windows.Forms.Button();
            this.txHeight = new System.Windows.Forms.TextBox();
            this.txSampleNumber = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.bnEditSampleLib = new System.Windows.Forms.Button();
            this.bnSaveSampleLib = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.pbSamplePreview = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txType = new System.Windows.Forms.TextBox();
            this.txHeightFont = new System.Windows.Forms.TextBox();
            this.txSamplesNumberFont = new System.Windows.Forms.TextBox();
            this.txTypeFont = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.rbLinearManual = new System.Windows.Forms.RadioButton();
            this.rbQuadraticManual = new System.Windows.Forms.RadioButton();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.txAllSymbols = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbSamplePreview)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(0, 1);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(409, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "You can load s sample set from a file:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "XML files|*.xml";
            // 
            // txFileName
            // 
            this.txFileName.Location = new System.Drawing.Point(19, 47);
            this.txFileName.Name = "txFileName";
            this.txFileName.ReadOnly = true;
            this.txFileName.Size = new System.Drawing.Size(375, 20);
            this.txFileName.TabIndex = 1;
            this.txFileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // bnLoadFromFile
            // 
            this.bnLoadFromFile.Location = new System.Drawing.Point(19, 68);
            this.bnLoadFromFile.Name = "bnLoadFromFile";
            this.bnLoadFromFile.Size = new System.Drawing.Size(94, 20);
            this.bnLoadFromFile.TabIndex = 2;
            this.bnLoadFromFile.Text = "Load";
            this.bnLoadFromFile.UseVisualStyleBackColor = true;
            this.bnLoadFromFile.Click += new System.EventHandler(this.bnLoadFromFile_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(0, 92);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(409, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Or generate it by selecting a font and size of the text";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fontDialog
            // 
            this.fontDialog.AllowVerticalFonts = false;
            this.fontDialog.FontMustExist = true;
            this.fontDialog.ShowEffects = false;
            // 
            // txSymbols
            // 
            this.txSymbols.Location = new System.Drawing.Point(19, 153);
            this.txSymbols.Multiline = true;
            this.txSymbols.Name = "txSymbols";
            this.txSymbols.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txSymbols.Size = new System.Drawing.Size(376, 124);
            this.txSymbols.TabIndex = 3;
            this.txSymbols.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz\',0123456789";
            this.txSymbols.TextChanged += new System.EventHandler(this.txSymbols_TextChanged);
            // 
            // bnSelectFont
            // 
            this.bnSelectFont.Location = new System.Drawing.Point(19, 283);
            this.bnSelectFont.Name = "bnSelectFont";
            this.bnSelectFont.Size = new System.Drawing.Size(94, 20);
            this.bnSelectFont.TabIndex = 2;
            this.bnSelectFont.Text = "Select Font";
            this.bnSelectFont.UseVisualStyleBackColor = true;
            this.bnSelectFont.Click += new System.EventHandler(this.bnSelectFont_Click);
            // 
            // bnAddEnglish
            // 
            this.bnAddEnglish.Location = new System.Drawing.Point(113, 283);
            this.bnAddEnglish.Name = "bnAddEnglish";
            this.bnAddEnglish.Size = new System.Drawing.Size(94, 20);
            this.bnAddEnglish.TabIndex = 2;
            this.bnAddEnglish.Text = "English Letters";
            this.bnAddEnglish.UseVisualStyleBackColor = true;
            this.bnAddEnglish.Click += new System.EventHandler(this.bnAddEnglish_Click);
            // 
            // bnAddRussian
            // 
            this.bnAddRussian.Location = new System.Drawing.Point(207, 283);
            this.bnAddRussian.Name = "bnAddRussian";
            this.bnAddRussian.Size = new System.Drawing.Size(94, 20);
            this.bnAddRussian.TabIndex = 2;
            this.bnAddRussian.Text = "Russian Letters";
            this.bnAddRussian.UseVisualStyleBackColor = true;
            this.bnAddRussian.Click += new System.EventHandler(this.bnAddRussian_Click);
            // 
            // bnAddNumbers
            // 
            this.bnAddNumbers.Location = new System.Drawing.Point(301, 283);
            this.bnAddNumbers.Name = "bnAddNumbers";
            this.bnAddNumbers.Size = new System.Drawing.Size(94, 20);
            this.bnAddNumbers.TabIndex = 2;
            this.bnAddNumbers.Text = "Numbers";
            this.bnAddNumbers.UseVisualStyleBackColor = true;
            this.bnAddNumbers.Click += new System.EventHandler(this.bnAddNumbers_Click);
            // 
            // bnGenerateSamples
            // 
            this.bnGenerateSamples.Location = new System.Drawing.Point(19, 303);
            this.bnGenerateSamples.Name = "bnGenerateSamples";
            this.bnGenerateSamples.Size = new System.Drawing.Size(94, 20);
            this.bnGenerateSamples.TabIndex = 2;
            this.bnGenerateSamples.Text = "Generate";
            this.bnGenerateSamples.UseVisualStyleBackColor = true;
            this.bnGenerateSamples.Click += new System.EventHandler(this.bnGenerateSamples_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Characters in a sample set:";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(0, 326);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label5.Size = new System.Drawing.Size(409, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Or create an empty set and add samples to it manually";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txHeightManual
            // 
            this.txHeightManual.Enabled = false;
            this.txHeightManual.Location = new System.Drawing.Point(58, 347);
            this.txHeightManual.Name = "txHeightManual";
            this.txHeightManual.Size = new System.Drawing.Size(55, 20);
            this.txHeightManual.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.Location = new System.Drawing.Point(16, 350);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Height";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bnEditSampleLib1
            // 
            this.bnEditSampleLib1.Enabled = false;
            this.bnEditSampleLib1.Location = new System.Drawing.Point(113, 303);
            this.bnEditSampleLib1.Name = "bnEditSampleLib1";
            this.bnEditSampleLib1.Size = new System.Drawing.Size(188, 20);
            this.bnEditSampleLib1.TabIndex = 2;
            this.bnEditSampleLib1.Text = "Edit manually";
            this.bnEditSampleLib1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Enabled = false;
            this.label7.Location = new System.Drawing.Point(119, 350);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Number of samples";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txSamplesNumberManual
            // 
            this.txSamplesNumberManual.Enabled = false;
            this.txSamplesNumberManual.Location = new System.Drawing.Point(222, 347);
            this.txSamplesNumberManual.Name = "txSamplesNumberManual";
            this.txSamplesNumberManual.Size = new System.Drawing.Size(39, 20);
            this.txSamplesNumberManual.TabIndex = 4;
            // 
            // bnCreateAndEdit
            // 
            this.bnCreateAndEdit.Enabled = false;
            this.bnCreateAndEdit.Location = new System.Drawing.Point(19, 371);
            this.bnCreateAndEdit.Name = "bnCreateAndEdit";
            this.bnCreateAndEdit.Size = new System.Drawing.Size(188, 20);
            this.bnCreateAndEdit.TabIndex = 2;
            this.bnCreateAndEdit.Text = "Create and edit";
            this.bnCreateAndEdit.UseVisualStyleBackColor = true;
            // 
            // bnSaveSampleLib1
            // 
            this.bnSaveSampleLib1.Location = new System.Drawing.Point(301, 303);
            this.bnSaveSampleLib1.Name = "bnSaveSampleLib1";
            this.bnSaveSampleLib1.Size = new System.Drawing.Size(94, 20);
            this.bnSaveSampleLib1.TabIndex = 2;
            this.bnSaveSampleLib1.Text = "Save";
            this.bnSaveSampleLib1.UseVisualStyleBackColor = true;
            this.bnSaveSampleLib1.Click += new System.EventHandler(this.bnSaveSampleLib_Click);
            // 
            // bnEditSampleLib2
            // 
            this.bnEditSampleLib2.Enabled = false;
            this.bnEditSampleLib2.Location = new System.Drawing.Point(207, 371);
            this.bnEditSampleLib2.Name = "bnEditSampleLib2";
            this.bnEditSampleLib2.Size = new System.Drawing.Size(94, 20);
            this.bnEditSampleLib2.TabIndex = 2;
            this.bnEditSampleLib2.Text = "Edit";
            this.bnEditSampleLib2.UseVisualStyleBackColor = true;
            // 
            // bnSaveSampleLib2
            // 
            this.bnSaveSampleLib2.Enabled = false;
            this.bnSaveSampleLib2.Location = new System.Drawing.Point(300, 371);
            this.bnSaveSampleLib2.Name = "bnSaveSampleLib2";
            this.bnSaveSampleLib2.Size = new System.Drawing.Size(94, 20);
            this.bnSaveSampleLib2.TabIndex = 2;
            this.bnSaveSampleLib2.Text = "Save";
            this.bnSaveSampleLib2.UseVisualStyleBackColor = true;
            // 
            // txHeight
            // 
            this.txHeight.Location = new System.Drawing.Point(58, 23);
            this.txHeight.Name = "txHeight";
            this.txHeight.ReadOnly = true;
            this.txHeight.Size = new System.Drawing.Size(55, 20);
            this.txHeight.TabIndex = 4;
            // 
            // txSampleNumber
            // 
            this.txSampleNumber.Location = new System.Drawing.Point(222, 23);
            this.txSampleNumber.Name = "txSampleNumber";
            this.txSampleNumber.ReadOnly = true;
            this.txSampleNumber.Size = new System.Drawing.Size(39, 20);
            this.txSampleNumber.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Height";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(119, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Number of samples";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bnEditSampleLib
            // 
            this.bnEditSampleLib.Enabled = false;
            this.bnEditSampleLib.Location = new System.Drawing.Point(113, 68);
            this.bnEditSampleLib.Name = "bnEditSampleLib";
            this.bnEditSampleLib.Size = new System.Drawing.Size(94, 20);
            this.bnEditSampleLib.TabIndex = 2;
            this.bnEditSampleLib.Text = "Edit";
            this.bnEditSampleLib.UseVisualStyleBackColor = true;
            // 
            // bnSaveSampleLib
            // 
            this.bnSaveSampleLib.Location = new System.Drawing.Point(207, 68);
            this.bnSaveSampleLib.Name = "bnSaveSampleLib";
            this.bnSaveSampleLib.Size = new System.Drawing.Size(94, 20);
            this.bnSaveSampleLib.TabIndex = 2;
            this.bnSaveSampleLib.Text = "Save";
            this.bnSaveSampleLib.UseVisualStyleBackColor = true;
            this.bnSaveSampleLib.Click += new System.EventHandler(this.bnSaveSampleLib_Click);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label11.Location = new System.Drawing.Point(1, 396);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label11.Size = new System.Drawing.Size(409, 17);
            this.label11.TabIndex = 0;
            this.label11.Text = "Sample set preview";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbSamplePreview
            // 
            this.pbSamplePreview.Location = new System.Drawing.Point(2, 417);
            this.pbSamplePreview.Name = "pbSamplePreview";
            this.pbSamplePreview.Size = new System.Drawing.Size(409, 106);
            this.pbSamplePreview.TabIndex = 7;
            this.pbSamplePreview.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(267, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Type";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txType
            // 
            this.txType.Location = new System.Drawing.Point(300, 23);
            this.txType.Name = "txType";
            this.txType.ReadOnly = true;
            this.txType.Size = new System.Drawing.Size(94, 20);
            this.txType.TabIndex = 4;
            // 
            // txHeightFont
            // 
            this.txHeightFont.Location = new System.Drawing.Point(58, 112);
            this.txHeightFont.Name = "txHeightFont";
            this.txHeightFont.ReadOnly = true;
            this.txHeightFont.Size = new System.Drawing.Size(55, 20);
            this.txHeightFont.TabIndex = 4;
            // 
            // txSamplesNumberFont
            // 
            this.txSamplesNumberFont.Location = new System.Drawing.Point(222, 112);
            this.txSamplesNumberFont.Name = "txSamplesNumberFont";
            this.txSamplesNumberFont.ReadOnly = true;
            this.txSamplesNumberFont.Size = new System.Drawing.Size(39, 20);
            this.txSamplesNumberFont.TabIndex = 4;
            // 
            // txTypeFont
            // 
            this.txTypeFont.Location = new System.Drawing.Point(300, 112);
            this.txTypeFont.Name = "txTypeFont";
            this.txTypeFont.ReadOnly = true;
            this.txTypeFont.Size = new System.Drawing.Size(94, 20);
            this.txTypeFont.TabIndex = 4;
            this.txTypeFont.Text = "Quadratic";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Height";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(119, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Number of samples";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(267, 115);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "Type";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rbLinearManual
            // 
            this.rbLinearManual.AutoSize = true;
            this.rbLinearManual.Enabled = false;
            this.rbLinearManual.Location = new System.Drawing.Point(269, 348);
            this.rbLinearManual.Name = "rbLinearManual";
            this.rbLinearManual.Size = new System.Drawing.Size(54, 17);
            this.rbLinearManual.TabIndex = 8;
            this.rbLinearManual.TabStop = true;
            this.rbLinearManual.Text = "Linear";
            this.rbLinearManual.UseVisualStyleBackColor = true;
            // 
            // rbQuadraticManual
            // 
            this.rbQuadraticManual.AutoSize = true;
            this.rbQuadraticManual.Enabled = false;
            this.rbQuadraticManual.Location = new System.Drawing.Point(329, 348);
            this.rbQuadraticManual.Name = "rbQuadraticManual";
            this.rbQuadraticManual.Size = new System.Drawing.Size(71, 17);
            this.rbQuadraticManual.TabIndex = 8;
            this.rbQuadraticManual.TabStop = true;
            this.rbQuadraticManual.Text = "Quadratic";
            this.rbQuadraticManual.UseVisualStyleBackColor = true;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "XML files|*.xml";
            // 
            // txAllSymbols
            // 
            this.txAllSymbols.Location = new System.Drawing.Point(2, 527);
            this.txAllSymbols.Multiline = true;
            this.txAllSymbols.Name = "txAllSymbols";
            this.txAllSymbols.ReadOnly = true;
            this.txAllSymbols.Size = new System.Drawing.Size(409, 29);
            this.txAllSymbols.TabIndex = 9;
            // 
            // frmSamplesLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 558);
            this.Controls.Add(this.txAllSymbols);
            this.Controls.Add(this.rbQuadraticManual);
            this.Controls.Add(this.rbLinearManual);
            this.Controls.Add(this.pbSamplePreview);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txTypeFont);
            this.Controls.Add(this.txSamplesNumberFont);
            this.Controls.Add(this.txType);
            this.Controls.Add(this.txSampleNumber);
            this.Controls.Add(this.txHeightFont);
            this.Controls.Add(this.txSamplesNumberManual);
            this.Controls.Add(this.txHeight);
            this.Controls.Add(this.txHeightManual);
            this.Controls.Add(this.txSymbols);
            this.Controls.Add(this.bnAddNumbers);
            this.Controls.Add(this.bnAddRussian);
            this.Controls.Add(this.bnCreateAndEdit);
            this.Controls.Add(this.bnEditSampleLib1);
            this.Controls.Add(this.bnAddEnglish);
            this.Controls.Add(this.bnSelectFont);
            this.Controls.Add(this.bnGenerateSamples);
            this.Controls.Add(this.bnEditSampleLib);
            this.Controls.Add(this.bnEditSampleLib2);
            this.Controls.Add(this.bnSaveSampleLib);
            this.Controls.Add(this.bnSaveSampleLib2);
            this.Controls.Add(this.bnSaveSampleLib1);
            this.Controls.Add(this.bnLoadFromFile);
            this.Controls.Add(this.txFileName);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSamplesLibrary";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Samples Library";
            this.Load += new System.EventHandler(this.frmSamplesLibrary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSamplePreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox txFileName;
        private System.Windows.Forms.Button bnLoadFromFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.TextBox txSymbols;
        private System.Windows.Forms.Button bnSelectFont;
        private System.Windows.Forms.Button bnAddEnglish;
        private System.Windows.Forms.Button bnAddRussian;
        private System.Windows.Forms.Button bnAddNumbers;
        private System.Windows.Forms.Button bnGenerateSamples;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txHeightManual;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bnEditSampleLib1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txSamplesNumberManual;
        private System.Windows.Forms.Button bnCreateAndEdit;
        private System.Windows.Forms.Button bnSaveSampleLib1;
        private System.Windows.Forms.Button bnEditSampleLib2;
        private System.Windows.Forms.Button bnSaveSampleLib2;
        private System.Windows.Forms.TextBox txHeight;
        private System.Windows.Forms.TextBox txSampleNumber;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button bnEditSampleLib;
        private System.Windows.Forms.Button bnSaveSampleLib;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pbSamplePreview;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txType;
        private System.Windows.Forms.TextBox txHeightFont;
        private System.Windows.Forms.TextBox txSamplesNumberFont;
        private System.Windows.Forms.TextBox txTypeFont;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RadioButton rbLinearManual;
        private System.Windows.Forms.RadioButton rbQuadraticManual;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TextBox txAllSymbols;
    }
}