using System;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            const string filename = "input.txt";
            const string firstWord = "я";
            const string secondWord = "сказать";
            
            MinMaxDistanceProcessor distanceProcessor = new MinMaxDistanceProcessor();
            MinMaxDistance minMaxDistance = distanceProcessor.Get(filename, firstWord, secondWord);

            int minDistance = minMaxDistance.Min;
            int maxDistance = minMaxDistance.Max;

            string minDistanceString = minDistance == -1 ? "Не существует" : minDistance.ToString();
            string maxDistanceString = maxDistance == -1 ? "Не существует" : maxDistance.ToString();
            
            Console.WriteLine($"min distance: {minDistanceString}\n" +
                              $"max distance: {maxDistanceString}");
        }
    }
}
