using SpiderProj;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var wall = new Wall(7, 15);
            var spider = new Spider(wall, 4, 10, Spider.Orientation.Left);
            var instructions = "FLFLFRFFLF";

            spider.Obey(instructions);

            Assert.AreEqual("X: 5 Y: 7  Facing: Right", spider.Position);
        }
    }
}