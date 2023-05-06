namespace MathParser.WinForms
{
    partial class MainForm
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
            txtFormula = new TextBox();
            btnParse = new Button();
            lblParsedExpression = new Label();
            lblParsed = new Label();
            lblFormula = new Label();
            lblVariables = new Label();
            txtVariables = new TextBox();
            label1 = new Label();
            lblCalculated = new Label();
            btnCalculate = new Button();
            SuspendLayout();
            // 
            // txtFormula
            // 
            txtFormula.Location = new Point(158, 12);
            txtFormula.Name = "txtFormula";
            txtFormula.Size = new Size(381, 27);
            txtFormula.TabIndex = 0;
            // 
            // btnParse
            // 
            btnParse.Location = new Point(12, 158);
            btnParse.Name = "btnParse";
            btnParse.Size = new Size(527, 29);
            btnParse.TabIndex = 1;
            btnParse.Text = "Parse";
            btnParse.UseVisualStyleBackColor = true;
            btnParse.Click += btnParse_Click;
            // 
            // lblParsedExpression
            // 
            lblParsedExpression.AutoSize = true;
            lblParsedExpression.Location = new Point(12, 86);
            lblParsedExpression.Name = "lblParsedExpression";
            lblParsedExpression.Size = new Size(129, 20);
            lblParsedExpression.TabIndex = 2;
            lblParsedExpression.Text = "Parsed Expression:";
            // 
            // lblParsed
            // 
            lblParsed.AutoSize = true;
            lblParsed.Location = new Point(158, 86);
            lblParsed.Name = "lblParsed";
            lblParsed.Size = new Size(18, 20);
            lblParsed.TabIndex = 3;
            lblParsed.Text = "...";
            // 
            // lblFormula
            // 
            lblFormula.AutoSize = true;
            lblFormula.Location = new Point(12, 19);
            lblFormula.Name = "lblFormula";
            lblFormula.Size = new Size(66, 20);
            lblFormula.TabIndex = 4;
            lblFormula.Text = "Formula:";
            // 
            // lblVariables
            // 
            lblVariables.AutoSize = true;
            lblVariables.Location = new Point(12, 53);
            lblVariables.Name = "lblVariables";
            lblVariables.Size = new Size(72, 20);
            lblVariables.TabIndex = 5;
            lblVariables.Text = "Variables:";
            // 
            // txtVariables
            // 
            txtVariables.Location = new Point(158, 53);
            txtVariables.Name = "txtVariables";
            txtVariables.Size = new Size(381, 27);
            txtVariables.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 122);
            label1.Name = "label1";
            label1.Size = new Size(129, 20);
            label1.TabIndex = 7;
            label1.Text = "Parsed Expression:";
            // 
            // lblCalculated
            // 
            lblCalculated.AutoSize = true;
            lblCalculated.Location = new Point(158, 122);
            lblCalculated.Name = "lblCalculated";
            lblCalculated.Size = new Size(18, 20);
            lblCalculated.TabIndex = 8;
            lblCalculated.Text = "...";
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(12, 193);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(527, 29);
            btnCalculate.TabIndex = 9;
            btnCalculate.Text = "Calculate";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(551, 229);
            Controls.Add(btnCalculate);
            Controls.Add(lblCalculated);
            Controls.Add(label1);
            Controls.Add(txtVariables);
            Controls.Add(lblVariables);
            Controls.Add(lblFormula);
            Controls.Add(lblParsed);
            Controls.Add(lblParsedExpression);
            Controls.Add(btnParse);
            Controls.Add(txtFormula);
            Name = "MainForm";
            Text = "MathParser 1.0";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFormula;
        private Button btnParse;
        private Label lblParsedExpression;
        private Label lblParsed;
        private Label lblFormula;
        private Label lblVariables;
        private TextBox txtVariables;
        private Label label1;
        private Label lblCalculated;
        private Button btnCalculate;
    }
}