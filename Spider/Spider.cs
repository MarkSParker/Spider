namespace SpiderProj
{
    public class Spider
    {

        /// <summary>
        /// Location and orientation of spider
        /// </summary>
        private uint X;
        private uint Y;
        private Orientation orientation;

        /// <summary>
        /// Directions the spider may face and turn
        /// Enum values are chosen so that:
        /// 
        /// newOrientation = oldOrientation + TurnDirection (modulo 4)
        /// </summary>
        public enum Orientation { Up = 0, Right = 1, Down = 2, Left = 3 };
        private enum TurnDirection {  TurnLeft = -1,  TurnRight = 1 };

        /// <summary>
        /// Wall te spider is on
        /// </summary>
        private Wall wall;

        // Current position and orientation
        public string Position => $"X: {X} Y: {Y}  Facing: {orientation}";

        /// <summary>
        /// Constructor. Initial (X,Y) and orientation should be given.
        /// </summary>
        /// <param name="wall"></param>
        /// <param name="initialX"></param>
        /// <param name="initialY"></param>
        /// <param name="initialOrientation"></param>
        public Spider(Wall wall, uint initialX, uint initialY, Orientation initialOrientation)
        {
            //  Check the requested start position is legal
            if (!wall.IsOnWall(initialX, initialY))
            {
                throw new ArgumentException("Requested spider start position is off the wall.");
            } 

            //  Record the start position
            X = initialX;
            Y = initialY;
            orientation = initialOrientation;
            this.wall = wall;
        }

        /// <summary>
        /// Spider obeys a series of movement instructions.
        /// </summary>
        /// <param name="instructions"></param>
        /// <exception cref="ArgumentException"></exception>
        public void Obey(string instructions)
        {
            foreach (var instruction in instructions)
            {
                switch (instruction)
                {
                    case 'F':
                        Creep();
                        break;

                    case 'L':
                        Turn(TurnDirection.TurnLeft); 
                        break;

                    case 'R':
                        Turn(TurnDirection.TurnRight);
                        break;

                    default:
                        throw new ArgumentException($"Illegal movement instruction '{instruction}'.");
                }
            }
        }

        /// <summary>
        /// Turn the spider by 90 degrees
        /// NOTE: Turn orders are from the spider's point-of-view, not the observer's.
        /// </summary>
        /// <param name="direction"></param>
        private void Turn(TurnDirection direction)
        {
            var newOrientation = ((int)orientation) + ((int)direction) + 4;
            newOrientation %= 4;

            orientation = (Orientation) newOrientation;
        }

        /// <summary>
        /// Creep: moves the spider 1 unit in the current direction. Orientation is preserved.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private void Creep()
        {
            // Calculate the destination X,Y coords based on orientation
            var newX = X;
            var newY = Y;

            switch (orientation)
            {
                case Orientation.Up:
                    newY = Y + 1;
                    break;

                case Orientation.Down:
                    if (Y == 0)
                    {
                        throw new ArgumentOutOfRangeException("Cannot move further down.");
                    }
                    newY = Y - 1;
                    break;

                case Orientation.Left:
                    if (X == 0)
                    {
                        throw new ArgumentOutOfRangeException("Cannot move further left.");
                    }
                    newX = X - 1;
                    break;

                case Orientation.Right:
                    newX = X + 1;
                    break;
            }

            // Before moving the spider check the intended destination is 
            // still on the wall. It's an edge case.
            if (!wall.IsOnWall(newX, newY))
            {
                throw new ArgumentOutOfRangeException($"Moving to (X={newX},Y={newY}) not possible due to wall size.");
            }

            // Move the spider
            X = newX;
            Y = newY;

            return;
        }
    }
}