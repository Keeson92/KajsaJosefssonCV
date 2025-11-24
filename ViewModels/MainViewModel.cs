using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KajsaJosefssonCV.Services;
using System.Collections.ObjectModel;
using System.Linq;

namespace KajsaJosefssonCV.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public ObservableCollection<BaseTabViewModel> Tabs { get; }
        private BaseTabViewModel _selectedTab;
        private readonly PdfService _pdfService;

        public IRelayCommand ExportPdfCommand { get; }

        public BaseTabViewModel SelectedTab
        {
            get => _selectedTab;
            set => SetProperty(ref _selectedTab, value);
        }

        // Header-information
        public string HeaderName => "Kajsa Josefsson";
        public string HeaderTitle => "Dataekonom söker jobb efter examen inom både IT och Ekonomi-sektorn";
        public string HeaderEmail => "kajsa.josefsson@email.com";
        public string HeaderPhone => "070-123 45 67";

        public MainViewModel()
        {
            _pdfService = new PdfService();

            ExportPdfCommand = new RelayCommand(() =>
            {
                _pdfService.CreatePdf(this);
            });

            // Skapa flikarna
            Tabs = new ObservableCollection<BaseTabViewModel>
            {
                new HomeViewModel { TabHeader = "Hem", DisplayContent = "Välkommen till mitt CV!" },
                new AboutViewModel { TabHeader = "Om mig", DisplayContent = "Jag är en driven dataekonom med intresse för BI och IT." },
                new ExperienceViewModel { TabHeader = "Arbetslivserfarenhet", DisplayContent = "Jobbat med ekonomisystem och dataanalys." },
                new EducationViewModel { TabHeader = "Utbildning", DisplayContent = "Examen inom Ekonomi och IT." },
                new SkillsViewModel { TabHeader = "Kompetenser", DisplayContent = "Excel, Power BI, SQL, WPF, C#." }
            };

            SelectedTab = Tabs.FirstOrDefault();
        }
    }
}