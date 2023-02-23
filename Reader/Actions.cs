using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reader
{
    public class Actions
    {
        int lastInterval = 200;
        bool active = false;

        public string path;
        public string[] words;

        public int activeWord=0;

        public Actions()
        {

        }

        public int ChangeInterval(string input)
        {
            int output;

            if (int.TryParse(input, out output)&&output>0)
            {
                lastInterval = output;
                return output;
            }
            else
                return lastInterval;

        }

        public void ChangeState(Button[] buttons, System.Windows.Forms.Timer timer)
        {
            
            
            active = !active;
            timer.Enabled = active;
            for (int i = 1; i < buttons.Length ; i++)
            {
                buttons[i].Enabled = !active;
            }

            if (active)
            {
                buttons[0].Text = "Stop";
            }
            else
                buttons[0].Text = "Start";

        }

        public void SelectFile(OpenFileDialog ofd, Label label,Button[] buttons)
        {
            ofd.Filter = "(*.txt)|*.txt";
            ofd.AddExtension = false;
            ofd.CheckFileExists = false;
            ofd.DereferenceLinks = true;
            ofd.Multiselect = false;
            ofd.FileName = "";
            ofd.Title = "Výběr souboru pro čtení";
            
            ofd.ShowDialog();

            path = ofd.FileName;

            if (!String.IsNullOrEmpty(path))
            {
                SetText();

                label.Text = "/ " + words.Length.ToString();
                if (words.Length != 0)
                {
                    for(int i = 0; i < buttons.Length; i++)
                    buttons[i].Enabled = true;
                }
            }

            
        }

        public void SetText()
        {
            words = string.Join(" ", File.ReadAllLines(path, Encoding.GetEncoding(65001))).Split(' '); 
        }

        public void Tick(Label label, TextBox textBox)
        {
            if (activeWord > words.Length - 1)
            {
                activeWord = words.Length - 1;
            } else if (activeWord < 0)
            {
                activeWord = 0;
                }
                label.Text = words[activeWord];
            int word = activeWord +1;
            textBox.Text = word.ToString();
        }

    }
}
