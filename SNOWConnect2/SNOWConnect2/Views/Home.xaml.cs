using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SNOWConnect2
{
    public partial class Home
    {
        public Home()
        {
            InitializeComponent();

            HomeViewModel viewmodel = new HomeViewModel(NavigateTo);
            this.BindingContext = viewmodel;
        }

        void NavigateTo(MyIncidents pageType)
        {
            // Get all the constructors of the page type.
            //IEnumerable<ConstructorInfo> constructors =
            //        pageType.GetTypeInfo().DeclaredConstructors;

            //foreach (ConstructorInfo constructor in constructors)
            //{
            //    // Check if the constructor has no parameters.
            //    if (constructor.GetParameters().Length == 0)
            //    {
            //        // If so, instantiate it, and navigate to it.
            //        Page page = (Page)constructor.Invoke(null);
            //        this.Navigation.PushAsync(page);

                    
            //        break;
            //    }
            //}
            //this.Navigation.PushAsync(pageType);

            DisplayAlert("alert", "Success", "OK", null);


        }
    }
}
