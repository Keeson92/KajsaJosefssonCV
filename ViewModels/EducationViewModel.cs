using KajsaJosefssonCV.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;

namespace KajsaJosefssonCV.ViewModels
{
    public class EducationViewModel : BaseTabViewModel
    {
        public ObservableCollection<EducationModel> Educations { get; }


        public EducationViewModel()
        {
            Educations = new ObservableCollection<EducationModel>
            {
                new EducationModel
                {
                    Degree = "Kandidatexamen i IT - inriktning Marknadsföring",
                    Institution = "Högskolan i Borås",
                    Period = "2023 - 2026",
                    Notes = "Kurser inom systemutveckling, affärssystem, verksamhetsanalys, databaser, modellering och ekonomi"
                },
                new EducationModel
                {
                    Degree = "Ekonomiassistent",
                    Institution = "Xpectum",
                    Period = "2023 7mån",
                    Notes = "Bokföring, redovisning, reskontrahantering, budgetering och rapportering."
                },
                new EducationModel
                {
                    Degree = "CNC-Teknik",
                    Institution = "Högskolan i Dalarna",
                    Period = "2023 6mån",
                    Notes = "Enskild högskolekurs, 2hp inom Isoprogrammering."
                },
                new EducationModel
                {
                    Degree = "Gymnasieexamen",
                    Institution = "Tingsholmsgymnasiet",
                    Period = "2010 - 2013",
                    Notes = "Estetiska programmet, med inriktning teater. \n Medverkade i slutmusikalen Hairspray, assisterade även som ljustekniker åt slutproduktionen året dessförinnan (Footloose)."
                }
            };
        }
    }
}