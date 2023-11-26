using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeachersHandsBooks.Core;
using TeachersHandsBooks.Core.Tables;

namespace TeachersHandsBooks
{
    public partial class MechanismoFAddingPairs : MaterialForm
    {
        private DatabaseContext context = new DatabaseContext();
        private ThemeSettings themeSettings;
        public List<string> EmptyPairsForDay { get; set; } = new List<string>();
        public string Pair { get; set; }
        public string Discipline { get; set; }
        public string Group { get; set; }
        public bool IsThemeChecked { get; set; }
        // Метод для получения доступных пар на определенный день
        //private List<string> GetAvailableEmptyPairsForDay(string dayOfWeek)
        //{
        //    List<string> emptyPairsForDay = new List<string>();

        //    foreach (var emptyCell in Emty)
        //    {
        //        if (emptyCell.DayOfWeek.Equals(dayOfWeek, StringComparison.OrdinalIgnoreCase))
        //        {
        //            emptyPairsForDay.Add(emptyCell.Pair);
        //        }
        //    }

        //    return emptyPairsForDay;
        //}

        public MechanismoFAddingPairs(ThemeSettings theme)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            this.themeSettings = theme;
        }
        private void LoadGetData()
        {
            DataLabel.Text = TransmissionOfInformation.Data;
            DayWeekLabel.Text = TransmissionOfInformation.DayWeek;
            DataGridViewComboBoxColumn pairColumn = new DataGridViewComboBoxColumn();
            pairColumn.HeaderText = "Пары";
            pairColumn.Name = "PairColumn";
            pairColumn.DataSource = EmptyPairsForDay;    //GetAvailableEmptyPairsForDay(DayWeekLabel.Text);
            pairColumn.DataPropertyName = "Pair";
            pairColumn.FlatStyle = FlatStyle.Popup;
            GridAddPair.Columns.Add(pairColumn);

            
            DataGridViewComboBoxColumn disciplineColumn = new DataGridViewComboBoxColumn();
            disciplineColumn.HeaderText = "Дисциплина";
            disciplineColumn.Name = "DisciplineColumn"; 
            disciplineColumn.DataSource = null;
            disciplineColumn.DataPropertyName = "Discipline";
            disciplineColumn.FlatStyle = FlatStyle.Popup;
            GridAddPair.Columns.Add(disciplineColumn);

            DataGridViewComboBoxColumn groupColumn = new DataGridViewComboBoxColumn();
            groupColumn.HeaderText = "Группа";
            groupColumn.Name = "GroupColumn"; 
            groupColumn.DataSource = null;
            groupColumn.DataPropertyName = "Group";
            groupColumn.FlatStyle = FlatStyle.Popup;
            GridAddPair.Columns.Add(groupColumn);

        }
        private void LoadSetting()
        {
            if (IsThemeChecked)
            {
                GridAddPair.BackgroundColor = Color.FromArgb(50, 50, 50);
                GridAddPair.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Dark;
            }
            else if (!IsThemeChecked)
            {
                GridAddPair.BackgroundColor = Color.WhiteSmoke;
                GridAddPair.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Teal;
            }
          
        }
        private void MechanismoFAddingPairs_Load(object sender, EventArgs e)
        {
            LoadGetData();
            LoadSetting();
        }

        private void BtnAddPairs_Click(object sender, EventArgs e)
        {

        }
    }
}
