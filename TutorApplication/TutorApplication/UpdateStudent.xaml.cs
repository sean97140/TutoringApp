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
    /// Interaction logic for UpdateStudent.xaml
    /// </summary>
    public partial class UpdateStudent : Window
    {
        public UpdateStudent()
        {
            InitializeComponent();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            // Open a connection to the database...
            MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=students;port=3306;password=;");
            conn.Open();
            // Perform the first query...
            String sql = "UPDATE students.subjectinfo SET subject1 = '" + Subject1.Text + "', subject2 = '" + Subject2.Text + "', subject3 = '" + Subject3.Text + "' WHERE id = '" + id.Text + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            MySqlDataReader sqlReader = cmd.ExecuteReader();
        }
    }
}
