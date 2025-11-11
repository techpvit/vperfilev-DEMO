using Avalonia.Controls;
using demo1.Context;
using demo1.Models;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;


namespace demo1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Auth_button(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            string _login = login.Text;
            string _password = password.Text;
            string[] logins = [];
            var AllUsers = Helper.DataBase.Users.ToList();
            foreach (var user in AllUsers)
            {
                if(_login == user.Login)
                {
                    Error.IsVisible = false;
                    if(_password == user.Password)
                    {
                        if (user.Admin == true)
                        {
                            new AdminPanel().Show();
                            Close();
                        }
                        else
                        {
                            if(user.Banned == false)
                            {
                                new Order().Show();
                                Close();
                                break;
                            }
                            else
                            {
                                Error.Text = "Your account is banned! \n Connect with admins for information";
                                Error.IsVisible = true;
                            }
                        }
                    }
                    else
                    {
                        Error.Text = "Wrong login or password";
                        Error.IsVisible = true;
                        continue;
                    }
                }
                else
                {
                    Error.Text = "Wrong login or password";
                    Error.IsVisible = true;
                    continue;
                }
            }
            
        }
    }
}