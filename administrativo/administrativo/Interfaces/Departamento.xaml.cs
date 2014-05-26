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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;
using administrativo.Clases;
using System.Diagnostics;
namespace administrativo.Interfaces
{
    /// <summary>
    /// Interaction logic for Departamento.xaml
    /// </summary>
    public partial class Departamento : UserControl
    {
        List<DepartamentoClass> _Departamento = null;
        public Departamento()
        {
            InitializeComponent();
            _Departamento = new DepartamentoClass().findAll();
            this.data.ItemsSource = _Departamento;
            
        }
        int index = 0;
        private void load_grid(object sender, RoutedEventArgs e)
        {
            

        }

        private void addRow_Click(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            foreach (object obj in this.data.SelectedItems)
            {
                this.tName.Text = ((DepartamentoClass)obj).nombre;
                this.tId.Text = ((DepartamentoClass)obj).id+"";
                this.tRut.Text = ((DepartamentoClass)obj).rut_jefe;
            }
            
       
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (new DepartamentoClass(int.Parse(this.tId.Text),
                                        this.tName.Text, this.tRut.Text
                                        ).update() > 0)
            {
                _Departamento = new DepartamentoClass().findAll();
                this.data.ItemsSource = _Departamento;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            new DepartamentoClass(this.tName.Text, this.tRut.Text).save();
            _Departamento = new DepartamentoClass().findAll();
            this.data.ItemsSource = _Departamento;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            foreach (object obj in this.data.SelectedItems)
            {
                new DepartamentoClass(((DepartamentoClass)obj).id).Delete(); 
            }
            _Departamento = new DepartamentoClass().findAll();
            this.data.ItemsSource = _Departamento;
        }







  
  }    
}
