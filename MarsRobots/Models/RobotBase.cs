namespace MarsRobots.Models
{
    public class RobotBase
    {
        Rectangle _rectangle;

        public RobotBase(Rectangle rectangle)
        {
            _rectangle = rectangle;
        }

        private RobotBase()
        {

        }

        public int CoordinateX { get; set; }

        public int CoordinateY { get; set; }

        public char CardinalPoint { get; set; }

        public string CommandCharacters { get; set; }

        public void ControlRobot()
        {
            for (int i = 0; i < CommandCharacters.Length; i++)
            {
                switch (CommandCharacters[i])
                {
                    case 'L':
                        TurnLeft();
                        break;
                    case 'R':
                        TurnRight();
                        break;
                    case 'M':
                        Move();
                        break;
                }
            }
        }

        private void TurnLeft()
        {
            switch (CardinalPoint)
            {
                case 'N':
                    CardinalPoint = 'W';
                    break;
                case 'S':
                    CardinalPoint = 'E';
                    break;
                case 'E':
                    CardinalPoint = 'N';
                    break;
                case 'W':
                    CardinalPoint = 'S';
                    break;
            }
        }

        private void TurnRight()
        {
            switch (CardinalPoint)
            {
                case 'N':
                    CardinalPoint = 'E';
                    break;
                case 'S':
                    CardinalPoint = 'W';
                    break;
                case 'E':
                    CardinalPoint = 'S';
                    break;
                case 'W':
                    CardinalPoint = 'N';
                    break;
            }
        }

        private void Move()
        {
            switch (CardinalPoint)
            {
                case 'N':
                    CoordinateY = CoordinateY + 1 <= _rectangle.CoordinateYSize ? CoordinateY + 1 : _rectangle.CoordinateYSize;
                    break;
                case 'S':
                    CoordinateY = CoordinateY - 1 >= 0 ? CoordinateY - 1 : 0;
                    break;
                case 'E':
                    CoordinateX = CoordinateX + 1 <= _rectangle.CoordinateXSize ? CoordinateX + 1 : _rectangle.CoordinateXSize;
                    break;
                case 'W':
                    CoordinateX = CoordinateX - 1 >= 0 ? CoordinateX - 1 : 0;
                    break;
            }
        }
    }
}
