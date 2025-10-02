using desafioKogui.ViewModels;

namespace desafioKogui.Views;

public partial class PrimeiraSecaoPage1 : ContentPage
{
	public PrimeiraSecaoPage1()
	{
		InitializeComponent();

		BindingContext = new PrimeiraSecao();
    }
}