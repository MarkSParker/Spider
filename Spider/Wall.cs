namespace SpiderProj
{
    public class Wall
    {
        private uint maxX;
        private uint maxY;

        /// <summary>
        /// Constructor
        /// Note a wall where no movement is possible is allowed
        /// </summary>
        /// <param name="maxX"></param>
        /// <param name="maxY"></param>
        public Wall(uint maxX, uint maxY)
        {
            this.maxX = maxX;
            this.maxY = maxY;
        }

        /// <summary>
        /// IsOnWall: Tests if an (X,Y) is a possible destination for the spider
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsOnWall(uint x, uint y)
        {
            return (x <= maxX && y <= maxY);
        }
    }
}
