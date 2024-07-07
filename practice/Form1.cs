using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
namespace practice
{
    public partial class Form1 : Form
    {
        int a = 100000;
        int b = -1001;
        int c = 1001;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Random random = new Random();
            int[] array = new int[a];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(b+1, c+1);
            }


            string filePath = "array.txt";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (int number in array)
                {
                    writer.WriteLine(number);
                }
            }

            MessageBox.Show("Файл с неотсортированным массивом создан.");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            string filePath = "array.txt";
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Файл с массивом не найден.");
                return;
            }

            string[] lines = File.ReadAllLines(filePath);
            int[] array = new int[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                array[i] = int.Parse(lines[i]);
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            array = ShellSort(array);
            stopwatch.Stop();
            string sortedFilePath = "sorted_array.txt";
            using (StreamWriter writer = new StreamWriter(sortedFilePath))
            {
                foreach (int number in array)
                {
                    writer.WriteLine(number);
                }
            }

            MessageBox.Show($"Массив отсортирован и записан в файл. Время сортировки: {stopwatch.Elapsed.TotalSeconds} секунд.");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToInt32(textBox1.Text);
            }
            catch (FormatException)
            {
                    MessageBox.Show("Некорректный ввод, введите число.");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {   
            try
            {
                b = Convert.ToInt32(textBox2.Text);
            }
            catch (FormatException)
            {
                if (textBox2.Text != "-")
                {
                    MessageBox.Show("Некорректный ввод, введите число.");
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                c = Convert.ToInt32(textBox3.Text);
            }
            catch (FormatException)
            {
                if (textBox3.Text != "-")
                {
                    MessageBox.Show("Некорректный ввод, введите число.");
                }
            }
        }


    }
}