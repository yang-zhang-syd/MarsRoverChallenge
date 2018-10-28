using Xunit;

namespace MarsRoverChallenge.Test
{
    public class RoverTests
    {
        [Fact]
        public void Rover_Run_TurnLeft()
        {
            var rover = new Rover(0, 0, 'N', new[] {2, 2});
            rover.Run('L');

            Assert.Equal('W', rover.Facing);
            Assert.Equal(0, rover.X);
            Assert.Equal(0, rover.Y);
        }

        [Fact]
        public void Rover_Run_TurnRight()
        {
            var rover = new Rover(0, 0, 'N', new[] { 2, 2 });
            rover.Run('R');

            Assert.Equal('E', rover.Facing);
            Assert.Equal(0, rover.X);
            Assert.Equal(0, rover.Y);
        }

        [Fact]
        public void Rover_Run_MultipleTurns()
        {
            var rover = new Rover(0, 0, 'N', new[] { 2, 2 });
            var commands = "LLLLRRRR";
            foreach (var command in commands)
            {
                rover.Run(command);
            }

            Assert.Equal('N', rover.Facing);
            Assert.Equal(0, rover.X);
            Assert.Equal(0, rover.Y);
        }

        [Fact]
        public void Rover_Run_Move()
        {
            var rover = new Rover(0, 0, 'N', new[] { 2, 2 });
            rover.Run('M');

            Assert.Equal('N', rover.Facing);
            Assert.Equal(0, rover.X);
            Assert.Equal(1, rover.Y);
        }

        [Fact]
        public void Rover_Run_AvoidGoBeyondBoundries_North()
        {
            var rover = new Rover(0, 0, 'N', new[] { 2, 2 });
            rover.AvoidGoBeyondBoundaries = true;

            rover.Run('M');
            rover.Run('M');
            rover.Run('M');

            Assert.Equal('N', rover.Facing);
            Assert.Equal(0, rover.X);
            Assert.Equal(2, rover.Y);
        }

        [Fact]
        public void Rover_Run_AvoidGoBeyondBoundries_South()
        {
            var rover = new Rover(0, 1, 'S', new[] { 2, 2 });
            rover.AvoidGoBeyondBoundaries = true;

            rover.Run('M');
            rover.Run('M');

            Assert.Equal('S', rover.Facing);
            Assert.Equal(0, rover.X);
            Assert.Equal(0, rover.Y);
        }

        [Fact]
        public void Rover_Run_AvoidGoBeyondBoundries_West()
        {
            var rover = new Rover(1, 0, 'W', new[] { 2, 2 });
            rover.AvoidGoBeyondBoundaries = true;

            rover.Run('M');
            rover.Run('M');

            Assert.Equal('W', rover.Facing);
            Assert.Equal(0, rover.X);
            Assert.Equal(0, rover.Y);
        }

        [Fact]
        public void Rover_Run_AvoidGoBeyondBoundries_East()
        {
            var rover = new Rover(0, 0, 'E', new[] { 2, 2 });
            rover.AvoidGoBeyondBoundaries = true;

            rover.Run('M');
            rover.Run('M');
            rover.Run('M');

            Assert.Equal('E', rover.Facing);
            Assert.Equal(2, rover.X);
            Assert.Equal(0, rover.Y);
        }

        [Fact]
        public void Rover_Run_IgnoreUnkownCommand()
        {
            var rover = new Rover(0, 0, 'N', new[] { 2, 2 });
            rover.Run('X');

            Assert.Equal('N', rover.Facing);
            Assert.Equal(0, rover.X);
            Assert.Equal(0, rover.Y);
        }
    }
}
