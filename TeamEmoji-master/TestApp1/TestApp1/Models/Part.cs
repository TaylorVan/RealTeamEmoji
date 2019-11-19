using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp1.Models
{
    public class Part
    {
        public string name;
        public string partId;
        public int colour;
        public int quantity;
        public int numPhotos;
        public string partURL;

        public Part(string pId, int c, int q, int n)
        {
            name = "Placeholder";
            partId = pId;
            partURL = "https://asset.pitsco.com/sharedimages/product/icongo/icg_45349-2x2-brick-single.jpg"; //PLACEHOLDER
            colour = c;
            quantity = q;
            numPhotos = n;
        }

        public Part(string nom, string pId, int c, int q, int n)
        {
            name = nom;
            partURL = "https://asset.pitsco.com/sharedimages/product/icongo/icg_45349-2x2-brick-single.jpg"; //PLACEHOLDER
            partId = pId;
            colour = c;
            quantity = q;
            numPhotos = n;
        }

        public Part(string nom, string pURL, string pId, int c, int q, int n)
        {
            name = nom;
            partURL = pURL;
            partId = pId;
            colour = c;
            quantity = q;
            numPhotos = n;
        }
    }
}
