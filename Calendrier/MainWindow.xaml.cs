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

        private void dp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_vm == null) return;
            if (dp.SelectedDate != null)
            {
                _vm.GetWeek(dp.SelectedDate.Value);
                Title.Text = string.Format("Calendrier : {0} sessions en semaine {1}", _vm.sessions.Count, _vm.Week);
            }
        }
    }
}
