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
using MySql.Data.MySqlClient;

namespace TutorApplication
{
    /// <summary>
    /// Interaction logic for StudentProfile.xaml
    /// </summary>
    public partial class StudentProfile : Window
    {
        public StudentProfile()
        {
            InitializeComponent();
            MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=students;port=3306;password=;");
            conn.Open();
            // Perform the first query...
            String sql = "SELECT f_name, score FROM demographics RIGHT OUTER JOIN studentscore ON demographics.id = studentscore.id";

            // Execute the SQL query
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            MySqlDataReader sqlReader = cmd.ExecuteReader();

            // Parse through results and store in a list...
            while (sqlReader.Read())
            {
                NameLbl.Content += sqlReader.GetValue(0).ToString();
                ScoreLbl.Content += sqlReader.GetValue(1).ToString();
            }
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (QuizRadio.IsChecked == true)
            {
                // Start a quiz
            }
            else if (SubjectRadio.IsChecked == true)
            {
                // Open window to change subject preferences
            }
            else if (TutorApptRadio.IsChecked == true)
            {
                // Open window to set up an appointment with a tutor.
                Appointment a = new Appointment();
                a.Show();
            }
            else if (CallTutorRadio.IsChecked == true)
            {
                // Open the call a tutor window...
                CallTutor c = new CallTutor();
                c.Show();
            }
        }
    }
}
