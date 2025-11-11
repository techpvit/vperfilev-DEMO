using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using System.Collections.Generic;
using System.Linq;
using demo1.Models;


namespace demo1;

public partial class AdminPanel : Window
{
    private List<User> _users;
    private User _selectedUser;

    public AdminPanel()
    {
        InitializeComponent();
        LoadUsers();
        DisableEditControls();
    }

    //private void InitializeComponent()
    //{
    //    AvaloniaXamlLoader.Load(this);
    //}

    private void LoadUsers()
    {
        _users = new List<User>();
        
        UsersListBox.SelectedItem = null;
        _selectedUser = null;
        ClearEditForm();
        DisableEditControls();
    }

    private void UsersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        _selectedUser = UsersListBox.SelectedItem as User;

        if (_selectedUser != null)
        {
            EnableEditControls();
            LoadUserDataToForm();
            UpdateUserInfo();
        }
        else
        {
            DisableEditControls();
            ClearEditForm();
        }
    }

    private void LoadUserDataToForm()
    {
        if (_selectedUser == null) return;

        LoginTextBox.Text = _selectedUser.Login;
        PasswordTextBox.Text = _selectedUser.Password;

        
        if (_selectedUser.Admin == true)
        {
            AdminRadio.IsChecked = true;
        }
        else
        {
            UserRadio.IsChecked = true;
        }

        
        BannedCheckBox.IsChecked = _selectedUser.Banned ?? false;
    }

    private void ClearEditForm()
    {
        LoginTextBox.Text = "";
        PasswordTextBox.Text = "";
        UserRadio.IsChecked = true;
        BannedCheckBox.IsChecked = false;
        UserInfoText.Text = "Выберите пользователя из списка для редактирования";
    }

    private void EnableEditControls()
    {
        LoginTextBox.IsEnabled = true;
        PasswordTextBox.IsEnabled = true;
        AdminRadio.IsEnabled = true;
        UserRadio.IsEnabled = true;
        BannedCheckBox.IsEnabled = true;
    }

    private void DisableEditControls()
    {
        LoginTextBox.IsEnabled = false;
        PasswordTextBox.IsEnabled = false;
        AdminRadio.IsEnabled = false;
        UserRadio.IsEnabled = false;
        BannedCheckBox.IsEnabled = false;
    }

    private void UpdateUserInfo()
    {
        if (_selectedUser == null) return;

        var role = _selectedUser.Admin == true ? "Администратор" : "Обычный пользователь";
        var status = _selectedUser.Banned == true ? "Заблокирован" : "Активен";

        UserInfoText.Text = $"ID: {_selectedUser.Id}\n" +
                           $"Логин: {_selectedUser.Login}\n" +
                           $"Роль: {role}\n" +
                           $"Статус: {status}";
    }

    //private async void AddUser_Click(object sender, RoutedEventArgs e)
    //{
    //    var dialog = new AddUserWindow();
    //    var result = await dialog.ShowDialog<bool?>(this);

    //    if (result == true)
    //    {
    //        var newUser = dialog.NewUser;
    //        if (UserService.AddUser(newUser))
    //        {
    //            await ShowMessage("Успех", "Пользователь успешно добавлен.");
    //            LoadUsers();
    //        }
    //        else
    //        {
    //            await ShowMessage("Ошибка", "Пользователь с таким логином уже существует.");
    //        }
    //    }
    //}

    private async void SaveUser_Click(object sender, RoutedEventArgs e)
    {
        if (_selectedUser == null)
        {
            await ShowMessage("Ошибка", "Выберите пользователя для редактирования.");
            return;
        }

        var login = LoginTextBox.Text?.Trim();
        var password = PasswordTextBox.Text?.Trim();

        if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
        {
            await ShowMessage("Ошибка", "Заполните все поля.");
            return;
        }

        var updatedUser = new User
        {
            Id = _selectedUser.Id,
            Login = login,
            Password = password,
            Admin = AdminRadio.IsChecked == true,
            Userdefault = UserRadio.IsChecked == true,
            Banned = BannedCheckBox.IsChecked
        };

        //if (UserService.UpdateUser(updatedUser))
        //{
        //    await ShowMessage("Успех", "Данные пользователя обновлены.");
        //    LoadUsers();
        //}
        //else
        //{
        //    await ShowMessage("Ошибка", "Пользователь с таким логином уже существует.");
        //}
    }

    private async void UnbanUser_Click(object sender, RoutedEventArgs e)
    {
        //if (_selectedUser == null)
        //{
        //    await ShowMessage("Ошибка", "Выберите пользователя для снятия блокировки.");
        //    return;
        //}

        //UserService.UnbanUser(_selectedUser.Id);
        //await ShowMessage("Успех", $"Блокировка с пользователя {_selectedUser.Login} снята.");
        //LoadUsers();
    }

    private async void DeleteUser_Click(object sender, RoutedEventArgs e)
    {
        if (_selectedUser == null)
        {
            await ShowMessage("Ошибка", "Выберите пользователя для удаления.");
            return;
        }

        if (_selectedUser.Admin == true)
        {
            await ShowMessage("Ошибка", "Нельзя удалить администратора.");
            return;
        }

        var result = await ShowConfirmation("Подтверждение",
            $"Вы уверены, что хотите удалить пользователя {_selectedUser.Login}?");

        if (result)
        {
            //if (UserService.DeleteUser(_selectedUser.Id))
            //{
            //    await ShowMessage("Успех", "Пользователь удален.");
            //    LoadUsers();
            //}
        }
    }

    private void RefreshUsers_Click(object sender, RoutedEventArgs e)
    {
        LoadUsers();
    }

    private async System.Threading.Tasks.Task ShowMessage(string title, string message)
    {
        var dialog = new Window
        {
            Title = title,
            Width = 300,
            Height = 150,
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };

        var stackPanel = new StackPanel();
        stackPanel.Children.Add(new TextBlock
        {
            Text = message,
            Margin = new Thickness(20),
            TextWrapping = Avalonia.Media.TextWrapping.Wrap
        });

        var button = new Button
        {
            Content = "OK",
            Margin = new Thickness(20),
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center
        };
        button.Click += (s, e) => dialog.Close();
        stackPanel.Children.Add(button);

        dialog.Content = stackPanel;
        await dialog.ShowDialog(this);
    }

    private async System.Threading.Tasks.Task<bool> ShowConfirmation(string title, string message)
    {
        var result = false;
        var dialog = new Window
        {
            Title = title,
            Width = 350,
            Height = 170,
            WindowStartupLocation = WindowStartupLocation.CenterOwner
        };

        var stackPanel = new StackPanel();
        stackPanel.Children.Add(new TextBlock
        {
            Text = message,
            Margin = new Thickness(20),
            TextWrapping = Avalonia.Media.TextWrapping.Wrap
        });

        var buttonPanel = new StackPanel
        {
            Orientation = Avalonia.Layout.Orientation.Horizontal,
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center
        };

        var yesButton = new Button
        {
            Content = "Да",
            Margin = new Thickness(5),
            Padding = new Thickness(10, 5)
        };
        yesButton.Click += (s, e) => { result = true; dialog.Close(); };

        var noButton = new Button
        {
            Content = "Нет",
            Margin = new Thickness(5),
            Padding = new Thickness(10, 5)
        };
        noButton.Click += (s, e) => { result = false; dialog.Close(); };

        buttonPanel.Children.Add(yesButton);
        buttonPanel.Children.Add(noButton);
        stackPanel.Children.Add(buttonPanel);

        dialog.Content = stackPanel;
        await dialog.ShowDialog(this);

        return result;
    }
}