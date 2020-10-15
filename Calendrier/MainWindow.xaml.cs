using Calendrier.Data;
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

namespace Calendrier
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Calendrier.ViewModel.CalendrierVM _vm;

        public MainWindow()
        {
            InitializeComponent();
            _vm = new ViewModel.CalendrierVM();
            DataContext = _vm;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnAnnule_Click(object sender, RoutedEventArgs e)
        {
            var s = (Session)dgData.SelectedItem;
            _vm.CancelSession(s.SessionId);
        }
    }
}
