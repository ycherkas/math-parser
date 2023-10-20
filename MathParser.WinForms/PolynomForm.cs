using MathParser.Helpers;
using MathParser.Nodes;
using Microsoft.Msagl.Drawing;

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
            ParseExpression();
        }

        private NodeBase ParseExpression()
        {
            var expression = ParserManager.Parse(txtFormula.Text);

            _tree = expression;

            lblParsed.Text = expression.ToString();
            lblResult.Text = "...";

            expression = ExpandHelpers.ExpandAlgebraic(expression);
            expression = Simplifier.Simplify(expression);
            //expression = ExpandHelpers.ExpandAlgebraic(expression);
            //expression = Simplifier.Simplify(expression);

            var isPolynom = CheckIfPolynom(expression);

            if (isPolynom)
            {
                lblResult.Text = expression.ToString();
                lblResultLabel.Text = "Polynom Form:";
                CreateGraph(expression);
            }

            CreateGraph(expression);

            return expression;
        }

        private bool CheckIfPolynom(NodeBase expression)
        {
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

            if (variables.Count == 1 && variables[0] is NodeVariable && expression.IsPolynomSingle((NodeVariable)variables.First()))
            {
                lblIsPolynom.Text = $"YES (single variable polynom)";
                return true;
            }
            else if (variables.Count > 1 && variables.All(v => v is NodeVariable) && expression.IsPolynomMulti(variables.Select(v => (NodeVariable)v).ToList()))
            {
                lblIsPolynom.Text = $"YES (multi variable polynom)";
                return true;
            }
            else if (expression.IsPolynom(variables))
            {
                lblIsPolynom.Text = $"YES (general polynom expression)";
                return true;
            }
            else
            {
                lblIsPolynom.Text = "NO";
                return false;
            }
        }

        private void btnSimplify_Click(object sender, EventArgs e)
        {
            try
            {
                var simplified = ParseExpression();

                lblIsPolynom.Text = "...";
                lblResult.Text = simplified.ToString();
                lblResultLabel.Text = "Simplified Result:";

                CreateGraph(simplified);
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
            }

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