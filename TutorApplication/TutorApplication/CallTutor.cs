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
    public partial class CallTutor : Form
    {
        public CallTutor()
        {
            InitializeComponent();
        }
        List<Record> list = new List<Record>();

        struct Record
        {
            #region Declarations
            private String id;
            public String userID;
            #endregion
            
            #region Methods
            public void AddRecord(String inID, String inuserID)
            {
                id = inID;
                userID = inuserID;
            }
            #endregion

            #region Properties
            public String ID
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

            public String UserID
            {
                get
                {
                    return userID;
                }
                set
                {
                    userID = value;
                }
            }

            #endregion
        }

        private void CallTutor_Load(object sender, EventArgs e)
        {
            Record entries = new Record();
            #region Database Handling
            MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=students;port=3306;password=;");
            conn.Open();
            // Perform the first query...
            String sql = "SELECT * FROM students.tutorsskype";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            MySqlDataReader sqlReader = cmd.ExecuteReader();
            #endregion

            // Parse through results and store in a list...
            while (sqlReader.Read())
            {
                entries.AddRecord(sqlReader.GetValue(0).ToString(), sqlReader.GetValue(1).ToString());
                comboBox1.Items.Add(sqlReader.GetValue(0).ToString());
                // Add the record to the list of records...
                list.Add(entries);
                //MessageBox.Show("User: " + entries.ID + "\nUser ID: " + entries.userID + "\n");
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=students;port=3306;password=;");
            conn.Open();
            // Perform the first query...
            String sql = "SELECT * FROM students.tutorsskype WHERE name='" + comboBox1.Text.ToString() + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            MySqlDataReader sqlReader = cmd.ExecuteReader();
            while (sqlReader.Read())
            {
               MessageBox.Show(sqlReader.GetValue(1).ToString());
            }
            skype_test.SkypeCall skypeInstance = new skype_test.SkypeCall();
            skypeInstance.StartSkypeSession(sqlReader.GetValue(1).ToString(), true);
        }
    }
}
