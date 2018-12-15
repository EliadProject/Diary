using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.Models
{
    public class Diary
    {
        
        private List<PartialTime> partialTimes;
        public Diary(List<PartialTime> partialTimes)
        {
            this.partialTimes = partialTimes;
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
            DateTime startTimeNEW = DateTime.ParseExact(freeTime.startTime, "HH:mm", null);
            DateTime endTimeNEW = DateTime.ParseExact(freeTime.endTime, "HH:mm", null);

            
                foreach (PartialTime partialTime in partialTimes)
                {
                    DateTime startTimeDiary = DateTime.ParseExact(partialTime.startTime, "HH:mm", null);
                    DateTime endTimeDiary = DateTime.ParseExact(partialTime.endTime, "HH:mm", null);

                    //checks if the new time conatains this duration
                    if (startTimeNEW <= startTimeDiary && endTimeNEW >= endTimeDiary)
                    {
                        //checks if already contains
                        if (!partialTime.names.Contains(freeTime.name))
                        {
                            //if not increase counter and add name
                            partialTime.peopleNum++;
                            partialTime.addPerson(freeTime.name);
                        }

                    }
                
                //edit JSON
               

            }
        }

        public bool isAppearInStart(string startTime)
        {
            foreach (PartialTime partialTime in partialTimes)
            {
                if (partialTime.startTime.Equals(startTime))
                    return true;
            }
            return false;
        }
        public bool isAppearInEnd(string endTime)
        {
            foreach (PartialTime partialTime in partialTimes)
            {
                if (partialTime.endTime.Equals(endTime))
                    return true;
            }
            return false;
        }
        public List<PartialTime> getPartialTimes()
        {
            return partialTimes;
        }

    }
}
