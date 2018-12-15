using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.Models
{
    public  class BuisnessLogic
    {
        public IHandleData _dataAccess;

        public BuisnessLogic(IHandleData _handleData)
        {
            _dataAccess = _handleData;
        }
        public List<String> getStartTimes()
        {
            return _dataAccess.getStartTimes();
        }
        public List<String> getEndTimes()
        {
            return _dataAccess.getEndTimes();
        }

        public void addName(FreeTime freeTime)
        {
            _dataAccess.addName(freeTime);
        }

        public string getJSON()
        {
            return _dataAccess.getJSON();
        }
        public bool isAppearInStart(string startTime)
        {
            return _dataAccess.isAppearInStart(startTime);
        }
        public bool isAppearInEnd(string endTime)
        {
            return _dataAccess.isAppearInEnd(endTime);
        }

    }
}
