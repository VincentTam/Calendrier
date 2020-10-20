using Calendrier.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Calendrier.ViewModel
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class CalendrierVM : UserControl,  INotifyPropertyChanged
    {
        public ObservableCollection<Session> sessions { get; private set; }

        public CalendrierVM()
        {
            var pe = new PachaDataFormationEntities();
            sessions = new ObservableCollection<Session>(pe.GetSessions(2011, 5));
            InitializeComponent();
        }

        internal void CancelSession(int sessionId)
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
