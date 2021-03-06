﻿using System;
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

namespace TutorApplication
{
    /// <summary>
    /// Interaction logic for TutorLogin.xaml
    /// </summary>
    public partial class TutorLogin : Window
    {
        public TutorLogin()
        {
            InitializeComponent();
        }

        List<Record> list = new List<Record>();
        struct Record
        {
            #region Declarations
            private String id;
            private String password;
            #endregion

            #region Methods
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

            public String Password
            {
                get
                {
                    return password;
                }
                set
                {
                    password = value;
                }
            }

            public void AddRecord(String inID, String inPassword)
            {
                id = inID;
                password = inPassword;
            }
            #endregion
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Record entries = new Record();

            #region Database Handling
            MySqlConnection conn = new MySqlConnection("server=localhost;user=root;database=students;port=3306;password=;");
            conn.Open();
            // Perform the first query...
            String sql = "SELECT * FROM students.tutorpasswords";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            MySqlDataReader sqlReader = cmd.ExecuteReader();
            #endregion

            // Parse through results and store in a list...
            while (sqlReader.Read())
            {
                entries.AddRecord(sqlReader.GetValue(0).ToString(), sqlReader.GetValue(1).ToString());
                // Add the record to the list of records...
                list.Add(entries);
                MessageBox.Show("User: " + entries.ID + "\nPassword: " + entries.Password  + "\n");
            }
        }
    }
}
