using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KajsaJosefssonCV.ViewModels
{
    public class BaseTabViewModel : ObservableObject
    {
        public string TabHeader { get; set; }
        public ObservableCollection<string> ContentItems { get; set; } = new();
    }
}