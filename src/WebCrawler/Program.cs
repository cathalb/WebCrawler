using System;

namespace WebCrawler
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Enter URL :");
            var url = Console.ReadLine();

            var webCrawler = new Engine.WebCrawler();
        }
    }
}