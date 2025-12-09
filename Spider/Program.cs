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

    // Create the wall
    Console.WriteLine("Enter max X and Y of wall as \"X Y\" below:");

    var commandLine = Console.ReadLine();
    var tokens = Parser.Parse(commandLine!, "^[0-9]*$", "^[0-9]*$");

    var maxX = uint.Parse(tokens[0]);
    var maxY = uint.Parse(tokens[1]);

    var wall = new Wall(maxX, maxY);

    // Create and place the spider
    Console.WriteLine("Enter spider start state as \"X Y Up|Down|Left|Right\":");
    commandLine = Console.ReadLine();

    tokens = Parser.Parse(commandLine!, "^[0-9]*$", "^[0-9]*$", "^(Up|Down|Left|Right)$");

    var startX = uint.Parse(tokens[0]);
    var startY = uint.Parse(tokens[1]);
    var startOrientation = (Spider.Orientation)Enum.Parse(typeof(Spider.Orientation), tokens[2]);
    
    var spider = new Spider(wall, startX, startY, startOrientation);

    // Get the instruction set
    Console.WriteLine("Enter the movement instructions as series of F, L, R characters with no spaces in between:");
    commandLine = Console.ReadLine();

    var instructions = Parser.Parse(commandLine!, "^[FLR]*$");

    //  Move the spider, report its final position
    Console.WriteLine("Processing...");
    Console.WriteLine();

    spider.Obey(instructions[0]);

    Console.WriteLine($"Final position is {spider.Position}");

    Console.WriteLine();
    Console.WriteLine("Press RETURN to exit...");
    Console.ReadLine();
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Error: {ex.Message}");
}