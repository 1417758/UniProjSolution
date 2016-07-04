using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebJobUniTest {
    public partial class StartUp : Form {
        public StartUp() {
            InitializeComponent();
        }

        private void btnMainXsd_Click(object sender, EventArgs e) {
              Application.Run(new TestMainDS());
        }

        private void btnApptXsd_Click(object sender, EventArgs e) {

        }

        private void btnMiscTesting_Click(object sender, EventArgs e) {
            //Application.Run(new Testing());
            //Testing.ActiveForm(); 

            Testing Check = new Testing();
            Check.Show();
            Hide();
        }
    }
}
