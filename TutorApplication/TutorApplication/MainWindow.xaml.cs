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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Drawing;

namespace TutorApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewStudent(object sender, RoutedEventArgs e)
        {
            // Open a new student form...
            NewStudent n = new NewStudent();
            n.Show();
        }

        private void OpenStudent(object sender, RoutedEventArgs e)
        {
            // Open the window to log in a student.
            OpenStudent o = new OpenStudent();
            o.Show();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            // Open the window to log in a tutor.
            TutorLogin l = new TutorLogin();
            l.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            // Closes the application.
            this.Close();
        }
    }
}
