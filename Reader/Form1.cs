namespace Reader
{
    public partial class Form1 : Form
    {
        
        
        Actions actions = new Actions();
        public Form1()
        {
            InitializeComponent();
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 60000/actions.ChangeInterval(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button[] buttons = { button2, button3, button4,button5,button6 };
            actions.ChangeState(buttons,timer1);
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
           Tick();
            actions.activeWord++;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Button[] buttons = {button2,button6,button5,button3 };
            actions.SelectFile(openFileDialog1, label2,buttons);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            actions.activeWord++;
            Tick();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            actions.activeWord--;
            Tick();
        }

        public void Tick()
        {
            actions.Tick(label1,textBox2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int value;
            int.TryParse(textBox2.Text, out value);
            if (value>0 && value<actions.words.Length)
            {
                actions.activeWord = value-1;
                Tick();
            }
            
        }
    }
}