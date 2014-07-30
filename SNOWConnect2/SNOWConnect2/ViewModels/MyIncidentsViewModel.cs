using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNOWConnect2.ViewModels
{
    public class MyIncidentsViewModel :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public List<SNOWConnect2.Models.MyIncidents.Result> _response;

        public MyIncidentsViewModel()
        {
            IMyIncidentsService _myincidentsService = new MyIncidentsService();

            _myincidentsService.GetMyIncidents("convenedev", "ikumar", "password",
                success =>
                {
                    Response = success.result;
                }, 
                error => 
                {
                    throw error;
                });
        }

        public List<SNOWConnect2.Models.MyIncidents.Result> Response 
        {
            get
            {
                return _response;
            }
            set
            {
                if (_response != value)
                {
                    _response = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Response"));
                    }
                }
            }
        }
    }
}
