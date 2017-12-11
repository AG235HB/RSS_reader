using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RSS_reader
{
    public class Post: INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string _title;
        private string _link;
        private string _description;
        private string _date;//перепилить в DateTime позднее
        
        public string Title
        {
            get { return _title; }
            set { _title = value;
                OnPropertyChanged("Title"); }
        }

        public string Link
        {
            get { return _link; }
            set
            {
                _link = value;
                OnPropertyChanged("Link"); }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description"); }
        }

        public string Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged("Date"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
