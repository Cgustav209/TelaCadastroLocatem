using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelaCadastroLocatem.Views;

public partial class LocadorPage : ContentPage
{

  // Variável booleana que controla se a senha será mostrada ou escondida
    private bool _showPassword = false;

    public LocadorPage()
    {
        InitializeComponent(); // Inicializa os componentes visuais definidos no arquivo XAML
    }

    // Oculta ou mostra a senha quando o usuário clica no ícone de olho
    private async void OnTogglePassword(object sender, EventArgs e)
    {
        // Inverte o valor da variável _showPassword (de true para false, e vice-versa)
        _showPassword = !_showPassword;

        // Altera a propriedade IsPassword do campo de senha (SenhaEntry)
        // Quando IsPassword = true ? oculta o texto (mostra bolinhas)
        // Quando IsPassword = false ? mostra o texto real digitado
        SenhaEntry.IsPassword = !_showPassword;
    }

    // Método executado quando o usuário clica no botão de login
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        // Lê os textos digitados nos campos da tela
        // O ?.Trim() remove espaços extras e evita erro caso o campo esteja nulo
        var nome = NomeEntry.Text?.Trim();
        var email = EmailEntry.Text?.Trim();
        var senha = SenhaEntry.Text?.Trim();
        var cnpj = CnpjEntry.Text?.Trim();
        var endereco = EnderecoEntry.Text?.Trim();

        // Verifica se os campos obrigatórios estão vazios
        // se (email = nulo/vazio OU senha = nula/vazia OU cnpj = nula/vazia)
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha) || string.IsNullOrEmpty(cnpj))
        {
            // Exibe uma mensagem de erro e interrompe o processo de login
            await DisplayAlert("Erro", "Por favor, preencha todos os campos.", "OK");
            return;
        }

        // Simulação de autenticação (apenas exemplo — substitua por sua lógica real)
        // Aqui o login é considerado válido se o email contém "0" e a senha tiver 4 ou mais caracteres
        if (email.Contains("0") && senha.Length >= 4)
        {
            // Exibe mensagem de sucesso e interrompe a execução do método
            await DisplayAlert("Sucesso", "Login realizado com sucesso!", "OK");
            return;
        }
        else
        {
            // Caso as condições acima não sejam atendidas, mostra mensagem de erro
            await DisplayAlert("Erro", "Email ou senha invalidos.", "OK");
        }
    }

    // Método executado quando o usuário clica no botão para ver os Termos de Serviço
    private async void OnShowTerms(object sender, EventArgs e)
    {
        // Abre o arquivo "Termos.txt" incluído no pacote do app
        using var stream = await FileSystem.OpenAppPackageFileAsync("Termos.txt");

        // Cria um leitor para ler o conteúdo do arquivo aberto
        using var reader = new StreamReader(stream);

        // Lê todo o conteúdo do arquivo de forma assíncrona
        var termos = await reader.ReadToEndAsync();

        // Exibe o texto lido em uma janela de alerta
        await DisplayAlert("Termos de Servico", termos, "OK");
    }

    private async void OnIrParaLocatarioClicked(object sender, EventArgs e)
    {
        // Navega para a página LocatarioPage usando o Shell do MAUI
        await Shell.Current.GoToAsync(nameof(LocatarioPage));
    }

}
