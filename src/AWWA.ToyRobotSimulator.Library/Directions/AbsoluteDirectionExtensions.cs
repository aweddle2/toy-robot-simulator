using System;
namespace AWWA.ToyRobotSimulator.Library.Directions
{
	public static class AbsoluteDirectionExtensions
	{

        /// <summary>
        /// This method will rotate an AbsoluteDirection 90 degrees to the left or right as per the passed in RelativeDirection
        /// </summary>
        /// <param name="value"></param>
        /// <param name="relativeDirection"></param>
        /// <returns></returns>
        public static AbsoluteDirection Rotate(this AbsoluteDirection value, RelativeDirection relativeDirection)
        {
            if (relativeDirection.Equals(RelativeDirection.Left))
            {
                switch (value)
                {
                    case AbsoluteDirection.North:
                        return AbsoluteDirection.West;
                    case AbsoluteDirection.West:
                        return AbsoluteDirection.South;
                    case AbsoluteDirection.South:
                        return AbsoluteDirection.East;
                    case AbsoluteDirection.East:
                        return AbsoluteDirection.North;
                }
            }
            else
            {
                switch (value)
                {
                    case AbsoluteDirection.North:
                        return AbsoluteDirection.East;
                    case AbsoluteDirection.East:
                        return AbsoluteDirection.South;
                    case AbsoluteDirection.South:
                        return AbsoluteDirection.West;
                    case AbsoluteDirection.West:
                        return AbsoluteDirection.North;
                }

            }

            throw new ArgumentException("AbsoluteDirection not recognised", nameof(value));

        }

    }
}

