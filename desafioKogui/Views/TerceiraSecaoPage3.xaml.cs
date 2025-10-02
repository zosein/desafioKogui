using desafioKogui.ViewModels;


namespace desafioKogui.Views;

public partial class TerceiraSecaoPage3 : ContentPage
{
	public TerceiraSecaoPage3()
	{
		InitializeComponent();
		BindingContext = new TerceiraSecao();
    }
}