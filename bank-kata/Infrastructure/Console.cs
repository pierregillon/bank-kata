namespace bank_kata.Infrastructure
{
    public class Console : IConsole
    {
        public void Print(string text)
        {
            System.Console.Write(text);
        }
    }
}