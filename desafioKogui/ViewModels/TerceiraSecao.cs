using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace desafioKogui.ViewModels;

public class TerceiraSecao : INotifyPropertyChanged
{
    private string? _enigmaResultado;
    public string? EnigmaResultado
    {
        get => _enigmaResultado;
        set
        {
            _enigmaResultado = value;
            OnPropertyChanged();
        }
    }

    private string? _nomeDoObjeto;
    public string? NomeDoObjeto
    {
        get => _nomeDoObjeto;
        set
        {
            _nomeDoObjeto = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public TerceiraSecao()
    {
        EnigmaResultado = string.Empty;
        Task.Run(async () => await ResolverEnigmaAsync());
    }

    private async Task ResolverEnigmaAsync()
    {
        try
        {
            var stream = await FileSystem.OpenAppPackageFileAsync("MATRIZ.txt");
            var reader = new StreamReader(stream);
            var conteudoMatriz = await reader.ReadToEndAsync();

            var stringBuilder = new StringBuilder();

            foreach (char digito in conteudoMatriz)
            {
                switch (digito)
                {
                    case '2':
                    case '4':
                    case '6':
                    case '8':
                        stringBuilder.Append(" ");
                        break;

                    case '1':
                    case '3':
                    case '5':
                    case '7':
                    case '9':
                        stringBuilder.Append('#');
                        break;

                    case '\r':
                        break;

                    case '\n':
                        stringBuilder.Append('\n');
                        break;

                    default:
                        stringBuilder.Append(digito);
                        break;
                }
            }

            MainThread.BeginInvokeOnMainThread(() =>
            {
                EnigmaResultado = stringBuilder.ToString();
                NomeDoObjeto = "Objeto Desconhecido";
            });
        }
        catch (Exception ex)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                EnigmaResultado = $"Erro ao resolver o enigma: {ex.Message}";
            });
        }
    }
}
