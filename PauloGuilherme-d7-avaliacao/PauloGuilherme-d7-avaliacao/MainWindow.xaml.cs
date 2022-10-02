using System.Linq;
using System.Windows;
using PauloGuilherme_d7_avaliacao.Data;

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

        if (validLoginAttempt())
        {

            var users = context.Users.ToList();
            foreach (User user in users)
            {
                if (checkEmailAndPassword(user))
                {
                    MessageBox.Show("Usuário autentificado!");
                    return;
                }
            }
        }

        MessageBox.Show("Credenciais inválidas!");
    }

    private bool validLoginAttempt()
    {
        return isValid(possibleUser.Email) && isValid(possibleUser.Password);
    }

    private static bool isValid(string field)
    {
        return (field != null && field.Length != 0);
    }

    private bool checkEmailAndPassword(User user)
    {
        return (user.Email == possibleUser.Email && possibleUser.Password == user.Password);
    }
}
