using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;

namespace TestApp1.ViewModels
{
    public class ResultsViewModel: INotifyPropertyChanged
    {
        public string Name { get; set; } = string.Empty;
        public string Group { get; set; } = string.Empty;
        public string PartID { get; set; } = string.Empty;
        public string StoreLink { get; set; } = string.Empty;

        public List<Piece> PiecesGuessed { get; set; }
        public Piece PieceGuessed { get; set; }

        public Boolean isLoading;
        public Boolean PieceNotIdentified;
        public double Probability;

        public event PropertyChangedEventHandler PropertyChanged;


        public Boolean OverrideBackButton { get; set; }

        public Boolean IsLoading
        {
            get { return isLoading; }

            set
            {
                if (isLoading != value)
                {
                    isLoading = value;

                    //if (PropertyChanged != null)
                    //{
                        PropertyChanged(this, new PropertyChangedEventArgs("IsLoading"));
                    //}
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var propertyChangedCallback = PropertyChanged;
            propertyChangedCallback?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

    }

}
