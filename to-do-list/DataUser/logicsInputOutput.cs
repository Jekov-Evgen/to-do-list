using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace to_do_list.DataUser
{
    internal class logicsInputOutput
    {
        private readonly string PATH;
        
        public logicsInputOutput(string path)
        {
            PATH = path;
        }

        public BindingList<Logics> DataLoad()
        {
            var fileEx = File.Exists(PATH);

            if (!fileEx) 
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<Logics>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileT = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<Logics>>(fileT);   
            }
        }

        public void SaveDataToHD(object listData)
        {
            using (StreamWriter writer = File.CreateText(PATH)) 
            {
                string output = JsonConvert.SerializeObject(listData);
                writer.WriteLine(output);
            }
        }
    }
}
