using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ToolScope.WPF.Controls;

public partial class NavigationButton : UserControl
{
    public new static readonly StyledProperty<string> SymbolProperty =
        AvaloniaProperty.Register<NavigationButton, string>(nameof(Symbol));
    public new static readonly StyledProperty<string> ContentProperty =
        AvaloniaProperty.Register<NavigationButton, string>(nameof(Content));

    public string Symbol
    {
        get => GetValue(SymbolProperty);
        set => SetValue(SymbolProperty, value);
    }
    public new string Content
    {
        get => GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }
    public NavigationButton()
    {
        DataContext = this;
        InitializeComponent();
    }
}