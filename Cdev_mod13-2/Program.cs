
using System.Text;

namespace Cdev_mod13_2;
class Program
{
    static void Main(string[] args)
    {
        string filePath = Path.Combine(Environment.CurrentDirectory.Replace("\\bin\\Debug\\net6.0", ""), "cdev-text.txt");
        Dictionary<string, int> dictionary = CreateDictionary(filePath);
        DisplayTop10(dictionary);
    }

    private static Dictionary<string, int> CreateDictionary(string filePath)
    {
        string text = File.ReadAllText(filePath).ToLower();
        var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
        char[] delimiters = new char[] { ' ', '\r', '\n' };
        var words = noPunctuationText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, int> dictionary = new Dictionary<string, int>();

        foreach (string word in words)
        {
            if (dictionary.ContainsKey(word))
            {
                dictionary[word]++;
            }
            else
            {
                dictionary.Add(word, 1);
            }
        }
        return dictionary;
    }
    
    private static void DisplayTop10(Dictionary<string, int> dictionary)
    {
        var sortedDictionary = dictionary.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

        for (int i = 0; i < 10; i++)
        {
            var element = sortedDictionary.ElementAt(i);
            Console.WriteLine($"{element.Key}: {element.Value}");
        }
    }



}
