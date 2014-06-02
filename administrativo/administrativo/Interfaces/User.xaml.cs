using administrativo.Clases;
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
        private ListBoxItem _dragged;
        List<User_group> userGroup;
        List<User_group> Privilegio;
        public User()
        {
            InitializeComponent();
            userGroup = new User_group().findAll();

            MenuItem root = new MenuItem() { Title = "User Group" };
            MenuItem childItem1 = new MenuItem() { Title = "ADMINISTRADOR" };
            childItem1.Items.Add(new MenuItem() { Title = "Escritura" });
            childItem1.Items.Add(new MenuItem() { Title = "Lectura" });


            MenuItem childItem2 = new MenuItem() { Title = "INVITADOR" };
            childItem2.Items.Add(new MenuItem() { Title = "Lectura" });

            root.Items.Add(childItem1);
            root.Items.Add(childItem2);
            trvMenu.Items.Add(root);
            llenaCombo();
        }

        public void llenaCombo(){
            foreach (User_group list in userGroup)
                this.comboGrupos.Items.Add(list.name);
        }



        private void comboGrupos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Privilegio = new User_group(this.comboGrupos.SelectedIndex+1).getPrivilegio();
            this.List1.Items.Clear();
            this.List2.Items.Clear();
            foreach (User_group list in Privilegio)
                this.List1.Items.Add(list.name);
        }

        private void List1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_dragged != null)
                return;

            UIElement element = List1.InputHitTest(e.GetPosition(List1)) as UIElement;

            while (element != null)
            {
                if (element is ListBoxItem)
                {
                    _dragged = (ListBoxItem)element;
                    break;
                }
                element = VisualTreeHelper.GetParent(element) as UIElement;
            }
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragged == null)
                return;
            if (e.LeftButton == MouseButtonState.Released)
            {
                _dragged = null;
                return;
            }

            DataObject obj = new DataObject(DataFormats.Text, _dragged.ToString());
            DragDrop.DoDragDrop(_dragged, obj, DragDropEffects.All);
        }
        private void List2_DragEnter(object sender, DragEventArgs e)
        {
            if (_dragged == null || e.Data.GetDataPresent(DataFormats.Text, true) == false)
                e.Effects = DragDropEffects.None;
            else
                e.Effects = DragDropEffects.All;
        }
        private void List2_Drop(object sender, DragEventArgs e)
        {
            List1.Items.Remove(_dragged);
            List2.Items.Add(_dragged);
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
