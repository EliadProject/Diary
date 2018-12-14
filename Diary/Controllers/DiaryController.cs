using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diary.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Diary.Controllers
{
    public class DiaryController : Controller
    {
        HandleJSON diary = HandleJSON.getInstance();
        public IActionResult getStartTimes()
        {
            return Json(diary.getStartTimes());
        }
        public IActionResult getEndTimes()
        {
            return Json(diary.getEndTimes());
        }

        [HttpPost]
        public IActionResult addPerson([FromBody]FreeTime freeTime)
        {
            
            //validate data
            if (!DiaryValidation.isFreeTimeLegal(freeTime, diary))
            {
                dynamic error = new JObject();
                error.ErrorCode = "UNAUTHORIZED_API_METHOD";
                error.Description = "illegal data";
               
                return Json(JsonConvert.SerializeObject(error));
            }


            diary.addName(freeTime);
            return Json(diary.getJSON());
        }

        public IActionResult getDiary()
        {
            return Json(diary.getJSON());
        }
    }
}