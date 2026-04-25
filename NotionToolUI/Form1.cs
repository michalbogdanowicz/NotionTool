using BusinessLogic;

namespace NotionToolUI
{
    public partial class Form1 : Form
    {
        bool flip = false;
        public Form1()
        {
            InitializeComponent();
        }

        private async void SubmitButton_Click(object sender, EventArgs e)
        {
            // Create a task :
            await  Program.business?.CreateTask("test me dis.");
            if (flip)
            {
                ColorTextBox.BackColor = SystemColors.Info;
            }
            else
            {
                ColorTextBox.BackColor = SystemColors.WindowText;
            }
            flip = !flip;

        }
    }
}
