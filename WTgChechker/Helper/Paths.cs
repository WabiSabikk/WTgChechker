namespace WTgChechker.Helper;
class Paths
{
    public const string BadDir = "Bad";
    public const string GoodDir = "Good";

    public static string GoodDirFile(string file)=> Path.Combine(GoodDir, file); 
    public static string BadDirFile(string file)=> Path.Combine(BadDir, file); 
}

