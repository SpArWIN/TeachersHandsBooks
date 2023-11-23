using MaterialSkin;
using MaterialSkin.Controls;
using OfficeOpenXml;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TeachersHandsBooks.Core;
using TeachersHandsBooks.Core.Tables;
using Displine = TeachersHandsBooks.Core.Tables.Displine;
using KTP = TeachersHandsBooks.Core.Tables.KTP;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace TeachersHandsBooks
{
    public partial class FormAddKTP : MaterialForm
    {
        private ThemeSettings themeSettings;
        DatabaseContext context = new DatabaseContext();
        private Timer progressTimer;
        private int currentProgress = 0;

        public FormAddKTP(ThemeSettings theme)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            this.themeSettings = theme;
            DataGridViewComboBoxColumn comboBoxColumn = (DataGridViewComboBoxColumn)GridKTPControll.Columns["Displines"];
            Displine.FillDisciplinesComboBoxColumn(comboBoxColumn);
            progressTimer = new Timer();
            progressTimer.Interval = 100; // Интервал обновления анимации (в миллисекундах)
            progressTimer.Tick += ProgressTimer_Tick;

        }

        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
            currentProgress += 10;
            if (currentProgress > guna2CircleProgressBar1.Maximum)
            {
                // Если достигнут максимум, останавливаем анимацию
                progressTimer.Stop();
                guna2CircleProgressBar1.Visible = false;
            }
            else
            {
                guna2CircleProgressBar1.Value = currentProgress;
            }
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
        private void ShowConnection(int ktpId)
        {
            using (var context = new DatabaseContext())
            {
                var allDisplines = context.Displines.ToList();

                // Получение ID дисциплин, связанных с выбранным КТП
                var connectedDisciplines = context.ConnectWithGroup
                    .Where(c => c.KTP.ID == ktpId)
                    .Select(c => c.Displine.ID)
                    .ToList();

                // Удаление из списка всех дисциплин тех, которые уже связаны с выбранным КТП
                foreach (var connectedDisciplineId in connectedDisciplines)
                {
                    var connectedDiscipline = allDisplines.FirstOrDefault(d => d.ID == connectedDisciplineId);
                    if (connectedDiscipline != null)
                    {
                        allDisplines.Remove(connectedDiscipline);
                    }
                }

                DataGridViewComboBoxColumn comboBoxColumn = (DataGridViewComboBoxColumn)GridKTPControll.Columns["Displines"];

                // Очистка и обновление ComboBoxColumn
                comboBoxColumn.DataSource = null;
                comboBoxColumn.Items.Clear();
                comboBoxColumn.DataSource = allDisplines;
                comboBoxColumn.DisplayMember = "NameDispline";
                comboBoxColumn.ValueMember = "ID";
            }
        }


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
                // Устанавливаем шрифт для строк в DataGridView
                foreach (DataGridViewRow row in GridKTPControll.Rows)
                {
                    row.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Regular); 
                }
                //Белый цвет заголовков
                foreach (DataGridViewColumn column in GridKTPControll.Columns)
                {
                    column.HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
                    column.HeaderCell.Style.ForeColor = Color.White;
                    
                }

                IsKTPLoaded = true;
                GridKTPControll.ReadOnly = IsKTPLoaded;
            }
        }
        private Color GetColorFromTheme(ThemeSettings setting)
        {
            Color selectedColor = Color.White; // Устанавливаем белый цвет по умолчанию

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
        private DataGridViewCellStyle SetDataGridViewStyleFromTheme(DataGridView dataGridView, ThemeSettings setting)
        {
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            if (!string.IsNullOrEmpty(setting.ColorTheme) && setting.ColorTheme != "Transparent")
            {
                Color selectedColor;
                try
                {
                    selectedColor = ColorTranslator.FromHtml(setting.ColorTheme); // Преобразование цвета из HTML/HEX в Color

                    // Создание нового стиля для заголовков столбцов

                    headerStyle.BackColor = selectedColor;

                    // Применение стиля к заголовкам столбцов
                    dataGridView.ColumnHeadersDefaultCellStyle = headerStyle;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    // Обработка ошибки, если есть
                }

            }
            return headerStyle;
        }

        private void FormAddKTP_Load(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ShowsConnect();
            GridKTPControll.ColumnHeadersDefaultCellStyle = SetDataGridViewStyleFromTheme(GridKTPControll, themeSettings);
            GridKTPControll.ColumnHeadersDefaultCellStyle.SelectionBackColor = GetColorFromTheme(themeSettings);




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
                // Проверяем, существует ли метка ktplabel, если нет, то создаем новую
                Label ktplabel = KTPPath.Controls.OfType<Label>().FirstOrDefault();
                if (ktplabel == null)
                {
                    ktplabel = new Label();
                    ktplabel.Width = 300;
                    KTPPath.Controls.Add(ktplabel);

                }

                SelectedPath = openFileDialog1.FileName;
                ktplabel.Text = SelectedPath;
                BtnCreateAdd.Enabled = true;

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

                            if (group != null)
                            {
                                BtnCreateAdd.Enabled = true;

                                // Очистить данные в DataGridView перед отображением новой группы
                                GridKTPControll.Rows.Clear();

                                // Получить существующий КТП по имени
                                var existingKtp = context.kTPs.FirstOrDefault(k => k.NameKTP == NameFile);

                                if (existingKtp == null)
                                {
                                    var newKTP = new KTP
                                    {
                                        NameKTP = NameFile
                                    };
                                    context.kTPs.Add(newKTP);
                                    context.SaveChanges();
                                    existingKtp = newKTP;
                                }
                                else
                                {
                                    var result = MessageBox.Show("КТП уже существует. Желаете перезаписать?", "Подтверждение", MessageBoxButtons.YesNo);

                                    if (result == DialogResult.Yes)
                                    {
                                        var ktpToDelete = context.kTPs.FirstOrDefault(b => b.NameKTP == NameFile);
                                        if (ktpToDelete != null)
                                        {
                                            // Находим связанные записи DisplineWithGroup, которые содержат этот KTP
                                            var relatedDisplineWithGroup = context.ConnectWithGroup
                .Where(dwg => dwg.KTP.ID == ktpToDelete.ID)
                .ToList();

                                            foreach (var connection in relatedDisplineWithGroup)
                                            {
                                                // Получаем информацию о дисциплине по ID
                                                var discipline = context.Displines.FirstOrDefault(d => d.ID == connection.Displine.ID);

                                                // Проверяем, что дисциплина найдена
                                                if (discipline != null)
                                                {
                                                    // Удаление папок, связанных с дисциплиной
                                                    DisplineWithGroup.DeleteFolders(groupName, discipline.NameDispline);
                                                }

                                                // Удаляем найденные связи из контекста данных
                                                context.ConnectWithGroup.Remove(connection);
                                            }

                                            // Теперь удаляем сам KTP
                                            context.kTPs.Remove(ktpToDelete);

                                            // Сохраняем изменения в базе данных
                                            context.SaveChanges();
                                        }
                                    }
                                    else
                                    {
                                        var IDktp = context.kTPs.FirstOrDefault(b => b.NameKTP == NameFile);
                                        if (IDktp != null)
                                        {
                                            int ktpId = IDktp.ID;
                                            ShowConnection(ktpId);
                                        }

                                    }
                                }




                                if (existingKtp != null)
                                {
                                    // Добавить данные группы и КТП в DataGridView
                                    GridKTPControll.Rows.Add(group.ID, group.NameGroup, existingKtp.NameKTP);
                                }
                                else
                                {
                                    MessageBox.Show("Группа не найдена в документе базы данных!", "Поиск не удался", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            else
            {
                
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
                        int DisplineID = Convert.ToInt32(row.Cells["Displines"].Value.ToString());
                        string ktpName = row.Cells["KTPs"].Value.ToString();



                        // Получаем ID КТП из базы данных по имени
                        int ktpId = context.kTPs
                                         .Where(k => k.NameKTP == ktpName)
                                         .Select(k => k.ID)
                                         .FirstOrDefault();

                        // Получаем название группы и дисциплины по их идентификаторам
                        var groupName = context.Groups
                                              .Where(g => g.ID == groupId)
                                              .Select(g => g.NameGroup)
                                              .FirstOrDefault();

                        var disciplineName = context.Displines
                                                   .Where(d => d.ID == DisplineID)
                                                   .Select(d => d.NameDispline)
                                                   .FirstOrDefault();


                        // Вызов метода AddCon для создания объекта DisplineWithGroup
                        DisplineWithGroup.AddCon(groupId, DisplineID, ktpId);

                        DisplineWithGroup.CreateFolders(groupName, disciplineName, SelectedPath);
                    }

                }


                guna2CircleProgressBar1.Visible = true;
                currentProgress = 0;
                guna2CircleProgressBar1.Value = currentProgress;
                progressTimer.Start();



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

