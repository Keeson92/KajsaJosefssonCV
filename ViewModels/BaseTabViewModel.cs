using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;

namespace KajsaJosefssonCV.ViewModels
{
    public class BaseTabViewModel : ObservableObject
    {
        public string TabHeader { get; set; }
        public string DisplayContent { get; set; }
    }
}