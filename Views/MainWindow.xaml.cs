using System.Windows;
using System.Windows.Input;
using System.Windows.Shell;

namespace ToolScope.WPF
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new MainWindowViewModel();
            var vm = (MainWindowViewModel)DataContext;

            InitializeComponent();
            WindowChrome.SetWindowChrome(this, new WindowChrome());
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void CloseCommand(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
