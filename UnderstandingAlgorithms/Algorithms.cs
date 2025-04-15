namespace UnderstandingAlgorithms;
public class Algorithms
{
    public static bool SearchBinary(int[] arr, int item)
    {
        int high = arr.Length - 1; // Último elemento do Array
        int low = 0; // Primeiro elemento do Array

        while (low <= high)
        {
            var mid = (high - low) / 2;

            if (arr[mid] == item) return true; // Verifica se o arr[mid] posssí o mesmo valor que item

            if (arr[mid] > item) high = mid - 1; // Caso arr[mid] for maior que item, high irá descer para abixo da metáde
            else low = mid + 1; // Caso o arr[mid] for menor que item, low irá subir para acima da metáde 
        }
        return false;
    }

    public static int[] SelectionSort(List<int> arr)
    {
        var @new = new int[arr.Count];
        for (int i = 0; i < @new.Length; i++)
        {
            var smallestIndex = FindSmallest(arr); // O(n) - irá percorrer a List<int>
            @new[i] = arr[smallestIndex]; // O(1) - Porque passamos seu index para acessar direto o menor elemento encontrado no momento
            arr.RemoveAt(smallestIndex); // O(n) - irá percorrer a List<int> para remover o index específicado e deixar que outro elemento seja o menor
        }
        return @new; // retornamos a nova lista sendo uma O(n x n) ou O(n²)
    }

    private static int FindSmallest(List<int> arr)
    {
        var smallest = arr[0]; // Irá receber o primeiro elemento da List<int>
        var smallestIndex = 0; // Começamos no primeiro index da List<int>

        for (int i = 0; i < arr.Count; i++)
        {
            if (arr[i] < smallest) // Verifica se o arr na posição i é menor que o elemento que está na váriavel smallest 
            {
                smallest = arr[i]; // Irá receber o elemento nessa posição
                smallestIndex = i; // E iremos atribuir o index desse elemento para a variável smallestIndex
            }
        }
        return smallestIndex; // Retornamos o index do menor elemento encontrado nessa iteração
    }
}