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
    public class ExperienceViewModel : BaseTabViewModel
    {
        public ObservableCollection<ExperienceModel> Experiences { get; }


        public ExperienceViewModel()
        {
            Experiences = new ObservableCollection<ExperienceModel>
{
                new ExperienceModel
                {
                    Role = "Timanställd amanuens",
                    Company = "Högskolan i Borås",
                    Period = "2025 - nuvarande",
                    Description = "Stödjer undervisningen i kurser som System- och organisationsteori, med handledning i verksamhetsanalys, modellering och organisationsanalys."
                },
                new ExperienceModel
                {
                    Role = "Lokalvårdare",
                    Company = "Hemtrevligt Skaraborg AB",
                    Period = "sommar 2024",
                    Description = "Planerade och utförde arbete självständigt med fokus på kvalitet, struktur och kundnöjdhet.\n Tränade förmågan att arbeta metodiskt, följa processer och hantera känslig information säkert.\n Lärde mig snabbt anpassa mig till nya rutiner och digitala verktyg – erfarenheter som stärker min IT-förståelse.\n"
                },
                new ExperienceModel
                {
                    Role = "Vårdbiträde 80%",
                    Company = "Ulricehamns Kommun",
                    Period = "2023-03 - 2023-08",
                    Description = "Ansvarade för omsorg, dokumentation och medicindelegering.\n Utvecklade min noggrannhet, ansvarskänsla och vana att följa standardiserade rutiner, färdigheter jag tillämpar även i systemarbete.\n"
                },
                new ExperienceModel
                {
                    Role = "Vårdbiträde helgjobb sommar",
                    Company = "SÄS, Borås Kommun",
                    Period = "2020",
                    Description = "Viss administrativ roll, förberedde rum och patienter inför radiologi-undersökningar. \n Stötte röntgensjuksköterskorna utefter deras behov. Hanterade hygieniska delar mellan moment."
                },
                new ExperienceModel
                {
                    Role = "Maskin/CNC-operatör",
                    Company = "Precomp Solutions AB, 6mån \n" + "samt Mastec 1mån",
                    Period = "2017",
                    Description = "Arbetade i strukturerade produktionsflöden med diverse maskiner, utförde mindre mätkontroller samt även sortering och packning.\n Några delar jag fick lära mig här var excenterpressar, nålprägling, anoljning, hantera lasermaskin, bandslip och fick även prova på robotsvets. \n Att jag lärde mig så mycket på 6 månader talar för att jag är snabblärd och anpassningsbar till de arbetsuppgifter som har prio. \n Fick förståelse för processer, precision och datadrivet arbete, vilket skapade en grund för mitt intresse för IT och system.\n"
                },
                new ExperienceModel
                {
                    Role = "Service och kundnära roller",
                    Company = "Transcom, Café Doppet, Rederi Åsunden",
                    Period = "2009-2014",
                    Description = "Diverse kundrelaterade arbeten på deltid upp till 75%, som kundtjänstmedarbetare och servitris. \n Här lärde jag mig multitasking, ta vara på kundkrav och uppnå kundnöjdhet. \n Lite allt i allo, med vissa administrativa uppgifter med, så som kalasbokningar, spärrtjänst och justeringar mot fakturor \n exempelvis kreditering eller justering av datum. Via Transcom fick jag erfarenhet av systemarbete med bland annat Siebel och CABS m.m."
                }
            };
        }
    }
}