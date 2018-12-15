using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.Models
{
    public interface IHandleData 
    { 
        string getJSON(Diary diary);
        Diary getDiary();
        void updateDiary(List<PartialTime> partialTimes);
    }
}
