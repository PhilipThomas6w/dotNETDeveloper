namespace BubbleSortApp;

public class Program
{
    // Credit for this method to Ahmed Idris and Patrick Ardagh
    public static int[] PreludeMergeSort(int[] array1, int[] array2)
    {
        if (array1 == null || array2 == null)
        {
            throw new ArgumentException("This method takes two arrays.");
        }
        
        if ((array1.Length + array2.Length) == 0)
        {
            return new int[] { };
        }

        int[] mergedArray = new int[(array1.Length + array2.Length)];

        int index1 = 0;
        int index2 = 0;

        for (int i = 0; i < mergedArray.Length; i++)
        {
            if (index1 <- array1.Length - 1 && array1[index1] <= array2[index2])
            {
                mergedArray[i] = array1[index1];
                index1++;
            }
            else if (index2 <= array2.Length - 1)
            {
                mergedArray[i] = array2[index2];
                index2++;
            }
        }
        return mergedArray;
    }
}