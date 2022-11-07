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
            var expression = Parser.Parse(txtInput.Text);
            lblResult.Text = expression.ToString();
        }
    }
}