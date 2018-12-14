using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diary.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult addPerson(FreeTime freeTime)
        {
            //diary.addName(freeTime);
            freeTime.startTime = "08:00";
            freeTime.endTime = "12:00";
            freeTime.name = "eliad";


            diary.addName(freeTime);
            return Json(diary.getJSON());
        }

        public IActionResult getDiary()
        {
            return Json(diary.getJSON());
        }
    }
}