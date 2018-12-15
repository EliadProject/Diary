using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.Models
{
    class BuisnessLogic
    {
        public IHandleData _dataAccess;

        public BuisnessLogic(IHandleData _handleData)
        {
            _dataAccess = _handleData;
        }

        
    }
}
