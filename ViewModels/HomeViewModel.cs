using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Ribbon;
using System.Collections.ObjectModel;

namespace KajsaJosefssonCV.ViewModels
{
    public class HomeViewModel : BaseTabViewModel
    {
        public string PageTitle { get; set; } = "IT-Ekonom som älskar system- och processförbättringar";
        public string WelcomeText { get; set; } = "Hej! Jag heter Kajsa Josefsson. Välkommen till mitt CV.";

        public HomeViewModel()
        {
            TabHeader = "Hem";

            // Fyll ContentItems om du vill visa välkomsttexten i PDF också
            ContentItems = new ObservableCollection<string>
            {
                WelcomeText
            };
        }
    }
}