using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using desafioKogui.Models;
using desafioKogui.Services;

namespace desafioKogui.ViewModels;

public class SegundaSecao : INotifyPropertyChanged
{
    public ObservableCollection<CorCard> CorCards { get; set; }
    
    private string? _fraseFormada;
    public string? FraseFormada 
    { 
        get => _fraseFormada;
        set
        {
            _fraseFormada = value;
            OnPropertyChanged(nameof(FraseFormada));
        }
    }

    private readonly CorApiService _cor;

    public SegundaSecao()
    {
        CorCards = [];
        _cor = new CorApiService();

        //usando task.run para nao travar a UI
        Task.Run(async () => await CarregarCorAsync());
    }

    private async Task CarregarCorAsync()
    {
        var hexValores = new List<string>
        {
            "#0000FF", "#00FF00", "#FFFFFF",
            "#FF0000", "#FFA500", "#FFFF00", "#000000"
        };

        var componentes = new List<ChaveCor>
        {
            new ChaveCor { COR = "White", COMPONENTE = "para" },
            new ChaveCor { COR = "Blue", COMPONENTE = "Pares" },
            new ChaveCor { COR = "Green", COMPONENTE = "alterar" },
            new ChaveCor { COR = "Black", COMPONENTE = "#" },
            new ChaveCor { COR = "WebOrange", COMPONENTE = "e" },
            new ChaveCor { COR = "Yellow", COMPONENTE = "impares" },
            new ChaveCor { COR = "Red", COMPONENTE = " " },
        };

        var construirFrase = new StringBuilder();

        foreach (var hex in hexValores)
        {
            string? corNome = await _cor.GetCorNomeAsync(hex);

            //adiciona o card na lista pra exibir na UI
            MainThread.BeginInvokeOnMainThread(() =>
            {
                   CorCards.Add(new CorCard { HexValor = hex, CorNome = corNome });
            });

            var componenteEncontrado = componentes.FirstOrDefault(c => c.COR.Equals(corNome, StringComparison.OrdinalIgnoreCase));
            if (componenteEncontrado != null)
            {
                construirFrase.Append(componenteEncontrado.COMPONENTE + " ");
            }
        }

        MainThread.BeginInvokeOnMainThread(() =>
        {
            FraseFormada = construirFrase.ToString().Trim();
        });
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

//classe pra auxiliar o card de cor
public class CorCard
{
    public string? HexValor { get; set; }
    public string? CorNome { get; set; }
}