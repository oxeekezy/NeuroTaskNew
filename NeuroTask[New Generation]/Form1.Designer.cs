namespace NeuroTask_New_Generation_
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.MainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.RadialBasicsBtn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.line = new System.Windows.Forms.RadioButton();
            this.fastline = new System.Windows.Forms.RadioButton();
            this.spline = new System.Windows.Forms.RadioButton();
            this.hiddenNeuronsCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.function = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.yBox = new System.Windows.Forms.TextBox();
            this.xBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.KohanenBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MainChart)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hiddenNeuronsCount)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainChart
            // 
            chartArea2.Name = "ChartArea1";
            this.MainChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.MainChart.Legends.Add(legend2);
            this.MainChart.Location = new System.Drawing.Point(12, 12);
            this.MainChart.Name = "MainChart";
            this.MainChart.Size = new System.Drawing.Size(776, 367);
            this.MainChart.TabIndex = 0;
            this.MainChart.Text = "chart1";
            // 
            // RadialBasicsBtn
            // 
            this.RadialBasicsBtn.Location = new System.Drawing.Point(6, 6);
            this.RadialBasicsBtn.Name = "RadialBasicsBtn";
            this.RadialBasicsBtn.Size = new System.Drawing.Size(94, 23);
            this.RadialBasicsBtn.TabIndex = 1;
            this.RadialBasicsBtn.Text = "Get Radial";
            this.RadialBasicsBtn.UseVisualStyleBackColor = true;
            this.RadialBasicsBtn.Click += new System.EventHandler(this.RadialBasicsBtn_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 385);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 119);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.TabIndexChanged += new System.EventHandler(this.tabControl1_TabIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.line);
            this.tabPage1.Controls.Add(this.fastline);
            this.tabPage1.Controls.Add(this.spline);
            this.tabPage1.Controls.Add(this.hiddenNeuronsCount);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.function);
            this.tabPage1.Controls.Add(this.RadialBasicsBtn);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 93);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Radial Basics Task";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // line
            // 
            this.line.AutoSize = true;
            this.line.Location = new System.Drawing.Point(499, 57);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(45, 17);
            this.line.TabIndex = 8;
            this.line.TabStop = true;
            this.line.Text = "Line";
            this.line.UseVisualStyleBackColor = true;
            this.line.CheckedChanged += new System.EventHandler(this.line_CheckedChanged);
            // 
            // fastline
            // 
            this.fastline.AutoSize = true;
            this.fastline.Location = new System.Drawing.Point(499, 34);
            this.fastline.Name = "fastline";
            this.fastline.Size = new System.Drawing.Size(65, 17);
            this.fastline.TabIndex = 7;
            this.fastline.TabStop = true;
            this.fastline.Text = "FastLine";
            this.fastline.UseVisualStyleBackColor = true;
            this.fastline.CheckedChanged += new System.EventHandler(this.fastline_CheckedChanged);
            // 
            // spline
            // 
            this.spline.AutoSize = true;
            this.spline.Location = new System.Drawing.Point(499, 9);
            this.spline.Name = "spline";
            this.spline.Size = new System.Drawing.Size(54, 17);
            this.spline.TabIndex = 6;
            this.spline.TabStop = true;
            this.spline.Text = "Spline";
            this.spline.UseVisualStyleBackColor = true;
            this.spline.CheckedChanged += new System.EventHandler(this.spline_CheckedChanged);
            // 
            // hiddenNeuronsCount
            // 
            this.hiddenNeuronsCount.Location = new System.Drawing.Point(105, 34);
            this.hiddenNeuronsCount.Name = "hiddenNeuronsCount";
            this.hiddenNeuronsCount.Size = new System.Drawing.Size(120, 20);
            this.hiddenNeuronsCount.TabIndex = 5;
            this.hiddenNeuronsCount.ValueChanged += new System.EventHandler(this.hiddenNeuronsCount_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(247, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Hidden Neurons";
            // 
            // function
            // 
            this.function.FormattingEnabled = true;
            this.function.Location = new System.Drawing.Point(105, 7);
            this.function.Name = "function";
            this.function.Size = new System.Drawing.Size(246, 21);
            this.function.TabIndex = 2;
            this.function.SelectedIndexChanged += new System.EventHandler(this.function_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.yBox);
            this.tabPage2.Controls.Add(this.xBox);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.KohanenBtn);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 93);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Kohanen Task";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(425, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = ":Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(199, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "X:";
            // 
            // yBox
            // 
            this.yBox.Location = new System.Drawing.Point(324, 28);
            this.yBox.Name = "yBox";
            this.yBox.Size = new System.Drawing.Size(100, 20);
            this.yBox.TabIndex = 3;
            // 
            // xBox
            // 
            this.xBox.Location = new System.Drawing.Point(218, 28);
            this.xBox.Name = "xBox";
            this.xBox.Size = new System.Drawing.Size(100, 20);
            this.xBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(297, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Test point";
            // 
            // KohanenBtn
            // 
            this.KohanenBtn.Location = new System.Drawing.Point(5, 26);
            this.KohanenBtn.Name = "KohanenBtn";
            this.KohanenBtn.Size = new System.Drawing.Size(113, 23);
            this.KohanenBtn.TabIndex = 0;
            this.KohanenBtn.Text = "Get Kohanen";
            this.KohanenBtn.UseVisualStyleBackColor = true;
            this.KohanenBtn.Click += new System.EventHandler(this.KohanenBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 516);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.MainChart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainChart)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hiddenNeuronsCount)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart MainChart;
        private System.Windows.Forms.Button RadialBasicsBtn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox function;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown hiddenNeuronsCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox yBox;
        private System.Windows.Forms.TextBox xBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button KohanenBtn;
        private System.Windows.Forms.RadioButton line;
        private System.Windows.Forms.RadioButton fastline;
        private System.Windows.Forms.RadioButton spline;
    }
}

