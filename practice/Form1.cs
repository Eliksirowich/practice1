using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
namespace practice
{
    public partial class Form1 : Form
    {
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
            int[] array = new int[100]; 

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-10001, 10001); 
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
