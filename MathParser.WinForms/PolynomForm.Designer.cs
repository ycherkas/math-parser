namespace MathParser.WinForms
{
    partial class PolynomForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PolynomForm));
            txtFormula = new TextBox();
            btnParse = new Button();
            lblParsedExpression = new Label();
            lblParsed = new Label();
            lblFormula = new Label();
            label1 = new Label();
            lblIsPolynom = new Label();
            lblResultLabel = new Label();
            lblResult = new Label();
            gViewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            panel1 = new Panel();
            txtVariables = new TextBox();
            label3 = new Label();
            btnSimplify = new Button();
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
            btnParse.Size = new Size(381, 31);
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 143);
            label1.Name = "label1";
            label1.Size = new Size(112, 25);
            label1.TabIndex = 7;
            label1.Text = "Is Polynom?";
            // 
            // lblIsPolynom
            // 
            lblIsPolynom.AutoSize = true;
            lblIsPolynom.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblIsPolynom.Location = new Point(205, 143);
            lblIsPolynom.Name = "lblIsPolynom";
            lblIsPolynom.Size = new Size(24, 28);
            lblIsPolynom.TabIndex = 8;
            lblIsPolynom.Text = "...";
            // 
            // lblResultLabel
            // 
            lblResultLabel.AutoSize = true;
            lblResultLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblResultLabel.Location = new Point(12, 183);
            lblResultLabel.Name = "lblResultLabel";
            lblResultLabel.Size = new Size(137, 25);
            lblResultLabel.TabIndex = 11;
            lblResultLabel.Text = "Polynom Form:";
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblResult.Location = new Point(205, 183);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(24, 28);
            lblResult.TabIndex = 12;
            lblResult.Text = "...";
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
            // txtVariables
            // 
            txtVariables.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtVariables.Location = new Point(205, 59);
            txtVariables.Name = "txtVariables";
            txtVariables.Size = new Size(497, 32);
            txtVariables.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 59);
            label3.Name = "label3";
            label3.Size = new Size(93, 25);
            label3.TabIndex = 16;
            label3.Text = "Variables:";
            // 
            // btnSimplify
            // 
            btnSimplify.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnSimplify.Location = new Point(708, 60);
            btnSimplify.Name = "btnSimplify";
            btnSimplify.Size = new Size(381, 29);
            btnSimplify.TabIndex = 17;
            btnSimplify.Text = "Simplify";
            btnSimplify.UseVisualStyleBackColor = true;
            btnSimplify.Click += btnSimplify_Click;
            // 
            // PolynomForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1098, 705);
            Controls.Add(btnSimplify);
            Controls.Add(label3);
            Controls.Add(txtVariables);
            Controls.Add(panel1);
            Controls.Add(lblResult);
            Controls.Add(lblResultLabel);
            Controls.Add(lblIsPolynom);
            Controls.Add(label1);
            Controls.Add(lblFormula);
            Controls.Add(lblParsed);
            Controls.Add(lblParsedExpression);
            Controls.Add(btnParse);
            Controls.Add(txtFormula);
            Name = "PolynomForm";
            Text = "MathParser 1.0";
            Load += PolynomForm_Load;
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
        private Label label1;
        private Label lblIsPolynom;
        private Label lblResultLabel;
        private Label lblResult;
        private Microsoft.Msagl.GraphViewerGdi.GViewer gViewer;
        private Panel panel1;
        private TextBox txtVariables;
        private Label label3;
        private Button btnSimplify;
    }
}