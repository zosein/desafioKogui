using System.Collections.ObjectModel;
using desafioKogui.Models;

namespace desafioKogui.ViewModels;

public class PrimeiraSecao
{
    public ObservableCollection<ChaveCor> ItensChaveCor { get; set; }

    public PrimeiraSecao()
    {
        ItensChaveCor = [];

        CarregarItens();
    }

    private void CarregarItens()
    {
        ItensChaveCor.Add(new ChaveCor { COR = "MagentaFuchsia", COMPONENTE = "(vazio)" });
        ItensChaveCor.Add(new ChaveCor { COR = "White", COMPONENTE = "para" });
        ItensChaveCor.Add(new ChaveCor { COR = "Blue", COMPONENTE = "Pares" });
        ItensChaveCor.Add(new ChaveCor { COR = "Green", COMPONENTE = "alterar" });
        ItensChaveCor.Add(new ChaveCor { COR = "Black", COMPONENTE = "#" });
        ItensChaveCor.Add(new ChaveCor { COR = "WebOrange", COMPONENTE = "e" });
        ItensChaveCor.Add(new ChaveCor { COR = "Yellow", COMPONENTE = "impares" });
        ItensChaveCor.Add(new ChaveCor { COR = "Red", COMPONENTE = " " });
        ItensChaveCor.Add(new ChaveCor { COR = "Coconut", COMPONENTE = "Busca" });
        ItensChaveCor.Add(new ChaveCor { COR = "CyanAqua", COMPONENTE = "primos" });
    }
}
