namespace WebJobUniTest {
    partial class StartUp {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnMiscTesting = new System.Windows.Forms.Button();
            this.btnMainXsd = new System.Windows.Forms.Button();
            this.btnApptXsd = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMiscTesting
            // 
            this.btnMiscTesting.Location = new System.Drawing.Point(11, 165);
            this.btnMiscTesting.Margin = new System.Windows.Forms.Padding(2);
            this.btnMiscTesting.Name = "btnMiscTesting";
            this.btnMiscTesting.Size = new System.Drawing.Size(109, 66);
            this.btnMiscTesting.TabIndex = 9;
            this.btnMiscTesting.Text = "Misc Testing";
            this.btnMiscTesting.UseVisualStyleBackColor = true;
            this.btnMiscTesting.Click += new System.EventHandler(this.btnMiscTesting_Click);
            // 
            // btnMainXsd
            // 
            this.btnMainXsd.Location = new System.Drawing.Point(11, 13);
            this.btnMainXsd.Margin = new System.Windows.Forms.Padding(2);
            this.btnMainXsd.Name = "btnMainXsd";
            this.btnMainXsd.Size = new System.Drawing.Size(109, 69);
            this.btnMainXsd.TabIndex = 7;
            this.btnMainXsd.Text = "Main XSD";
            this.btnMainXsd.UseVisualStyleBackColor = true;
            this.btnMainXsd.Click += new System.EventHandler(this.btnMainXsd_Click);
            // 
            // btnApptXsd
            // 
            this.btnApptXsd.Location = new System.Drawing.Point(11, 89);
            this.btnApptXsd.Margin = new System.Windows.Forms.Padding(2);
            this.btnApptXsd.Name = "btnApptXsd";
            this.btnApptXsd.Size = new System.Drawing.Size(109, 69);
            this.btnApptXsd.TabIndex = 5;
            this.btnApptXsd.Text = "Appt XSD";
            this.btnApptXsd.UseVisualStyleBackColor = true;
            this.btnApptXsd.Click += new System.EventHandler(this.btnApptXsd_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(148, 165);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 66);
            this.button1.TabIndex = 12;
            this.button1.Text = " ";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(148, 13);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 69);
            this.button2.TabIndex = 11;
            this.button2.Text = " ";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(148, 89);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(109, 69);
            this.button3.TabIndex = 10;
            this.button3.Text = " ";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // StartUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnMiscTesting);
            this.Controls.Add(this.btnMainXsd);
            this.Controls.Add(this.btnApptXsd);
            this.Name = "StartUp";
            this.Text = "StartUp";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnMiscTesting;
        internal System.Windows.Forms.Button btnMainXsd;
        internal System.Windows.Forms.Button btnApptXsd;
        internal System.Windows.Forms.Button button1;
        internal System.Windows.Forms.Button button2;
        internal System.Windows.Forms.Button button3;
    }
}