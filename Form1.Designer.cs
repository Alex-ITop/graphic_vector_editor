namespace TeorProg2
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxFigure = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonColor2 = new System.Windows.Forms.Button();
            this.buttonContourColor = new System.Windows.Forms.Button();
            this.buttonColor1 = new System.Windows.Forms.Button();
            this.buttonFillColor = new System.Windows.Forms.Button();
            this.buttonUnite = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.comboBoxFigure);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.buttonColor2);
            this.panel1.Controls.Add(this.buttonContourColor);
            this.panel1.Controls.Add(this.buttonColor1);
            this.panel1.Controls.Add(this.buttonFillColor);
            this.panel1.Controls.Add(this.buttonUnite);
            this.panel1.Location = new System.Drawing.Point(-1, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1213, 594);
            this.panel1.TabIndex = 1;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(425, 10);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 9;
            this.button1.Text = "Разбить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxFigure
            // 
            this.comboBoxFigure.FormattingEnabled = true;
            this.comboBoxFigure.Items.AddRange(new object[] {
            "...",
            "Линия",
            "Прямоугольник",
            "Эллипс"});
            this.comboBoxFigure.Location = new System.Drawing.Point(32, 14);
            this.comboBoxFigure.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxFigure.Name = "comboBoxFigure";
            this.comboBoxFigure.Size = new System.Drawing.Size(217, 24);
            this.comboBoxFigure.TabIndex = 8;
            this.comboBoxFigure.SelectedIndexChanged += new System.EventHandler(this.comboBoxFigure_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Толщина 1",
            "Толщина 2",
            "Толщина 3",
            "Толщина 4",
            "Толщина 5",
            "Толщина 6",
            "Толщина 7",
            "Толщина 8",
            "Толщина 9",
            "Толщина 10"});
            this.comboBox1.Location = new System.Drawing.Point(970, 15);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(160, 24);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // buttonColor2
            // 
            this.buttonColor2.Location = new System.Drawing.Point(890, 12);
            this.buttonColor2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonColor2.Name = "buttonColor2";
            this.buttonColor2.Size = new System.Drawing.Size(33, 28);
            this.buttonColor2.TabIndex = 6;
            this.buttonColor2.UseVisualStyleBackColor = true;
            // 
            // buttonContourColor
            // 
            this.buttonContourColor.Location = new System.Drawing.Point(775, 11);
            this.buttonContourColor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonContourColor.Name = "buttonContourColor";
            this.buttonContourColor.Size = new System.Drawing.Size(107, 28);
            this.buttonContourColor.TabIndex = 5;
            this.buttonContourColor.Text = "Цвет контура";
            this.buttonContourColor.UseVisualStyleBackColor = true;
            this.buttonContourColor.Click += new System.EventHandler(this.buttonContourColor_Click);
            // 
            // buttonColor1
            // 
            this.buttonColor1.Location = new System.Drawing.Point(706, 11);
            this.buttonColor1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonColor1.Name = "buttonColor1";
            this.buttonColor1.Size = new System.Drawing.Size(32, 28);
            this.buttonColor1.TabIndex = 4;
            this.buttonColor1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonColor1.UseVisualStyleBackColor = true;
            // 
            // buttonFillColor
            // 
            this.buttonFillColor.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonFillColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonFillColor.Location = new System.Drawing.Point(562, 11);
            this.buttonFillColor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonFillColor.Name = "buttonFillColor";
            this.buttonFillColor.Size = new System.Drawing.Size(136, 28);
            this.buttonFillColor.TabIndex = 3;
            this.buttonFillColor.Text = "Цвет заливки";
            this.buttonFillColor.UseVisualStyleBackColor = false;
            this.buttonFillColor.Click += new System.EventHandler(this.buttonFillColor_Click);
            // 
            // buttonUnite
            // 
            this.buttonUnite.Location = new System.Drawing.Point(296, 11);
            this.buttonUnite.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonUnite.Name = "buttonUnite";
            this.buttonUnite.Size = new System.Drawing.Size(121, 28);
            this.buttonUnite.TabIndex = 2;
            this.buttonUnite.Text = "Группировать";
            this.buttonUnite.UseVisualStyleBackColor = true;
            this.buttonUnite.Click += new System.EventHandler(this.buttonUnite_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 591);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1087, 112);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            this.Resize += new System.EventHandler(this.Form1_SizeChanged);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonUnite;
        private System.Windows.Forms.Button buttonFillColor;
        private System.Windows.Forms.Button buttonColor1;
        private System.Windows.Forms.Button buttonColor2;
        private System.Windows.Forms.Button buttonContourColor;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBoxFigure;
        private System.Windows.Forms.Button button1;
    }
}

