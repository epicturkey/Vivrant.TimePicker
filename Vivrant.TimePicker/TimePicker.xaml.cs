using CSHTML5;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Vivrant.Controls
{
    public partial class TimePicker : UserControl
    {
        #region Constructor
        public TimePicker()
        {
            this.Loaded += TimePicker_Loaded;
            CSharpXamlForHtml5.DomManagement.SetHtmlRepresentation(this, "<input type='time'>");
            this.InitializeComponent();
        }
        #endregion
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(String propName)
        {
            var args = new PropertyChangedEventArgs(propName);
            this.PropertyChanged?.Invoke(this, args);
        }
        #endregion
        #region Loaded Event
        private void TimePicker_Loaded(object sender, RoutedEventArgs e)
        {// Get the reference to the "input" element:
            var inputElement = CSHTML5.Interop.GetDiv(this);

            Action<object> OnChanged = (content) =>
            {
                try
                {
                    TimeSpan ts = DateTime.Parse(content.ToString()).TimeOfDay;
                    this.Time = ts;
                }
                catch (Exception ex)
                {
                    //invalid dt value
                    //this.Time = null;
                }
            };

            // Listen to the "change" property of the "input" element, and call the callback:
            CSHTML5.Interop.ExecuteJavaScript(@"
                $0.addEventListener(""input"", function(e){
                    if(!e){
                      e = window.event;
                    }
                    $1(this.value);
                });", inputElement, OnChanged);
        }
        #endregion
        #region Dependancy Properties
        private static void OnPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {

        }
        public static readonly DependencyProperty TimeProperty =
            DependencyProperty.Register("Time", typeof(string), typeof(TimePicker), new PropertyMetadata(String.Empty, new PropertyChangedCallback(OnPropertyChanged)));
        public TimeSpan? Time
        {
            get { return (TimeSpan?)this.GetValue(TimePicker.TimeProperty); }
            set
            {
                this.SetValue(TimePicker.TimeProperty, value);
                this.RaisePropertyChanged("Time");
            }
        }
        #endregion
    }
}
