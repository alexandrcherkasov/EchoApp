using EchoApplication.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EchoApplication.Helper
{
    public static class DataSaver
    {
        public static ObservableCollection<Project> ProjectCollectionForSave { get; set; }


        public static void SaveData()
        {
            string jsonData = JsonConvert.SerializeObject(ProjectCollectionForSave);
            File.WriteAllText(Directory.GetCurrentDirectory() + "\\dataFile.json", jsonData);
            MessageBox.Show("Файл сохранен");
        }
    }
}
