using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MetroFramework.Forms;
using Newtonsoft.Json;

namespace NetFolderManager
{
    public partial class Form1 : MetroForm
    {
        private List<NetworkConnection> networkConnections = new List<NetworkConnection>();
        private int currentIndex = 0;
        private const string labelText = "Network Folder Manager";
        private const string NetworkConnectionsFile = "network_connections.json";

        public Form1()
        {
            InitializeComponent();
            InitializeTimers();
            InitializeTooltips();
        }

        private void InitializeTimers()
        {
            timerLabelPrint.Tick += TimerLabelPrint_Tick;
            timerLabelPrint.Interval = 100;
            timerLabelPrint.Start();
        }

        private void InitializeTooltips()
        {
            metroToolTip.SetToolTip(addButton, "Нажмите, чтобы добавить новое сетевое соединение");
            metroToolTip.SetToolTip(folderPathTextBox, "Пример: \\\\число.число.число.число\\имя_папки");
            metroToolTip.SetToolTip(usernameTextBox, "Логин от сетевого соединения (Это не логин 1С и учетной записи Windows)");
            metroToolTip.SetToolTip(passwordTextBox, "Пароль от сетевого соединения (Это не пароль от вашей учетной записи)");
        }

        private void TimerLabelPrint_Tick(object sender, EventArgs e)
        {
            if (currentIndex < labelText.Length)
            {
                nameLabel.Text += labelText[currentIndex];
                currentIndex++;
            }
            else
            {
                timerLabelPrint.Stop();
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string folderPath = folderPathTextBox.Text.Trim();
            string username = usernameTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(folderPath) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля для добавления сетевой папки.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (networkConnections.Any(connection => connection.FolderPath.Equals(folderPath, StringComparison.OrdinalIgnoreCase) &&
                                                      connection.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Эта сетевая папка уже добавлена с этими учетными данными.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NetworkConnection newConnection = new NetworkConnection(folderPath, username, password);
            networkConnections.Add(newConnection);

            networkFoldersListBox.Items.Add(newConnection.ToString());

            folderPathTextBox.Clear();
            usernameTextBox.Clear();
            passwordTextBox.Clear();

            SaveNetworkConnections();
        }

        private void networkFoldersListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (networkFoldersListBox.SelectedIndex != -1)
            {
                NetworkConnection selectedConnection = networkConnections[networkFoldersListBox.SelectedIndex];
                ConnectToNetworkFolder(selectedConnection);
            }
        }

        private void ConnectToNetworkFolder(NetworkConnection connection)
        {
            if (IsNetworkFolderOpen(connection.FolderPath))
            {
                DialogResult result = MessageBox.Show(
                    "Данное сетевое расположение уже открыто. Необходимо закрыть предыдущее расположение перед открытием нового. Хотите закрыть текущее расположение?",
                    "Предупреждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    CloseNetworkFolder(connection.FolderPath);
                    OpenNetworkFolder(connection);
                }
            }
            else
            {
                OpenNetworkFolder(connection);
            }
        }

        private bool IsNetworkFolderOpen(string folderPath)
        {
            var cmd = $"/c net use | find \"{folderPath}\"";
            return ExecuteCommand(cmd) == 0;
        }

        private void OpenNetworkFolder(NetworkConnection connection)
        {
            var cmd = $"/c net use {connection.FolderPath} /user:{connection.Username} {connection.Password} /persistent:yes";
            ExecuteCommand(cmd);

            cmd = $"/c explorer \"{connection.FolderPath}\"";
            ExecuteCommand(cmd);
        }

        private void CloseNetworkFolder(string folderPath)
        {
            var cmd = $"/c net use /delete /y \"{folderPath}\"";
            ExecuteCommand(cmd);
        }

        private void RemoveAllNetworkConnections()
        {
            foreach (NetworkConnection connection in networkConnections)
            {
                CloseNetworkFolder(connection.FolderPath);
            }
        }

        private void DuranInvisibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool isVisible = DuranInvisibleCheckBox.Checked;
            clearAllButton.Visible = isVisible;
            importButton.Visible = isVisible;
            autorLabel.Visible = isVisible;
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*",
                Title = "Выберите файл для импорта"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    string[] lines = File.ReadAllLines(filePath);

                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        if (parts.Length >= 3)
                        {
                            string folderPath = parts[0];
                            string username = parts[1];
                            string password = parts[2];

                            NetworkConnection newConnection = new NetworkConnection(folderPath, username, password);

                            if (!networkConnections.Any(connection => connection.FolderPath.Equals(folderPath, StringComparison.OrdinalIgnoreCase) &&
                                                                       connection.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
                            {
                                networkConnections.Add(newConnection);
                                networkFoldersListBox.Items.Add(newConnection.ToString());
                            }
                            else
                            {
                                MessageBox.Show($"Сетевая папка {folderPath} уже добавлена с этими учетными данными.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Неправильный формат строки: {line}. Строка должна быть в формате: FOLDER NAME PASSWORD", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    MessageBox.Show("Сетевые папки успешно импортированы.", "Импорт завершен", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при импорте сетевых папок: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                SaveNetworkConnections();
            }
        }

        private void clearAllButton_Click(object sender, EventArgs e)
        {
            networkConnections.Clear();
            networkFoldersListBox.Items.Clear();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D5)
            {
                DuranInvisibleCheckBox.Visible = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            LoadNetworkConnections();
        }

        private void SaveNetworkConnections()
        {
            try
            {
                string json = JsonConvert.SerializeObject(networkConnections, Formatting.Indented);
                File.WriteAllText(NetworkConnectionsFile, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении сетевых подключений: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadNetworkConnections()
        {
            try
            {
                if (File.Exists(NetworkConnectionsFile))
                {
                    string json = File.ReadAllText(NetworkConnectionsFile);
                    networkConnections = JsonConvert.DeserializeObject<List<NetworkConnection>>(json) ?? new List<NetworkConnection>();

                    foreach (NetworkConnection connection in networkConnections)
                    {
                        networkFoldersListBox.Items.Add(connection.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке сетевых подключений: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int ExecuteCommand(string cmd)
        {
            var process = new System.Diagnostics.Process
            {
                StartInfo = new System.Diagnostics.ProcessStartInfo
                {
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = cmd
                }
            };
            process.Start();
            process.WaitForExit();
            return process.ExitCode;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveNetworkConnections();
        }

        [Serializable]
        public class NetworkConnection
        {
            public string FolderPath { get; set; }
            public string Username { get;  set; }
            public string Password { get; set; }

            public NetworkConnection(string folderPath, string username, string password)
            {
                FolderPath = folderPath;
                Username = username;
                Password = password;
            }

            public override string ToString()
            {
                return $"{FolderPath} ({Username})";
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

        }
    }
}
