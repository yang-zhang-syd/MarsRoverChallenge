using System;

namespace MarsRoverChallenge
{
    public class Rover
    {
        private readonly string _directions = "NESW";
        private readonly int[] _dimentions;

        private int _facingDirectionIndex;

        public Rover(int x, int y, char facing, int[] dimentions)
        {
            X = x;
            Y = y;
            Facing = facing;
            _dimentions = dimentions;

            _facingDirectionIndex = _directions.IndexOf(facing);
        }

        public int X { get; private set; }
        public int Y { get; private set; }
        public char Facing { get; private set; }

        /// <summary>
        /// If set to true, rover will not go beyond boundries defined by dimensions.
        /// </summary>
        public bool AvoidGoBeyondBoundaries { get; set; }

        public void Run(char instruction)
        {
            if (instruction == 'M')
            {
                moveOneStep();
            }
            else if (instruction == 'L' || instruction == 'R')
            {
                turn(instruction);
            }
            else
            {
                Console.WriteLine("Unknown Instruction Received.");
            }
        }

        private void moveOneStep()
        {
            if (Facing == 'N' && (Y + 1 <= _dimentions[1] || !AvoidGoBeyondBoundaries))
            {
                Y += 1;
            }
            else if (Facing == 'S' && (Y - 1 >= 0 || !AvoidGoBeyondBoundaries))
            {
                Y -= 1;
            }
            else if (Facing == 'E' && (X + 1 <= _dimentions[0] || !AvoidGoBeyondBoundaries))
            {
                X += 1;
            }
            else if (Facing == 'W' && (X - 1 >= 0 || !AvoidGoBeyondBoundaries))
            {
                X -= 1;
            }
        }

        private void turn(char instruction)
        {
            var length = _directions.Length;

            if (instruction == 'L')
            {
                _facingDirectionIndex = (_facingDirectionIndex - 1) % length;

                if (_facingDirectionIndex < 0)
                {
                    _facingDirectionIndex += length;
                }
            }
            else if (instruction == 'R')
            {
                _facingDirectionIndex = (_facingDirectionIndex + 1) % length;
            }

            Facing = _directions[_facingDirectionIndex];
        }
    }
}
