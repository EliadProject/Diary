using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.Models
{
    public class HandleJSON
    {
        private const string JSON_PATH = @"wwwroot/data/diary.json";
        private static HandleJSON handleJSON;
        private static Object lockObj = new Object();

        private List<PartialTime> partialTimes;
        private HandleJSON()
        {
             partialTimes = JsonConvert.DeserializeObject<List<PartialTime>>(File.ReadAllText(JSON_PATH));
        }
        public static  HandleJSON getInstance()
        {
            if(handleJSON == null)
            {
                lock (lockObj)
                {
                    handleJSON = new HandleJSON();
                }
            }
            return handleJSON;
        }
        public List<String> getStartTimes()
        {
            List<String> startTimeList = new List<string>();
            foreach (PartialTime partialTime in partialTimes)
            {
                startTimeList.Add(partialTime.startTime);
            }
            return startTimeList;
        }
        public List<String> getEndTimes()
        {
            List<String> endTimeList = new List<string>();
            foreach (PartialTime partialTime in partialTimes)
            {
                endTimeList.Add(partialTime.endTime);
            }
            return endTimeList;
        }
        public void addName(string name, string startTime, string endTime)
        {

        }
       
    }
}
