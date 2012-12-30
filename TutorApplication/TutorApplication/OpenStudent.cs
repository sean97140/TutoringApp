using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace TutorApplication
{
    public partial class OpenStudent : Form
    {
        public OpenStudent()
        {
            InitializeComponent();
        }

        List<Record> list = new List<Record>();
        struct Record
        {
            #region Declarations
            private int id;
            private String firstName;
            private String middleInitial;
            private String lastName;
            #endregion

            #region Methods
            public void AddRecord(int inID, String inFname, String inmiddleInitial, String inLname)
            {
                id = inID;
                firstName = inFname;
                middleInitial = inmiddleInitial;
                lastName = inLname;
            }
            #endregion

            #region Properties
            public int ID
            {
                get
                {
                    return id;
                }
                set
                {
                    id = value;
                }
            }

            public String FirstName
            {
                get
                {
                    return firstName;
                }
                set
                {
                    firstName = value;
                }
            }

            public String MiddleInitial
            {
                get
                {
                    return middleInitial;
                }
                set
                {
                    middleInitial = value;
                }
            }

            public String LastName
            {
                get
                {
                    return lastName;
                }
                set
                {
                    lastName = value;
                }
            }
            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Record entries = new Record();

            #region Database Handling
            list.Clear();
            var id = StudentID.Text;
            // Open a connection to the database...
            MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=students;port=3306;password=;");
            conn.Open();
            // Perform the first query...
            String sql = "SELECT * FROM students.demographics WHERE id = '" + id + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            MySqlDataReader sqlReader = cmd.ExecuteReader();
            #endregion

            // Parse through results and store in a list...
            while (sqlReader.Read())
            {
                entries.AddRecord(Convert.ToInt32(sqlReader.GetValue(0)), sqlReader.GetValue(1).ToString(), sqlReader.GetValue(2).ToString(), sqlReader.GetValue(3).ToString());
                // Add the record to the list of records...
                list.Add(entries);
            }

            // If we have an empty list, let the user know.
            if (list.Count == 0)
            {
                MessageBox.Show("ID returned no matches", "No results");
            }
            else
            {
                MessageBox.Show("Confirm:\nYour name is: " + entries.FirstName + " " + entries.LastName, "Confirmation", MessageBoxButtons.YesNo);
            }
        }
    }
}
