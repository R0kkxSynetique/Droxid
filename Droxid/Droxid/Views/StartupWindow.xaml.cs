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
        private string _password = "";

        private string _defaultConfigPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\droxid\\" + "config.json";
        private string _defaultDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private string _appDataDroxidDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\droxid";
        private string _configFilePath;

        private StartupWindowViewModel? _vm;

        private bool _success;
        private bool _firstTime;


        public StartupWindow()
        {
            InitializeComponent();
            _success = false;
            _firstTime = false;
            _configFilePath = _defaultConfigPath;
            _vm = this.DataContext as StartupWindowViewModel;

            if (!Directory.Exists(_appDataDroxidDirectory))
            {
                Directory.CreateDirectory(_appDataDroxidDirectory);
            }

            if (File.Exists(_defaultConfigPath))
            {
                ImportConfig(_defaultConfigPath);
            }
            else
            {
                CreateConfigFile();
            }

        }


        public string? Username { get => _username; }
        public bool Success { get => _success; }

        private async void OnConnect_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                button.IsEnabled = false;

                if (!String.IsNullOrWhiteSpace(txtDBServer.Text) && !String.IsNullOrWhiteSpace(txtDBUser.Text) && !String.IsNullOrWhiteSpace(txtDBName.Text) && !String.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    _dbServer = txtDBServer.Text;
                    _dbPassword = txtDBPassword.Text;
                    _dbUser = txtDBUser.Text;
                    _dbName = txtDBName.Text;
                    _username = txtUsername.Text;
                    _configFilePath = txtPath.Text;
                }
                if (await Task<bool>.Run(() => ViewModel.TestConnection(_dbServer, _dbName, _dbUser, _dbPassword)))
                {
                    dbHeader.Background = (Brush)new BrushConverter().ConvertFrom("#36393f");
                    if (await Task<bool>.Run(() => _vm.LoginAs(_username)))
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

                button.IsEnabled = true;
            }
        }

        private void OnImportConfig_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = _defaultDirectory;
            openFileDialog.Filter = "All files (*.json)|*.json";

            if (openFileDialog.ShowDialog() == true)
            {
                if (openFileDialog.FileName != null)
                {
                    txtPath.Text = openFileDialog.FileName;
                    ImportConfig(txtPath.Text);
                }
            }
        }

        private void OnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtDBServer.Text) && !String.IsNullOrWhiteSpace(txtDBUser.Text) && !String.IsNullOrWhiteSpace(txtDBName.Text) && !String.IsNullOrWhiteSpace(txtUsername.Text))
            {
                _dbServer = txtDBServer.Text;
                _dbPassword = txtDBPassword.Text;
                _dbUser = txtDBUser.Text;
                _dbName = txtDBName.Text;
                _username = txtUsername.Text;

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

                r.Close();

                JObject result = JObject.Parse(json);

                txtDBServer.Text = (string)result["DBConnection"]["Server"];
                txtDBName.Text = (string)result["DBConnection"]["Database"];
                txtDBUser.Text = (string)result["DBConnection"]["User"];
                txtDBPassword.Text = (string)result["DBConnection"]["Password"];

                txtUsername.Text = (string)result["Client"]["Username"];
            }
        }

        private void SaveConfig()
        {
            StreamReader r = new StreamReader(_configFilePath);

            string json = r.ReadToEnd();

            r.Close();

            JObject result = JObject.Parse(json);
            JObject configurations = (JObject)result;

            configurations["DBConnection"]["Server"] = _dbServer;
            configurations["DBConnection"]["Database"] = _dbName;
            configurations["DBConnection"]["User"] = _dbUser;
            configurations["DBConnection"]["Password"] = _dbPassword;

            configurations["Client"]["Username"] = _username;
            configurations["Client"]["Password"] = _password;

            using (StreamWriter file = File.CreateText(_configFilePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, configurations);
            }
        }

        private void CreateConfigFile()
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
                    },
                    Client = new
                    {
                        Username = _username,
                        Password = _password
                    }
                });
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, json);
            }
        }

        private void EnableSaveButton(object sender, KeyEventArgs e)
        {
            if ((e.Key >= Key.A && e.Key <= Key.Z) || (e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || (e.Key == Key.Delete) || (e.Key == Key.Back))
            {
                btnSave.IsEnabled = true;
            }
        }
    }
}

