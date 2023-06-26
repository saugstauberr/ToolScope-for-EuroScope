using ScintillaNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Windows.Controls;
using Newtonsoft.Json;
using static ToolScope_for_EuroScope.Main;

namespace ToolScope_for_EuroScope
{
    public partial class PSEditor : Form
    {
        private const int cGrip = 16;      // Grip size
        private const int cCaption = 32;   // Caption bar height;

        Main.ClientConfig config = new Main.ClientConfig();

        public PSEditor()
        {
            config = JsonConvert.DeserializeObject<ClientConfig>(File.ReadAllText("config.json"));
            InitializeComponent();
            ConfigEditor();
            try
            {
                codeeditor.Text = File.ReadAllText("custom-ps.ps1");
            } catch
            {

            }
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            codeeditor.Zoom = config.codezoom;
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            config.codezoom = codeeditor.Zoom;
            File.WriteAllText("config.json", JsonConvert.SerializeObject(config, Formatting.Indented));
            closebtn.Enabled = false;
            Close();
        }

        private void minimizebtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void maximizebtn_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        #region PS Editor Config
        private void ConfigEditor()
        {
            this.codeeditor.Margins[0].Width = 16;

            this.codeeditor.StyleResetDefault();
            this.codeeditor.Styles[Style.Default].Font = "Consolas";
            codeeditor.Styles[Style.Default].BackColor = Color.FromArgb(33, 34, 36);
            codeeditor.Styles[Style.Default].ForeColor = Color.White;
            this.codeeditor.Styles[Style.Default].Size = 10;
            this.codeeditor.StyleClearAll();

            this.codeeditor.Styles[Style.PowerShell.Default].ForeColor = Color.Silver;
            this.codeeditor.Styles[Style.PowerShell.Comment].ForeColor = Color.FromArgb(0, 128, 0); // Green
            this.codeeditor.Styles[Style.PowerShell.Number].ForeColor = Color.Olive;
            this.codeeditor.Styles[Style.PowerShell.String].ForeColor = Color.FromArgb(163, 21, 21); // Red
            this.codeeditor.Styles[Style.PowerShell.Character].ForeColor = Color.FromArgb(163, 21, 21); // Red
            this.codeeditor.Styles[Style.PowerShell.Operator].ForeColor = Color.Purple;

            this.codeeditor.SetProperty("fold", "1");
            this.codeeditor.SetProperty("fold.compact", "1");

            this.codeeditor.Margins[2].Type = MarginType.Symbol;
            this.codeeditor.Margins[2].Mask = Marker.MaskFolders;
            this.codeeditor.Margins[2].Sensitive = true;
            this.codeeditor.Margins[2].Width = 20;
            codeeditor.Margins[2].BackColor = Color.FromArgb(33, 34, 36);
            codeeditor.Styles[Style.LineNumber].BackColor = Color.FromArgb(42, 43, 46);
            codeeditor.SetFoldMarginColor(true, Color.FromArgb(37, 38, 41));
            codeeditor.SetFoldMarginHighlightColor(true, Color.FromArgb(37, 38, 41));

            // Set colors for all folding markers
            for (int i = 25; i <= 31; i++)
            {
                this.codeeditor.Markers[i].SetForeColor(SystemColors.ControlLightLight);
                this.codeeditor.Markers[i].SetBackColor(SystemColors.ControlDark);
            }

            // Configure folding markers with respective symbols
            this.codeeditor.Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
            this.codeeditor.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
            this.codeeditor.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
            this.codeeditor.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            this.codeeditor.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
            this.codeeditor.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            this.codeeditor.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;
            codeeditor.IndentationGuides = IndentView.LookBoth;
            codeeditor.Styles[Style.BraceLight].BackColor = Color.FromArgb(33, 34, 36);
            codeeditor.Styles[Style.BraceLight].ForeColor = Color.BlueViolet;
            codeeditor.Styles[Style.BraceBad].ForeColor = Color.Red;

            // Enable automatic folding
            this.codeeditor.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);
        }

        private void scintilla1_CharAdded(object sender, CharAddedEventArgs e)
        {
            // Find the word start
            var currentPos = codeeditor.CurrentPosition;
            var wordStartPos = codeeditor.WordStartPosition(currentPos, true);

            // Display the autocompletion list
            var lenEntered = currentPos - wordStartPos;
            if (lenEntered > 0)
            {
                if (!codeeditor.AutoCActive)
                    codeeditor.AutoCShow(lenEntered, "abstract as base break case catch checked continue default delegate do else event explicit extern false finally fixed for foreach goto if implicit in interface internal is lock namespace new null object operator out override params private protected public readonly ref return sealed sizeof stackalloc switch this throw true try typeof unchecked unsafe using virtual while");
            }

            savebtn.Enabled = true;
        }

