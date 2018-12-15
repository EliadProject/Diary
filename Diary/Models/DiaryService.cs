using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.Models
{
    public class DiaryService
    {
        private IHandleData dataConnection;
        private Diary diary;
        private static Object lockObj = new Object();
        public DiaryService(IHandleData handleData)
        {
            dataConnection = handleData;
            diary = dataConnection.getDiary();
        }

        public List<String> getStartTimes()
        {
            return diary.getStartTimes();
        }
        public List<String> getEndTimes()
        {  
            return diary.getEndTimes();
        }
        public void addName(FreeTime freeTime)
        {
            //sensetive acces, need to be synchronized
            lock (lockObj)
            { 
                diary.addName(freeTime);
                dataConnection.updateDiary(diary.getPartialTimes());
            }
                   
        }
        public bool isAppearInStart(string startTime)
        {
            return diary.isAppearInStart(startTime);
        }
        public bool isAppearInEnd(string endTime)
        {

            return diary.isAppearInEnd(endTime);
        }
        public string getJSON()
        {
            return dataConnection.getJSON(diary);
        }

    }
}
