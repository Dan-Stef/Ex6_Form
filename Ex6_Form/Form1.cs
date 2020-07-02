using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Ex6_Form
{
    public partial class Form1 : Form
    {
        private int[] oneArray;
        private int[,] twoArray;
        private bool isPressed = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void StructureListener(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text == ""&& 
                IsValueTypeValid(textBox1.Text))
            {
                isPressed = true;
                SetStricture(Convert.ToInt32(textBox1.Text));
            }
            else if(textBox1.Text != "" && textBox2.Text != "" && 
                IsValueTypeValid(textBox2.Text) && IsValueTypeValid(textBox1.Text))
            {
                isPressed = true;
                SetStricture(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
            }
        }
        private void SetStricture(int size)
        {
            dataGridView1.ColumnCount = size;
            oneArray = new int[size];
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void SetStricture(int lines, int columns)
        {
            dataGridView1.RowCount = lines;
            dataGridView1.ColumnCount = columns;
            twoArray = new int[lines, columns];
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        private void NegAvgListener(object sender, EventArgs e)
        {
            if (isPressed)
            {
                if (textBox1.Text != "" && textBox2.Text == "" && IsValueTypeValid(textBox1.Text))
                {
                    GetDataForOneArray();
                }
                else
                {
                    GetDataForTwoArray();
                }
            }
        }
        private void GetDataForOneArray()
        {
            for (int rows = 0; rows < dataGridView1.Rows.Count - 1; rows++)
            {
                for (int col = 0; col < dataGridView1.Rows[rows].Cells.Count; col++)
                {
                    oneArray[col] = Convert.ToInt32(dataGridView1.Rows[rows].Cells[col].Value);
                }
            }
            
            ShowData();
        }
        private void GetDataForTwoArray()
        {
            for (int rows = 0; rows < dataGridView1.Rows.Count - 1; rows++)
            {
                for (int col = 0; col < dataGridView1.Rows[rows].Cells.Count; col++)
                {
                    twoArray[rows, col] = Convert.ToInt32(dataGridView1.Rows[rows].Cells[col].Value);
                }
            }
            ShowData();
        }
        private void ShowData()
        {
            if (textBox1.Text != "" && textBox2.Text == "" && IsValueTypeValid(textBox1.Text))
            {
                oneArray = oneArray.Where(x => x < 0).ToArray();
                double counter = 0;
                foreach (var item in oneArray)
                {
                    counter += item;
                }
                dataGridView1.ColumnCount = 1;
                dataGridView1.Rows[0].Cells[0].Value = counter / oneArray.Length;
            }
            else
            {
                double counter = 0;
                int c = 0;
                foreach (var item in twoArray)
                {
                    if (item < 0)
                    {
                        counter += item;
                        c++;
                    }
                }
                dataGridView1.ColumnCount = 1;
                dataGridView1.RowCount = 1;
                dataGridView1.Rows[0].Cells[0].Value = counter / c;
            }
        }

        private void FindFirstMinListener(object sender, EventArgs e)
        {
            if (isPressed)
            {
                if (textBox1.Text != "" && textBox2.Text == "" && IsValueTypeValid(textBox1.Text))
                {
                    FindFirstMinElement();
                }
            }
        }
        private void FindFirstMinElement()
        {
            for (int rows = 0; rows < dataGridView1.Rows.Count - 1; rows++)
            {
                for (int col = 0; col < dataGridView1.Rows[rows].Cells.Count; col++)
                {
                    oneArray[col] = Convert.ToInt32(dataGridView1.Rows[rows].Cells[col].Value);
                }
            }
            dataGridView1.ColumnCount = 1;
            dataGridView1.RowCount = 1;
            dataGridView1.Rows[0].Cells[0].Value = Convert.ToString(oneArray[0]);
        }

        private void ChangeLinesListener(object sender, EventArgs e)
        {
            if (isPressed)
            {
                if (textBox1.Text != "" && textBox2.Text != "" &&
                    IsValueTypeValid(textBox1.Text) && IsValueTypeValid(textBox2.Text))
                {
                    ChangeLinesPlaces();
                }
            }
        }

        private void ChangeLinesPlaces()
        {
            for (int rows = 0; rows < dataGridView1.Rows.Count - 1; rows++)
            {
                for (int col = 0; col < dataGridView1.Rows[rows].Cells.Count; col++)
                {
                    twoArray[rows, col] = Convert.ToInt32(dataGridView1.Rows[rows].Cells[col].Value);
                }
            }

            int n = 0;
            int m = 0;
            if (twoArray.GetLength(0) % 2 == 0)
            {
                n = (twoArray.GetLength(0) / 2) - 1;
                m = (twoArray.GetLength(0) / 2);
            }
            else
            { m = twoArray.GetLength(0) / 2; }
            for (int j = 0; j <= twoArray.GetLength(0) - 1; j++)
            {
                int temp = twoArray[n, j];
                twoArray[n, j] = twoArray[m, j];
                twoArray[m, j] = temp;
            }
            for (int rows = 0; rows < dataGridView1.Rows.Count - 1; rows++)
            {
                for (int col = 0; col < dataGridView1.Rows[rows].Cells.Count; col++)
                {
                    dataGridView1.Rows[rows].Cells[col].Value = twoArray[rows,col];
                }
            }
        }

        private void NegSumListener(object sender, EventArgs e)
        {
            if (isPressed)
            {
                if (textBox1.Text != "" && textBox2.Text != "" &&
                IsValueTypeValid(textBox1.Text) && IsValueTypeValid(textBox2.Text))
                {
                    FindNegSum();
                }
            }
        }

        private void FindNegSum()
        {
            oneArray  = new int[twoArray.GetLength(0)];
            for (int rows = 0; rows < dataGridView1.Rows.Count - 1; rows++)
            {
                for (int col = 0; col < dataGridView1.Rows[rows].Cells.Count; col++)
                {
                    twoArray[rows, col] = Convert.ToInt32(dataGridView1.Rows[rows].Cells[col].Value);
                }
            }
            for (int i = 0; i < twoArray.GetLength(0); i++)
            {
                for (int j = 0; j < twoArray.GetLength(1); j++)
                {
                    if (twoArray[j,i] < 0)
                    {
                        oneArray[i] += twoArray[j,i];
                    }
                }
            }
            dataGridView1.RowCount = 1;
            for (int rows = 0; rows < dataGridView1.Rows.Count; rows++)
            {
                for (int col = 0; col < dataGridView1.Rows[rows].Cells.Count; col++)
                {
                    dataGridView1.Rows[rows].Cells[col].Value = oneArray[col];
                }
            }
        }
        private bool IsValueTypeValid(String str)
        {
            char[] chArr = str.ToCharArray();
            for (int i = 0; i < chArr.Length; i++)
            {
                if (!(chArr[i] >= '0' && chArr[i] <= '9') && chArr[i] != '-')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
