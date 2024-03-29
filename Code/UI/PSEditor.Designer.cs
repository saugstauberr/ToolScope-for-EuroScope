﻿namespace ToolScope_for_EuroScope
{
    partial class PSEditor
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
            this.components = new System.ComponentModel.Container();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges4 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges5 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges6 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges7 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PSEditor));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.codeeditor = new ScintillaNET.Scintilla();
            this.label2 = new System.Windows.Forms.Label();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse3 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse4 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.savebtn = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.loadoldscriptbtn = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.increasefontbtn = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.decreasefontbtn = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.minimizebtn = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.closebtn = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.maximizebtn = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 30;
            this.bunifuElipse1.TargetControl = this;
            // 
            // codeeditor
            // 
            this.codeeditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.codeeditor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.codeeditor.CaretForeColor = System.Drawing.Color.WhiteSmoke;
            this.codeeditor.EdgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.codeeditor.FontQuality = ScintillaNET.FontQuality.AntiAliased;
            this.codeeditor.Lexer = ScintillaNET.Lexer.PowerShell;
            this.codeeditor.Location = new System.Drawing.Point(1, 42);
            this.codeeditor.Name = "codeeditor";
            this.codeeditor.Size = new System.Drawing.Size(1158, 580);
            this.codeeditor.TabIndex = 48;
            this.codeeditor.CharAdded += new System.EventHandler<ScintillaNET.CharAddedEventArgs>(this.scintilla1_CharAdded);
            this.codeeditor.UpdateUI += new System.EventHandler<ScintillaNET.UpdateUIEventArgs>(this.scintilla1_UpdateUI);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(25)))), ((int)(((byte)(26)))));
            this.label2.Font = new System.Drawing.Font("Microsoft PhagsPa", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 10);
            this.label2.TabIndex = 3;
            this.label2.Text = "for EuroScope";
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 50;
            this.bunifuElipse2.TargetControl = this;
            // 
            // bunifuElipse3
            // 
            this.bunifuElipse3.ElipseRadius = 50;
            this.bunifuElipse3.TargetControl = this;
            // 
            // bunifuElipse4
            // 
            this.bunifuElipse4.ElipseRadius = 50;
            this.bunifuElipse4.TargetControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(25)))), ((int)(((byte)(26)))));
            this.pictureBox1.BackgroundImage = global::ToolScope_for_EuroScope.Properties.Resources.ToolScope_Banner;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::ToolScope_for_EuroScope.Properties.Resources.ToolScope_Banner;
            this.pictureBox1.Location = new System.Drawing.Point(10, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(93, 32);
            this.pictureBox1.TabIndex = 49;
            this.pictureBox1.TabStop = false;
            // 
            // savebtn
            // 
            this.savebtn.AllowAnimations = true;
            this.savebtn.AllowMouseEffects = true;
            this.savebtn.AllowToggling = false;
            this.savebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.savebtn.AnimationSpeed = 200;
            this.savebtn.AutoGenerateColors = false;
            this.savebtn.AutoRoundBorders = false;
            this.savebtn.AutoSizeLeftIcon = true;
            this.savebtn.AutoSizeRightIcon = true;
            this.savebtn.BackColor = System.Drawing.Color.Transparent;
            this.savebtn.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.savebtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("savebtn.BackgroundImage")));
            this.savebtn.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.savebtn.ButtonText = "Save";
            this.savebtn.ButtonTextMarginLeft = 0;
            this.savebtn.ColorContrastOnClick = 45;
            this.savebtn.ColorContrastOnHover = 45;
            this.savebtn.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges4.BottomLeft = true;
            borderEdges4.BottomRight = true;
            borderEdges4.TopLeft = true;
            borderEdges4.TopRight = true;
            this.savebtn.CustomizableEdges = borderEdges4;
            this.savebtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.savebtn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.savebtn.DisabledFillColor = System.Drawing.Color.Empty;
            this.savebtn.DisabledForecolor = System.Drawing.Color.Empty;
            this.savebtn.Enabled = false;
            this.savebtn.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.savebtn.Font = new System.Drawing.Font("Microsoft PhagsPa", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.ForeColor = System.Drawing.Color.White;
            this.savebtn.IconLeft = null;
            this.savebtn.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.savebtn.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.savebtn.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.savebtn.IconMarginLeft = 11;
            this.savebtn.IconPadding = 10;
            this.savebtn.IconRight = null;
            this.savebtn.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.savebtn.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.savebtn.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.savebtn.IconSize = 25;
            this.savebtn.IdleBorderColor = System.Drawing.Color.Empty;
            this.savebtn.IdleBorderRadius = 0;
            this.savebtn.IdleBorderThickness = 0;
            this.savebtn.IdleFillColor = System.Drawing.Color.Empty;
            this.savebtn.IdleIconLeftImage = null;
            this.savebtn.IdleIconRightImage = null;
            this.savebtn.IndicateFocus = false;
            this.savebtn.Location = new System.Drawing.Point(1089, 625);
            this.savebtn.Name = "savebtn";
            this.savebtn.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.savebtn.OnDisabledState.BorderRadius = 15;
            this.savebtn.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.savebtn.OnDisabledState.BorderThickness = 2;
            this.savebtn.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.savebtn.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.savebtn.OnDisabledState.IconLeftImage = null;
            this.savebtn.OnDisabledState.IconRightImage = null;
            this.savebtn.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(189)))), ((int)(((byte)(111)))));
            this.savebtn.onHoverState.BorderRadius = 15;
            this.savebtn.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.savebtn.onHoverState.BorderThickness = 2;
            this.savebtn.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(189)))), ((int)(((byte)(111)))));
            this.savebtn.onHoverState.ForeColor = System.Drawing.Color.White;
            this.savebtn.onHoverState.IconLeftImage = null;
            this.savebtn.onHoverState.IconRightImage = null;
            this.savebtn.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(148)))), ((int)(((byte)(87)))));
            this.savebtn.OnIdleState.BorderRadius = 15;
            this.savebtn.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.savebtn.OnIdleState.BorderThickness = 2;
            this.savebtn.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(148)))), ((int)(((byte)(87)))));
            this.savebtn.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.savebtn.OnIdleState.IconLeftImage = null;
            this.savebtn.OnIdleState.IconRightImage = null;
            this.savebtn.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(189)))), ((int)(((byte)(111)))));
            this.savebtn.OnPressedState.BorderRadius = 15;
            this.savebtn.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.savebtn.OnPressedState.BorderThickness = 2;
            this.savebtn.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(189)))), ((int)(((byte)(111)))));
            this.savebtn.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.savebtn.OnPressedState.IconLeftImage = null;
            this.savebtn.OnPressedState.IconRightImage = null;
            this.savebtn.Size = new System.Drawing.Size(60, 29);
            this.savebtn.TabIndex = 52;
            this.savebtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.savebtn.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.savebtn.TextMarginLeft = 0;
            this.savebtn.TextPadding = new System.Windows.Forms.Padding(0);
            this.savebtn.UseDefaultRadiusAndThickness = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // loadoldscriptbtn
            // 
            this.loadoldscriptbtn.AllowAnimations = true;
            this.loadoldscriptbtn.AllowMouseEffects = true;
            this.loadoldscriptbtn.AllowToggling = false;
            this.loadoldscriptbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.loadoldscriptbtn.AnimationSpeed = 200;
            this.loadoldscriptbtn.AutoGenerateColors = false;
            this.loadoldscriptbtn.AutoRoundBorders = false;
            this.loadoldscriptbtn.AutoSizeLeftIcon = true;
            this.loadoldscriptbtn.AutoSizeRightIcon = true;
            this.loadoldscriptbtn.BackColor = System.Drawing.Color.Transparent;
            this.loadoldscriptbtn.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.loadoldscriptbtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("loadoldscriptbtn.BackgroundImage")));
            this.loadoldscriptbtn.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.loadoldscriptbtn.ButtonText = "Load unsaved PowerShell Script";
            this.loadoldscriptbtn.ButtonTextMarginLeft = 0;
            this.loadoldscriptbtn.ColorContrastOnClick = 45;
            this.loadoldscriptbtn.ColorContrastOnHover = 45;
            this.loadoldscriptbtn.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges5.BottomLeft = true;
            borderEdges5.BottomRight = true;
            borderEdges5.TopLeft = true;
            borderEdges5.TopRight = true;
            this.loadoldscriptbtn.CustomizableEdges = borderEdges5;
            this.loadoldscriptbtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.loadoldscriptbtn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.loadoldscriptbtn.DisabledFillColor = System.Drawing.Color.Empty;
            this.loadoldscriptbtn.DisabledForecolor = System.Drawing.Color.Empty;
            this.loadoldscriptbtn.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.loadoldscriptbtn.Font = new System.Drawing.Font("Microsoft PhagsPa", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadoldscriptbtn.ForeColor = System.Drawing.Color.White;
            this.loadoldscriptbtn.IconLeft = null;
            this.loadoldscriptbtn.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.loadoldscriptbtn.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.loadoldscriptbtn.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.loadoldscriptbtn.IconMarginLeft = 11;
            this.loadoldscriptbtn.IconPadding = 10;
            this.loadoldscriptbtn.IconRight = null;
            this.loadoldscriptbtn.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.loadoldscriptbtn.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.loadoldscriptbtn.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.loadoldscriptbtn.IconSize = 25;
            this.loadoldscriptbtn.IdleBorderColor = System.Drawing.Color.Empty;
            this.loadoldscriptbtn.IdleBorderRadius = 0;
            this.loadoldscriptbtn.IdleBorderThickness = 0;
            this.loadoldscriptbtn.IdleFillColor = System.Drawing.Color.Empty;
            this.loadoldscriptbtn.IdleIconLeftImage = null;
            this.loadoldscriptbtn.IdleIconRightImage = null;
            this.loadoldscriptbtn.IndicateFocus = false;
            this.loadoldscriptbtn.Location = new System.Drawing.Point(897, 625);
            this.loadoldscriptbtn.Name = "loadoldscriptbtn";
            this.loadoldscriptbtn.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.loadoldscriptbtn.OnDisabledState.BorderRadius = 15;
            this.loadoldscriptbtn.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.loadoldscriptbtn.OnDisabledState.BorderThickness = 2;
            this.loadoldscriptbtn.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.loadoldscriptbtn.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.loadoldscriptbtn.OnDisabledState.IconLeftImage = null;
            this.loadoldscriptbtn.OnDisabledState.IconRightImage = null;
            this.loadoldscriptbtn.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.loadoldscriptbtn.onHoverState.BorderRadius = 15;
            this.loadoldscriptbtn.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.loadoldscriptbtn.onHoverState.BorderThickness = 2;
            this.loadoldscriptbtn.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.loadoldscriptbtn.onHoverState.ForeColor = System.Drawing.Color.White;
            this.loadoldscriptbtn.onHoverState.IconLeftImage = null;
            this.loadoldscriptbtn.onHoverState.IconRightImage = null;
            this.loadoldscriptbtn.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.loadoldscriptbtn.OnIdleState.BorderRadius = 15;
            this.loadoldscriptbtn.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.loadoldscriptbtn.OnIdleState.BorderThickness = 2;
            this.loadoldscriptbtn.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.loadoldscriptbtn.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.loadoldscriptbtn.OnIdleState.IconLeftImage = null;
            this.loadoldscriptbtn.OnIdleState.IconRightImage = null;
            this.loadoldscriptbtn.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.loadoldscriptbtn.OnPressedState.BorderRadius = 15;
            this.loadoldscriptbtn.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.loadoldscriptbtn.OnPressedState.BorderThickness = 2;
            this.loadoldscriptbtn.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.loadoldscriptbtn.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.loadoldscriptbtn.OnPressedState.IconLeftImage = null;
            this.loadoldscriptbtn.OnPressedState.IconRightImage = null;
            this.loadoldscriptbtn.Size = new System.Drawing.Size(192, 29);
            this.loadoldscriptbtn.TabIndex = 53;
            this.loadoldscriptbtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.loadoldscriptbtn.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.loadoldscriptbtn.TextMarginLeft = 0;
            this.loadoldscriptbtn.TextPadding = new System.Windows.Forms.Padding(0);
            this.loadoldscriptbtn.UseDefaultRadiusAndThickness = true;
            this.loadoldscriptbtn.Click += new System.EventHandler(this.loadoldscriptbtn_Click);
            // 
            // increasefontbtn
            // 
            this.increasefontbtn.AllowAnimations = true;
            this.increasefontbtn.AllowMouseEffects = true;
            this.increasefontbtn.AllowToggling = false;
            this.increasefontbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.increasefontbtn.AnimationSpeed = 200;
            this.increasefontbtn.AutoGenerateColors = false;
            this.increasefontbtn.AutoRoundBorders = false;
            this.increasefontbtn.AutoSizeLeftIcon = true;
            this.increasefontbtn.AutoSizeRightIcon = true;
            this.increasefontbtn.BackColor = System.Drawing.Color.Transparent;
            this.increasefontbtn.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.increasefontbtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("increasefontbtn.BackgroundImage")));
            this.increasefontbtn.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.increasefontbtn.ButtonText = "+";
            this.increasefontbtn.ButtonTextMarginLeft = 0;
            this.increasefontbtn.ColorContrastOnClick = 45;
            this.increasefontbtn.ColorContrastOnHover = 45;
            this.increasefontbtn.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges6.BottomLeft = true;
            borderEdges6.BottomRight = true;
            borderEdges6.TopLeft = true;
            borderEdges6.TopRight = true;
            this.increasefontbtn.CustomizableEdges = borderEdges6;
            this.increasefontbtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.increasefontbtn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.increasefontbtn.DisabledFillColor = System.Drawing.Color.Empty;
            this.increasefontbtn.DisabledForecolor = System.Drawing.Color.Empty;
            this.increasefontbtn.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.increasefontbtn.Font = new System.Drawing.Font("Microsoft PhagsPa", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.increasefontbtn.ForeColor = System.Drawing.Color.White;
            this.increasefontbtn.IconLeft = null;
            this.increasefontbtn.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.increasefontbtn.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.increasefontbtn.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.increasefontbtn.IconMarginLeft = 11;
            this.increasefontbtn.IconPadding = 10;
            this.increasefontbtn.IconRight = null;
            this.increasefontbtn.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.increasefontbtn.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.increasefontbtn.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.increasefontbtn.IconSize = 25;
            this.increasefontbtn.IdleBorderColor = System.Drawing.Color.Empty;
            this.increasefontbtn.IdleBorderRadius = 0;
            this.increasefontbtn.IdleBorderThickness = 0;
            this.increasefontbtn.IdleFillColor = System.Drawing.Color.Empty;
            this.increasefontbtn.IdleIconLeftImage = null;
            this.increasefontbtn.IdleIconRightImage = null;
            this.increasefontbtn.IndicateFocus = false;
            this.increasefontbtn.Location = new System.Drawing.Point(867, 625);
            this.increasefontbtn.Name = "increasefontbtn";
            this.increasefontbtn.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.increasefontbtn.OnDisabledState.BorderRadius = 15;
            this.increasefontbtn.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.increasefontbtn.OnDisabledState.BorderThickness = 2;
            this.increasefontbtn.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.increasefontbtn.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.increasefontbtn.OnDisabledState.IconLeftImage = null;
            this.increasefontbtn.OnDisabledState.IconRightImage = null;
            this.increasefontbtn.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.increasefontbtn.onHoverState.BorderRadius = 15;
            this.increasefontbtn.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.increasefontbtn.onHoverState.BorderThickness = 2;
            this.increasefontbtn.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.increasefontbtn.onHoverState.ForeColor = System.Drawing.Color.White;
            this.increasefontbtn.onHoverState.IconLeftImage = null;
            this.increasefontbtn.onHoverState.IconRightImage = null;
            this.increasefontbtn.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.increasefontbtn.OnIdleState.BorderRadius = 15;
            this.increasefontbtn.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.increasefontbtn.OnIdleState.BorderThickness = 2;
            this.increasefontbtn.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.increasefontbtn.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.increasefontbtn.OnIdleState.IconLeftImage = null;
            this.increasefontbtn.OnIdleState.IconRightImage = null;
            this.increasefontbtn.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.increasefontbtn.OnPressedState.BorderRadius = 15;
            this.increasefontbtn.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.increasefontbtn.OnPressedState.BorderThickness = 2;
            this.increasefontbtn.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.increasefontbtn.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.increasefontbtn.OnPressedState.IconLeftImage = null;
            this.increasefontbtn.OnPressedState.IconRightImage = null;
            this.increasefontbtn.Size = new System.Drawing.Size(30, 29);
            this.increasefontbtn.TabIndex = 55;
            this.increasefontbtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.increasefontbtn.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.increasefontbtn.TextMarginLeft = 0;
            this.increasefontbtn.TextPadding = new System.Windows.Forms.Padding(0);
            this.increasefontbtn.UseDefaultRadiusAndThickness = true;
            this.increasefontbtn.Click += new System.EventHandler(this.increasefontbtn_Click);
            // 
            // decreasefontbtn
            // 
            this.decreasefontbtn.AllowAnimations = true;
            this.decreasefontbtn.AllowMouseEffects = true;
            this.decreasefontbtn.AllowToggling = false;
            this.decreasefontbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.decreasefontbtn.AnimationSpeed = 200;
            this.decreasefontbtn.AutoGenerateColors = false;
            this.decreasefontbtn.AutoRoundBorders = false;
            this.decreasefontbtn.AutoSizeLeftIcon = true;
            this.decreasefontbtn.AutoSizeRightIcon = true;
            this.decreasefontbtn.BackColor = System.Drawing.Color.Transparent;
            this.decreasefontbtn.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.decreasefontbtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("decreasefontbtn.BackgroundImage")));
            this.decreasefontbtn.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.decreasefontbtn.ButtonText = "-";
            this.decreasefontbtn.ButtonTextMarginLeft = 0;
            this.decreasefontbtn.ColorContrastOnClick = 45;
            this.decreasefontbtn.ColorContrastOnHover = 45;
            this.decreasefontbtn.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges7.BottomLeft = true;
            borderEdges7.BottomRight = true;
            borderEdges7.TopLeft = true;
            borderEdges7.TopRight = true;
            this.decreasefontbtn.CustomizableEdges = borderEdges7;
            this.decreasefontbtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.decreasefontbtn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.decreasefontbtn.DisabledFillColor = System.Drawing.Color.Empty;
            this.decreasefontbtn.DisabledForecolor = System.Drawing.Color.Empty;
            this.decreasefontbtn.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.decreasefontbtn.Font = new System.Drawing.Font("Microsoft PhagsPa", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decreasefontbtn.ForeColor = System.Drawing.Color.White;
            this.decreasefontbtn.IconLeft = null;
            this.decreasefontbtn.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.decreasefontbtn.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.decreasefontbtn.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.decreasefontbtn.IconMarginLeft = 11;
            this.decreasefontbtn.IconPadding = 10;
            this.decreasefontbtn.IconRight = null;
            this.decreasefontbtn.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.decreasefontbtn.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.decreasefontbtn.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.decreasefontbtn.IconSize = 25;
            this.decreasefontbtn.IdleBorderColor = System.Drawing.Color.Empty;
            this.decreasefontbtn.IdleBorderRadius = 0;
            this.decreasefontbtn.IdleBorderThickness = 0;
            this.decreasefontbtn.IdleFillColor = System.Drawing.Color.Empty;
            this.decreasefontbtn.IdleIconLeftImage = null;
            this.decreasefontbtn.IdleIconRightImage = null;
            this.decreasefontbtn.IndicateFocus = false;
            this.decreasefontbtn.Location = new System.Drawing.Point(837, 625);
            this.decreasefontbtn.Name = "decreasefontbtn";
            this.decreasefontbtn.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.decreasefontbtn.OnDisabledState.BorderRadius = 15;
            this.decreasefontbtn.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.decreasefontbtn.OnDisabledState.BorderThickness = 2;
            this.decreasefontbtn.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.decreasefontbtn.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.decreasefontbtn.OnDisabledState.IconLeftImage = null;
            this.decreasefontbtn.OnDisabledState.IconRightImage = null;
            this.decreasefontbtn.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.decreasefontbtn.onHoverState.BorderRadius = 15;
            this.decreasefontbtn.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.decreasefontbtn.onHoverState.BorderThickness = 2;
            this.decreasefontbtn.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.decreasefontbtn.onHoverState.ForeColor = System.Drawing.Color.White;
            this.decreasefontbtn.onHoverState.IconLeftImage = null;
            this.decreasefontbtn.onHoverState.IconRightImage = null;
            this.decreasefontbtn.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.decreasefontbtn.OnIdleState.BorderRadius = 15;
            this.decreasefontbtn.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.decreasefontbtn.OnIdleState.BorderThickness = 2;
            this.decreasefontbtn.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.decreasefontbtn.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.decreasefontbtn.OnIdleState.IconLeftImage = null;
            this.decreasefontbtn.OnIdleState.IconRightImage = null;
            this.decreasefontbtn.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.decreasefontbtn.OnPressedState.BorderRadius = 15;
            this.decreasefontbtn.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.decreasefontbtn.OnPressedState.BorderThickness = 2;
            this.decreasefontbtn.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.decreasefontbtn.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.decreasefontbtn.OnPressedState.IconLeftImage = null;
            this.decreasefontbtn.OnPressedState.IconRightImage = null;
            this.decreasefontbtn.Size = new System.Drawing.Size(30, 29);
            this.decreasefontbtn.TabIndex = 54;
            this.decreasefontbtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.decreasefontbtn.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.decreasefontbtn.TextMarginLeft = 0;
            this.decreasefontbtn.TextPadding = new System.Windows.Forms.Padding(0);
            this.decreasefontbtn.UseDefaultRadiusAndThickness = true;
            this.decreasefontbtn.Click += new System.EventHandler(this.decreasefontbtn_Click);
            // 
            // minimizebtn
            // 
            this.minimizebtn.AllowAnimations = true;
            this.minimizebtn.AllowMouseEffects = true;
            this.minimizebtn.AllowToggling = false;
            this.minimizebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizebtn.AnimationSpeed = 200;
            this.minimizebtn.AutoGenerateColors = false;
            this.minimizebtn.AutoRoundBorders = false;
            this.minimizebtn.AutoSizeLeftIcon = true;
            this.minimizebtn.AutoSizeRightIcon = true;
            this.minimizebtn.BackColor = System.Drawing.Color.Transparent;
            this.minimizebtn.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.minimizebtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("minimizebtn.BackgroundImage")));
            this.minimizebtn.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.minimizebtn.ButtonText = "";
            this.minimizebtn.ButtonTextMarginLeft = 0;
            this.minimizebtn.ColorContrastOnClick = 45;
            this.minimizebtn.ColorContrastOnHover = 45;
            this.minimizebtn.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.minimizebtn.CustomizableEdges = borderEdges2;
            this.minimizebtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.minimizebtn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.minimizebtn.DisabledFillColor = System.Drawing.Color.Empty;
            this.minimizebtn.DisabledForecolor = System.Drawing.Color.Empty;
            this.minimizebtn.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.minimizebtn.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizebtn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.minimizebtn.IconLeft = global::ToolScope_for_EuroScope.Properties.Resources.compress;
            this.minimizebtn.IconLeftAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.minimizebtn.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.minimizebtn.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.minimizebtn.IconMarginLeft = 11;
            this.minimizebtn.IconPadding = 9;
            this.minimizebtn.IconRight = null;
            this.minimizebtn.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.minimizebtn.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.minimizebtn.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.minimizebtn.IconSize = 25;
            this.minimizebtn.IdleBorderColor = System.Drawing.Color.Empty;
            this.minimizebtn.IdleBorderRadius = 0;
            this.minimizebtn.IdleBorderThickness = 0;
            this.minimizebtn.IdleFillColor = System.Drawing.Color.Empty;
            this.minimizebtn.IdleIconLeftImage = global::ToolScope_for_EuroScope.Properties.Resources.compress;
            this.minimizebtn.IdleIconRightImage = null;
            this.minimizebtn.IndicateFocus = false;
            this.minimizebtn.Location = new System.Drawing.Point(1093, 5);
            this.minimizebtn.Name = "minimizebtn";
            this.minimizebtn.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.minimizebtn.OnDisabledState.BorderRadius = 22;
            this.minimizebtn.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.minimizebtn.OnDisabledState.BorderThickness = 2;
            this.minimizebtn.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.minimizebtn.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.minimizebtn.OnDisabledState.IconLeftImage = null;
            this.minimizebtn.OnDisabledState.IconRightImage = null;
            this.minimizebtn.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(161)))), ((int)(((byte)(44)))));
            this.minimizebtn.onHoverState.BorderRadius = 22;
            this.minimizebtn.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.minimizebtn.onHoverState.BorderThickness = 2;
            this.minimizebtn.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(161)))), ((int)(((byte)(44)))));
            this.minimizebtn.onHoverState.ForeColor = System.Drawing.Color.White;
            this.minimizebtn.onHoverState.IconLeftImage = null;
            this.minimizebtn.onHoverState.IconRightImage = null;
            this.minimizebtn.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(161)))), ((int)(((byte)(44)))));
            this.minimizebtn.OnIdleState.BorderRadius = 22;
            this.minimizebtn.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.minimizebtn.OnIdleState.BorderThickness = 2;
            this.minimizebtn.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(161)))), ((int)(((byte)(44)))));
            this.minimizebtn.OnIdleState.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.minimizebtn.OnIdleState.IconLeftImage = global::ToolScope_for_EuroScope.Properties.Resources.compress;
            this.minimizebtn.OnIdleState.IconRightImage = null;
            this.minimizebtn.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(161)))), ((int)(((byte)(44)))));
            this.minimizebtn.OnPressedState.BorderRadius = 22;
            this.minimizebtn.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.minimizebtn.OnPressedState.BorderThickness = 2;
            this.minimizebtn.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(161)))), ((int)(((byte)(44)))));
            this.minimizebtn.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.minimizebtn.OnPressedState.IconLeftImage = null;
            this.minimizebtn.OnPressedState.IconRightImage = null;
            this.minimizebtn.Size = new System.Drawing.Size(29, 29);
            this.minimizebtn.TabIndex = 57;
            this.minimizebtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.minimizebtn.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.minimizebtn.TextMarginLeft = 0;
            this.minimizebtn.TextPadding = new System.Windows.Forms.Padding(0);
            this.minimizebtn.UseDefaultRadiusAndThickness = true;
            this.minimizebtn.Click += new System.EventHandler(this.minimizebtn_Click);
            // 
            // closebtn
            // 
            this.closebtn.AllowAnimations = true;
            this.closebtn.AllowMouseEffects = true;
            this.closebtn.AllowToggling = false;
            this.closebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closebtn.AnimationSpeed = 200;
            this.closebtn.AutoGenerateColors = false;
            this.closebtn.AutoRoundBorders = false;
            this.closebtn.AutoSizeLeftIcon = true;
            this.closebtn.AutoSizeRightIcon = true;
            this.closebtn.BackColor = System.Drawing.Color.Transparent;
            this.closebtn.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.closebtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("closebtn.BackgroundImage")));
            this.closebtn.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.closebtn.ButtonText = "";
            this.closebtn.ButtonTextMarginLeft = 0;
            this.closebtn.ColorContrastOnClick = 45;
            this.closebtn.ColorContrastOnHover = 45;
            this.closebtn.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges3.BottomLeft = true;
            borderEdges3.BottomRight = true;
            borderEdges3.TopLeft = true;
            borderEdges3.TopRight = true;
            this.closebtn.CustomizableEdges = borderEdges3;
            this.closebtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.closebtn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.closebtn.DisabledFillColor = System.Drawing.Color.Empty;
            this.closebtn.DisabledForecolor = System.Drawing.Color.Empty;
            this.closebtn.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.closebtn.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closebtn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.closebtn.IconLeft = global::ToolScope_for_EuroScope.Properties.Resources.power_off;
            this.closebtn.IconLeftAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.closebtn.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.closebtn.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.closebtn.IconMarginLeft = 11;
            this.closebtn.IconPadding = 9;
            this.closebtn.IconRight = null;
            this.closebtn.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.closebtn.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.closebtn.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.closebtn.IconSize = 25;
            this.closebtn.IdleBorderColor = System.Drawing.Color.Empty;
            this.closebtn.IdleBorderRadius = 0;
            this.closebtn.IdleBorderThickness = 0;
            this.closebtn.IdleFillColor = System.Drawing.Color.Empty;
            this.closebtn.IdleIconLeftImage = global::ToolScope_for_EuroScope.Properties.Resources.power_off;
            this.closebtn.IdleIconRightImage = null;
            this.closebtn.IndicateFocus = false;
            this.closebtn.Location = new System.Drawing.Point(1124, 5);
            this.closebtn.Name = "closebtn";
            this.closebtn.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.closebtn.OnDisabledState.BorderRadius = 22;
            this.closebtn.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.closebtn.OnDisabledState.BorderThickness = 2;
            this.closebtn.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.closebtn.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.closebtn.OnDisabledState.IconLeftImage = null;
            this.closebtn.OnDisabledState.IconRightImage = null;
            this.closebtn.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.closebtn.onHoverState.BorderRadius = 22;
            this.closebtn.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.closebtn.onHoverState.BorderThickness = 2;
            this.closebtn.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.closebtn.onHoverState.ForeColor = System.Drawing.Color.White;
            this.closebtn.onHoverState.IconLeftImage = null;
            this.closebtn.onHoverState.IconRightImage = null;
            this.closebtn.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.closebtn.OnIdleState.BorderRadius = 22;
            this.closebtn.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.closebtn.OnIdleState.BorderThickness = 2;
            this.closebtn.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.closebtn.OnIdleState.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.closebtn.OnIdleState.IconLeftImage = global::ToolScope_for_EuroScope.Properties.Resources.power_off;
            this.closebtn.OnIdleState.IconRightImage = null;
            this.closebtn.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.closebtn.OnPressedState.BorderRadius = 22;
            this.closebtn.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.closebtn.OnPressedState.BorderThickness = 2;
            this.closebtn.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.closebtn.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.closebtn.OnPressedState.IconLeftImage = null;
            this.closebtn.OnPressedState.IconRightImage = null;
            this.closebtn.Size = new System.Drawing.Size(29, 29);
            this.closebtn.TabIndex = 56;
            this.closebtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.closebtn.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.closebtn.TextMarginLeft = 0;
            this.closebtn.TextPadding = new System.Windows.Forms.Padding(0);
            this.closebtn.UseDefaultRadiusAndThickness = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // maximizebtn
            // 
            this.maximizebtn.AllowAnimations = true;
            this.maximizebtn.AllowMouseEffects = true;
            this.maximizebtn.AllowToggling = false;
            this.maximizebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maximizebtn.AnimationSpeed = 200;
            this.maximizebtn.AutoGenerateColors = false;
            this.maximizebtn.AutoRoundBorders = false;
            this.maximizebtn.AutoSizeLeftIcon = true;
            this.maximizebtn.AutoSizeRightIcon = true;
            this.maximizebtn.BackColor = System.Drawing.Color.Transparent;
            this.maximizebtn.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.maximizebtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("maximizebtn.BackgroundImage")));
            this.maximizebtn.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.maximizebtn.ButtonText = "";
            this.maximizebtn.ButtonTextMarginLeft = 0;
            this.maximizebtn.ColorContrastOnClick = 45;
            this.maximizebtn.ColorContrastOnHover = 45;
            this.maximizebtn.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.maximizebtn.CustomizableEdges = borderEdges1;
            this.maximizebtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.maximizebtn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.maximizebtn.DisabledFillColor = System.Drawing.Color.Empty;
            this.maximizebtn.DisabledForecolor = System.Drawing.Color.Empty;
            this.maximizebtn.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.maximizebtn.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maximizebtn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.maximizebtn.IconLeft = global::ToolScope_for_EuroScope.Properties.Resources.expand;
            this.maximizebtn.IconLeftAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.maximizebtn.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.maximizebtn.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.maximizebtn.IconMarginLeft = 11;
            this.maximizebtn.IconPadding = 9;
            this.maximizebtn.IconRight = null;
            this.maximizebtn.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.maximizebtn.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.maximizebtn.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.maximizebtn.IconSize = 25;
            this.maximizebtn.IdleBorderColor = System.Drawing.Color.Empty;
            this.maximizebtn.IdleBorderRadius = 0;
            this.maximizebtn.IdleBorderThickness = 0;
            this.maximizebtn.IdleFillColor = System.Drawing.Color.Empty;
            this.maximizebtn.IdleIconLeftImage = global::ToolScope_for_EuroScope.Properties.Resources.expand;
            this.maximizebtn.IdleIconRightImage = null;
            this.maximizebtn.IndicateFocus = false;
            this.maximizebtn.Location = new System.Drawing.Point(1062, 5);
            this.maximizebtn.Name = "maximizebtn";
            this.maximizebtn.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.maximizebtn.OnDisabledState.BorderRadius = 22;
            this.maximizebtn.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.maximizebtn.OnDisabledState.BorderThickness = 2;
            this.maximizebtn.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.maximizebtn.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.maximizebtn.OnDisabledState.IconLeftImage = null;
            this.maximizebtn.OnDisabledState.IconRightImage = null;
            this.maximizebtn.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(189)))), ((int)(((byte)(111)))));
            this.maximizebtn.onHoverState.BorderRadius = 22;
            this.maximizebtn.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.maximizebtn.onHoverState.BorderThickness = 2;
            this.maximizebtn.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(189)))), ((int)(((byte)(111)))));
            this.maximizebtn.onHoverState.ForeColor = System.Drawing.Color.White;
            this.maximizebtn.onHoverState.IconLeftImage = null;
            this.maximizebtn.onHoverState.IconRightImage = null;
            this.maximizebtn.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(148)))), ((int)(((byte)(87)))));
            this.maximizebtn.OnIdleState.BorderRadius = 22;
            this.maximizebtn.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.maximizebtn.OnIdleState.BorderThickness = 2;
            this.maximizebtn.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(148)))), ((int)(((byte)(87)))));
            this.maximizebtn.OnIdleState.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.maximizebtn.OnIdleState.IconLeftImage = global::ToolScope_for_EuroScope.Properties.Resources.expand;
            this.maximizebtn.OnIdleState.IconRightImage = null;
            this.maximizebtn.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(189)))), ((int)(((byte)(111)))));
            this.maximizebtn.OnPressedState.BorderRadius = 22;
            this.maximizebtn.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.maximizebtn.OnPressedState.BorderThickness = 2;
            this.maximizebtn.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(189)))), ((int)(((byte)(111)))));
            this.maximizebtn.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.maximizebtn.OnPressedState.IconLeftImage = null;
            this.maximizebtn.OnPressedState.IconRightImage = null;
            this.maximizebtn.Size = new System.Drawing.Size(29, 29);
            this.maximizebtn.TabIndex = 58;
            this.maximizebtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.maximizebtn.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.maximizebtn.TextMarginLeft = 0;
            this.maximizebtn.TextPadding = new System.Windows.Forms.Padding(0);
            this.maximizebtn.UseDefaultRadiusAndThickness = true;
            this.maximizebtn.Click += new System.EventHandler(this.maximizebtn_Click);
            // 
            // PSEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(25)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(1162, 657);
            this.Controls.Add(this.maximizebtn);
            this.Controls.Add(this.minimizebtn);
            this.Controls.Add(this.closebtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.loadoldscriptbtn);
            this.Controls.Add(this.increasefontbtn);
            this.Controls.Add(this.decreasefontbtn);
            this.Controls.Add(this.codeeditor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PSEditor";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PSEditor";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private ScintillaNET.Scintilla codeeditor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton loadoldscriptbtn;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton savebtn;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton increasefontbtn;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton decreasefontbtn;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse3;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse4;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton maximizebtn;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton minimizebtn;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton closebtn;
    }
}