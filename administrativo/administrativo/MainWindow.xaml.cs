using administrativo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace administrativo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Departamento _Departamento;
        private User _User;
        public MainWindow()
        {
            InitializeComponent();
            _Departamento = new Departamento();
            _User = new User();
        }

        private void TreeView_Loaded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = new TreeViewItem();
            item.Header = "Gestion Usuarios";
            item.ItemsSource = new string[] { "Privilegios", "Grupos Usuarios", "Nuevo usuario" };

            // ... Create a second TreeViewItem.
            TreeViewItem item2 = new TreeViewItem();
            item2.Header = "Departamento";
            item2.ItemsSource = new string[] { "Nuevo departamento", "Asignar jefe" };

            // ... Get TreeView reference and add both items.
            var tree = sender as TreeView;
            tree.Items.Add(item);
            tree.Items.Add(item2);
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var tree = sender as TreeView;

            // ... Determine type of SelectedItem.
            if (tree.SelectedItem is TreeViewItem)
            {
                // ... Handle a TreeViewItem.
                var item = tree.SelectedItem as TreeViewItem;
                this.Title = "Selected header padre: " + item.Header.ToString();
                if (item.Header.ToString().Equals("Departamento"))
                {
                    this.WorkSpace.Children.Clear();
                    this.WorkSpace.Children.Add(_Departamento);

                }else{
                    this.WorkSpace.Children.Clear();
                    this.WorkSpace.Children.Add(_User);
                }
            }
            else if (tree.SelectedItem is string)
            {
                // ... Handle a string.
                this.Title = "Selected hijo: " + tree.SelectedItem.ToString();
            }
        }
    }
}
