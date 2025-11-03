namespace TelaCadastroLocatem.Views;

public partial class LocatarioPage : ContentPage

{
    // Campo privado (variável) para controlar o estado da visibilidade da senha.
    // 'false' significa que a senha começa escondida (com asteriscos).
    private bool _showPassword = false;

    // Construtor da página. É executado quando a página é criada.
    public LocatarioPage()
    {
        // Método essencial: carrega o layout visual definido no arquivo XAML (MainPage.xaml)
        // e conecta os elementos (como 'SenhaEntry', 'EmailEntry', etc.) a esta classe.
        InitializeComponent();

        // NOTA: Se esta View estivesse usando o padrão MVVM,
        // a conexão com o ViewModel (visto no código anterior) seria feita aqui,
        // geralmente com a linha:
        // this.BindingContext = new LocatemCadastroLocatario.ViewsModel.CadastroViewModel();
    }


    // Método (event handler) chamado quando o usuário clica no botão/ícone de "mostrar/esconder senha".
    // 'async void' é comum para event handlers, mas 'async' não é estritamente necessário aqui,
    // já que não há operações 'await'. Poderia ser 'private void'.
    private async void OnTogglePassword(object sender, EventArgs e)
    {
        // Inverte o valor booleano. Se era 'false', vira 'true'; se era 'true', vira 'false'.
        _showPassword = !_showPassword;

        // 'SenhaEntry' é o nome (x:Name) do campo de senha no XAML.
        // A propriedade 'IsPassword' define se o texto é mascarado (true) ou mostrado (false).
        // Aqui, ele define a propriedade para o *oposto* do estado atual.
        // (Se _showPassword é true, IsPassword vira false -> mostra a senha).
        SenhaEntry.IsPassword = !_showPassword;
    }

    // Método (event handler) chamado quando o botão de "Login" (ou "Cadastrar") é clicado.
    // 'async' é usado porque ele chama 'DisplayAlert', que é uma operação assíncrona.
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        // Pega o texto de cada campo de entrada (Entry) da tela.
        // 'NomeEntry', 'EmailEntry', etc., são os nomes (x:Name) dos elementos no XAML.
        // O '?' (null-conditional operator) evita erro se o 'Text' for nulo.
        // '.Trim()' remove espaços em branco do início e do fim do texto.
        var nome = NomeEntry.Text?.Trim();
        var email = EmailEntry.Text?.Trim();
        var senha = SenhaEntry.Text?.Trim();
        var cpf = CpfEntry.Text?.Trim();
        var endereco = EnderecoEntry.Text?.Trim();

        // Inicia uma verificação (validação) dos campos.
        // Verifica se os campos 'email', 'senha' ou 'cpf' estão vazios ou nulos.
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha) || string.IsNullOrEmpty(cpf))
        {
            // Se algum campo obrigatório estiver vazio, exibe um pop-up de alerta para o usuário.
            // 'await' pausa a execução do método até que o usuário clique em "OK".
            await DisplayAlert("Erro", "Por favor, preencha todos os campos.", "OK");

            // Interrompe a execução do método, impedindo que o código de "sucesso" abaixo seja executado.
            return;
        }

        // Início da lógica de autenticação (atualmente é apenas uma simulação).
        // Em um app real, isso seria uma chamada a uma API ou banco de dados.
        // Simulação de autenticação (substitua com sua lógica real)

        // Lógica de validação SIMULADA:
        // Verifica se o email contém o caractere "0" E se a senha tem 4 ou mais caracteres.
        if (email.Contains("0") && senha.Length >= 4)
        {
            // Se a simulação for bem-sucedida, mostra um pop-up de sucesso.
            await DisplayAlert("Sucesso", "Login realizado com sucesso!", "OK");

            // Sai do método.
            return;
        }
        else
        {
            // Se a condição 'if' (simulação) falhar, mostra uma mensagem de erro genérica.
            await DisplayAlert("Erro", "Email ou senha invalidos.", "OK");
        }

    }

    // Método (event handler) chamado quando o usuário clica para ver os "Termos de Serviço".
    // 'async' é necessário por causa das operações de arquivo (await FileSystem e ReadToEndAsync).
    private async void OnShowTerms(object sender, EventArgs e)
    {
        // Abre um fluxo de leitura (stream) para um arquivo chamado "Termos.txt".
        // 'FileSystem.OpenAppPackageFileAsync' lê um arquivo que está "empacotado" com o aplicativo.
        // (No Android, fica na pasta Assets; no iOS, em Resources).
        // 'using' garante que o 'stream' será fechado e liberado da memória, mesmo se ocorrer um erro.
        using var stream = await FileSystem.OpenAppPackageFileAsync("Termos.txt");

        // Cria um "leitor de stream" (StreamReader) para facilitar a leitura do conteúdo do 'stream'.
        // 'using' também garante que o 'reader' será descartado corretamente.
        using var reader = new StreamReader(stream);

        // Lê todo o conteúdo do arquivo (do início ao fim) de forma assíncrona
        // e armazena o texto completo na variável 'termos'.
        var termos = await reader.ReadToEndAsync();

        // Exibe um pop-up de alerta grande, mostrando o título "Termos de Servico"
        // e o conteúdo do arquivo 'termos' como mensagem principal.
        await DisplayAlert("Termos de Servico", termos, "OK");
    }

    private async void OnIrParaLocadorClicked(object sender, EventArgs e)
    {
        // Navega para a página LocadorPage usando o Shell do MAUI.
        await Shell.Current.GoToAsync("///LocadorPage");
    }
} 
