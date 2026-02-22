using SpiderProj;

namespace Test
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void Test1_NormalTravel()
        {
            var wall = new Wall(7, 15);
            var spider = new Spider(wall, 4, 10, Spider.Orientation.Left);
            var instructions = "FLFLFRFFLF";

            spider.Obey(instructions);

            Assert.AreEqual("X: 5 Y: 7  Facing: Right", spider.Position);
        }

        [TestMethod]
        public void Test2_OffWallStart()
        {
            var wall = new Wall(7, 15);

            var ex = Assert.ThrowsException<ArgumentException>(() =>
            {
                var spider = new Spider(wall, 8, 10, Spider.Orientation.Left);
            });

            Assert.AreEqual("Requested spider start position is off the wall.", ex.Message);
        }

        [TestMethod]
        public void Test3_OffWallMove()
        {
            var wall = new Wall(7, 15);
            var spider = new Spider(wall, 2, 3, Spider.Orientation.Left);
            var instructions = "FFFFF";

            var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(() => spider.Obey(instructions));

            Assert.AreEqual(
                "Specified argument was out of the range of valid values. (Parameter 'Cannot move further left.')",
                ex.Message);
        }

        [TestMethod]
        public void Test3_NegativeTurn()
        {
            var wall = new Wall(10, 10);
            var spider = new Spider(wall, 5, 5, Spider.Orientation.Up);
            var instructions = "L";

            spider.Obey(instructions);

            Assert.AreEqual("X: 5 Y: 5  Facing: Left", spider.Position);
        }
    }
}