namespace str_recognition
{
    partial class frmMain
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
            this.bnSamples = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bnLearning = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txType = new System.Windows.Forms.TextBox();
            this.txSampleNumber = new System.Windows.Forms.TextBox();
            this.txHeight = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pbSamplePreview = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bnLoad = new System.Windows.Forms.Button();
            this.txSampleString = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bnGenerate = new System.Windows.Forms.Button();
            this.bnAddNoise = new System.Windows.Forms.Button();
            this.pbSourceImage = new System.Windows.Forms.PictureBox();
            this.bnSave = new System.Windows.Forms.Button();
            this.txTop = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txLeft = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txBottom = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txRight = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txResult = new System.Windows.Forms.TextBox();
            this.txfff = new System.Windows.Forms.Label();
            this.txShift = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.pbRegenrated = new System.Windows.Forms.PictureBox();
            this.bnRecognise = new System.Windows.Forms.Button();
            this.cbFontSpacing = new System.Windows.Forms.CheckBox();
            this.bnSelectFont = new System.Windows.Forms.Button();
            this.txDispersion = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.bnSelectFont2 = new System.Windows.Forms.Button();
            this.lbIdentical = new System.Windows.Forms.Label();
            this.txAllSymbols = new System.Windows.Forms.TextBox();
            this.lbProcessing = new System.Windows.Forms.Label();
            this.bnCompareImages = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbSamplePreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSourceImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRegenrated)).BeginInit();
            this.SuspendLayout();
            // 
            // bnSamples
            // 
            this.bnSamples.Location = new System.Drawing.Point(8, 17);
            this.bnSamples.Name = "bnSamples";
            this.bnSamples.Size = new System.Drawing.Size(176, 28);
            this.bnSamples.TabIndex = 0;
            this.bnSamples.Text = "Samples library";
            this.bnSamples.UseVisualStyleBackColor = true;
            this.bnSamples.Click += new System.EventHandler(this.bnSamples_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Location = new System.Drawing.Point(216, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 44);
            this.label1.TabIndex = 1;
            this.label1.Text = "Here you can load from file or generate a set of samples. You can choose font and" +
                " font size for sample generation.\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bnLearning
            // 
            this.bnLearning.Enabled = false;
            this.bnLearning.Location = new System.Drawing.Point(8, 61);
            this.bnLearning.Name = "bnLearning";
            this.bnLearning.Size = new System.Drawing.Size(176, 28);
            this.bnLearning.TabIndex = 0;
            this.bnLearning.Text = "Samples learning";
            this.bnLearning.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.Location = new System.Drawing.Point(216, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(237, 35);
            this.label3.TabIndex = 1;
            this.label3.Text = "Here you can create samples of linear type from\r\na given image, string and sizes " +
                "of letters\r\n";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(117, 126);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Number of samples";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Height";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txType
            // 
            this.txType.Location = new System.Drawing.Point(304, 123);
            this.txType.Name = "txType";
            this.txType.ReadOnly = true;
            this.txType.Size = new System.Drawing.Size(94, 20);
            this.txType.TabIndex = 9;
            // 
            // txSampleNumber
            // 
            this.txSampleNumber.Location = new System.Drawing.Point(220, 123);
            this.txSampleNumber.Name = "txSampleNumber";
            this.txSampleNumber.ReadOnly = true;
            this.txSampleNumber.Size = new System.Drawing.Size(39, 20);
            this.txSampleNumber.TabIndex = 7;
            // 
            // txHeight
            // 
            this.txHeight.Location = new System.Drawing.Point(56, 123);
            this.txHeight.Name = "txHeight";
            this.txHeight.ReadOnly = true;
            this.txHeight.Size = new System.Drawing.Size(55, 20);
            this.txHeight.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label4.Location = new System.Drawing.Point(-2, 100);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label4.Size = new System.Drawing.Size(503, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Current sample library";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(265, 126);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Type";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbSamplePreview
            // 
            this.pbSamplePreview.Location = new System.Drawing.Point(13, 151);
            this.pbSamplePreview.Name = "pbSamplePreview";
            this.pbSamplePreview.Size = new System.Drawing.Size(488, 40);
            this.pbSamplePreview.TabIndex = 13;
            this.pbSamplePreview.TabStop = false;
            this.pbSamplePreview.Click += new System.EventHandler(this.pbSamplePreview_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(0, 225);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label5.Size = new System.Drawing.Size(500, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Image for recognition";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bnLoad
            // 
            this.bnLoad.Location = new System.Drawing.Point(130, 351);
            this.bnLoad.Name = "bnLoad";
            this.bnLoad.Size = new System.Drawing.Size(118, 21);
            this.bnLoad.TabIndex = 14;
            this.bnLoad.Text = "Load from file";
            this.bnLoad.UseVisualStyleBackColor = true;
            this.bnLoad.Click += new System.EventHandler(this.bnLoad_Click);
            // 
            // txSampleString
            // 
            this.txSampleString.Location = new System.Drawing.Point(78, 246);
            this.txSampleString.Multiline = true;
            this.txSampleString.Name = "txSampleString";
            this.txSampleString.Size = new System.Drawing.Size(407, 47);
            this.txSampleString.TabIndex = 15;
            this.txSampleString.Text = "The Comedy of Errors is one of William Shakespeare\'s earliest plays, believed to " +
                "have been written between 1592 and 1594";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 249);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Test string";
            // 
            // bnGenerate
            // 
            this.bnGenerate.Location = new System.Drawing.Point(12, 351);
            this.bnGenerate.Name = "bnGenerate";
            this.bnGenerate.Size = new System.Drawing.Size(118, 21);
            this.bnGenerate.TabIndex = 14;
            this.bnGenerate.Text = "Generate from string";
            this.bnGenerate.UseVisualStyleBackColor = true;
            this.bnGenerate.Click += new System.EventHandler(this.bnGenerate_Click);
            // 
            // bnAddNoise
            // 
            this.bnAddNoise.Location = new System.Drawing.Point(248, 351);
            this.bnAddNoise.Name = "bnAddNoise";
            this.bnAddNoise.Size = new System.Drawing.Size(118, 21);
            this.bnAddNoise.TabIndex = 14;
            this.bnAddNoise.Text = "Add noise";
            this.bnAddNoise.UseVisualStyleBackColor = true;
            this.bnAddNoise.Click += new System.EventHandler(this.bnAddNoise_Click);
            // 
            // pbSourceImage
            // 
            this.pbSourceImage.Location = new System.Drawing.Point(12, 378);
            this.pbSourceImage.Name = "pbSourceImage";
            this.pbSourceImage.Size = new System.Drawing.Size(473, 40);
            this.pbSourceImage.TabIndex = 13;
            this.pbSourceImage.TabStop = false;
            this.pbSourceImage.Click += new System.EventHandler(this.pbSourceImage_Click);
            // 
            // bnSave
            // 
            this.bnSave.Location = new System.Drawing.Point(366, 351);
            this.bnSave.Name = "bnSave";
            this.bnSave.Size = new System.Drawing.Size(118, 21);
            this.bnSave.TabIndex = 14;
            this.bnSave.Text = "Save Image";
            this.bnSave.UseVisualStyleBackColor = true;
            this.bnSave.Click += new System.EventHandler(this.bnSave_Click);
            // 
            // txTop
            // 
            this.txTop.Location = new System.Drawing.Point(104, 321);
            this.txTop.Name = "txTop";
            this.txTop.Size = new System.Drawing.Size(63, 20);
            this.txTop.TabIndex = 17;
            this.txTop.Text = "0";
            this.txTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txTop.Validating += new System.ComponentModel.CancelEventHandler(this.txTop_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(76, 324);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "top";
            // 
            // txLeft
            // 
            this.txLeft.Location = new System.Drawing.Point(211, 321);
            this.txLeft.Name = "txLeft";
            this.txLeft.Size = new System.Drawing.Size(63, 20);
            this.txLeft.TabIndex = 17;
            this.txLeft.Text = "0";
            this.txLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txLeft.Validating += new System.ComponentModel.CancelEventHandler(this.txTop_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(183, 324);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "left";
            // 
            // txBottom
            // 
            this.txBottom.Location = new System.Drawing.Point(316, 321);
            this.txBottom.Name = "txBottom";
            this.txBottom.Size = new System.Drawing.Size(63, 20);
            this.txBottom.TabIndex = 17;
            this.txBottom.Text = "0";
            this.txBottom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txBottom.Validating += new System.ComponentModel.CancelEventHandler(this.txTop_Validating);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(277, 324);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "bottom";
            // 
            // txRight
            // 
            this.txRight.Location = new System.Drawing.Point(422, 321);
            this.txRight.Name = "txRight";
            this.txRight.Size = new System.Drawing.Size(63, 20);
            this.txRight.TabIndex = 17;
            this.txRight.Text = "0";
            this.txRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txRight.Validating += new System.ComponentModel.CancelEventHandler(this.txTop_Validating);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(389, 324);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(27, 13);
            this.label13.TabIndex = 18;
            this.label13.Text = "right";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(15, 319);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 28);
            this.label14.TabIndex = 19;
            this.label14.Text = "White margins";
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label15.Location = new System.Drawing.Point(0, 423);
            this.label15.Name = "label15";
            this.label15.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label15.Size = new System.Drawing.Size(499, 17);
            this.label15.TabIndex = 6;
            this.label15.Text = "Recognition";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txResult
            // 
            this.txResult.Location = new System.Drawing.Point(79, 444);
            this.txResult.Multiline = true;
            this.txResult.Name = "txResult";
            this.txResult.ReadOnly = true;
            this.txResult.Size = new System.Drawing.Size(407, 47);
            this.txResult.TabIndex = 15;
            // 
            // txfff
            // 
            this.txfff.Location = new System.Drawing.Point(16, 447);
            this.txfff.Name = "txfff";
            this.txfff.Size = new System.Drawing.Size(56, 44);
            this.txfff.TabIndex = 16;
            this.txfff.Text = "Result \r\nstring";
            // 
            // txShift
            // 
            this.txShift.Location = new System.Drawing.Point(79, 494);
            this.txShift.Name = "txShift";
            this.txShift.ReadOnly = true;
            this.txShift.Size = new System.Drawing.Size(63, 20);
            this.txShift.TabIndex = 17;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(19, 497);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(44, 13);
            this.label17.TabIndex = 18;
            this.label17.Text = "top shift";
            this.label17.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pbRegenrated
            // 
            this.pbRegenrated.Location = new System.Drawing.Point(15, 548);
            this.pbRegenrated.Name = "pbRegenrated";
            this.pbRegenrated.Size = new System.Drawing.Size(473, 40);
            this.pbRegenrated.TabIndex = 13;
            this.pbRegenrated.TabStop = false;
            this.pbRegenrated.Click += new System.EventHandler(this.pbRegenrated_Click);
            // 
            // bnRecognise
            // 
            this.bnRecognise.Location = new System.Drawing.Point(366, 522);
            this.bnRecognise.Name = "bnRecognise";
            this.bnRecognise.Size = new System.Drawing.Size(118, 21);
            this.bnRecognise.TabIndex = 14;
            this.bnRecognise.Text = "Recognise";
            this.bnRecognise.UseVisualStyleBackColor = true;
            this.bnRecognise.Click += new System.EventHandler(this.bnRecognise_Click);
            // 
            // cbFontSpacing
            // 
            this.cbFontSpacing.AutoSize = true;
            this.cbFontSpacing.Location = new System.Drawing.Point(205, 498);
            this.cbFontSpacing.Name = "cbFontSpacing";
            this.cbFontSpacing.Size = new System.Drawing.Size(160, 17);
            this.cbFontSpacing.TabIndex = 20;
            this.cbFontSpacing.Text = "Use font spacing information";
            this.cbFontSpacing.UseVisualStyleBackColor = true;
            this.cbFontSpacing.CheckedChanged += new System.EventHandler(this.cbFontSpacing_CheckedChanged);
            // 
            // bnSelectFont
            // 
            this.bnSelectFont.Location = new System.Drawing.Point(366, 496);
            this.bnSelectFont.Name = "bnSelectFont";
            this.bnSelectFont.Size = new System.Drawing.Size(118, 21);
            this.bnSelectFont.TabIndex = 14;
            this.bnSelectFont.Text = "Select Font";
            this.bnSelectFont.UseVisualStyleBackColor = true;
            this.bnSelectFont.Click += new System.EventHandler(this.bnSelectFont_Click);
            // 
            // txDispersion
            // 
            this.txDispersion.Location = new System.Drawing.Point(104, 296);
            this.txDispersion.Name = "txDispersion";
            this.txDispersion.Size = new System.Drawing.Size(63, 20);
            this.txDispersion.TabIndex = 17;
            this.txDispersion.Text = "10";
            this.txDispersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txDispersion.Validating += new System.ComponentModel.CancelEventHandler(this.txDispersion_Validating);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 298);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(84, 13);
            this.label16.TabIndex = 18;
            this.label16.Text = "Noise dispersion";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "PNG files|*.png";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "PNG files|*.png";
            // 
            // bnSelectFont2
            // 
            this.bnSelectFont2.Location = new System.Drawing.Point(366, 297);
            this.bnSelectFont2.Name = "bnSelectFont2";
            this.bnSelectFont2.Size = new System.Drawing.Size(118, 21);
            this.bnSelectFont2.TabIndex = 14;
            this.bnSelectFont2.Text = "Select Font";
            this.bnSelectFont2.UseVisualStyleBackColor = true;
            this.bnSelectFont2.Click += new System.EventHandler(this.bnSelectFont_Click);
            // 
            // lbIdentical
            // 
            this.lbIdentical.AutoSize = true;
            this.lbIdentical.ForeColor = System.Drawing.Color.Green;
            this.lbIdentical.Location = new System.Drawing.Point(19, 526);
            this.lbIdentical.Name = "lbIdentical";
            this.lbIdentical.Size = new System.Drawing.Size(99, 13);
            this.lbIdentical.TabIndex = 21;
            this.lbIdentical.Text = "Strings are identical";
            this.lbIdentical.Visible = false;
            // 
            // txAllSymbols
            // 
            this.txAllSymbols.Location = new System.Drawing.Point(16, 197);
            this.txAllSymbols.Multiline = true;
            this.txAllSymbols.Name = "txAllSymbols";
            this.txAllSymbols.ReadOnly = true;
            this.txAllSymbols.Size = new System.Drawing.Size(484, 22);
            this.txAllSymbols.TabIndex = 22;
            // 
            // lbProcessing
            // 
            this.lbProcessing.AutoSize = true;
            this.lbProcessing.ForeColor = System.Drawing.Color.Green;
            this.lbProcessing.Location = new System.Drawing.Point(140, 526);
            this.lbProcessing.Name = "lbProcessing";
            this.lbProcessing.Size = new System.Drawing.Size(74, 13);
            this.lbProcessing.TabIndex = 21;
            this.lbProcessing.Text = "Processing.....";
            this.lbProcessing.Visible = false;
            // 
            // bnCompareImages
            // 
            this.bnCompareImages.Location = new System.Drawing.Point(248, 522);
            this.bnCompareImages.Name = "bnCompareImages";
            this.bnCompareImages.Size = new System.Drawing.Size(118, 21);
            this.bnCompareImages.TabIndex = 14;
            this.bnCompareImages.Text = "Compare images";
            this.bnCompareImages.UseVisualStyleBackColor = true;
            this.bnCompareImages.Click += new System.EventHandler(this.bnCompareImages_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 595);
            this.Controls.Add(this.txAllSymbols);
            this.Controls.Add(this.lbProcessing);
            this.Controls.Add(this.lbIdentical);
            this.Controls.Add(this.cbFontSpacing);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txRight);
            this.Controls.Add(this.txBottom);
            this.Controls.Add(this.txLeft);
            this.Controls.Add(this.txShift);
            this.Controls.Add(this.txDispersion);
            this.Controls.Add(this.txTop);
            this.Controls.Add(this.txfff);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txResult);
            this.Controls.Add(this.txSampleString);
            this.Controls.Add(this.bnCompareImages);
            this.Controls.Add(this.bnRecognise);
            this.Controls.Add(this.bnSave);
            this.Controls.Add(this.bnSelectFont2);
            this.Controls.Add(this.bnSelectFont);
            this.Controls.Add(this.bnAddNoise);
            this.Controls.Add(this.bnGenerate);
            this.Controls.Add(this.bnLoad);
            this.Controls.Add(this.pbRegenrated);
            this.Controls.Add(this.pbSourceImage);
            this.Controls.Add(this.pbSamplePreview);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txType);
            this.Controls.Add(this.txSampleNumber);
            this.Controls.Add(this.txHeight);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bnLearning);
            this.Controls.Add(this.bnSamples);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "Strings recognition lab";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSamplePreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSourceImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRegenrated)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnSamples;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bnLearning;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txType;
        private System.Windows.Forms.TextBox txSampleNumber;
        private System.Windows.Forms.TextBox txHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pbSamplePreview;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bnLoad;
        private System.Windows.Forms.TextBox txSampleString;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bnGenerate;
        private System.Windows.Forms.Button bnAddNoise;
        private System.Windows.Forms.PictureBox pbSourceImage;
        private System.Windows.Forms.Button bnSave;
        private System.Windows.Forms.TextBox txTop;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txLeft;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txBottom;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txRight;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txResult;
        private System.Windows.Forms.Label txfff;
        private System.Windows.Forms.TextBox txShift;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.PictureBox pbRegenrated;
        private System.Windows.Forms.Button bnRecognise;
        private System.Windows.Forms.CheckBox cbFontSpacing;
        private System.Windows.Forms.Button bnSelectFont;
        private System.Windows.Forms.TextBox txDispersion;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button bnSelectFont2;
        private System.Windows.Forms.Label lbIdentical;
        private System.Windows.Forms.TextBox txAllSymbols;
        private System.Windows.Forms.Label lbProcessing;
        private System.Windows.Forms.Button bnCompareImages;
    }
}

