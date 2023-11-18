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

        private void FormationRasp_Load(object sender, EventArgs e)
        {

        }
    }
}
