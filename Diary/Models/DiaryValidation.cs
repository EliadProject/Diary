using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.Models
{
    public static class DiaryValidation
    {
        public static  bool isFreeTimeLegal(FreeTime freeTime, BuisnessLogic dataService)
        {
            //checks if start and end time appear in the list 
            if  (!dataService.isAppearInStart(freeTime.startTime))
                return false;
            if (!dataService.isAppearInEnd(freeTime.endTime))
                return false;

            //checks if end is bigger than start
            DateTime startTime = DateTime.ParseExact(freeTime.startTime, "HH:mm", null);
            DateTime endTime = DateTime.ParseExact(freeTime.endTime, "HH:mm", null);

            if (startTime > endTime)
                return false;

            if (String.IsNullOrEmpty(freeTime.name))
                return false;
            return true;
        }

    }
}
