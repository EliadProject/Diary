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
        BuisnessLogic buisnessLogic;
        public DiaryController(IHandleData handleData)
        {
            buisnessLogic = new BuisnessLogic(handleData);
        }
        public IActionResult getStartTimes()
        {
            return Json(buisnessLogic.getStartTimes());
        }
        public IActionResult getEndTimes()
        {
            return Json(buisnessLogic.getEndTimes());
        }

        [HttpPost]
        public IActionResult addPerson([FromBody]FreeTime freeTime)
        {
            
            //validate data
            if (!DiaryValidation.isFreeTimeLegal(freeTime, buisnessLogic))
            {
                dynamic error = new JObject();
                error.ErrorCode = "UNAUTHORIZED_API_METHOD";
                error.Description = "illegal data";
               
                return Json(JsonConvert.SerializeObject(error));
            }


            buisnessLogic.addName(freeTime);
            return Json(buisnessLogic.getJSON());
        }

        public IActionResult getDiary()
        {
            return Json(buisnessLogic.getJSON());
        }
    }
}