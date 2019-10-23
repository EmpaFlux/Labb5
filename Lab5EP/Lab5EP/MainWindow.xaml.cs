using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab5EP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void NewUser()
        {
            UserListBox.Items.Add(new User(EnterNameTextbox.Text, EnterEmailTextbox.Text));
        }
        public bool CheckInput()
        {

            if (EnterNameTextbox.Text == null || EnterNameTextbox.Text == string.Empty)
            {
                MessageBox.Show("Please enter name.");
                return false;
            }
            else if (EnterEmailTextbox.Text == null || EnterEmailTextbox.Text == string.Empty)
            {
                MessageBox.Show("Please enter email.");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void UserCreationButton_Click(object sender, RoutedEventArgs e) //todo = conecta till CheckInput
        {
            
            NewUser();
            EnterNameTextbox.Clear();
            EnterEmailTextbox.Clear();
            AdminListBox.UnselectAll();
            UserListBox.UnselectAll();
            ButtonsDisabled();
        }

        private void DemoteButton_Click(object sender, RoutedEventArgs e)
        {
            UserListBox.Items.Add(AdminListBox.SelectedItem);
            AdminListBox.Items.Remove(AdminListBox.SelectedItem);
            ButtonsDisabled();
        }

        private void UserPromotionButton_Click(object sender, RoutedEventArgs e)
        {
            AdminListBox.Items.Add(UserListBox.SelectedItem);
            UserListBox.Items.Remove(UserListBox.SelectedItem);
            ButtonsDisabled();
        }
        public void ButtonsDisabled()
        {
            UserDeletionButton.IsEnabled = false;
            UserPromotionButton.IsEnabled = false;
            DemoteButton.IsEnabled = false;
            UsrerModificationButton.IsEnabled = false;
        }

        private void UserDeletionButton_Click(object sender, RoutedEventArgs e)
        {
            UserListBox.Items.Remove(UserListBox.SelectedItem);
            ButtonsDisabled();
        }
        private void AdminListBox_SelectionChange(object sender, SelectionChangedEventArgs e)
        {
            DemoteButton.IsEnabled = true;
            UserDeletionButton.IsEnabled = true;
            UsrerModificationButton.IsEnabled = true;
            if ((User)AdminListBox.SelectedItem != null)
            {
                UserListBox.UnselectAll();
                UserInfoLabel.Content = "Admin: " + ((User)AdminListBox.SelectedItem).UserName +
                    "\nEmail Adress: " + ((User)AdminListBox.SelectedItem).Email;
            }
            else
            {
                UserInfoLabel.Content = string.Empty;
            }
        }

        private void UserListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserPromotionButton.IsEnabled = true;
            UserDeletionButton.IsEnabled = true;
            UsrerModificationButton.IsEnabled = true;
            if ((User)UserListBox.SelectedItem != null)
            {
                AdminListBox.UnselectAll();
                UserInfoLabel.Content = "Username: " + ((User)UserListBox.SelectedItem).UserName +
                    "\nEmail Adress: " + ((User)UserListBox.SelectedItem).Email;
            }
            else
            {
                UserInfoLabel.Content = string.Empty;
            }
        }

        private void UsrerModificationButton_Click(object sender, RoutedEventArgs e)
        {
            if (((User)UserListBox.SelectedItem != null))
            {
                EnterNameTextbox.Text = ((User)UserListBox.SelectedItem).UserName;
                EnterEmailTextbox.Text = ((User)UserListBox.SelectedItem).Email;
            }
            else if (((User)AdminListBox.SelectedItem != null))
            {
                EnterNameTextbox.Text = ((User)AdminListBox.SelectedItem).UserName;
                EnterEmailTextbox.Text = ((User)AdminListBox.SelectedItem).Email;
            }
            ButtonsDisabled();
            UpdateButton.IsEnabled = true;
            UserCreationButton.IsEnabled = false;
            UserListBox.IsEnabled = false;
            AdminListBox.IsEnabled = false;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            NewUser();
            if (((User)UserListBox.SelectedItem != null))
            {
                ((User)UserListBox.SelectedItem).UserName = EnterNameTextbox.Text;
                ((User)UserListBox.SelectedItem).Email = EnterEmailTextbox.Text;
                UserListBox.Items.Remove(UserListBox.SelectedItem);
            }
            else if (((User)AdminListBox.SelectedItem != null))
            {
                ((User)AdminListBox.SelectedItem).UserName = EnterNameTextbox.Text;
                ((User)AdminListBox.SelectedItem).Email = EnterEmailTextbox.Text;
                AdminListBox.Items.Remove(AdminListBox.SelectedItem);
            }
            ButtonsDisabled();
            UpdateButton.IsEnabled = false;
            UserCreationButton.IsEnabled = true;
            UserListBox.IsEnabled = true;
            AdminListBox.IsEnabled = true;
            EnterNameTextbox.Clear();
            EnterEmailTextbox.Clear();
        }
    }
}

       