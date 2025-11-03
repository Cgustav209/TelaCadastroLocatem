using Microsoft.Maui.Controls;
using TelaCadastroLocatem.Views;
namespace TelaCadastroLocatem
{
    public partial class AppShell : Shell
    {
        private static bool _routeaRegistered; // Campo estático para rastrear se a rota já foi registrada.
        public AppShell()
        {
            InitializeComponent();


            if (!_routeaRegistered)
            {
                Routing.RegisterRoute(nameof(Views.LocatarioPage), typeof(Views.LocatarioPage)); // Registra a rota para LocatarioPage, permitindo a navegação para essa página usando seu nome.
                _routeaRegistered = true; // Define o campo como true para evitar registros duplicados.
            }

            if (!_routeaRegistered)
            {
                Routing.RegisterRoute(nameof(Views.LocadorPage), typeof(Views.LocadorPage)); // Registra a rota para locadorPage, permitindo a navegação para essa página usando seu nome.
                _routeaRegistered = true; // Define o campo como true para evitar registros duplicados.
            }
        }
    }
}
