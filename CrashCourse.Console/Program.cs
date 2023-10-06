// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var inputs = new int[]
{
    1, 1, 2,2,2,3,3,3,3,4,4,4,4,4,5,5,5,5,5
};

if (!inputs.Any())
{
    Console.WriteLine("Nothing was passed. Please enter values");
    return;
}

int maxOccurrence = 0;
int maxItem = 0;

Dictionary<int, int> frequencyMap = new Dictionary<int, int>();
foreach (var item in inputs)
{
    if (frequencyMap.ContainsKey(item))
    {
        frequencyMap[item]++;
    }
    else
    {
        frequencyMap[item] = 1;
    }
    if (frequencyMap[item] > maxOccurrence)
    {
        maxOccurrence = frequencyMap[item];
        maxItem = item;
    }
}
Console.WriteLine($"The highest occurring item is {maxItem}, with a frequency of {maxOccurrence}");
Console.ReadLine();