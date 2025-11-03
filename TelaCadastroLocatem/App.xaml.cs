using Microsoft.Maui.Controls;
using TelaCadastroLocatem.Views;

namespace TelaCadastroLocatem
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

        }
    }
}