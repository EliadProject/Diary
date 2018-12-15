using Microsoft.VisualStudio.TestTools.UnitTesting;
using Diary.Models;
namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DiaryService diaryService = new DiaryService(new HandleJSON());
            Assert.AreEqual(DiaryValidation.isFreeTimeLegal(new FreeTime("Eliad","08:00","12:00"), diaryService),true);
            Assert.AreEqual(DiaryValidation.isFreeTimeLegal(new FreeTime("", "12:00", "10:00"), diaryService), false);
            Assert.AreEqual(DiaryValidation.isFreeTimeLegal(new FreeTime("Eliad", "12:30", "16:00"), diaryService), false);

            
            Assert.AreEqual(diaryService.isAppearInEnd("12:00"), true);
            Assert.AreEqual(diaryService.isAppearInEnd("18:00"), false);

            Assert.AreEqual(diaryService.isAppearInStart("12:00"), true);
            Assert.AreEqual(diaryService.isAppearInStart("17:50"), false);


        }
    }
}
