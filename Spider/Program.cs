//
//  Program:    Spider - Robotic spider on wall simulator
//
//  Author:     Mark Parker (markstjohnparker@gmail.com)
//              23/Oct/25
//

using SpiderProj;

try
{
    Console.WriteLine("");
    Console.WriteLine("Spider Simulator");
    Console.WriteLine("================");
    Console.WriteLine("");
    Console.WriteLine("Enter max X and Y of wall as \"X Y\" below:");

    // Create the wall
    var tokens = Command.ReadAndParse("^[0-9]*$", "^[0-9]*$");
    var wall = new Wall(uint.Parse(tokens[0]), uint.Parse(tokens[1]));

    // Create and place the spider
    Console.WriteLine("Enter spider start state as \"X Y Up|Down|Left|Right\"");

    tokens = Command.ReadAndParse("^[0-9]*$", "^[0-9]*$", "^(Up|Down|Left|Right)$");
    var orientation = (Spider.Orientation)Enum.Parse(typeof(Spider.Orientation), tokens[2]);
    var spider = new Spider(wall, uint.Parse(tokens[0]), uint.Parse(tokens[1]), orientation);

    // Get the instruction set
    Console.WriteLine("Enter the movement instructions as series of F, L, R characters with no spaces in between");
    var instructions = Command.ReadAndParse("^[FLR]*$");

    //  Move the spider, report its final position
    Console.WriteLine("Processing...");
    Console.WriteLine("");

    spider.Obey(instructions[0]);

    Console.WriteLine($"Final position: {spider.currentX} {spider.currentY} {spider.orientation}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}