using MathParser.Contexts;

namespace MathParser.WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            var expression = Parser.Parse(txtFormula.Text);
            lblParsed.Text = expression.ToString();
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

                var expression = Parser.Parse(txtFormula.Text);
                lblParsed.Text = expression.ToString();

                var context = new SimpleContext(variables);
                var calculated = expression.Eval(context);
                lblCalculated.Text = calculated.ToString();
            }
            catch(Exception ex)
            {
                lblCalculated.Text = ex.Message;
            }

        }

        private void btnSimplify_Click(object sender, EventArgs e)
        {
            try
            {
                var expression = Parser.Parse(txtFormula.Text);
                lblParsed.Text = expression.ToString();

                var simplified = Simplifier.Simplify(expression);
                lblSimplified.Text = simplified.ToString();
            }
            catch(Exception ex)
            {
                lblSimplified.Text = ex.Message;
            }

        }
    }
}