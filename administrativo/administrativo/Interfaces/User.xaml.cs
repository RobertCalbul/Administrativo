using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace administrativo.Interfaces
{
    /// <summary>
    /// Interaction logic for User.xaml
    /// </summary>
    public partial class User : UserControl
    {
        public User()
        {
            InitializeComponent(); 
            MenuItem root = new MenuItem() { Title = "User Group" };
            MenuItem childItem1 = new MenuItem() { Title = "ADMINISTRADOR" };
            childItem1.Items.Add(new MenuItem() { Title = "Escritura" });
            childItem1.Items.Add(new MenuItem() { Title = "Lectura" });


            MenuItem childItem2 = new MenuItem() { Title = "INVITADOR" };
            childItem2.Items.Add(new MenuItem() { Title = "Lectura" });

            root.Items.Add(childItem1);
            root.Items.Add(childItem2);
            trvMenu.Items.Add(root);
        }

        private void UserGroupLoad(object sender, RoutedEventArgs e)
        {
           

        }

    }
    public class MenuItem
    {
        public MenuItem()
        {
            this.Items = new ObservableCollection<MenuItem>();
        }

        public string Title { get; set; }

        public ObservableCollection<MenuItem> Items { get; set; }
    }

}
