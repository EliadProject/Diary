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
    }
}