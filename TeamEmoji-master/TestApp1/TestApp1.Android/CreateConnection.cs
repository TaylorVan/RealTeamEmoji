using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.IO;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TestApp1.Droid
{
    public class CreateConnection
    {
        public static void Open()
        {
            //Name of file
            var sqliteFilename = "lego_parts.db3";
            //Location to save it to in app storage
            string documentsDirectoryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            //Combine the directory and filename to make the file path
            var path = Path.Combine(documentsDirectoryPath, sqliteFilename);

            //Check if the file already exists in the app storage
            //if not, copy it to the internal app storage from the assets folder
            if(!File.Exists(path))
            {
                //Write the file from the assets folder to app storage
                using (var binaryReader = new BinaryReader(Android.App.Application.Context.Assets.Open(sqliteFilename)))
                {
                    using (var binaryWriter = new BinaryWriter(new FileStream(path, FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int length = 0;
                        while((length = binaryReader.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            binaryWriter.Write(buffer, 0, length);
                        }
                    }
                }
            } else
            {
                //Database already created in the app storage, skip creating it
                Console.WriteLine("Database already saved on device");
            }

            
        }
    }
}