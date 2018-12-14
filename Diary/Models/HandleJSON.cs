using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        public void addName(FreeTime freeTime)
        {
            DateTime startTimeNEW = DateTime.ParseExact(freeTime.startTime, "HH:mm",null);
            DateTime endTimeNEW = DateTime.ParseExact(freeTime.endTime, "HH:mm", null);

            lock (lockObj)
            {
                foreach(PartialTime partialTime in partialTimes)
                {
                    DateTime startTimeDiary = DateTime.ParseExact(partialTime.startTime, "HH:mm", null);
                    DateTime endTimeDiary = DateTime.ParseExact(partialTime.endTime, "HH:mm", null);

                    //checks if the new time conatains this duration
                    if(startTimeNEW<=startTimeDiary && endTimeNEW >= endTimeDiary)
                    {
                        //checks if already contains
                        if (!partialTime.names.Contains(freeTime.name))
                        {
                            //if not increase counter and add name
                            partialTime.peopleNum++;
                            partialTime.addPerson(freeTime.name);
                        }
                    
                    }
                }
                //edit JSON
                File.WriteAllText(JSON_PATH, JsonConvert.SerializeObject(partialTimes));

            }
        }

        public string getJSON()
        {
            return JsonConvert.SerializeObject(partialTimes);
        }
        public bool appearInStart(string startTime)
        {
            foreach (PartialTime partialTime in partialTimes)
            {
                if (partialTime.startTime.Equals(startTime))
                    return true;
            }
            return false;
        }
        public bool appearInEnd(string endTime)
        {
            foreach (PartialTime partialTime in partialTimes)
            {
                if (partialTime.endTime.Equals(endTime))
                    return true;
            }
            return false;
        }

    }
}
