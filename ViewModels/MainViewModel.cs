using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KajsaJosefssonCV.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KajsaJosefssonCV.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        // Flikarna i TabControl
        public ObservableCollection<BaseTabViewModel> Tabs { get; }

        private BaseTabViewModel _selectedTab;
        private readonly PdfService _pdfService;

        public IRelayCommand ExportPdfCommand { get; }

        public BaseTabViewModel SelectedTab
        {
            get => _selectedTab;
            set => SetProperty(ref _selectedTab, value);
        }

        // Header-information som visas högst upp
        public string HeaderName => "Kajsa Josefsson";
        public string HeaderEmail => "kajsa.josefsson92@hotmail.com";
        public string HeaderPhone => "073-089 15 12";
        public string HeaderTitle => "Dataekonom söker jobb efter examen inom både IT och Ekonomi-sektorn";

        public MainViewModel()
        {
            _pdfService = new PdfService();

            ExportPdfCommand = new RelayCommand(() =>
            {
                _pdfService.CreatePdf();
            });

            // Skapa flikarna med rätt ViewModels
            Tabs = new ObservableCollection<BaseTabViewModel>
            {
                new HomeViewModel { TabHeader = "Hem" },
                new AboutViewModel { TabHeader = "Om mig" },
                new ExperienceViewModel { TabHeader = "Arbetslivserfarenhet" },
                new EducationViewModel { TabHeader = "Utbildning" },
                new SkillsViewModel { TabHeader = "Kompetenser" }
            };

            // Välj första fliken som standard
            SelectedTab = Tabs.FirstOrDefault();
        }
    }
}