        private static bool IsBrace(int c)
        {
            switch (c)
            {
                case '(':
                case ')':
                case '[':
                case ']':
                case '{':
                case '}':
                case '<':
                case '>':
                    return true;
            }

            return false;
        }

        private void scintilla1_UpdateUI(object sender, UpdateUIEventArgs e)
        {
            int lastCaretPos = 0;
            // Has the caret changed position?
            var caretPos = codeeditor.CurrentPosition;
            if (lastCaretPos != caretPos)
            {
                lastCaretPos = caretPos;
                var bracePos1 = -1;
                var bracePos2 = -1;

                // Is there a brace to the left or right?
                if (caretPos > 0 && IsBrace(codeeditor.GetCharAt(caretPos - 1)))
                    bracePos1 = (caretPos - 1);
                else if (IsBrace(codeeditor.GetCharAt(caretPos)))
                    bracePos1 = caretPos;

                if (bracePos1 >= 0)
                {
                    // Find the matching brace
                    bracePos2 = codeeditor.BraceMatch(bracePos1);
                    if (bracePos2 == Scintilla.InvalidPosition)
                        codeeditor.BraceBadLight(bracePos1);
                    else
                        codeeditor.BraceHighlight(bracePos1, bracePos2);
                }
                else
                {
                    // Turn off brace matching
                    codeeditor.BraceHighlight(Scintilla.InvalidPosition, Scintilla.InvalidPosition);
                }
            }
        }

        #endregion

        #region Resizable
        private const int
           HTLEFT = 10,
           HTRIGHT = 11,
           HTTOP = 12,
           HTTOPLEFT = 13,
           HTTOPRIGHT = 14,
           HTBOTTOM = 15,
           HTBOTTOMLEFT = 16,
           HTBOTTOMRIGHT = 17;

        const int _ = 10; // you can rename this variable if you like

        new Rectangle Top { get { return new Rectangle(0, 0, this.ClientSize.Width, _); } }
        new Rectangle Left { get { return new Rectangle(0, 0, _, this.ClientSize.Height); } }
        new Rectangle Bottom { get { return new Rectangle(0, this.ClientSize.Height - _, this.ClientSize.Width, _); } }
        new Rectangle Right { get { return new Rectangle(this.ClientSize.Width - _, 0, _, this.ClientSize.Height); } }
        Rectangle TopLeft { get { return new Rectangle(0, 0, _, _); } }
        Rectangle TopRight { get { return new Rectangle(this.ClientSize.Width - _, 0, _, _); } }

        Rectangle BottomLeft { get { return new Rectangle(0, this.ClientSize.Height - _, _, _); } }
        Rectangle BottomRight { get { return new Rectangle(this.ClientSize.Width - _, this.ClientSize.Height - _, _, _); } }


        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == 0x84) // WM_NCHITTEST
            {
                var cursor = this.PointToClient(Cursor.Position);

                if (TopLeft.Contains(cursor)) message.Result = (IntPtr)HTTOPLEFT;
                else if (TopRight.Contains(cursor)) message.Result = (IntPtr)HTTOPRIGHT;
                else if (BottomLeft.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMLEFT;
                else if (BottomRight.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMRIGHT;

                else if (Top.Contains(cursor)) message.Result = (IntPtr)HTTOP;
                else if (Left.Contains(cursor)) message.Result = (IntPtr)HTLEFT;
                else if (Right.Contains(cursor)) message.Result = (IntPtr)HTRIGHT;
                else if (Bottom.Contains(cursor)) message.Result = (IntPtr)HTBOTTOM;
            }
        }
        #endregion

        private void loadoldscriptbtn_Click(object sender, EventArgs e)
        {
            try
            {
                codeeditor.Text = File.ReadAllText("custom-ps.ps1");
            }
            catch
            {

            }
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            File.WriteAllText("custom-ps.ps1", codeeditor.Text);
            savebtn.Enabled = false;
        }

        private void decreasefontbtn_Click(object sender, EventArgs e)
        {
            this.codeeditor.Zoom = codeeditor.Zoom - 2;
        }

        private void increasefontbtn_Click(object sender, EventArgs e)
        {
            this.codeeditor.Zoom = codeeditor.Zoom + 2;
        }
    }
}
