using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivrant.Presenter
{
    public class TimePresenter
    {
        public TimePresenter()
        {

        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChangedEvent(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private TimeSpan _ts;
        public TimeSpan Time
        {
            get { return _ts; }
            set
            {
                _ts = value;
                RaisePropertyChangedEvent("Time");
            }
        }
    }
}
