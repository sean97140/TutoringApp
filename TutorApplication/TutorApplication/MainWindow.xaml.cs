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

        private void NewAppointment(object sender, RoutedEventArgs e)
        {
            Appointment a = new Appointment();
            a.Show();
        }

        private void NewStudent(object sender, RoutedEventArgs e)
        {
            NewStudent n = new NewStudent();
            n.Show();
        }

        private void OpenStudent(object sender, RoutedEventArgs e)
        {
            OpenStudent o = new OpenStudent();
            o.Show();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            TutorLogin l = new TutorLogin();
            l.Show();
        }
    }
}
