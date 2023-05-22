using MathParser.Contexts;
using MathParser.Nodes;
using Microsoft.Msagl.Drawing;
using MathParser.Helpers;
using Microsoft.Msagl.GraphViewerGdi;
using Microsoft.Msagl.DebugHelpers;

namespace MathParser.WinForms
{
    public partial class MainForm : Form
    {
        private NodeBase _tree;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            gViewer.ToolBarIsVisible = false;
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            ParseExpression(showGraph: true);
        }

        private void ParseExpression(bool showGraph = false)
        {
            var expression = Parser.Parse(txtFormula.Text);

            _tree = expression;

            lblParsed.Text = expression.ToString();

            if (showGraph)
            {
                CreateGraph(expression);
            }

            radioBinaryForm.Enabled = true;
            radioNaryForm.Enabled = true;
            radioBinaryForm.Checked = true;
            radioNaryForm.Checked = false;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                var variables = new Dictionary<string, double>();

                foreach (var item in txtVariables.Text.Split(','))
                {
                    if (string.IsNullOrEmpty(item)) continue;

                    if (!item.Contains('=')) continue;

                    var key = item.Split('=')[0];
                    var value = double.Parse(item.Split("=")[1]);

                    variables.Add(key, value);
                }

                ParseExpression(showGraph: false);

                var simplified = Simplifier.Simplify(_tree);
                CreateGraph(simplified);

                var context = new SimpleContext(variables);
                var calculated = simplified.Eval(context);
                lblCalculated.Text = calculated.ToString();
            }
            catch (Exception ex)
            {
                lblCalculated.Text = ex.Message;
            }

        }

        private void btnSimplify_Click(object sender, EventArgs e)
        {
            try
            {
                ParseExpression();

                var simplified = Simplifier.Simplify(_tree);
                lblSimplified.Text = simplified.ToString();

                CreateGraph(simplified);

                radioNaryForm.Checked = true;
            }
            catch (Exception ex)
            {
                lblSimplified.Text = ex.Message;
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

            _tree = _tree.ToMultichildTree();

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

            foreach (var child in node.Children)
            {
                var childNode = graph.AddNode(Guid.NewGuid().ToString());
                childNode.LabelText = child.StringValue;
                graph.AddEdge(parrentNode.Id, childNode.Id);

                AddEdge(graph, childNode, child);
            }
        }

        #endregion
    }
}