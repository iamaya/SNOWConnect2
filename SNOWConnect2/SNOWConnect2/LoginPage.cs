using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SNOWConnect2
{
    class LoginPage : ContentPage
    {
        public LoginPage()
        {
            Label header = new Label
            {
                Text = "Service Now Login",
                Font = Font.BoldSystemFontOfSize(30),
                HorizontalOptions = LayoutOptions.Center
            };

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            Entry domain = new Entry
                   {
                       Placeholder = "<instancename>.service-now.com"
                   };
            domain.SetBinding(Entry.TextProperty, "DomainName");

            Entry username = new Entry
                   {
                       Placeholder = "User Name",
                       //BindingContext = LoginViewModel
                       //VerticalOptions = LayoutOptions.CenterAndExpand
                   };
            username.SetBinding(Entry.TextProperty, "UserName");

            ViewCell cell = new ViewCell() { 
            
            };

            Entry password = new Entry
            {
                Placeholder = "Password",
                
                //BindingContext = LoginViewModel
                //VerticalOptions = LayoutOptions.CenterAndExpand
            };
            password.SetBinding(Entry.TextProperty, "Password");

            Label statusMessage = new Label() { 
            HeightRequest = 50, TextColor = Color.Aqua
            };

            statusMessage.SetBinding(Label.TextProperty, "StatusMessage");

            // Build the page.
            this.Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                
                Children = 
                {
                   header,
                   domain,
                   username,
                   password,

                   new Button{
                        Text="Login",
                        //WidthRequest=10,
                       // HeightRequest=25
                       Command = new Command(()=>{

                           DisplayAlert("Alert", "", "", "");
                       
                       }),
                    }
                }
            };
        }


    }
}