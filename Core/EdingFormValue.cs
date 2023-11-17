using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeachersHandsBooks.Core
{
    public class EdingFormValue
    {
        ///<summary>
        /// Добавляет контролы на форму
        ///</summary>
        public void AddControl(Control control)
        {
            /*PanelContainer.Controls.Clear();
           PanelContainer.Controls.Add(UserControl);
            */
            control.BringToFront();
        }


        /// <summary>
        /// Преобразует строку в цвет и присваивает значение в GroupBox
        /// </summary>
        /// <param name="groupAddBox"></param>
        /// <param name="themeSettings"></param>
        public void SetBorderColorFromTheme(Guna2GroupBox groupAddBox, ThemeSettings themeSettings)
        {
            if (!string.IsNullOrEmpty(themeSettings.ColorTheme) && themeSettings.ColorTheme != "Transparent")
            {
                Color selectedColor;

                // Попытка преобразовать строку в Color
                try
                {
                    selectedColor = Color.FromName(themeSettings.ColorTheme);
                    groupAddBox.BorderColor = selectedColor;

                }
                catch (Exception)
                {

                    groupAddBox.BorderColor = Color.White;

                }
            }
            else
            {
                groupAddBox.BorderColor = Color.White;

            }
        }
        /// <summary>
        /// Преобразует из строки в Color для Picturebox
        /// </summary>
        /// <param name="picture"></param>
        /// <param name="setting"></param>
        public void SetBorderColorFromTheme(PictureBox picture, ThemeSettings setting)
        {
            if (!string.IsNullOrEmpty(setting.ColorTheme) && setting.ColorTheme != "Transparent")
            {
                Color selectedColor;
                try
                {
                    selectedColor = Color.FromName(setting.ColorTheme);
                    picture.BackColor = selectedColor;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    picture.BackColor = Color.White;
                }
            }
            else
            {
                picture.BackColor = Color.White;
            }
        }
    }
}
