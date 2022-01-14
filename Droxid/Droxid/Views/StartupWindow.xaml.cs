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
using System.Windows.Shapes;
using Droxid.ViewModels;
using System.IO;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Droxid.Views
{
    /// <summary>
    /// Interaction logic for StartupWindow.xaml
    /// </summary>
    public partial class StartupWindow : Window
    {
        private string _dbServer = "";
        private string _dbPassword = "";
        private string _dbUser = "";
        private string _dbName = "";
        private string _username = "";
        private string _configFilePath;
        private string _defaultConfigPath = AppDomain.CurrentDomain.BaseDirectory + "config.drxd";
        private string _defaultDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private StartupWindowViewModel? _vm;
        private bool _success;


        public StartupWindow()
        {
            InitializeComponent();
            _success = false;
            _vm = this.DataContext as StartupWindowViewModel;

            if (File.Exists(_defaultConfigPath))
            {
                ImportConfig(_defaultConfigPath);
            }
        }


        public string? Username { get => _username; }
        public bool Success { get => _success; }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtDBServer.Text) && !String.IsNullOrWhiteSpace(txtDBUser.Text) && !String.IsNullOrWhiteSpace(txtDBName.Text) && !String.IsNullOrWhiteSpace(txtUsername.Text))
            {
                _dbServer = txtDBServer.Text;
                _dbPassword = txtDBPassword.Text;
                _dbUser = txtDBUser.Text;
                _dbName = txtDBName.Text;
                _username = txtUsername.Text;
                _configFilePath = txtPath.Text;
            }

            if (ViewModel.TestConnection(_dbServer, _dbName, _dbUser, _dbPassword))
            {
                dbHeader.Background = (Brush)new BrushConverter().ConvertFrom("#36393f");
                if (_vm.LoginAs(_username))
                {
                    appHeader.Background = (Brush)new BrushConverter().ConvertFrom("#36393f");
                    _success = true;
                    this.Close();
                }
                else
                {
                    appHeader.Background = new SolidColorBrush(Colors.Red);
                }
            }
            else
            {
                dbHeader.Background = new SolidColorBrush(Colors.Red);
            }
        }

        private void btnImportConfig_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = _defaultDirectory;
            openFileDialog.Filter = "All files (*.drxd)|*.drxd";

            if (openFileDialog.ShowDialog() == true)
            {
                if (openFileDialog.FileName != null)
                {
                    txtPath.Text = openFileDialog.FileName;
                    ImportConfig(txtPath.Text);
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtDBServer.Text) && !String.IsNullOrWhiteSpace(txtDBUser.Text) && !String.IsNullOrWhiteSpace(txtDBName.Text) && !String.IsNullOrWhiteSpace(txtUsername.Text))
            {
                _dbServer = txtDBServer.Text;
                _dbPassword = txtDBPassword.Text;
                _dbUser = txtDBUser.Text;
                _dbName = txtDBName.Text;
                _username = txtUsername.Text;
                _configFilePath = txtPath.Text;

                if (File.Exists(_defaultConfigPath))
                {
                    if (MessageBox.Show("Le Fichier de configuration existe déjà. Voulez-vous l'écraser avec celui-ci?", "Fichier Existant!", MessageBoxButton.YesNo, MessageBoxImage.Information, MessageBoxResult.No) == MessageBoxResult.Yes)
                    {
                        SaveConfig();
                    }
                }
                else
                {
                    SaveConfig();
                    MessageBox.Show("Configuration sauvée!", "Sauvgarde", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void ImportConfig(string fileName)
        {
            if (File.ReadAllText(fileName).Length != 0)
            {

                StreamReader r = new StreamReader(fileName);

                string json = r.ReadToEnd();

                JObject result = JObject.Parse(json);

                txtDBServer.Text = (string)result["DBConnection"]["Server"];
                txtDBName.Text = (string)result["DBConnection"]["Database"];
                txtDBUser.Text = (string)result["DBConnection"]["User"];
                txtDBPassword.Text = (string)result["DBConnection"]["Password"];
            }
        }

        private void SaveConfig()
        {
            using (StreamWriter file = File.CreateText(_configFilePath))
            {
                JObject json = JObject.FromObject(new
                {
                    DBConnection = new
                    {
                        Server = _dbServer,
                        Database = _dbName,
                        User = _dbUser,
                        Password = _dbPassword
                    }
                });
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, json);
            }
        }
    }
}

