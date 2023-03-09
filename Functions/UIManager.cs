using Bunifu.UI.WinForms.BunifuButton;
using Ini;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolScope_for_EuroScope.Properties;
using static System.Net.Mime.MediaTypeNames;

namespace ToolScope_for_EuroScope
{
    public partial class Main
    {
        public void notifyText(string type, string text, int seconds)
        {
            notifytxt.Text = text;
            notifytxt.Visible = true;
            notifytimer.Stop();

            int duration = seconds * 1000;

            switch (type)
            {
                case "success":
                    notifytxt.ForeColor = Color.Green;
                    notifytimer.Interval = duration;
                    notifytimer.Start();
                    break;

                case "error":
                    notifytxt.ForeColor = Color.Red;
                    notifytimer.Interval = duration;
                    notifytimer.Start();
                    break;

                default:
                    notifytxt.ForeColor = Color.Silver;
                    notifytimer.Interval = duration;
                    notifytimer.Start();
                    break;
            }
        }

        public void notifytimer_Tick(object sender, EventArgs e)
        {
            notifytxt.Visible = false;
            notifytimer.Stop();
        }

        /*public void CreateButton(string type, int x, int y, string text)
        {
            BunifuButton delairac = new BunifuButton();

            delairac.AllowAnimations = true;
            delairac.AllowMouseEffects = true;
            delairac.AllowToggling = false;
            delairac.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            delairac.AnimationSpeed = 200;
            delairac.AutoGenerateColors = false;
            delairac.AutoRoundBorders = false;
            delairac.AutoSizeLeftIcon = true;
            delairac.AutoSizeRightIcon = true;
            delairac.BackColor = System.Drawing.Color.Transparent;
            delairac.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            delairac.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            delairac.ButtonText = text;
            delairac.ButtonTextMarginLeft = 0;
            delairac.ColorContrastOnClick = 45;
            delairac.ColorContrastOnHover = 45;
            delairac.Cursor = System.Windows.Forms.Cursors.Default;
            delairac.DialogResult = System.Windows.Forms.DialogResult.None;
            delairac.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            delairac.DisabledFillColor = System.Drawing.Color.Empty;
            delairac.DisabledForecolor = System.Drawing.Color.Empty;
            delairac.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            delairac.Font = new System.Drawing.Font("Microsoft PhagsPa", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            delairac.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            delairac.IconLeft = null;
            delairac.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            delairac.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            delairac.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            delairac.IconMarginLeft = 11;
            delairac.IconPadding = 10;
            delairac.IconRight = null;
            delairac.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            delairac.IconRightCursor = System.Windows.Forms.Cursors.Default;
            delairac.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            delairac.IconSize = 25;
            delairac.IdleBorderColor = System.Drawing.Color.Empty;
            delairac.IdleBorderRadius = 0;
            delairac.IdleBorderThickness = 0;
            delairac.IdleFillColor = System.Drawing.Color.Empty;
            delairac.IdleIconLeftImage = null;
            delairac.IdleIconRightImage = null;
            delairac.IndicateFocus = false;
            delairac.Location = new System.Drawing.Point(x, y);
            delairac.Name = type;
            delairac.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            delairac.OnDisabledState.BorderRadius = 0;
            delairac.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            delairac.OnDisabledState.BorderThickness = 2;
            delairac.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            delairac.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            delairac.OnDisabledState.IconLeftImage = null;
            delairac.OnDisabledState.IconRightImage = null;
            delairac.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            delairac.onHoverState.BorderRadius = 0;
            delairac.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            delairac.onHoverState.BorderThickness = 2;
            delairac.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            delairac.onHoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            delairac.onHoverState.IconLeftImage = null;
            delairac.onHoverState.IconRightImage = null;
            delairac.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            delairac.OnIdleState.BorderRadius = 0;
            delairac.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            delairac.OnIdleState.BorderThickness = 2;
            delairac.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            delairac.OnIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            delairac.OnIdleState.IconLeftImage = null;
            delairac.OnIdleState.IconRightImage = null;
            delairac.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            delairac.OnPressedState.BorderRadius = 0;
            delairac.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            delairac.OnPressedState.BorderThickness = 2;
            delairac.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            delairac.OnPressedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(163)))));
            delairac.OnPressedState.IconLeftImage = null;
            delairac.OnPressedState.IconRightImage = null;
            delairac.Size = new System.Drawing.Size(103, 26);
            delairac.TabIndex = 48;
            delairac.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            delairac.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            delairac.TextMarginLeft = 0;
            delairac.TextPadding = new System.Windows.Forms.Padding(0);
            delairac.UseDefaultRadiusAndThickness = true;
            delairac.Click += new System.EventHandler(this.DeleteAirac);
            airacdownloadpan.Controls.Add(delairac);
        }

        public void DeleteAirac(object sender, EventArgs e)
        {
            BunifuButton type = (sender as BunifuButton);

        }

        public void CreateInstalledLabels()
        {
            int x_label = 341;
            int x_uninstall = 291;
            int y = 52;

            foreach (string package in installedpackages)
            {
                Label namelabel = new Label();
                namelabel.Location = new Point(x_label, y);
                namelabel.Text = package;
                namelabel.AutoSize = true;
                namelabel.TextAlign = ContentAlignment.MiddleLeft;
                namelabel.ForeColor = Color.FromArgb(255, 224, 224, 224);
                namelabel.Font = new Font("Microsoft PhagsPa", 9);
                airacdownloadpan.Controls.Add(namelabel);
                CreateButton(package, x_uninstall, y, "Uninstall");
                y += 30;
            }
        }*/


        private void ChangeUI(string pagename, Bunifu.UI.WinForms.BunifuButton.BunifuButton current)
        {
            UpdateUI("read");
            current.OnIdleState.FillColor = Color.FromArgb(255, 196, 147, 0);
            current.onHoverState.FillColor = Color.FromArgb(255, 196, 147, 0);
            current.OnPressedState.FillColor = Color.FromArgb(255, 196, 147, 0);

            if (lastButton != null)
            {
                lastButton.OnIdleState.FillColor = Color.FromArgb(255, 255, 191, 0);
                lastButton.onHoverState.FillColor = Color.FromArgb(255, 255, 191, 0);
                lastButton.OnPressedState.FillColor = Color.FromArgb(255, 255, 191, 0);
            }

            lastButton = current;
            pagenametxt.Text = pagename;
        }
    }
}
