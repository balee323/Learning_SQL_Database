using Notes_CRUD_App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notes_CRUD_App
{
    public partial class Form1 : Form
    {
        private DatabaseAccessManager _databaseAccessManager;

        private int _tabIterator = 1;

        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Add("Note");


            var newTab = tabControl1.TabPages[tabControl1.TabPages.Count - 1];

            newTab.Controls.Add(CreateSaveButton());
            newTab.Controls.Add(CreateCloseTabButton());
            newTab.Controls.Add(CreateNoteTextBox(newTab));

            tabControl1.SelectTab(newTab);

            _tabIterator++;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _databaseAccessManager = new DatabaseAccessManager();
            LoadUserList();            
        }

        private void LoadUserList()
        {
                      
            comboBox1.DataSource = _databaseAccessManager.GetUsers();
            comboBox1.ValueMember = "UserID";
            comboBox1.DisplayMember = "FullName";

            comboBox1.Text = "Please select a user.";
  
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clear checkListBox
            checkedListBox1.Items.Clear();

            var selectedUser = (User)comboBox1.SelectedItem;
            checkedListBox1.Items.AddRange(
                _databaseAccessManager.GetNotes(selectedUser.UserID).ToArray<Note>());

            this.checkedListBox1.SelectionMode = SelectionMode.One;
            this.checkedListBox1.DisplayMember = "NoteBody";
                               
        }


        private Button CreateSaveButton()
        {
            var button = new System.Windows.Forms.Button();

            button.Location = new System.Drawing.Point(796, 6);
            button.Name = "button" + _tabIterator;
            button.Size = new System.Drawing.Size(113, 68);
            button.TabIndex = 2;
            button.Text = "Save";
            button.UseVisualStyleBackColor = true;

            return button;
        }

        private Button CreateCloseTabButton()
        {
            var button = new System.Windows.Forms.Button();

            button.Location = new System.Drawing.Point(665, 6);
            button.Name = "btnClose" + _tabIterator;
            button.Size = new System.Drawing.Size(113, 68);
            button.TabIndex = 3;
            button.Text = "Close";
            button.UseVisualStyleBackColor = true;
            button.Click += new System.EventHandler(this.CloseTab_Click);

            return button;
        }


        private TextBox CreateNoteTextBox(TabPage tab)
        {
            Note note = (Note)checkedListBox1.SelectedItem;

            var textBox = new System.Windows.Forms.TextBox();

            textBox.Location = new System.Drawing.Point(18, 87);
            textBox.Multiline = true;
            textBox.Name = "textBox" + _tabIterator;
            textBox.Size = new System.Drawing.Size(891, 393);
            textBox.TabIndex = 1;
            textBox.Text = note.NoteBody;
            textBox.Select(0, 0);

            CreateNoteDateLabel(tab, note);

            return textBox;
        }


        private void CreateNoteDateLabel(TabPage tab, Note note)
        {
            var label = new System.Windows.Forms.Label();

            label.AutoSize = true;
            label.Location = new System.Drawing.Point(15, 34);
            label.Name = "label" + _tabIterator;
            label.Size = new System.Drawing.Size(56, 13);
            label.TabIndex = 0;
            label.Text = note.NoteDate.ToString();

            tab.Controls.Add(label);
        }


        private void CloseTab_Click(object sender, EventArgs e)
        {
            var tabPage = tabControl1.SelectedTab;
            tabControl1.TabPages.Remove(tabPage);
        }
    }
}
