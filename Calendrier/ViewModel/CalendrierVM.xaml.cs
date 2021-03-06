﻿using Calendrier.Data;
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
        public int Year { get; private set; }
        public byte Week { get; private set; }

        public CalendrierVM()
        {
            var pe = new PachaDataFormationEntities();
            sessions = new ObservableCollection<Session>(pe.GetSessions(2011, 5));
            Year = 2011;
            Week = 5;
            //InitializeComponent();
        }

        protected void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        internal void GetWeek(DateTime dt)
        {
            Year = dt.Year;
            var cal = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
            Week = (byte) cal.GetWeekOfYear(dt.ToLocalTime(),
                System.Globalization.CalendarWeekRule.FirstDay, System.DayOfWeek.Sunday);

            var pe = new PachaDataFormationEntities();
            sessions = new ObservableCollection<Session>(pe.GetSessions(Year, Week));
            OnPropertyChanged("sessions");
        }
        internal void CancelSession(int sessionId)
        {
            var pe = new PachaDataFormationEntities();
            pe.DeleteSession(sessionId);
            sessions.Remove(sessions.First(s => s.SessionId == sessionId));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
