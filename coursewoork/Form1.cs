using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coursewoork
{
    public partial class Form1 : Form
    {
        private int[,] adjacencyMatrix; // Матрица смежности
        public static char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'K', 'J' };
        public static string[] lettersClass = { "A", "B", "C", "J", "K", "D", "E", "F" };

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonDrawGraph_Click(object sender, EventArgs e)
        {
            adjacencyMatrix = GetAdjacencyMatrix();

            // Нарисуйте вершины графа
            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                DrawClasses(i, adjacencyMatrix.GetLength(0));
            }

            // Нарисуйте ребра графа
            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                for (int j = i + 1; j < adjacencyMatrix.GetLength(0); j++)
                {
                    if (adjacencyMatrix[i, j] == 1 && i != j && adjacencyMatrix[j, i] == 1)
                    {
                        DrawEdge(i, j);
                    }
                    else if (adjacencyMatrix[i, j] == 1 && adjacencyMatrix[j, i] != 1)
                    {
                        MessageBox.Show("Матрица должна быть симметричной, а на главной диагонали должны быть нули");
                    }
                }
            }
        }

        public void DrawClasses(int classNumber, int length)
        {
            Graphics g = pictureBox1.CreateGraphics();
            if (classNumber == 0)
            {
                g.DrawRectangle(Pens.Black, 215, 100, 100, 150); //класс
                g.FillRectangle(Brushes.White, new Rectangle(200, 150, 80, 25));
                g.DrawRectangle(Pens.Black, 200, 150, 80, 25);// public
                g.DrawString("Public", Font, Brushes.Black, 210, 155);
                g.DrawRectangle(Pens.Black, 225, 185, 80, 40);//  private
                g.DrawString("Private", Font, Brushes.Black, 235, 188);
                if (length >= 3)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        g.FillRectangle(Brushes.Black, new Rectangle(235 + i * 20, 210, 10, 10));
                    }
                }
                else
                {
                    for (int i = 0; i < length - 1; i++)
                    {
                        g.FillRectangle(Brushes.Black, new Rectangle(235 + i * 20, 210, 10, 10));
                    }
                }
                g.FillRectangle(Brushes.White, new Rectangle(225, 235, 80, 25));
                g.DrawRectangle(Pens.Black, 225, 235, 80, 25);//  protected
                g.DrawString("Protected", Font, Brushes.Black, 235, 240);
            }
            else if (classNumber != 0 && classNumber < 4)
            {
                g.DrawRectangle(Pens.Black, 65 + (classNumber - 1) * 150, 275, 100, 150); //класс
                g.FillRectangle(Brushes.White, new Rectangle(50 + (classNumber - 1) * 150, 325, 80, 25));
                g.DrawRectangle(Pens.Black, 50 + (classNumber - 1) * 150, 325, 80, 25); // public
                g.DrawString("Public", Font, Brushes.Black, 60 + (classNumber - 1) * 150, 330);
                g.DrawRectangle(Pens.Black, 75 + (classNumber - 1) * 150, 360, 80, 40);//  private
                g.DrawString("Private", Font, Brushes.Black, 95 + (classNumber - 1) * 150, 363);
                if (classNumber < 3)
                {
                    if (length > 4)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            g.FillRectangle(Brushes.Black, new Rectangle(95 + (classNumber - 1) * 150 + i * 30, 385, 10, 10));
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 2; i++)
                    {
                        g.FillRectangle(Brushes.White, new Rectangle(95 + (classNumber - 1) * 150 + i * 30, 385, 10, 10));
                    }
                }
                g.FillRectangle(Brushes.White, new Rectangle(75 + (classNumber - 1) * 150, 410, 80, 25));
                g.DrawRectangle(Pens.Black, 75 + (classNumber - 1) * 150, 410, 80, 25);//  protected
                g.DrawString("Protected", Font, Brushes.Black, 85 + (classNumber - 1) * 150, 415);
            }
            else
            {
                g.DrawRectangle(Pens.Black, 15 + (classNumber - 4) * 125, 450, 100, 150); //класс
                g.FillRectangle(Brushes.White, new Rectangle((classNumber - 4) * 125, 500, 80, 25));
                g.DrawRectangle(Pens.Black, (classNumber - 4) * 125, 500, 80, 25); // public
                g.DrawString("Public", Font, Brushes.Black, 10 + (classNumber - 4) * 125, 505);
                g.DrawRectangle(Pens.Black, 25 + (classNumber - 4) * 125, 535, 80, 40);//  private
                g.DrawString("Private", Font, Brushes.Black, 35 + (classNumber - 4) * 125, 538);
                g.FillRectangle(Brushes.White, new Rectangle(25 + (classNumber - 4) * 125, 585, 80, 25));
                g.DrawRectangle(Pens.Black, 25 + (classNumber - 4) * 125, 585, 80, 25);//  protected
                g.DrawString("Protected", Font, Brushes.Black, 35 + (classNumber - 4) * 125, 590);
            }
        }

        public void DrawEdge(int from, int to)
        {
            if (from == 0)
            {
                Point firstPoint = new Point(225, 100);
                Point secondPoint = new Point(75 + (to - 1) * 150, 285);
                Graphics g = pictureBox1.CreateGraphics();
                g.DrawString(lettersClass[from], Font, Brushes.Black, firstPoint);
                g.DrawString(lettersClass[to], Font, Brushes.Black, secondPoint);
                g.DrawLine(Pens.Black, 235 + (to - 1) * 20, 210, 115 + (to - 1) * 150, 275);
            }
            else if (adjacencyMatrix.GetLength(0) > 4)
            {
                Point secondPoint = new Point(25 + (to - 4) * 125, 460);
                Graphics g = pictureBox1.CreateGraphics();
                g.DrawString(lettersClass[to], Font, Brushes.Black, secondPoint);
                g.DrawLine(Pens.Black, 95 + (to - 4) * 30 + (from - 1) * 90, 385, 65 + (to - 4) * 125, 450);
            }
        }        

        private int[,] GetAdjacencyMatrix()
        {
            int rows = dataGridView1.Rows.Count;
            int[,] adjacencyMatrix = new int[rows, rows];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    DataGridViewCell cell = dataGridView1.Rows[i].Cells[j];

                    if (cell.Value != null)
                    {
                        adjacencyMatrix[i, j] = Convert.ToInt32(cell.Value);
                    }
                }
            }

            return adjacencyMatrix;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear(); //удаляем ранее созданые столбцы
            if (numericUpDown1.Value <= 8)
            {
                int f = (int)numericUpDown1.Value; //размер матрицы
                dataGridView1.ColumnCount = f;
                dataGridView1.RowCount = f;
                for (int i = 0; i < f; i++)
                {
                    dataGridView1.Rows[i].HeaderCell.Value = lettersClass[i];
                    dataGridView1.Columns[i].HeaderCell.Value = lettersClass[i];
                    dataGridView1.Columns[i].Width = 50;
                }

                for (int i = 0; i < f; i++)
                {
                    for (int j = 0; j < f; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = 0.ToString();
                    }
                }
            }

            else 
            {
                MessageBox.Show("Можно ввести максимально 8 классов");
            }

            Graphics graphics = pictureBox1.CreateGraphics();
            graphics.Clear(Color.White); // очищаем рисунок, нарисованный ранее
            graphics.Dispose(); // освобождаем ресурсы
        }

        
    }
}