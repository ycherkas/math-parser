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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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
            btnSimplify = new Button();
            lblSimplifiedResult = new Label();
            lblSimplified = new Label();
            gViewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            panel1 = new Panel();
            radioBinaryForm = new RadioButton();
            radioNaryForm = new RadioButton();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtFormula
            // 
            txtFormula.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtFormula.Location = new Point(205, 12);
            txtFormula.Name = "txtFormula";
            txtFormula.Size = new Size(497, 32);
            txtFormula.TabIndex = 0;
            // 
            // btnParse
            // 
            btnParse.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnParse.Location = new Point(708, 13);
            btnParse.Name = "btnParse";
            btnParse.Size = new Size(381, 29);
            btnParse.TabIndex = 1;
            btnParse.Text = "Analyse";
            btnParse.UseVisualStyleBackColor = true;
            btnParse.Click += btnParse_Click;
            // 
            // lblParsedExpression
            // 
            lblParsedExpression.AutoSize = true;
            lblParsedExpression.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblParsedExpression.Location = new Point(12, 101);
            lblParsedExpression.Name = "lblParsedExpression";
            lblParsedExpression.Size = new Size(167, 25);
            lblParsedExpression.TabIndex = 2;
            lblParsedExpression.Text = "Parsed Expression:";
            // 
            // lblParsed
            // 
            lblParsed.AutoSize = true;
            lblParsed.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblParsed.Location = new Point(205, 101);
            lblParsed.Name = "lblParsed";
            lblParsed.Size = new Size(24, 28);
            lblParsed.TabIndex = 3;
            lblParsed.Text = "...";
            // 
            // lblFormula
            // 
            lblFormula.AutoSize = true;
            lblFormula.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblFormula.Location = new Point(12, 19);
            lblFormula.Name = "lblFormula";
            lblFormula.Size = new Size(85, 25);
            lblFormula.TabIndex = 4;
            lblFormula.Text = "Formula:";
            // 
            // lblVariables
            // 
            lblVariables.AutoSize = true;
            lblVariables.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblVariables.Location = new Point(12, 60);
            lblVariables.Name = "lblVariables";
            lblVariables.Size = new Size(93, 25);
            lblVariables.TabIndex = 5;
            lblVariables.Text = "Variables:";
            // 
            // txtVariables
            // 
            txtVariables.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtVariables.Location = new Point(205, 53);
            txtVariables.Name = "txtVariables";
            txtVariables.Size = new Size(497, 32);
            txtVariables.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 143);
            label1.Name = "label1";
            label1.Size = new Size(160, 25);
            label1.TabIndex = 7;
            label1.Text = "Calculated Result:";
            // 
            // lblCalculated
            // 
            lblCalculated.AutoSize = true;
            lblCalculated.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblCalculated.Location = new Point(205, 143);
            lblCalculated.Name = "lblCalculated";
            lblCalculated.Size = new Size(24, 28);
            lblCalculated.TabIndex = 8;
            lblCalculated.Text = "...";
            // 
            // btnCalculate
            // 
            btnCalculate.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnCalculate.Location = new Point(708, 56);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(381, 29);
            btnCalculate.TabIndex = 9;
            btnCalculate.Text = "Calculate";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // btnSimplify
            // 
            btnSimplify.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnSimplify.Location = new Point(708, 97);
            btnSimplify.Name = "btnSimplify";
            btnSimplify.Size = new Size(381, 29);
            btnSimplify.TabIndex = 10;
            btnSimplify.Text = "Simplify";
            btnSimplify.UseVisualStyleBackColor = true;
            btnSimplify.Click += btnSimplify_Click;
            // 
            // lblSimplifiedResult
            // 
            lblSimplifiedResult.AutoSize = true;
            lblSimplifiedResult.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblSimplifiedResult.Location = new Point(12, 183);
            lblSimplifiedResult.Name = "lblSimplifiedResult";
            lblSimplifiedResult.Size = new Size(155, 25);
            lblSimplifiedResult.TabIndex = 11;
            lblSimplifiedResult.Text = "Simplified Result:";
            // 
            // lblSimplified
            // 
            lblSimplified.AutoSize = true;
            lblSimplified.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblSimplified.Location = new Point(205, 183);
            lblSimplified.Name = "lblSimplified";
            lblSimplified.Size = new Size(24, 28);
            lblSimplified.TabIndex = 12;
            lblSimplified.Text = "...";
            // 
            // gViewer
            // 
            gViewer.ArrowheadLength = 10D;
            gViewer.AsyncLayout = false;
            gViewer.AutoScroll = true;
            gViewer.BackwardEnabled = false;
            gViewer.BuildHitTree = true;
            gViewer.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.UseSettingsOfTheGraph;
            gViewer.Dock = DockStyle.Fill;
            gViewer.EdgeInsertButtonVisible = true;
            gViewer.FileName = "";
            gViewer.ForwardEnabled = false;
            gViewer.Graph = null;
            gViewer.IncrementalDraggingModeAlways = false;
            gViewer.InsertingEdge = false;
            gViewer.LayoutAlgorithmSettingsButtonVisible = true;
            gViewer.LayoutEditingEnabled = true;
            gViewer.Location = new Point(0, 0);
            gViewer.LooseOffsetForRouting = 0.25D;
            gViewer.MouseHitDistance = 0.05D;
            gViewer.Name = "gViewer";
            gViewer.NavigationVisible = true;
            gViewer.NeedToCalculateLayout = true;
            gViewer.OffsetForRelaxingInRouting = 0.6D;
            gViewer.PaddingForEdgeRouting = 8D;
            gViewer.PanButtonPressed = false;
            gViewer.SaveAsImageEnabled = true;
            gViewer.SaveAsMsaglEnabled = true;
            gViewer.SaveButtonVisible = true;
            gViewer.SaveGraphButtonVisible = true;
            gViewer.SaveInVectorFormatEnabled = true;
            gViewer.Size = new Size(1074, 467);
            gViewer.TabIndex = 13;
            gViewer.TightOffsetForRouting = 0.125D;
            gViewer.ToolBarIsVisible = true;
            gViewer.Transform = (Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation)resources.GetObject("gViewer.Transform");
            gViewer.UndoRedoButtonsVisible = true;
            gViewer.WindowZoomButtonPressed = false;
            gViewer.ZoomF = 1D;
            gViewer.ZoomWindowThreshold = 0.05D;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(gViewer);
            panel1.Location = new Point(12, 226);
            panel1.Name = "panel1";
            panel1.Size = new Size(1074, 467);
            panel1.TabIndex = 14;
            // 
            // radioBinaryForm
            // 
            radioBinaryForm.AutoSize = true;
            radioBinaryForm.Enabled = false;
            radioBinaryForm.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            radioBinaryForm.Location = new Point(708, 139);
            radioBinaryForm.Name = "radioBinaryForm";
            radioBinaryForm.Size = new Size(169, 29);
            radioBinaryForm.TabIndex = 15;
            radioBinaryForm.TabStop = true;
            radioBinaryForm.Text = "binary tree form";
            radioBinaryForm.UseVisualStyleBackColor = true;
            radioBinaryForm.CheckedChanged += radioBinaryForm_CheckedChanged;
            // 
            // radioNaryForm
            // 
            radioNaryForm.AutoSize = true;
            radioNaryForm.Enabled = false;
            radioNaryForm.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            radioNaryForm.Location = new Point(708, 174);
            radioNaryForm.Name = "radioNaryForm";
            radioNaryForm.Size = new Size(161, 29);
            radioNaryForm.TabIndex = 16;
            radioNaryForm.TabStop = true;
            radioNaryForm.Text = "n-ary tree form";
            radioNaryForm.UseVisualStyleBackColor = true;
            radioNaryForm.CheckedChanged += radioNaryForm_CheckedChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1098, 705);
            Controls.Add(radioNaryForm);
            Controls.Add(radioBinaryForm);
            Controls.Add(panel1);
            Controls.Add(lblSimplified);
            Controls.Add(lblSimplifiedResult);
            Controls.Add(btnSimplify);
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
            panel1.ResumeLayout(false);
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
        private Button btnSimplify;
        private Label lblSimplifiedResult;
        private Label lblSimplified;
        private Microsoft.Msagl.GraphViewerGdi.GViewer gViewer;
        private Panel panel1;
        private RadioButton radioBinaryForm;
        private RadioButton radioNaryForm;
    }
}