using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.Models
{
    public interface IHandleData 
    {
        List<String> getStartTimes();
        List<String> getEndTimes();

        void addName(FreeTime freeTime);
    
         string getJSON();

        bool isAppearInStart(string startTime);
        bool isAppearInEnd(string endTime);
        
    }
}
