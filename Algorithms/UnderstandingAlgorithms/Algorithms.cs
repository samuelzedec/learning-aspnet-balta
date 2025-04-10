namespace UnderstandingAlgorithms;

public class Algorithms
{
    /// <summary>
    /// Aqui estamos vendo um pouco do tempo logarítmico O(log₂n),
    /// utilizando a busca binária em um array ordenado.
    /// </summary>
    /// <param name="numbers">Array de inteiros ordenado em ordem crescente.</param>
    /// <param name="num">Número a ser buscado.</param>
    /// <returns>True se o número existir no array, senão false.</returns>
    public static bool SearchBinary(int[] numbers, int num)
    {
        var high = numbers.Length - 1;
        var low = 0;

        while (low <= high)
        {
            var mid = (high + low) / 2;
            if (numbers[mid] == num) 
                return true;

            if (numbers[mid] > num) high = mid - 1;
            else low = mid - 1;
        }
        return false;
    }
}