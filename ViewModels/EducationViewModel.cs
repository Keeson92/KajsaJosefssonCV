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
    public class EducationModel
    {
        public string Degree { get; set; }
        public string Institution { get; set; }
        public string Period { get; set; }
        public string Notes { get; set; }
    }

    public class EducationViewModel : BaseTabViewModel
    {
        public ObservableCollection<EducationModel> Educations { get; }

        public EducationViewModel()
        {
            TabHeader = "Utbildning";

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
                    Notes = "Estetiska programmet, med inriktning teater.\nMedverkade i slutmusikalen Hairspray, assisterade även som ljustekniker åt slutproduktionen året dessförinnan (Footloose)."
                }
            };

            PopulateContentItems();
        }

        private void PopulateContentItems()
        {
            ContentItems = new ObservableCollection<string>();

            foreach (var edu in Educations)
            {
                ContentItems.Add($"{edu.Degree} - {edu.Institution} ({edu.Period})");

                if (!string.IsNullOrWhiteSpace(edu.Notes))
                {
                    foreach (var line in edu.Notes.Split('\n'))
                    {
                        ContentItems.Add("  " + line.Trim());
                    }
                }

                ContentItems.Add(""); // extra rad mellan utbildningar
            }
        }
    }
}