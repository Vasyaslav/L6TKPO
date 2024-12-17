namespace MVCWFA
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelView1 = new Panel();
            panelView2 = new Panel();
            panelView3 = new Panel();
            label1 = new Label();
            numericUpDown1 = new NumericUpDown();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label2 = new Label();
            label3 = new Label();
            numericUpDown2 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // panelView1
            // 
            panelView1.Location = new Point(12, 12);
            panelView1.Name = "panelView1";
            panelView1.Size = new Size(200, 426);
            panelView1.TabIndex = 0;
            // 
            // panelView2
            // 
            panelView2.Location = new Point(218, 12);
            panelView2.Name = "panelView2";
            panelView2.Size = new Size(200, 426);
            panelView2.TabIndex = 1;
            // 
            // panelView3
            // 
            panelView3.Location = new Point(424, 12);
            panelView3.Name = "panelView3";
            panelView3.Size = new Size(200, 426);
            panelView3.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(630, 12);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 3;
            label1.Text = "Введите этаж";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(630, 30);
            numericUpDown1.Maximum = new decimal(new int[] { 9, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(158, 23);
            numericUpDown1.TabIndex = 4;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // button1
            // 
            button1.Location = new Point(630, 59);
            button1.Name = "button1";
            button1.Size = new Size(158, 23);
            button1.TabIndex = 5;
            button1.Text = "Поехать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(630, 114);
            button2.Name = "button2";
            button2.Size = new Size(158, 23);
            button2.TabIndex = 6;
            button2.Text = "Добавить человека";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(630, 143);
            button3.Name = "button3";
            button3.Size = new Size(158, 23);
            button3.TabIndex = 7;
            button3.Text = "Убрать человека";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(630, 204);
            label2.Name = "label2";
            label2.Size = new Size(83, 15);
            label2.TabIndex = 8;
            label2.Text = "Введите шанс";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(630, 219);
            label3.Name = "label3";
            label3.Size = new Size(158, 15);
            label3.TabIndex = 9;
            label3.Text = "отключения электричества";
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(630, 237);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(158, 23);
            numericUpDown2.TabIndex = 10;
            numericUpDown2.Value = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown2.ValueChanged += numericUpDown2_ValueChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(791, 450);
            Controls.Add(numericUpDown2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(numericUpDown1);
            Controls.Add(label1);
            Controls.Add(panelView3);
            Controls.Add(panelView2);
            Controls.Add(panelView1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelView1;
        private Panel panelView2;
        private Panel panelView3;
        private Label label1;
        private NumericUpDown numericUpDown1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label2;
        private Label label3;
        private NumericUpDown numericUpDown2;
    }
}
