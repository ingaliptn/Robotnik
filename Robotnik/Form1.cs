using System;
using System.Windows.Forms;
using System.IO;

namespace Robotnik
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        class Person
        {
            public string name;
            public double salary;
            public int house;
            public string post;
            public string city;
            public string street;

            public string Getarr()
            {
                return name + " " + salary + " " + house + " " + post + " " + city + " " + street;
            }
        }
        Person[] people = new Person[0];
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Другое")
                textBox4.Visible = true;
            else
                textBox4.Visible = false;
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Другое")
                textBox5.Visible = true;
            else
                textBox5.Visible = false;
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "Другое")
                textBox6.Visible = true;
            else
                textBox6.Visible = false;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Array.Resize(ref people, people.Length + 1);
                people[people.Length - 1] = new Person();
                people[people.Length - 1].name = textBox1.Text;
                people[people.Length - 1].salary = Convert.ToDouble(textBox2.Text);
                people[people.Length - 1].house = Convert.ToInt32(textBox3.Text);

                if (textBox4.Visible == true)
                    people[people.Length - 1].post = textBox4.Text;
                else
                    people[people.Length - 1].post = comboBox1.Text;

                if (textBox5.Visible == true)
                    people[people.Length - 1].city = textBox5.Text;
                else
                    people[people.Length - 1].city = comboBox2.Text;

                if (textBox6.Visible == true)
                    people[people.Length - 1].street = textBox6.Text;
                else
                    people[people.Length - 1].street = comboBox3.Text;
                listBox1.Items.Add(people[people.Length - 1].Getarr());
            }
            catch
            {
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                int tmp = 0;
                for (int i = 0; i < people.Length; i++)
                {
                    if ((listBox1.SelectedItem).ToString() == people[people.Length - 1].Getarr())
                    {
                        tmp = i;
                        people[i].name = textBox1.Text;
                        people[i].salary = Convert.ToDouble(textBox2.Text);
                        people[i].house = Convert.ToInt32(textBox3.Text);
                        people[i].post = Convert.ToString(comboBox1.SelectedItem);
                        people[i].city = Convert.ToString(comboBox2.SelectedItem);
                        people[i].street = Convert.ToString(comboBox3.SelectedItem);
                    }
                }
                listBox1.Items.RemoveAt(tmp);
                listBox1.Items.Add(people[people.Length - 1].Getarr());
            }
            catch
            {
            }
        }

        private void ListBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string tmp = listBox1.SelectedItem.ToString();
            string[] strtmp = tmp.Split(' ');
            textBox1.Text = strtmp[0];
            textBox2.Text = strtmp[1];
            textBox3.Text = strtmp[2];

            bool cmbox1 = true;
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                if (comboBox1.Items[i].ToString() == strtmp[3])
                {
                    comboBox1.Text = strtmp[3];
                    cmbox1 = false;
                }
            }
            if (cmbox1 == true)
            {
                comboBox1.Text = "Другое";
                textBox4.Visible = true;
                textBox4.Text = strtmp[3];
            }

            bool cmbox2 = true;
            for (int i = 0; i < comboBox2.Items.Count; i++)
            {
                if (comboBox2.Items[i].ToString() == strtmp[4])
                {
                    cmbox2 = false;
                    comboBox2.Text = strtmp[4];
                }
            }
            if (cmbox2 == true)
            {
                comboBox2.Text = "Другое";
                textBox5.Visible = true;
                textBox5.Text = strtmp[4];
            }

            bool cmbox3 = true;

            for (int i = 0; i < comboBox3.Items.Count; i++)
            {
                if (comboBox3.Items[i].ToString() == strtmp[5])
                {
                    cmbox3 = false;
                    comboBox3.Text = strtmp[5];
                }
            }
            if (cmbox3 == true)
            {
                comboBox3.Text = "Другое";
                textBox6.Visible = true;
                textBox6.Text = strtmp[5];
            }
        }
        private void СохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(save.FileName);

                for (int i = 0; i < people.Length; i++)
                {
                    writer.Write(people[i].Getarr());
                }
                writer.Close();
            }
        }

        private void ОткрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "All Files(*.*)|*.*|Text Files (*.txt)|*.txt||";
            open.FilterIndex = 1;

            if (open.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = File.OpenText(open.FileName);
                foreach (string a in File.ReadLines(open.FileName))
                {
                    string str = reader.ReadLine();
                    string[] strtmp = str.Split(' ');
                    listBox1.Items.Add(str);

                    Array.Resize(ref people, people.Length + 1);
                    people[people.Length - 1] = new Person();
                    try
                    {
                        people[people.Length - 1].name = strtmp[0];
                        people[people.Length - 1].salary = Convert.ToDouble(strtmp[1]);
                        people[people.Length - 1].house = Convert.ToInt32(strtmp[2]);
                        people[people.Length - 1].post = strtmp[3];
                        people[people.Length - 1].city = strtmp[4];
                        people[people.Length - 1].street = strtmp[5];
                    }
                    catch
                    {
                    }
                }
                reader.Close();
            }
        }
    }
}