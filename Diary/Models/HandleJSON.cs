using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.Models
{
    public class HandleJSON : IHandleData
    {
        private const string JSON_PATH = @"wwwroot/data/diary.json";
            
        public void updateDiary(List<PartialTime> partialTimes)
        {
            //edit JSON
            File.WriteAllText(JSON_PATH, JsonConvert.SerializeObject(partialTimes));
        }

        public string getJSON(Diary diary)
        {
            return JsonConvert.SerializeObject(diary.getPartialTimes());
        }

        public Diary getDiary()
        {
            List<PartialTime> partialTimes = JsonConvert.DeserializeObject<List<PartialTime>>(File.ReadAllText(JSON_PATH));
            return new Diary(partialTimes);
        }

        
    }
}
