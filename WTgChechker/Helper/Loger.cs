namespace WTgChechker.Helper
{
    public enum TypeLog
    {
        GOOD,
        ERROR,
        WARNING,
        DEFAULT
    }
    public class Loger
    {
        public static void Print(string text, TypeLog typeLog = TypeLog.DEFAULT)
        {
            switch (typeLog)
            {
                case TypeLog.GOOD:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case TypeLog.ERROR:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case TypeLog.WARNING:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
