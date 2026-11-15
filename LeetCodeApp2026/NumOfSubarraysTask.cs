using NUnit.Framework;

namespace LeetCodeApp2026;

// 1524
public class NumOfSubarraysTask
{
    public int NumOfSubarrays(int[] arr)
    {
        int left = 0, right = 0;
        var sum = 0;
        var result = 0;

        while (left < arr.Length)
        {
            while (right < arr.Length)
            {
                sum += arr[right++];
                if (sum % 2 == 1)
                {
                    result++;
                }
            }
            sum -= arr[left++];
            if (sum % 2 == 1)
            {
                result++;
            }
            right--;
            while (right >= left)
            {
                sum -= arr[right--];
                if (sum % 2 == 1)
                {
                    result++;
                }
            }

            left++;
            right = left;

        }

        return result % (1000000007);
    }

    public int NumOfSubarrays2(int[] arr)
    {
        var evenSum = 1;
        var oddSum = 0;
        var sum = 0;
        var result = 0;

        foreach (var item in arr)
        {
            sum += item;
            if (sum % 2 == 0)
            {
                evenSum++;
                result += oddSum;
            }
            else
            {
                oddSum++;
                result += evenSum;
            }
        }
        
        return result % (1000000007);
    }
    
}

public class NumOfSubarraysTaskTests
{
    [Test]
    [TestCase(new int[] {1, 3, 5}, 4)]
    [TestCase(new int[] {2, 4, 6}, 0)]
    [TestCase(new int[] {1, 2, 3, 4, 5, 6, 7}, 16)]
    public void Test(int[] arr, int expected)
    {
        var actual = new NumOfSubarraysTask().NumOfSubarrays2(arr);
        Assert.AreEqual(expected, actual);
    }
}