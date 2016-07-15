﻿using System;
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
            TestMainDS Check = new TestMainDS();
            Check.Show();
            Hide();
        }

        private void btnApptXsd_Click(object sender, EventArgs e) {
            TestApptDS Check = new TestApptDS();
            Check.Show();
            Hide();
        }

        private void btnMiscTesting_Click(object sender, EventArgs e) {
            Testing Check = new Testing();
            Check.Show();
            Hide();
        }

        private void btnMainADDXsd_Click(object sender, EventArgs e) {
            TestMainAdd Check = new TestMainAdd();
            Check.Show();
            Hide();
        }
    }
}
