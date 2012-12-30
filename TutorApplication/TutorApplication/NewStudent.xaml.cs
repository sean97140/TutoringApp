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
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace TutorApplication
{
    /// <summary>
    /// Interaction logic for NewStudent.xaml
    /// </summary>
    public partial class NewStudent : Window
    {
        public NewStudent()
        {
            InitializeComponent();
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            string connStr = "server=localhost;user=root;database=students;port=3306;password=;";
            MySqlConnection conn = new MySqlConnection(connStr);
            List<String> errorList = new List<String>();
            int numErrors = 0;
            try
            {
                #region Error Validation
                // Begin error validation checks using Regular Expressions
                if (!Regex.IsMatch(f_name.Text, "[A-Za-z]"))
                {
                    errorList.Add("First Name");
                    numErrors++;
                }
                if (!Regex.IsMatch(mi.Text, "[A-Za-z]{1}"))
                {
                    errorList.Add("Middle Initial");
                    numErrors++;
                }
                if (!Regex.IsMatch(l_name.Text, "[A-Za-z]"))
                {
                    errorList.Add("Last Name");
                    numErrors++;
                }
                if (!Regex.IsMatch(subject.Text, "[A-Za-z]") && subject.Text.Length > 0)
                {
                    errorList.Add("Subject 1");
                    numErrors++;
                }
                if (!Regex.IsMatch(subject2.Text, "[A-Za-z]") && subject2.Text.Length > 0)
                {
                    errorList.Add("Subject 2");
                    numErrors++;
                } 
                if (!Regex.IsMatch(subject3.Text, "[A-Za-z]") && subject3.Text.Length > 0)
                {
                    errorList.Add("Subject 3");
                    numErrors++;
                }
                // End error checking
                #endregion

                // If there are errors, print them out so the user can rectify...
                if (numErrors > 0)
                {
                    StringBuilder errorsToFix = new StringBuilder("");
                    errorsToFix.Append("Please fix the following fields:\n");
                    foreach (String error in errorList)
                    {
                        errorsToFix.Append(error + '\n');
                    }
                    MessageBox.Show(errorsToFix.ToString(), "Errors found");
                }
                else if (numErrors == 0)
                {
                    #region Database Handling
                    // Open a connection to the database...
                    conn.Open();
                    // Perform the first query...
                    String sql = "INSERT INTO students.demographics(id, f_name, mi, l_name) VALUES('" + id.Text + "', '" + f_name.Text + "', '" + mi.Text + "', '" + l_name.Text + "')";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    // Perform the second SQL query...
                    sql = "INSERT INTO students.subjectinfo(id, subject1, subject2, subject3) VALUES('" + id.Text + "', '" + subject.Text + "', '" + subject2.Text + "', '" + subject3.Text + "')";
                    cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conn.Close();
        }
    }
}
