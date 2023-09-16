using MathParser.Contexts;
using MathParser.Nodes;
using Microsoft.Msagl.Drawing;
using MathParser.Helpers;
using Microsoft.Msagl.GraphViewerGdi;
using Microsoft.Msagl.DebugHelpers;
using Microsoft.Msagl.Core.ProjectionSolver;

namespace MathParser.WinForms
{
    public partial class PolynomForm : Form
    {
        private NodeBase _tree;

        public PolynomForm()
        {
            InitializeComponent();
        }

        private void PolynomForm_Load(object sender, EventArgs e)
        {
            gViewer.ToolBarIsVisible = false;
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            ParseExpression(showGraph: true);
        }

        private void ParseExpression(bool showGraph = false)
        {
            var expression = ParserManager.Parse(txtFormula.Text);

            _tree = expression;

            lblParsed.Text = expression.ToString();

            if (showGraph)
            {
                CreateGraph(expression);
            }

            expression = Simplifier.Simplify(expression);

            bool isPolynom;
            var variablesString = txtVariables.Text;
            List<NodeBase> variables;
            if (!string.IsNullOrEmpty(variablesString))
            {
                variables = variablesString.Split(',').ToList().Select(v => Simplifier.Simplify(v)).ToList();
            }
            else
            {
                variables = expression.GetVariables();
            }

            isPolynom = expression.IsPolynom(variables);
            lblIsPolynom.Text = isPolynom.ToString();

            lblResult.Text = "...";
        }


        private void btnSimplify_Click(object sender, EventArgs e)
        {
            try
            {
                ParseExpression();

                var simplified = Simplifier.Simplify(_tree);
                lblResult.Text = simplified.ToString();

                CreateGraph(simplified);
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
            }

        }

        private void radioBinaryForm_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton? rb = sender as RadioButton;

            if (rb == null || !rb.Checked || _tree == null) return;

            _tree = _tree.ToBinaryForm();

            CreateGraph(_tree);
        }

        private void radioNaryForm_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton? rb = sender as RadioButton;

            if (rb == null || !rb.Checked || _tree == null) return;

            _tree = _tree.ToMultichildTreeFull();

            CreateGraph(_tree);
        }

        #region Graph Visualization

        private void CreateGraph(NodeBase node)
        {
            var graph = new Graph("clusters");

            var rootNode = graph.AddNode(Guid.NewGuid().ToString());
            rootNode.LabelText = node.StringValue;

            AddEdge(graph, rootNode, node);

            gViewer.Graph = graph;
        }

        private void AddEdge(Graph graph, Node parrentNode, NodeBase node)
        {
            if (!node.Children.Any()) return;

            for (var i = node.Children.Count - 1; i >= 0; i--)
            {
                var child = node.Children[i];
                var childNode = graph.AddNode(Guid.NewGuid().ToString());
                childNode.LabelText = child.StringValue;
                graph.AddEdge(parrentNode.Id, childNode.Id);

                AddEdge(graph, childNode, child);
            }
        }

        #endregion
    }
}