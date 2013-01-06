using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TutorApplication
{
    /// <summary>
    /// Interaction logic for QuizPage.xaml
    /// </summary>
    public partial class QuizPage : Window
    {
        String correctAnswer;
        public QuizPage()
        {
            InitializeComponent();
            MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=students;port=3306;password=;");
            conn.Open();
            // Perform the first query...
            String sql = "SELECT * FROM testbank";

            // Execute the SQL query
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            MySqlDataReader sqlReader = cmd.ExecuteReader();

            // Parse through results and store in a list...
            while (sqlReader.Read())
            {
                correctAnswer = sqlReader.GetValue(0).ToString();
                QuestionLbl.Content += sqlReader.GetValue(1).ToString();
                Answer1.Content += sqlReader.GetValue(2).ToString();
                Answer2.Content += sqlReader.GetValue(3).ToString();
                Answer3.Content += sqlReader.GetValue(4).ToString();
                Answer4.Content += sqlReader.GetValue(5).ToString();
            }

        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (Answer1.IsChecked == true)
            {

            }
            else if (Answer2.IsChecked == true)
            {

            }
            else if (Answer2.IsChecked == true)
            {

            }
            else if (Answer2.IsChecked == true)
            {

            }
        }
    }
}
