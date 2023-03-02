namespace ToolScope_for_EuroScope
{
    partial class main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges4 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.controlbar = new Bunifu.UI.WinForms.BunifuPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.minimizebtn = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.closebtn = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.airacsettingsbtn = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuButton1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.notifytxt = new System.Windows.Forms.Label();
            this.bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.notifytimer = new System.Windows.Forms.Timer(this.components);
            this.packagebox = new Bunifu.UI.WinForms.BunifuDropdown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.regionbox = new Bunifu.UI.WinForms.BunifuDropdown();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.airactxt = new System.Windows.Forms.Label();
            this.releasetxt = new System.Windows.Forms.Label();
            this.controlbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlbar
            // 
            this.controlbar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.controlbar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("controlbar.BackgroundImage")));
            this.controlbar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.controlbar.BorderColor = System.Drawing.Color.Transparent;
            this.controlbar.BorderRadius = 0;
            this.controlbar.BorderThickness = 0;
            this.controlbar.Controls.Add(this.notifytxt);
            this.controlbar.Controls.Add(this.label2);
            this.controlbar.Controls.Add(this.label1);
            this.controlbar.Controls.Add(this.minimizebtn);
            this.controlbar.Controls.Add(this.closebtn);
            this.controlbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlbar.Location = new System.Drawing.Point(0, 0);
            this.controlbar.Name = "controlbar";
            this.controlbar.ShowBorders = false;
            this.controlbar.Size = new System.Drawing.Size(601, 31);
            this.controlbar.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.label2.Font = new System.Drawing.Font("Microsoft PhagsPa", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(78, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "for EuroScope";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.label1.Font = new System.Drawing.Font("Microsoft PhagsPa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "ToolScope";
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
            this.minimizebtn.ButtonText = "_";
            this.minimizebtn.ButtonTextMarginLeft = 0;
            this.minimizebtn.ColorContrastOnClick = 45;
            this.minimizebtn.ColorContrastOnHover = 45;
            this.minimizebtn.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.minimizebtn.CustomizableEdges = borderEdges1;
            this.minimizebtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.minimizebtn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.minimizebtn.DisabledFillColor = System.Drawing.Color.Empty;
            this.minimizebtn.DisabledForecolor = System.Drawing.Color.Empty;
            this.minimizebtn.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.minimizebtn.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizebtn.ForeColor = System.Drawing.Color.White;
            this.minimizebtn.IconLeft = null;
            this.minimizebtn.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.minimizebtn.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.minimizebtn.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.minimizebtn.IconMarginLeft = 11;
            this.minimizebtn.IconPadding = 10;
            this.minimizebtn.IconRight = null;
            this.minimizebtn.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.minimizebtn.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.minimizebtn.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.minimizebtn.IconSize = 25;
            this.minimizebtn.IdleBorderColor = System.Drawing.Color.Empty;
            this.minimizebtn.IdleBorderRadius = 0;
            this.minimizebtn.IdleBorderThickness = 0;
            this.minimizebtn.IdleFillColor = System.Drawing.Color.Empty;
            this.minimizebtn.IdleIconLeftImage = null;
            this.minimizebtn.IdleIconRightImage = null;
            this.minimizebtn.IndicateFocus = false;
            this.minimizebtn.Location = new System.Drawing.Point(539, 0);
            this.minimizebtn.Name = "minimizebtn";
            this.minimizebtn.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.minimizebtn.OnDisabledState.BorderRadius = 0;
            this.minimizebtn.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.minimizebtn.OnDisabledState.BorderThickness = 1;
            this.minimizebtn.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.minimizebtn.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.minimizebtn.OnDisabledState.IconLeftImage = null;
            this.minimizebtn.OnDisabledState.IconRightImage = null;
            this.minimizebtn.onHoverState.BorderColor = System.Drawing.Color.Gray;
            this.minimizebtn.onHoverState.BorderRadius = 0;
            this.minimizebtn.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.minimizebtn.onHoverState.BorderThickness = 1;
            this.minimizebtn.onHoverState.FillColor = System.Drawing.Color.Gray;
            this.minimizebtn.onHoverState.ForeColor = System.Drawing.Color.White;
            this.minimizebtn.onHoverState.IconLeftImage = null;
            this.minimizebtn.onHoverState.IconRightImage = null;
            this.minimizebtn.OnIdleState.BorderColor = System.Drawing.Color.Gray;
            this.minimizebtn.OnIdleState.BorderRadius = 0;
            this.minimizebtn.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.minimizebtn.OnIdleState.BorderThickness = 1;
            this.minimizebtn.OnIdleState.FillColor = System.Drawing.Color.Gray;
            this.minimizebtn.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.minimizebtn.OnIdleState.IconLeftImage = null;
            this.minimizebtn.OnIdleState.IconRightImage = null;
            this.minimizebtn.OnPressedState.BorderColor = System.Drawing.Color.Gray;
            this.minimizebtn.OnPressedState.BorderRadius = 0;
            this.minimizebtn.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.minimizebtn.OnPressedState.BorderThickness = 1;
            this.minimizebtn.OnPressedState.FillColor = System.Drawing.Color.Gray;
            this.minimizebtn.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.minimizebtn.OnPressedState.IconLeftImage = null;
            this.minimizebtn.OnPressedState.IconRightImage = null;
            this.minimizebtn.Size = new System.Drawing.Size(31, 31);
            this.minimizebtn.TabIndex = 1;
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
            this.closebtn.ButtonText = "X";
            this.closebtn.ButtonTextMarginLeft = 0;
            this.closebtn.ColorContrastOnClick = 45;
            this.closebtn.ColorContrastOnHover = 45;
            this.closebtn.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.closebtn.CustomizableEdges = borderEdges2;
            this.closebtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.closebtn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.closebtn.DisabledFillColor = System.Drawing.Color.Empty;
            this.closebtn.DisabledForecolor = System.Drawing.Color.Empty;
            this.closebtn.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.closebtn.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closebtn.ForeColor = System.Drawing.Color.White;
            this.closebtn.IconLeft = null;
            this.closebtn.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.closebtn.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.closebtn.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.closebtn.IconMarginLeft = 11;
            this.closebtn.IconPadding = 10;
            this.closebtn.IconRight = null;
            this.closebtn.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.closebtn.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.closebtn.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.closebtn.IconSize = 25;
            this.closebtn.IdleBorderColor = System.Drawing.Color.Empty;
            this.closebtn.IdleBorderRadius = 0;
            this.closebtn.IdleBorderThickness = 0;
            this.closebtn.IdleFillColor = System.Drawing.Color.Empty;
            this.closebtn.IdleIconLeftImage = null;
            this.closebtn.IdleIconRightImage = null;
            this.closebtn.IndicateFocus = false;
            this.closebtn.Location = new System.Drawing.Point(570, 0);
            this.closebtn.Name = "closebtn";
            this.closebtn.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.closebtn.OnDisabledState.BorderRadius = 0;
            this.closebtn.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.closebtn.OnDisabledState.BorderThickness = 1;
            this.closebtn.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.closebtn.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.closebtn.OnDisabledState.IconLeftImage = null;
            this.closebtn.OnDisabledState.IconRightImage = null;
            this.closebtn.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.closebtn.onHoverState.BorderRadius = 0;
            this.closebtn.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.closebtn.onHoverState.BorderThickness = 1;
            this.closebtn.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.closebtn.onHoverState.ForeColor = System.Drawing.Color.White;
            this.closebtn.onHoverState.IconLeftImage = null;
            this.closebtn.onHoverState.IconRightImage = null;
            this.closebtn.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.closebtn.OnIdleState.BorderRadius = 0;
            this.closebtn.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.closebtn.OnIdleState.BorderThickness = 1;
            this.closebtn.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.closebtn.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.closebtn.OnIdleState.IconLeftImage = null;
            this.closebtn.OnIdleState.IconRightImage = null;
            this.closebtn.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.closebtn.OnPressedState.BorderRadius = 0;
            this.closebtn.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.closebtn.OnPressedState.BorderThickness = 1;
            this.closebtn.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.closebtn.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.closebtn.OnPressedState.IconLeftImage = null;
            this.closebtn.OnPressedState.IconRightImage = null;
            this.closebtn.Size = new System.Drawing.Size(31, 31);
            this.closebtn.TabIndex = 0;
            this.closebtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.closebtn.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.closebtn.TextMarginLeft = 0;
            this.closebtn.TextPadding = new System.Windows.Forms.Padding(0);
            this.closebtn.UseDefaultRadiusAndThickness = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // bunifuPanel1
            // 
            this.bunifuPanel1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(0)))));
            this.bunifuPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel1.BackgroundImage")));
            this.bunifuPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuPanel1.BorderRadius = 3;
            this.bunifuPanel1.BorderThickness = 0;
            this.bunifuPanel1.Location = new System.Drawing.Point(-3, 29);
            this.bunifuPanel1.Name = "bunifuPanel1";
            this.bunifuPanel1.ShowBorders = false;
            this.bunifuPanel1.Size = new System.Drawing.Size(807, 3);
            this.bunifuPanel1.TabIndex = 2;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.controlbar;
            this.bunifuDragControl1.Vertical = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label3.Font = new System.Drawing.Font("Microsoft PhagsPa", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(168, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "AIRAC Updater";
            // 
            // airacsettingsbtn
            // 
            this.airacsettingsbtn.AllowAnimations = true;
            this.airacsettingsbtn.AllowMouseEffects = true;
            this.airacsettingsbtn.AllowToggling = false;
            this.airacsettingsbtn.AnimationSpeed = 200;
            this.airacsettingsbtn.AutoGenerateColors = false;
            this.airacsettingsbtn.AutoRoundBorders = false;
            this.airacsettingsbtn.AutoSizeLeftIcon = true;
            this.airacsettingsbtn.AutoSizeRightIcon = true;
            this.airacsettingsbtn.BackColor = System.Drawing.Color.Transparent;
            this.airacsettingsbtn.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.airacsettingsbtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("airacsettingsbtn.BackgroundImage")));
            this.airacsettingsbtn.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.airacsettingsbtn.ButtonText = "Updater Settings";
            this.airacsettingsbtn.ButtonTextMarginLeft = 0;
            this.airacsettingsbtn.ColorContrastOnClick = 45;
            this.airacsettingsbtn.ColorContrastOnHover = 45;
            this.airacsettingsbtn.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges3.BottomLeft = true;
            borderEdges3.BottomRight = true;
            borderEdges3.TopLeft = true;
            borderEdges3.TopRight = true;
            this.airacsettingsbtn.CustomizableEdges = borderEdges3;
            this.airacsettingsbtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.airacsettingsbtn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.airacsettingsbtn.DisabledFillColor = System.Drawing.Color.Empty;
            this.airacsettingsbtn.DisabledForecolor = System.Drawing.Color.Empty;
            this.airacsettingsbtn.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.airacsettingsbtn.Font = new System.Drawing.Font("Microsoft PhagsPa", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.airacsettingsbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(240)))), ((int)(((byte)(159)))));
            this.airacsettingsbtn.IconLeft = null;
            this.airacsettingsbtn.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.airacsettingsbtn.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.airacsettingsbtn.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.airacsettingsbtn.IconMarginLeft = 11;
            this.airacsettingsbtn.IconPadding = 10;
            this.airacsettingsbtn.IconRight = null;
            this.airacsettingsbtn.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.airacsettingsbtn.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.airacsettingsbtn.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.airacsettingsbtn.IconSize = 25;
            this.airacsettingsbtn.IdleBorderColor = System.Drawing.Color.Empty;
            this.airacsettingsbtn.IdleBorderRadius = 0;
            this.airacsettingsbtn.IdleBorderThickness = 0;
            this.airacsettingsbtn.IdleFillColor = System.Drawing.Color.Empty;
            this.airacsettingsbtn.IdleIconLeftImage = null;
            this.airacsettingsbtn.IdleIconRightImage = null;
            this.airacsettingsbtn.IndicateFocus = false;
            this.airacsettingsbtn.Location = new System.Drawing.Point(315, 173);
            this.airacsettingsbtn.Name = "airacsettingsbtn";
            this.airacsettingsbtn.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.airacsettingsbtn.OnDisabledState.BorderRadius = 1;
            this.airacsettingsbtn.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.airacsettingsbtn.OnDisabledState.BorderThickness = 2;
            this.airacsettingsbtn.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.airacsettingsbtn.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.airacsettingsbtn.OnDisabledState.IconLeftImage = null;
            this.airacsettingsbtn.OnDisabledState.IconRightImage = null;
            this.airacsettingsbtn.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(222)))), ((int)(((byte)(0)))));
            this.airacsettingsbtn.onHoverState.BorderRadius = 1;
            this.airacsettingsbtn.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.airacsettingsbtn.onHoverState.BorderThickness = 2;
            this.airacsettingsbtn.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(71)))), ((int)(((byte)(28)))));
            this.airacsettingsbtn.onHoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(240)))), ((int)(((byte)(159)))));
            this.airacsettingsbtn.onHoverState.IconLeftImage = null;
            this.airacsettingsbtn.onHoverState.IconRightImage = null;
            this.airacsettingsbtn.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(181)))), ((int)(((byte)(6)))));
            this.airacsettingsbtn.OnIdleState.BorderRadius = 1;
            this.airacsettingsbtn.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.airacsettingsbtn.OnIdleState.BorderThickness = 2;
            this.airacsettingsbtn.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(53)))), ((int)(((byte)(22)))));
            this.airacsettingsbtn.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(240)))), ((int)(((byte)(159)))));
            this.airacsettingsbtn.OnIdleState.IconLeftImage = null;
            this.airacsettingsbtn.OnIdleState.IconRightImage = null;
            this.airacsettingsbtn.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(181)))), ((int)(((byte)(6)))));
            this.airacsettingsbtn.OnPressedState.BorderRadius = 1;
            this.airacsettingsbtn.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.airacsettingsbtn.OnPressedState.BorderThickness = 2;
            this.airacsettingsbtn.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(53)))), ((int)(((byte)(22)))));
            this.airacsettingsbtn.OnPressedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(240)))), ((int)(((byte)(159)))));
            this.airacsettingsbtn.OnPressedState.IconLeftImage = null;
            this.airacsettingsbtn.OnPressedState.IconRightImage = null;
            this.airacsettingsbtn.Size = new System.Drawing.Size(128, 29);
            this.airacsettingsbtn.TabIndex = 5;
            this.airacsettingsbtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.airacsettingsbtn.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.airacsettingsbtn.TextMarginLeft = 0;
            this.airacsettingsbtn.TextPadding = new System.Windows.Forms.Padding(0);
            this.airacsettingsbtn.UseDefaultRadiusAndThickness = true;
            this.airacsettingsbtn.Click += new System.EventHandler(this.airacsettingsbtn_Click);
            // 
            // bunifuButton1
            // 
            this.bunifuButton1.AllowAnimations = true;
            this.bunifuButton1.AllowMouseEffects = true;
            this.bunifuButton1.AllowToggling = false;
            this.bunifuButton1.AnimationSpeed = 200;
            this.bunifuButton1.AutoGenerateColors = false;
            this.bunifuButton1.AutoRoundBorders = false;
            this.bunifuButton1.AutoSizeLeftIcon = true;
            this.bunifuButton1.AutoSizeRightIcon = true;
            this.bunifuButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuButton1.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.bunifuButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton1.BackgroundImage")));
            this.bunifuButton1.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton1.ButtonText = "Update AIRAC";
            this.bunifuButton1.ButtonTextMarginLeft = 0;
            this.bunifuButton1.ColorContrastOnClick = 45;
            this.bunifuButton1.ColorContrastOnHover = 45;
            this.bunifuButton1.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges4.BottomLeft = true;
            borderEdges4.BottomRight = true;
            borderEdges4.TopLeft = true;
            borderEdges4.TopRight = true;
            this.bunifuButton1.CustomizableEdges = borderEdges4;
            this.bunifuButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bunifuButton1.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.bunifuButton1.DisabledFillColor = System.Drawing.Color.Empty;
            this.bunifuButton1.DisabledForecolor = System.Drawing.Color.Empty;
            this.bunifuButton1.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.bunifuButton1.Font = new System.Drawing.Font("Microsoft PhagsPa", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(252)))), ((int)(((byte)(159)))));
            this.bunifuButton1.IconLeft = null;
            this.bunifuButton1.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuButton1.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.bunifuButton1.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.bunifuButton1.IconMarginLeft = 11;
            this.bunifuButton1.IconPadding = 10;
            this.bunifuButton1.IconRight = null;
            this.bunifuButton1.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bunifuButton1.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.bunifuButton1.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.bunifuButton1.IconSize = 25;
            this.bunifuButton1.IdleBorderColor = System.Drawing.Color.Empty;
            this.bunifuButton1.IdleBorderRadius = 0;
            this.bunifuButton1.IdleBorderThickness = 0;
            this.bunifuButton1.IdleFillColor = System.Drawing.Color.Empty;
            this.bunifuButton1.IdleIconLeftImage = null;
            this.bunifuButton1.IdleIconRightImage = null;
            this.bunifuButton1.IndicateFocus = false;
            this.bunifuButton1.Location = new System.Drawing.Point(181, 173);
            this.bunifuButton1.Name = "bunifuButton1";
            this.bunifuButton1.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.bunifuButton1.OnDisabledState.BorderRadius = 1;
            this.bunifuButton1.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton1.OnDisabledState.BorderThickness = 2;
            this.bunifuButton1.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bunifuButton1.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.bunifuButton1.OnDisabledState.IconLeftImage = null;
            this.bunifuButton1.OnDisabledState.IconRightImage = null;
            this.bunifuButton1.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.bunifuButton1.onHoverState.BorderRadius = 1;
            this.bunifuButton1.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton1.onHoverState.BorderThickness = 2;
            this.bunifuButton1.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(87)))), ((int)(((byte)(28)))));
            this.bunifuButton1.onHoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(252)))), ((int)(((byte)(159)))));
            this.bunifuButton1.onHoverState.IconLeftImage = null;
            this.bunifuButton1.onHoverState.IconRightImage = null;
            this.bunifuButton1.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(207)))), ((int)(((byte)(6)))));
            this.bunifuButton1.OnIdleState.BorderRadius = 1;
            this.bunifuButton1.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton1.OnIdleState.BorderThickness = 2;
            this.bunifuButton1.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(64)))), ((int)(((byte)(22)))));
            this.bunifuButton1.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(252)))), ((int)(((byte)(159)))));
            this.bunifuButton1.OnIdleState.IconLeftImage = null;
            this.bunifuButton1.OnIdleState.IconRightImage = null;
            this.bunifuButton1.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(207)))), ((int)(((byte)(6)))));
            this.bunifuButton1.OnPressedState.BorderRadius = 1;
            this.bunifuButton1.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton1.OnPressedState.BorderThickness = 2;
            this.bunifuButton1.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(64)))), ((int)(((byte)(22)))));
            this.bunifuButton1.OnPressedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(252)))), ((int)(((byte)(159)))));
            this.bunifuButton1.OnPressedState.IconLeftImage = null;
            this.bunifuButton1.OnPressedState.IconRightImage = null;
            this.bunifuButton1.Size = new System.Drawing.Size(128, 29);
            this.bunifuButton1.TabIndex = 6;
            this.bunifuButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuButton1.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.bunifuButton1.TextMarginLeft = 0;
            this.bunifuButton1.TextPadding = new System.Windows.Forms.Padding(0);
            this.bunifuButton1.UseDefaultRadiusAndThickness = true;
            // 
            // notifytxt
            // 
            this.notifytxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.notifytxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.notifytxt.Font = new System.Drawing.Font("Microsoft PhagsPa", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notifytxt.ForeColor = System.Drawing.Color.White;
            this.notifytxt.Location = new System.Drawing.Point(158, 7);
            this.notifytxt.Name = "notifytxt";
            this.notifytxt.Size = new System.Drawing.Size(375, 17);
            this.notifytxt.TabIndex = 4;
            this.notifytxt.Text = "Notification here!";
            this.notifytxt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.notifytxt.Visible = false;
            // 
            // bunifuDragControl2
            // 
            this.bunifuDragControl2.Fixed = true;
            this.bunifuDragControl2.Horizontal = true;
            this.bunifuDragControl2.TargetControl = this.notifytxt;
            this.bunifuDragControl2.Vertical = true;
            // 
            // notifytimer
            // 
            this.notifytimer.Interval = 5000;
            this.notifytimer.Tick += new System.EventHandler(this.notifytimer_Tick);
            // 
            // packagebox
            // 
            this.packagebox.BackColor = System.Drawing.Color.Transparent;
            this.packagebox.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.packagebox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.packagebox.BorderRadius = 0;
            this.packagebox.Color = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.packagebox.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.packagebox.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.packagebox.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.packagebox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.packagebox.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.packagebox.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.packagebox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.packagebox.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thick;
            this.packagebox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.packagebox.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.packagebox.FillDropDown = true;
            this.packagebox.FillIndicator = false;
            this.packagebox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.packagebox.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F);
            this.packagebox.ForeColor = System.Drawing.Color.White;
            this.packagebox.FormattingEnabled = true;
            this.packagebox.Icon = null;
            this.packagebox.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.packagebox.IndicatorColor = System.Drawing.Color.DarkGray;
            this.packagebox.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.packagebox.IndicatorThickness = 2;
            this.packagebox.IsDropdownOpened = false;
            this.packagebox.ItemBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.packagebox.ItemBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.packagebox.ItemForeColor = System.Drawing.Color.White;
            this.packagebox.ItemHeight = 19;
            this.packagebox.ItemHighLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.packagebox.ItemHighLightForeColor = System.Drawing.Color.White;
            this.packagebox.ItemTopMargin = 3;
            this.packagebox.Location = new System.Drawing.Point(193, 127);
            this.packagebox.Name = "packagebox";
            this.packagebox.Size = new System.Drawing.Size(145, 25);
            this.packagebox.TabIndex = 19;
            this.packagebox.Text = null;
            this.packagebox.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.packagebox.TextLeftMargin = 5;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label6.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label6.Location = new System.Drawing.Point(104, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 29);
            this.label6.TabIndex = 18;
            this.label6.Text = "Package:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label5.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label5.Location = new System.Drawing.Point(344, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 29);
            this.label5.TabIndex = 20;
            this.label5.Text = "AIRAC:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // regionbox
            // 
            this.regionbox.BackColor = System.Drawing.Color.Transparent;
            this.regionbox.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.regionbox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.regionbox.BorderRadius = 0;
            this.regionbox.Color = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.regionbox.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.regionbox.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.regionbox.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.regionbox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.regionbox.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.regionbox.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.regionbox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.regionbox.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thick;
            this.regionbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.regionbox.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.regionbox.FillDropDown = true;
            this.regionbox.FillIndicator = false;
            this.regionbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.regionbox.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F);
            this.regionbox.ForeColor = System.Drawing.Color.White;
            this.regionbox.FormattingEnabled = true;
            this.regionbox.Icon = null;
            this.regionbox.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.regionbox.IndicatorColor = System.Drawing.Color.DarkGray;
            this.regionbox.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.regionbox.IndicatorThickness = 2;
            this.regionbox.IsDropdownOpened = false;
            this.regionbox.ItemBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.regionbox.ItemBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.regionbox.ItemForeColor = System.Drawing.Color.White;
            this.regionbox.ItemHeight = 19;
            this.regionbox.ItemHighLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.regionbox.ItemHighLightForeColor = System.Drawing.Color.White;
            this.regionbox.ItemTopMargin = 3;
            this.regionbox.Location = new System.Drawing.Point(193, 96);
            this.regionbox.Name = "regionbox";
            this.regionbox.Size = new System.Drawing.Size(145, 25);
            this.regionbox.TabIndex = 23;
            this.regionbox.Text = null;
            this.regionbox.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.regionbox.TextLeftMargin = 5;
            this.regionbox.SelectedIndexChanged += new System.EventHandler(this.regionbox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label4.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label4.Location = new System.Drawing.Point(104, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 29);
            this.label4.TabIndex = 22;
            this.label4.Text = "Region:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label7.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label7.Location = new System.Drawing.Point(344, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 29);
            this.label7.TabIndex = 24;
            this.label7.Text = "Released:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // airactxt
            // 
            this.airactxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.airactxt.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.airactxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.airactxt.Location = new System.Drawing.Point(417, 96);
            this.airactxt.Name = "airactxt";
            this.airactxt.Size = new System.Drawing.Size(67, 29);
            this.airactxt.TabIndex = 25;
            this.airactxt.Text = "AIRAC";
            this.airactxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // releasetxt
            // 
            this.releasetxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.releasetxt.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.releasetxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.releasetxt.Location = new System.Drawing.Point(417, 123);
            this.releasetxt.Name = "releasetxt";
            this.releasetxt.Size = new System.Drawing.Size(67, 29);
            this.releasetxt.TabIndex = 26;
            this.releasetxt.Text = "RELEASE";
            this.releasetxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(601, 263);
            this.Controls.Add(this.releasetxt);
            this.Controls.Add(this.airactxt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.regionbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.packagebox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bunifuButton1);
            this.Controls.Add(this.airacsettingsbtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bunifuPanel1);
            this.Controls.Add(this.controlbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ToolScope for EuroScope";
            this.Load += new System.EventHandler(this.main_Load);
            this.controlbar.ResumeLayout(false);
            this.controlbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPanel controlbar;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton minimizebtn;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton closebtn;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton airacsettingsbtn;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton bunifuButton1;
        private System.Windows.Forms.Label notifytxt;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl2;
        private System.Windows.Forms.Timer notifytimer;
        private Bunifu.UI.WinForms.BunifuDropdown packagebox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private Bunifu.UI.WinForms.BunifuDropdown regionbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label airactxt;
        private System.Windows.Forms.Label releasetxt;
    }
}

