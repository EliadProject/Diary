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
        IHandleData diaryService;
        public DiaryController(IHandleData handleData)
        {
            this.diaryService = handleData;
        }
        public IActionResult getStartTimes()
        {
            return Json(diaryService.getStartTimes());
        }
        public IActionResult getEndTimes()
        {
            return Json(diaryService.getEndTimes());
        }

        [HttpPost]
        public IActionResult addPerson([FromBody]FreeTime freeTime)
        {
            
            //validate data
            if (!DiaryValidation.isFreeTimeLegal(freeTime, diaryService))
            {
                dynamic error = new JObject();
                error.ErrorCode = "UNAUTHORIZED_API_METHOD";
                error.Description = "illegal data";
               
                return Json(JsonConvert.SerializeObject(error));
            }


            diaryService.addName(freeTime);
            return Json(diaryService.getJSON());
        }

        public IActionResult getDiary()
        {
            return Json(diaryService.getJSON());
        }

        
    }
}
