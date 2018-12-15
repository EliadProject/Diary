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
            DataService dataService = new DataService();
            Assert.AreEqual(DiaryValidation.isFreeTimeLegal(new FreeTime("Eliad","08:00","12:00"),dataService),true);
            Assert.AreEqual(DiaryValidation.isFreeTimeLegal(new FreeTime("", "12:00", "10:00"), dataService), false);
            Assert.AreEqual(DiaryValidation.isFreeTimeLegal(new FreeTime("Eliad", "12:30", "16:00"), dataService), false);

            HandleJSON handleJSON = HandleJSON.getInstance();
            Assert.AreEqual(handleJSON.isAppearInEnd("12:00"), true);
            Assert.AreEqual(handleJSON.isAppearInEnd("18:00"), false);

            Assert.AreEqual(handleJSON.isAppearInStart("12:00"), true);
            Assert.AreEqual(handleJSON.isAppearInStart("17:50"), false);


        }
    }
}
