using Doljniki.Model;
using Doljniki.ViewModel.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Doljniki.ViewModel.Classes
{
    public class JsonFileService : IFileService
    {
        public List<Doljnik> Open(string filename)
        {
            List<Doljnik> doljniks = new List<Doljnik>();
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Doljnik>));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                doljniks = jsonFormatter.ReadObject(fs) as List<Doljnik>;
            }

            return doljniks;
        }

        public void Save(string filename, List<Doljnik> doljnikList)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Doljnik>));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, doljnikList);
            }
        }
    }
}
