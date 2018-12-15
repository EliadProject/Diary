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
            BuisnessLogic buisnessLogic = new BuisnessLogic(new HandleJSON());
            Assert.AreEqual(DiaryValidation.isFreeTimeLegal(new FreeTime("Eliad","08:00","12:00"), buisnessLogic),true);
            Assert.AreEqual(DiaryValidation.isFreeTimeLegal(new FreeTime("", "12:00", "10:00"), buisnessLogic), false);
            Assert.AreEqual(DiaryValidation.isFreeTimeLegal(new FreeTime("Eliad", "12:30", "16:00"), buisnessLogic), false);

            
            Assert.AreEqual(buisnessLogic.isAppearInEnd("12:00"), true);
            Assert.AreEqual(buisnessLogic.isAppearInEnd("18:00"), false);

            Assert.AreEqual(buisnessLogic.isAppearInStart("12:00"), true);
            Assert.AreEqual(buisnessLogic.isAppearInStart("17:50"), false);


        }
    }
}
