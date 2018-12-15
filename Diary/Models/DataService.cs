using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.Models
{
    public class DataService
    {
        private BuisnessLogic _customerService;

        public DataService()
        {
            _customerService = new BuisnessLogic(HandleJSON.getInstance());
        }

        public List<String> getStartTimes()
        {
            return _customerService._dataAccess.getStartTimes();
        }
        public List<String> getEndTimes()
        {
            return _customerService._dataAccess.getEndTimes();
        }

        public void addName(FreeTime freeTime)
        {
            _customerService._dataAccess.addName(freeTime);
        }

        public string getJSON()
        {
            return _customerService._dataAccess.getJSON();
        }
        public bool isAppearInStart(string startTime)
        {
            return _customerService._dataAccess.isAppearInStart(startTime);
        }
        public bool isAppearInEnd(string endTime)
        {
            return _customerService._dataAccess.isAppearInEnd(endTime);
        }

    }
}
