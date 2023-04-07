namespace LoopExamples;

public static class Loops
{
    public static int HighestForLoop(List<int> nums)
    {
        int highestNum = nums[0];
        for (int i = 1; i < nums.Count; i++)
        {
            if (nums[i] > highestNum)
            {
                highestNum = nums[i];
            }
        }
        return highestNum;

        // highestNum is initialized to the value of the first element in the nums list;
        // a for loop is used to iterate through the list.
        // Each element is compared to the current value of highestNum, and if greater, updates highestNum. 
    }
    public static int HighestForEachLoop(List<int> nums)
    {
        int highestNum = nums[0];
        foreach (int num in nums)
        {
            if (num > highestNum)
            {
                highestNum = num;
            }
        }
        return highestNum;

        // highestNum is initialized to the value of the first element in the nums list;
        // a foreach loop is used to iterate through each element in the list.
        // Each element is compared to the current value of highestNum, and if greater, updates highestNum.
    }

    public static int HighestWhileLoop(List<int> nums)
    {
        int highestNum = nums[0];
        int i = 1;
        while (i < nums.Count)
        {
            if (nums[i] > highestNum)
            {
                highestNum = nums[i];
            }
            i++;
        }
        return highestNum;

        // highestNum is initialized to the value of the first element in the nums list.
        // a while loop is used to iterate through the remaining elements in the list.
        // A separate variable, i, is used as the loop counter and intialised to 1.
        // Each element is compared to the current value of highestNum, and if greater, updates highestNum.
    }

    public static int HighestDoWhileLoop(List<int> nums)
    {
        int highestNum = nums[0];
        int i = 1;
        do
        {
            if (nums[i] > highestNum)
            {
                highestNum = nums[i];
            }
            i++;
        } while (i < nums.Count);

        return highestNum;

        // highestNum is initialized to the value of the first element in the nums list.
        // a dowhile loop is used to iterate through the remaining elements in the list.
        // A separate variable, i, is used as the loop counter and initialised to 1.
        // Each element is compared to the current value of highestNum, and if greater, updates highestNum.
    }
}