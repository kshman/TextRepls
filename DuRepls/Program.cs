// See https://aka.ms/new-console-template for more information

using DuRepls;

Console.ForegroundColor = ConsoleColor.Green;
Console.Write("DuRepls! ");
Console.ResetColor();
Console.Write("Command line version of ");
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("TextRepls");
Console.ResetColor();

if (args.Length != 2)
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write("Usage");
    Console.ResetColor();
    Console.WriteLine(": DuRepls <repls-file> <filelist-file>");
    return 1;
}

var replsFile = args[0];
var listFile = args[1];

var wr = new WorkRepls(replsFile, listFile);

var msgTest = wr.TestInputs();
if (msgTest != null)
{
    Console.WriteLine(msgTest);
    return 2;
}

var msgRead = wr.ReadInputs();
if (msgRead != null)
{
    Console.WriteLine(msgRead);
    return 3;
}

var count = wr.Run();
if (count < 0)
{
    Console.WriteLine("Error during processing: " + count);
    return 4;
}

Console.WriteLine($"Processed {count} files successfully.");

return 0;