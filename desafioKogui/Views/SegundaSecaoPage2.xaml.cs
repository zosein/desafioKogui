using desafioKogui.ViewModels;


namespace desafioKogui.Views;

public partial class SegundaSecaoPage2 : ContentPage
{
	public SegundaSecaoPage2()
	{
		InitializeComponent();
		BindingContext = new SegundaSecao();
    }
}