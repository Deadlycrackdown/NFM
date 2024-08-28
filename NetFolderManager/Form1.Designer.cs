
namespace NetFolderManager
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.addButton = new MetroFramework.Controls.MetroButton();
            this.networkFoldersListBox = new System.Windows.Forms.ListBox();
            this.folderPathTextBox = new MetroFramework.Controls.MetroTextBox();
            this.usernameTextBox = new MetroFramework.Controls.MetroTextBox();
            this.passwordTextBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.importButton = new MetroFramework.Controls.MetroButton();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.nameLabel = new MetroFramework.Controls.MetroLabel();
            this.timerLabelPrint = new System.Windows.Forms.Timer(this.components);
            this.DuranInvisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.clearAllButton = new MetroFramework.Controls.MetroButton();
            this.autorLabel = new MetroFramework.Controls.MetroLabel();
            this.metroToolTip = new MetroFramework.Components.MetroToolTip();
            this.deleteButton = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(359, 230);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(177, 23);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Добавить";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // networkFoldersListBox
            // 
            this.networkFoldersListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.networkFoldersListBox.FormattingEnabled = true;
            this.networkFoldersListBox.ItemHeight = 20;
            this.networkFoldersListBox.Location = new System.Drawing.Point(23, 91);
            this.networkFoldersListBox.Name = "networkFoldersListBox";
            this.networkFoldersListBox.Size = new System.Drawing.Size(284, 284);
            this.networkFoldersListBox.TabIndex = 1;
            this.networkFoldersListBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.networkFoldersListBox_MouseDoubleClick);
            // 
            // folderPathTextBox
            // 
            this.folderPathTextBox.Location = new System.Drawing.Point(359, 91);
            this.folderPathTextBox.Name = "folderPathTextBox";
            this.folderPathTextBox.Size = new System.Drawing.Size(177, 23);
            this.folderPathTextBox.TabIndex = 2;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(359, 139);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(177, 23);
            this.usernameTextBox.TabIndex = 3;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(359, 187);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(177, 23);
            this.passwordTextBox.TabIndex = 4;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(359, 69);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(147, 19);
            this.metroLabel1.TabIndex = 5;
            this.metroLabel1.Text = "Путь до сетевой папки";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(359, 117);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(122, 19);
            this.metroLabel2.TabIndex = 6;
            this.metroLabel2.Text = "Имя пользователя";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(359, 165);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(54, 19);
            this.metroLabel3.TabIndex = 7;
            this.metroLabel3.Text = "Пароль";
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(358, 352);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(177, 23);
            this.importButton.TabIndex = 8;
            this.importButton.Text = "Импорт данных[Эксперт]";
            this.importButton.Visible = false;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(74, 69);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(172, 19);
            this.metroLabel4.TabIndex = 9;
            this.metroLabel4.Text = "Добавленные соединения";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(74, 32);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(0, 0);
            this.nameLabel.TabIndex = 10;
            // 
            // DuranInvisibleCheckBox
            // 
            this.DuranInvisibleCheckBox.AutoSize = true;
            this.DuranInvisibleCheckBox.Location = new System.Drawing.Point(359, 381);
            this.DuranInvisibleCheckBox.Name = "DuranInvisibleCheckBox";
            this.DuranInvisibleCheckBox.Size = new System.Drawing.Size(111, 17);
            this.DuranInvisibleCheckBox.TabIndex = 11;
            this.DuranInvisibleCheckBox.Text = "Режим эксперта";
            this.DuranInvisibleCheckBox.UseVisualStyleBackColor = true;
            this.DuranInvisibleCheckBox.Visible = false;
            this.DuranInvisibleCheckBox.CheckedChanged += new System.EventHandler(this.DuranInvisibleCheckBox_CheckedChanged);
            // 
            // clearAllButton
            // 
            this.clearAllButton.Location = new System.Drawing.Point(358, 323);
            this.clearAllButton.Name = "clearAllButton";
            this.clearAllButton.Size = new System.Drawing.Size(177, 23);
            this.clearAllButton.TabIndex = 12;
            this.clearAllButton.Text = "Очистить все соединения";
            this.clearAllButton.Visible = false;
            this.clearAllButton.Click += new System.EventHandler(this.clearAllButton_Click);
            // 
            // autorLabel
            // 
            this.autorLabel.AutoSize = true;
            this.autorLabel.Location = new System.Drawing.Point(23, 411);
            this.autorLabel.Name = "autorLabel";
            this.autorLabel.Size = new System.Drawing.Size(201, 19);
            this.autorLabel.TabIndex = 13;
            this.autorLabel.Text = "developed by Nuriev R. (ver. 1.01)";
            this.autorLabel.Visible = false;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(359, 294);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(177, 23);
            this.deleteButton.TabIndex = 14;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.Visible = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(568, 450);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.autorLabel);
            this.Controls.Add(this.clearAllButton);
            this.Controls.Add(this.DuranInvisibleCheckBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.folderPathTextBox);
            this.Controls.Add(this.networkFoldersListBox);
            this.Controls.Add(this.addButton);
            this.Name = "Form1";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Text = "NFM";
            this.Theme = MetroFramework.MetroThemeStyle.Light;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton addButton;
        private System.Windows.Forms.ListBox networkFoldersListBox;
        private MetroFramework.Controls.MetroTextBox folderPathTextBox;
        private MetroFramework.Controls.MetroTextBox usernameTextBox;
        private MetroFramework.Controls.MetroTextBox passwordTextBox;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroButton importButton;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel nameLabel;
        private System.Windows.Forms.Timer timerLabelPrint;
        private System.Windows.Forms.CheckBox DuranInvisibleCheckBox;
        private MetroFramework.Controls.MetroButton clearAllButton;
        private MetroFramework.Controls.MetroLabel autorLabel;
        private MetroFramework.Components.MetroToolTip metroToolTip;
        private MetroFramework.Controls.MetroButton deleteButton;
    }
}

