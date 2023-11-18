using Guna.UI2.WinForms;
using MaterialSkin;
using MaterialSkin.Controls;
using OfficeOpenXml;
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
using LicenseContext = OfficeOpenXml.LicenseContext;
using Displine = TeachersHandsBooks.Core.Tables.Displine;
using KTP = TeachersHandsBooks.Core.Tables.KTP;
using System.IO;
using TeachersHandsBooks.Core.Tables;

namespace TeachersHandsBooks
{
    public partial class FormAddKTP : MaterialForm
    {
        private ThemeSettings themeSettings;
        DatabaseContext context = new DatabaseContext();
        public FormAddKTP(ThemeSettings theme)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            this.themeSettings = theme;
            DataGridViewComboBoxColumn comboBoxColumn = (DataGridViewComboBoxColumn)GridKTPControll.Columns["Displines"];
            Displine.FillDisciplinesComboBoxColumn(comboBoxColumn);

        }

        private void GetNamesFromIds(int groupId, int disciplineId, int ktpId)
        {
            using (var context = new DatabaseContext())
            {
                var groupName = context.Groups.FirstOrDefault(g => g.ID == groupId)?.NameGroup;
                var disciplineName = context.Displines.FirstOrDefault(d => d.ID == disciplineId)?.NameDispline;
                var ktpName = context.kTPs.FirstOrDefault(k => k.ID == ktpId)?.NameKTP;

                // Делайте что-то с полученными именами (например, выводите их в консоль)

            }
        }
        private bool IsKTPLoaded = false;
        private void ShowsConnect()
            {

                if (SelectedPath == null)
                {
                using (var context = new DatabaseContext())
                {
                    var allDisplineWithGroup = context.ConnectWithGroup.ToList();

                    foreach (var connection in allDisplineWithGroup)
                    {
                        // Получаем имена группы, дисциплины и КТП на основе их ID
                        GetNamesFromIds(connection.Group.ID, connection.Displine.ID, connection.KTP.ID);

                        // Добавляем данные в DataGridView
                        GridKTPControll.Rows.Add(
                            connection.Group.ID, // Column1 - скрытый столбец с ID группы
                            connection.Group.NameGroup, // GroupNameColumn - имя группы
                            connection.KTP.NameKTP, // KTPS - название КТП
                            connection.Displine.NameDispline // Displines - название дисциплины
                        );
                    }
                }
                IsKTPLoaded = true;
                GridKTPControll.ReadOnly = IsKTPLoaded;
            }
        }
        private void FormAddKTP_Load(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ShowsConnect();


        }
        private string SelectedPath;
        private void label4_Click(object sender, EventArgs e)
        {
            IsKTPLoaded = true;
            GridKTPControll.ReadOnly = !IsKTPLoaded;
            openFileDialog1.Title = "Выберите файл Excel";
            openFileDialog1.Filter = "Файлы Excel|*.xlsx;*.xls|Все файлы|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Label ktplabel = new Label();
                SelectedPath = openFileDialog1.FileName;
                ktplabel.Text = SelectedPath;
                ktplabel.Width = 300;
                KTPPath.Controls.Add(ktplabel);
            }
            using (var excel = new ExcelPackage(openFileDialog1.FileName))
            {
                ExcelWorksheet worksheet = excel.Workbook.Worksheets[0];
                string NameFile = Path.GetFileName(SelectedPath);


                string groupCellValue = worksheet.Cells["B6"].Text;
                string[] parts = groupCellValue.Split('-');
                if (parts.Length > 0)
                {
                   
                    string groupName = parts[0].Trim();

                    using (var context = new DatabaseContext())
                    {
                        var group = context.Groups.FirstOrDefault(g => g.NameGroup == groupName);

                        var Ktp = context.kTPs.FirstOrDefault(b => b.NameKTP == NameFile);
                        if (group != null)
                        {
                            BtnCreateAdd.Enabled = true;

                            // Очистить данные в DataGridView перед отображением новой группы
                            GridKTPControll.Rows.Clear();

                            // Добавить данные группы в DataGridView
                            
                            var existingKtp = context.kTPs.FirstOrDefault(k => k.NameKTP == NameFile);
                         
                            if (existingKtp == null)
                            {
                                var KTP = new KTP
                                {
                                    NameKTP = NameFile
                                };
                                context.kTPs.Add(KTP);
                                context.SaveChanges();
                                existingKtp = KTP;
                            }
                            if (existingKtp != null)
                            {
                                GridKTPControll.Rows.Add(group.ID, group.NameGroup, existingKtp.NameKTP);
                            }
                            else
                            {
                                MessageBox.Show("КТП уже существует ");
                            }
                           


                        }
                        else
                        {
                            MessageBox.Show("Группа не найдена в документе базы данных!", "Поиск не удался", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                       
                    }


                }
            }
        }
        private bool AreAllDisciplinesSelected(DataGridView dataGridView)
        {
            bool allDisciplinesSelected = true;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                DataGridViewComboBoxCell comboBoxCell = row.Cells["Displines"] as DataGridViewComboBoxCell;

                if (comboBoxCell != null)
                {
                    if (comboBoxCell.Value == null || comboBoxCell.Value.ToString() == "")
                    {
                        allDisciplinesSelected = false;
                        break;
                    }
                }
            }

            return allDisciplinesSelected;
        }
        private void BtnCreateAdd_Click(object sender, EventArgs e)
        {
            if (AreAllDisciplinesSelected(GridKTPControll))
            {
                foreach (DataGridViewRow row in GridKTPControll.Rows)
                {
                    // Получение значений из ячеек DataGridView
                    if (row.Cells["Column1"].Value != null &&
                        row.Cells["Displines"].Value != null &&
                        row.Cells["KTPs"].Value != null)
                    {
                        int groupId = Convert.ToInt32(row.Cells["Column1"].Value);
                        int DisplineID =  Convert.ToInt32(row.Cells["Displines"].Value.ToString());
                        string ktpName = row.Cells["KTPs"].Value.ToString();

                        

                        // Получаем ID КТП из базы данных по имени
                        int ktpId = context.kTPs
                                         .Where(k => k.NameKTP == ktpName)
                                         .Select(k => k.ID)
                                         .FirstOrDefault();

                        // Вызов метода AddCon для создания объекта DisplineWithGroup
                        DisplineWithGroup.AddCon(groupId, DisplineID, ktpId);
                    }

                }
                MessageBox.Show("Связь успешно установлена");
            }
            else
            {
                MessageBox.Show("Дисциплина не выбрана", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GridKTPControll_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //ignore
        }
    }
}
