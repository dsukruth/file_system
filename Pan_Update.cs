using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace student
{
    public partial class Pan_Update : Form
    {
        int flag;
        String path1 = Environment.CurrentDirectory + "/" + "Index.txt";
        String path2 = Environment.CurrentDirectory + "/" + "Record.txt";
        public Pan_Update()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            String path2 = Environment.CurrentDirectory + "/" + "Record.txt";
            using (StreamReader reader = new StreamReader(path2))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] strarr = line.Split('|');

                    if (string.Compare(txtPan_Search.Text, strarr[0]) == 0)
                    {
                        string[] row = new string[] { strarr[0], strarr[1], strarr[2], strarr[3], strarr[4] };
                        dataGridView1.Rows.Add(row);
                        txtPan_Search.Text = strarr[0];
                        txtPanNo.Text = strarr[0];
                        txtName.Text = strarr[1];
                        txtFatherName.Text = strarr[2];
                        txtDOB.Text = strarr[3];
                        richtxtAddress.Text = strarr[4];


                    }

                }

            }


        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            using (StreamReader file = new StreamReader(path1))
            {

                string ln;
                long no = CountLinesReader(path1);

                for (int i = 0; i < no; i++)

                {
                    ln = file.ReadLine();
                    string[] strarr = ln.Split('|');
                    if (string.Compare(txtPan_Search.Text, strarr[0]) == 0)
                    {
                        flag = i;
                    }
                }
                file.Close();

                string[] arrLine1 = File.ReadAllLines(path1);
                arrLine1[flag] = txtPanNo.Text + "|" + flag;
                File.WriteAllLines(path1, arrLine1);

                string[] arrLine2 = File.ReadAllLines(path2);
                arrLine2[flag] = txtPanNo.Text + "|" + txtName.Text + "|" + txtFatherName.Text + "|" + txtDOB.Text + "|" + richtxtAddress.Text;
                File.WriteAllLines(path2, arrLine2);
            }
            
        }

        long CountLinesReader(String path1)
        {
            var lineCounter = 0L;
            using (var reader = new StreamReader(path2))
            {
                while (reader.ReadLine() != null)
                {
                    lineCounter++;
                }
                return lineCounter;

            }
        }

        private void Pan_Update_Load(object sender, EventArgs e)
        {

        }
    }

}
       
    

