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

namespace TeachersHandsBooks
{
    public partial class FormationRasp : MaterialForm
    {
        private ThemeSettings themeSettings;
        DatabaseContext context = new DatabaseContext();
        public FormationRasp(ThemeSettings theme)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            this.themeSettings = theme;
        }

        private DataGridViewCellStyle SetDataGridViewStyleFromTheme(DataGridView dataGridView, ThemeSettings setting)
        {
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            if (!string.IsNullOrEmpty(setting.ColorTheme) && setting.ColorTheme != "Transparent")
            {
                Color selectedColor;
                try
                {
                    selectedColor = ColorTranslator.FromHtml(setting.ColorTheme); 

     

                    headerStyle.BackColor = selectedColor;

         
                    dataGridView.ColumnHeadersDefaultCellStyle = headerStyle;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
              
                }

            }
            return headerStyle;
        }


        private Color GetColorFromTheme(ThemeSettings setting)
        {
            Color selectedColor = Color.White;

            if (!string.IsNullOrEmpty(setting.ColorTheme) && setting.ColorTheme != "Transparent")
            {
                try
                {
                    selectedColor = Color.FromName(setting.ColorTheme);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    // Если возникла ошибка, установим цвет по умолчанию
                    selectedColor = Color.White;
                }
            }

            return selectedColor;
        }


        private void ShowsPairsANDDay()
        {
            var pairs = context.Pairs.Select(p => p.Pair).ToList();

            // Получаем дни недели из базы данных
            var daysOfWeek = context.DayTables.Select(d => d.Day).ToList();

            // Очистить все предыдущие столбцы и строки, если нужно
            GridRasp.Columns.Clear();
            GridRasp.Rows.Clear();

            // Добавляем столбец для номеров пар
            DataGridViewTextBoxColumn pairsColumn = new DataGridViewTextBoxColumn();
            pairsColumn.HeaderText = "Пары";
            pairsColumn.Name = "PairsColumn";
            GridRasp.Columns.Add(pairsColumn);

            // Добавляем заголовки дней недели как столбцы
            foreach (var day in daysOfWeek)
            {
                GridRasp.Columns.Add(day, day);
                GridRasp.Columns[day].Visible = true;
            }

            // Добавляем пары в столбец "Пары"
            foreach (var pair in pairs)
            {
                int rowIndex = GridRasp.Rows.Add(pair);

                
               
            }
            GridRasp.Columns["PairsColumn"].ReadOnly = true;
        }
       
        private void AddRows()
        {

        }
        private void FormationRasp_Load(object sender, EventArgs e)
        {

            ShowsPairsANDDay();
            GridRasp.ColumnHeadersDefaultCellStyle = SetDataGridViewStyleFromTheme(GridRasp, themeSettings);
            GridRasp.ColumnHeadersDefaultCellStyle.SelectionBackColor = GetColorFromTheme(themeSettings);

        }
    }
}
