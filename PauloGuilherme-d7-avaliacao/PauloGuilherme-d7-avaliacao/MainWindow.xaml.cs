using System.Linq;
using System.Windows;
using PauloGuilherme_d7_avaliacao.Data;
using System.ComponentModel.DataAnnotations;

namespace PauloGuilherme_d7_avaliacao;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly Context context;
    User possibleUser = new();

    public MainWindow(Context context)
    {
        this.context = context;
        InitializeComponent();
        UserGrid.DataContext = possibleUser;
    }

    public void AccessSystem(object s, RoutedEventArgs e)
    {
        if (checkIfEmailIsValid(possibleUser.Email))
        {
            var users = context.Users.ToList();
            foreach (User user in users)
            {
                if (user.Email == possibleUser.Email && user.Password == possibleUser.Password)
                {
                    MessageBox.Show("Usuário autentificado");
                    return;
                } 
            }
        }

        MessageBox.Show("Credenciais inválidas");
    }

    public static bool checkIfEmailIsValid(string email)
    {
        if (email == null)
        {
            return false;
        }

        if (new EmailAddressAttribute().IsValid(email))
        {
            return true;
        }

        return false;
    }
}
