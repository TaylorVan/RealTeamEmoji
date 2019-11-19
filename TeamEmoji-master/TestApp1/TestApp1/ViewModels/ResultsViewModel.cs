using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using TestApp1.Models;

namespace TestApp1.ViewModels
{
    public class ResultsViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Group { get; set; } = string.Empty;
        public string PartID { get; set; } = string.Empty;
        public string storeLink { get; set; } = string.Empty;

        public Part PartGuessed { get; set; }


    }

}
