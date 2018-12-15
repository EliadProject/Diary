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
        //HandleJSON diary = HandleJSON.getInstance();
        DataService dataService = new DataService();
        public IActionResult getStartTimes()
        {
            return Json(dataService.getStartTimes());
        }
        public IActionResult getEndTimes()
        {
            return Json(dataService.getEndTimes());
        }

        [HttpPost]
        public IActionResult addPerson([FromBody]FreeTime freeTime)
        {
            
            //validate data
            if (!DiaryValidation.isFreeTimeLegal(freeTime,dataService))
            {
                dynamic error = new JObject();
                error.ErrorCode = "UNAUTHORIZED_API_METHOD";
                error.Description = "illegal data";
               
                return Json(JsonConvert.SerializeObject(error));
            }


            dataService.addName(freeTime);
            return Json(dataService.getJSON());
        }

        public IActionResult getDiary()
        {
            return Json(dataService.getJSON());
        }
    }
}