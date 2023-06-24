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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PSEditor));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges5 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges6 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges7 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges8 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.codeeditor = new ScintillaNET.Scintilla();
            this.pagenametxt = new System.Windows.Forms.Label();
            this.bunifuShadowPanel1 = new Bunifu.UI.WinForms.BunifuShadowPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse3 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuElipse4 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.maximizebtn = new FontAwesome.Sharp.IconButton();
            this.minimizebtn = new FontAwesome.Sharp.IconButton();
            this.closebtn = new FontAwesome.Sharp.IconButton();
            this.increasefontbtn = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.decreasefontbtn = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.savebtn = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.loadoldscriptbtn = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuShadowPanel1.SuspendLayout();
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
            this.codeeditor.Location = new System.Drawing.Point(1, 62);
            this.codeeditor.Name = "codeeditor";
            this.codeeditor.Size = new System.Drawing.Size(1158, 592);
            this.codeeditor.TabIndex = 48;
            this.codeeditor.CharAdded += new System.EventHandler<ScintillaNET.CharAddedEventArgs>(this.scintilla1_CharAdded);
            this.codeeditor.UpdateUI += new System.EventHandler<ScintillaNET.UpdateUIEventArgs>(this.scintilla1_UpdateUI);
            // 
            // pagenametxt
            // 
            this.pagenametxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(36)))));
            this.pagenametxt.Font = new System.Drawing.Font("Microsoft PhagsPa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagenametxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.pagenametxt.Location = new System.Drawing.Point(133, 13);
            this.pagenametxt.Name = "pagenametxt";
            this.pagenametxt.Size = new System.Drawing.Size(147, 21);
            this.pagenametxt.TabIndex = 49;
            this.pagenametxt.Text = "PowerShell Editor";
            this.pagenametxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bunifuShadowPanel1
            // 
            this.bunifuShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuShadowPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(191)))), ((int)(((byte)(0)))));
            this.bunifuShadowPanel1.BorderRadius = 20;
            this.bunifuShadowPanel1.BorderThickness = 1;
            this.bunifuShadowPanel1.Controls.Add(this.pagenametxt);
            this.bunifuShadowPanel1.Controls.Add(this.label2);
            this.bunifuShadowPanel1.Controls.Add(this.savebtn);
            this.bunifuShadowPanel1.Controls.Add(this.loadoldscriptbtn);
            this.bunifuShadowPanel1.Controls.Add(this.pictureBox1);
            this.bunifuShadowPanel1.FillStyle = Bunifu.UI.WinForms.BunifuShadowPanel.FillStyles.Solid;
            this.bunifuShadowPanel1.GradientMode = Bunifu.UI.WinForms.BunifuShadowPanel.GradientModes.Vertical;
            this.bunifuShadowPanel1.Location = new System.Drawing.Point(12, 2);
            this.bunifuShadowPanel1.Name = "bunifuShadowPanel1";
            this.bunifuShadowPanel1.PanelColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(36)))));
            this.bunifuShadowPanel1.PanelColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(36)))));
            this.bunifuShadowPanel1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(36)))));
            this.bunifuShadowPanel1.ShadowDept = 2;
            this.bunifuShadowPanel1.ShadowDepth = 3;
            this.bunifuShadowPanel1.ShadowStyle = Bunifu.UI.WinForms.BunifuShadowPanel.ShadowStyles.Dropped;
            this.bunifuShadowPanel1.ShadowTopLeftVisible = false;
            this.bunifuShadowPanel1.Size = new System.Drawing.Size(589, 54);
            this.bunifuShadowPanel1.Style = Bunifu.UI.WinForms.BunifuShadowPanel.BevelStyles.Raised;
            this.bunifuShadowPanel1.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(36)))));
            this.label2.Font = new System.Drawing.Font("Microsoft PhagsPa", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(22, 30);
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
            this.bunifuElipse2.TargetControl = this.maximizebtn;
            // 
            // bunifuElipse3
            // 
            this.bunifuElipse3.ElipseRadius = 50;
            this.bunifuElipse3.TargetControl = this.closebtn;
            // 
            // bunifuElipse4
            // 
            this.bunifuElipse4.ElipseRadius = 50;
            this.bunifuElipse4.TargetControl = this.minimizebtn;
            // 
            // maximizebtn
            // 
            this.maximizebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maximizebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(36)))));
            this.maximizebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maximizebtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(25)))), ((int)(((byte)(26)))));
            this.maximizebtn.IconChar = FontAwesome.Sharp.IconChar.Expand;
            this.maximizebtn.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(219)))), ((int)(((byte)(143)))));
            this.maximizebtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.maximizebtn.IconSize = 18;
            this.maximizebtn.Location = new System.Drawing.Point(1091, 7);
            this.maximizebtn.Name = "maximizebtn";
            this.maximizebtn.Size = new System.Drawing.Size(31, 32);
            this.maximizebtn.TabIndex = 66;
            this.maximizebtn.UseVisualStyleBackColor = false;
            this.maximizebtn.Click += new System.EventHandler(this.maximizebtn_Click);
            // 
            // minimizebtn
            // 
            this.minimizebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(36)))));
            this.minimizebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizebtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(25)))), ((int)(((byte)(26)))));
            this.minimizebtn.IconChar = FontAwesome.Sharp.IconChar.Compress;
            this.minimizebtn.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(233)))), ((int)(((byte)(171)))));
            this.minimizebtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.minimizebtn.IconSize = 18;
            this.minimizebtn.Location = new System.Drawing.Point(1054, 7);
            this.minimizebtn.Name = "minimizebtn";
            this.minimizebtn.Size = new System.Drawing.Size(31, 32);
            this.minimizebtn.TabIndex = 65;
            this.minimizebtn.UseVisualStyleBackColor = false;
            this.minimizebtn.Click += new System.EventHandler(this.minimizebtn_Click);
            // 
            // closebtn
            // 
            this.closebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(36)))));
            this.closebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closebtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(25)))), ((int)(((byte)(26)))));
            this.closebtn.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            this.closebtn.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(171)))), ((int)(((byte)(171)))));
            this.closebtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.closebtn.IconSize = 18;
            this.closebtn.Location = new System.Drawing.Point(1128, 7);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(31, 32);
            this.closebtn.TabIndex = 64;
            this.closebtn.UseVisualStyleBackColor = false;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // increasefontbtn
            // 
            this.increasefontbtn.AllowAnimations = true;
            this.increasefontbtn.AllowMouseEffects = true;
            this.increasefontbtn.AllowToggling = false;
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
            borderEdges5.BottomLeft = true;
            borderEdges5.BottomRight = true;
            borderEdges5.TopLeft = true;
            borderEdges5.TopRight = true;
            this.increasefontbtn.CustomizableEdges = borderEdges5;
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
            this.increasefontbtn.Location = new System.Drawing.Point(637, 13);
            this.increasefontbtn.Name = "increasefontbtn";
            this.increasefontbtn.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.increasefontbtn.OnDisabledState.BorderRadius = 15;
            this.increasefontbtn.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.increasefontbtn.OnDisabledState.BorderThickness = 2;
            this.increasefontbtn.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.increasefontbtn.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.increasefontbtn.OnDisabledState.IconLeftImage = null;
            this.increasefontbtn.OnDisabledState.IconRightImage = null;
            this.increasefontbtn.onHoverState.BorderColor = System.Drawing.Color.DarkGray;
            this.increasefontbtn.onHoverState.BorderRadius = 15;
            this.increasefontbtn.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.increasefontbtn.onHoverState.BorderThickness = 2;
            this.increasefontbtn.onHoverState.FillColor = System.Drawing.Color.Gray;
            this.increasefontbtn.onHoverState.ForeColor = System.Drawing.Color.White;
            this.increasefontbtn.onHoverState.IconLeftImage = null;
            this.increasefontbtn.onHoverState.IconRightImage = null;
            this.increasefontbtn.OnIdleState.BorderColor = System.Drawing.Color.DarkGray;
            this.increasefontbtn.OnIdleState.BorderRadius = 15;
            this.increasefontbtn.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.increasefontbtn.OnIdleState.BorderThickness = 2;
            this.increasefontbtn.OnIdleState.FillColor = System.Drawing.Color.Gray;
            this.increasefontbtn.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.increasefontbtn.OnIdleState.IconLeftImage = null;
            this.increasefontbtn.OnIdleState.IconRightImage = null;
            this.increasefontbtn.OnPressedState.BorderColor = System.Drawing.Color.DarkGray;
            this.increasefontbtn.OnPressedState.BorderRadius = 15;
            this.increasefontbtn.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.increasefontbtn.OnPressedState.BorderThickness = 2;
            this.increasefontbtn.OnPressedState.FillColor = System.Drawing.Color.Gray;
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
            borderEdges6.BottomLeft = true;
            borderEdges6.BottomRight = true;
            borderEdges6.TopLeft = true;
            borderEdges6.TopRight = true;
            this.decreasefontbtn.CustomizableEdges = borderEdges6;
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
            this.decreasefontbtn.Location = new System.Drawing.Point(607, 13);
            this.decreasefontbtn.Name = "decreasefontbtn";
            this.decreasefontbtn.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.decreasefontbtn.OnDisabledState.BorderRadius = 15;
            this.decreasefontbtn.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.decreasefontbtn.OnDisabledState.BorderThickness = 2;
            this.decreasefontbtn.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.decreasefontbtn.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.decreasefontbtn.OnDisabledState.IconLeftImage = null;
            this.decreasefontbtn.OnDisabledState.IconRightImage = null;
            this.decreasefontbtn.onHoverState.BorderColor = System.Drawing.Color.DarkGray;
            this.decreasefontbtn.onHoverState.BorderRadius = 15;
            this.decreasefontbtn.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.decreasefontbtn.onHoverState.BorderThickness = 2;
            this.decreasefontbtn.onHoverState.FillColor = System.Drawing.Color.Gray;
            this.decreasefontbtn.onHoverState.ForeColor = System.Drawing.Color.White;
            this.decreasefontbtn.onHoverState.IconLeftImage = null;
            this.decreasefontbtn.onHoverState.IconRightImage = null;
            this.decreasefontbtn.OnIdleState.BorderColor = System.Drawing.Color.DarkGray;
            this.decreasefontbtn.OnIdleState.BorderRadius = 15;
            this.decreasefontbtn.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.decreasefontbtn.OnIdleState.BorderThickness = 2;
            this.decreasefontbtn.OnIdleState.FillColor = System.Drawing.Color.Gray;
            this.decreasefontbtn.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.decreasefontbtn.OnIdleState.IconLeftImage = null;
            this.decreasefontbtn.OnIdleState.IconRightImage = null;
            this.decreasefontbtn.OnPressedState.BorderColor = System.Drawing.Color.DarkGray;
            this.decreasefontbtn.OnPressedState.BorderRadius = 15;
            this.decreasefontbtn.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.decreasefontbtn.OnPressedState.BorderThickness = 2;
            this.decreasefontbtn.OnPressedState.FillColor = System.Drawing.Color.Gray;
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
            // savebtn
            // 
            this.savebtn.AllowAnimations = true;
            this.savebtn.AllowMouseEffects = true;
            this.savebtn.AllowToggling = false;
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
            borderEdges7.BottomLeft = true;
            borderEdges7.BottomRight = true;
            borderEdges7.TopLeft = true;
            borderEdges7.TopRight = true;
            this.savebtn.CustomizableEdges = borderEdges7;
            this.savebtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.savebtn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.savebtn.DisabledFillColor = System.Drawing.Color.Empty;
            this.savebtn.DisabledForecolor = System.Drawing.Color.Empty;
            this.savebtn.Enabled = false;
            this.savebtn.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.savebtn.Font = new System.Drawing.Font("Microsoft PhagsPa", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savebtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(252)))), ((int)(((byte)(159)))));
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
            this.savebtn.Location = new System.Drawing.Point(296, 10);
            this.savebtn.Name = "savebtn";
            this.savebtn.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.savebtn.OnDisabledState.BorderRadius = 15;
            this.savebtn.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.savebtn.OnDisabledState.BorderThickness = 2;
            this.savebtn.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.savebtn.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.savebtn.OnDisabledState.IconLeftImage = null;
            this.savebtn.OnDisabledState.IconRightImage = null;
            this.savebtn.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.savebtn.onHoverState.BorderRadius = 15;
            this.savebtn.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.savebtn.onHoverState.BorderThickness = 2;
            this.savebtn.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(87)))), ((int)(((byte)(28)))));
            this.savebtn.onHoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(252)))), ((int)(((byte)(159)))));
            this.savebtn.onHoverState.IconLeftImage = null;
            this.savebtn.onHoverState.IconRightImage = null;
            this.savebtn.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(207)))), ((int)(((byte)(6)))));
            this.savebtn.OnIdleState.BorderRadius = 15;
            this.savebtn.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.savebtn.OnIdleState.BorderThickness = 2;
            this.savebtn.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(64)))), ((int)(((byte)(22)))));
            this.savebtn.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(252)))), ((int)(((byte)(159)))));
            this.savebtn.OnIdleState.IconLeftImage = null;
            this.savebtn.OnIdleState.IconRightImage = null;
            this.savebtn.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(207)))), ((int)(((byte)(6)))));
            this.savebtn.OnPressedState.BorderRadius = 15;
            this.savebtn.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.savebtn.OnPressedState.BorderThickness = 2;
            this.savebtn.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(64)))), ((int)(((byte)(22)))));
            this.savebtn.OnPressedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(252)))), ((int)(((byte)(159)))));
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
            borderEdges8.BottomLeft = true;
            borderEdges8.BottomRight = true;
            borderEdges8.TopLeft = true;
            borderEdges8.TopRight = true;
            this.loadoldscriptbtn.CustomizableEdges = borderEdges8;
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
            this.loadoldscriptbtn.Location = new System.Drawing.Point(367, 10);
            this.loadoldscriptbtn.Name = "loadoldscriptbtn";
            this.loadoldscriptbtn.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.loadoldscriptbtn.OnDisabledState.BorderRadius = 15;
            this.loadoldscriptbtn.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.loadoldscriptbtn.OnDisabledState.BorderThickness = 2;
            this.loadoldscriptbtn.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.loadoldscriptbtn.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.loadoldscriptbtn.OnDisabledState.IconLeftImage = null;
            this.loadoldscriptbtn.OnDisabledState.IconRightImage = null;
            this.loadoldscriptbtn.onHoverState.BorderColor = System.Drawing.Color.DarkGray;
            this.loadoldscriptbtn.onHoverState.BorderRadius = 15;
            this.loadoldscriptbtn.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.loadoldscriptbtn.onHoverState.BorderThickness = 2;
            this.loadoldscriptbtn.onHoverState.FillColor = System.Drawing.Color.Gray;
            this.loadoldscriptbtn.onHoverState.ForeColor = System.Drawing.Color.White;
            this.loadoldscriptbtn.onHoverState.IconLeftImage = null;
            this.loadoldscriptbtn.onHoverState.IconRightImage = null;
            this.loadoldscriptbtn.OnIdleState.BorderColor = System.Drawing.Color.DarkGray;
            this.loadoldscriptbtn.OnIdleState.BorderRadius = 15;
            this.loadoldscriptbtn.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.loadoldscriptbtn.OnIdleState.BorderThickness = 2;
            this.loadoldscriptbtn.OnIdleState.FillColor = System.Drawing.Color.Gray;
            this.loadoldscriptbtn.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.loadoldscriptbtn.OnIdleState.IconLeftImage = null;
            this.loadoldscriptbtn.OnIdleState.IconRightImage = null;
            this.loadoldscriptbtn.OnPressedState.BorderColor = System.Drawing.Color.DarkGray;
            this.loadoldscriptbtn.OnPressedState.BorderRadius = 15;
            this.loadoldscriptbtn.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.loadoldscriptbtn.OnPressedState.BorderThickness = 2;
            this.loadoldscriptbtn.OnPressedState.FillColor = System.Drawing.Color.Gray;
            this.loadoldscriptbtn.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.loadoldscriptbtn.OnPressedState.IconLeftImage = null;
            this.loadoldscriptbtn.OnPressedState.IconRightImage = null;
            this.loadoldscriptbtn.Size = new System.Drawing.Size(204, 29);
            this.loadoldscriptbtn.TabIndex = 53;
            this.loadoldscriptbtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.loadoldscriptbtn.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.loadoldscriptbtn.TextMarginLeft = 0;
            this.loadoldscriptbtn.TextPadding = new System.Windows.Forms.Padding(0);
            this.loadoldscriptbtn.UseDefaultRadiusAndThickness = true;
            this.loadoldscriptbtn.Click += new System.EventHandler(this.loadoldscriptbtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(36)))));
            this.pictureBox1.BackgroundImage = global::ToolScope_for_EuroScope.Properties.Resources.ToolScope_Banner;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::ToolScope_for_EuroScope.Properties.Resources.ToolScope_Banner;
            this.pictureBox1.Location = new System.Drawing.Point(22, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(93, 32);
            this.pictureBox1.TabIndex = 49;
            this.pictureBox1.TabStop = false;
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
            this.Controls.Add(this.increasefontbtn);
            this.Controls.Add(this.decreasefontbtn);
            this.Controls.Add(this.bunifuShadowPanel1);
            this.Controls.Add(this.codeeditor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PSEditor";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PSEditor";
            this.bunifuShadowPanel1.ResumeLayout(false);
            this.bunifuShadowPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private ScintillaNET.Scintilla codeeditor;
        private System.Windows.Forms.Label pagenametxt;
        private Bunifu.UI.WinForms.BunifuShadowPanel bunifuShadowPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton loadoldscriptbtn;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton savebtn;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton increasefontbtn;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton decreasefontbtn;
        private FontAwesome.Sharp.IconButton minimizebtn;
        private FontAwesome.Sharp.IconButton closebtn;
        private FontAwesome.Sharp.IconButton maximizebtn;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse3;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse4;
    }
}