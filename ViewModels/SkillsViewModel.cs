using KajsaJosefssonCV.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KajsaJosefssonCV.ViewModels
{
    public class SkillsViewModel : BaseTabViewModel
    {
        public ObservableCollection<SkillModel> Skills { get; }


        public SkillsViewModel()
        {
            Skills = new ObservableCollection<SkillModel>
            {
                new SkillModel { Name = "B-körkort", Level = "God" },
                new SkillModel { Name = "Svenska", Level = "God" },
                new SkillModel { Name = "Engelska", Level = "God" },
                new SkillModel { Name = "Franska", Level = "Nybörjare" },
                new SkillModel { Name = "Isoprogrammering", Level = "Nybörjare-Medel" },
                new SkillModel { Name = "Power BI", Level = "Medel" },
                new SkillModel { Name = "SQL", Level = "Medel" },
                new SkillModel { Name = "C# / WPF", Level = "Nybörjare–Medel" },
                new SkillModel { Name = "Systemutveckling, verksamhets- & datamodellering", Level = "Medel" },
                new SkillModel { Name = "Databaser & Affärssystem (ERP), digitala flöden", Level = "Medel" },
                new SkillModel { Name = "FA/SIMM, VIBA inom förändringsanalys & IS-design", Level = "Medel" },
                new SkillModel { Name = "Bokföring, redovisning, kund- och leverantörsreskontra", Level = "Nybörjare–Medel" },
                new SkillModel { Name = "Bokslutsarbete, ekonomistyrning och budgetuppföljning", Level = "Nybörjare" },
                new SkillModel { Name = "Systemvana med VISMA och Fortnox", Level = "Medel" },
                new SkillModel { Name = "SWOT-analyser", Level = "Medel" },
                new SkillModel { Name = "Marknadsundersökningar", Level = "Nybörjare–Medel" },
                new SkillModel { Name = "Kravhantering", Level = "Medel" },
                new SkillModel { Name = "Strukturerad informationshantering", Level = "Medel" },
                new SkillModel { Name = "Processförbättring & systemförståelse", Level = "Medel" },
                new SkillModel { Name = "Dokumentation och kvalitetsarbete", Level = "Medel" }
            };
        }
    }
}