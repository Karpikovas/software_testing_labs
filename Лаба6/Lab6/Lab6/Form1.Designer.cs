namespace Lab6
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Namespace = new System.Windows.Forms.TextBox();
            this.addTestBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Class = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Method = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Params = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Expected = new System.Windows.Forms.TextBox();
            this.tests = new System.Windows.Forms.TreeView();
            this.results = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Namespace
            // 
            this.Namespace.Location = new System.Drawing.Point(28, 83);
            this.Namespace.Name = "Namespace";
            this.Namespace.Size = new System.Drawing.Size(313, 22);
            this.Namespace.TabIndex = 0;
            // 
            // addTestBtn
            // 
            this.addTestBtn.Location = new System.Drawing.Point(28, 444);
            this.addTestBtn.Name = "addTestBtn";
            this.addTestBtn.Size = new System.Drawing.Size(310, 42);
            this.addTestBtn.TabIndex = 1;
            this.addTestBtn.Text = "Add test";
            this.addTestBtn.UseVisualStyleBackColor = true;
            this.addTestBtn.Click += new System.EventHandler(this.btnAddTestClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(23, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Create test";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "namespace";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "class";
            // 
            // Class
            // 
            this.Class.Location = new System.Drawing.Point(28, 144);
            this.Class.Name = "Class";
            this.Class.Size = new System.Drawing.Size(313, 22);
            this.Class.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "method";
            // 
            // Method
            // 
            this.Method.Location = new System.Drawing.Point(28, 196);
            this.Method.Name = "Method";
            this.Method.Size = new System.Drawing.Size(313, 22);
            this.Method.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "params";
            // 
            // Params
            // 
            this.Params.Location = new System.Drawing.Point(28, 255);
            this.Params.Multiline = true;
            this.Params.Name = "Params";
            this.Params.Size = new System.Drawing.Size(313, 63);
            this.Params.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 337);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "expected";
            // 
            // Expected
            // 
            this.Expected.Location = new System.Drawing.Point(28, 357);
            this.Expected.Multiline = true;
            this.Expected.Name = "Expected";
            this.Expected.Size = new System.Drawing.Size(313, 63);
            this.Expected.TabIndex = 13;
            // 
            // tests
            // 
            this.tests.Location = new System.Drawing.Point(379, 83);
            this.tests.Name = "tests";
            this.tests.Size = new System.Drawing.Size(320, 467);
            this.tests.TabIndex = 15;
            // 
            // results
            // 
            this.results.Location = new System.Drawing.Point(731, 83);
            this.results.Name = "results";
            this.results.Size = new System.Drawing.Size(429, 467);
            this.results.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(28, 508);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(310, 42);
            this.button1.TabIndex = 17;
            this.button1.Text = "Run all";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnRunTestsClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(374, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 25);
            this.label7.TabIndex = 18;
            this.label7.Text = "Tests";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(726, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 25);
            this.label8.TabIndex = 19;
            this.label8.Text = "Results";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 575);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.results);
            this.Controls.Add(this.tests);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Expected);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Params);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Method);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Class);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addTestBtn);
            this.Controls.Add(this.Namespace);
            this.Name = "Form1";
            this.Text = "Test driver";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Namespace;
        private System.Windows.Forms.Button addTestBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Class;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Method;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Params;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Expected;
        private System.Windows.Forms.TreeView tests;
        private System.Windows.Forms.TreeView results;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

