using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KajsaJosefssonCV.ViewModels
{
    public class HomeViewModel : BaseTabViewModel
    {
        public string PageTitle { get; set; } = "IT-Ekonom som älskar system- och processförbättringar";
        public string WelcomeText { get; set; } =
            "Hej! Jag heter Kajsa Josefsson. Välkommen till mitt CV.";
    }
}