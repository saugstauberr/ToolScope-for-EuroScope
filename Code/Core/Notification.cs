using System.Drawing;

namespace ToolScope_for_EuroScope.Code.Core
{
    public class Notification
    {
        public void Success(Main form, string text, int seconds)
        {
            form.notifytxt.ForeColor = Color.Green;
            NotifyText(form, text, seconds);
        }

        public void Information(Main form, string text, int seconds)
        {
            form.notifytxt.ForeColor = Color.SlateGray;
            NotifyText(form, text, seconds);
        }

        public void Warning(Main form, string text, int seconds)
        {
            form.notifytxt.ForeColor = Color.Orange;
            NotifyText(form, text, seconds);
        }

        public void Error(Main form, string text, int seconds)
        {
            form.notifytxt.ForeColor = Color.Red;
            NotifyText(form, text, seconds);
        }



        private void NotifyText(Main form, string text, int seconds)
        {
            form.notifytxt.Text = text;
            form.notifytxt.Visible = true;
            form.notifytimer.Stop();

            int duration = seconds * 1000;



            form.notifytimer.Interval = duration;
            form.notifytimer.Start();
        }
    }
}
