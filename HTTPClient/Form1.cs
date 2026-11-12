using System.Net.Http.Json;
using System.Text.RegularExpressions;

namespace HTTPClient
{
    public partial class Form1 : Form
    {
        MyHTTP myHttp = new MyHTTP();
        string exChar = @"[@#!]";

        public Form1()
        {
            InitializeComponent();
            textBox1.Multiline = true;
            textBox1.ReadOnly = true;
            textBox1.Clear();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = await myHttp.Listen();

                if (Regex.IsMatch(textBox1.Text, exChar))
                {
                    MessageBox.Show("Обнаружены запрещённые символы!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    internal class MyHTTP
    {
        public async Task<string> Listen()
        {
            using HttpClient httpClient = new HttpClient();

            var result = await httpClient.GetFromJsonAsync<Person>(
                "http://localhost:5127");

            return $"Имя: {result?.Name}\r\n" +
                   $"Возраст: {result?.Age}\r\n" +
                   $"Студент: {result?.IsStudent}";
        }

        record Person(string Name, int Age, bool IsStudent);
    }
}
