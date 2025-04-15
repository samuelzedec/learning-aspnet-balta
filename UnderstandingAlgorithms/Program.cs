using static UnderstandingAlgorithms.Algorithms;

int[] array = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
List<int> list = [80, 8, 56, 98, 67, 12, 1, 9, 5];

// Console.WriteLine(SearchBinary(arr: array, item: 0));
Console.WriteLine(string.Join(", ", SelectionSort(list)));