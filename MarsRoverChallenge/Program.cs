using System;
using System.Linq;

namespace MarsRoverChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimentions =  Console.ReadLine()?.Trim().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();

            string roverInfo = null;
            while (!string.IsNullOrEmpty(roverInfo = Console.ReadLine()))
            {
                var commands = Console.ReadLine();
                if (string.IsNullOrEmpty(commands))
                {
                    break;
                }

                var roverInfoArray = roverInfo.Trim().Split(' ');

                var rover = new Rover(Convert.ToInt32(roverInfoArray[0]), Convert.ToInt32(roverInfoArray[1]), Convert.ToChar(roverInfoArray[2]), dimentions);
                rover.AvoidGoBeyondBoundaries = true;

                foreach (var command in commands)
                {
                    rover.Run(command);
                }

                Console.WriteLine($"{rover.X} {rover.Y} {rover.Facing}");
            }
        }
    }
}
