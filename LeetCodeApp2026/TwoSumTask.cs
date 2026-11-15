using NUnit.Framework;

namespace LeetCodeApp2026;

// 1
public class TwoSumTask
{
    public int[] TwoSum(int[] nums, int target) 
    {
        var complements = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            var complement = target - nums[i];
            if (complements.ContainsKey(complement))
                return [i, complements[complement]];
            complements[nums[i]] = i;
        }
            
        return [];
    }
}

public class TwoSumTaskTests
{
    [Test]
    [TestCase(new int[] {2,7,11,15}, 9, new int[] {0, 1})]
    [TestCase(new int[] {3,2,4}, 6, new int[] {1, 2})]
    [TestCase(new int[] {3, 3}, 6, new int[] {0, 1})]
    public static void Test(int[] nums, int target, int[] expected)
    {
        var actual = new TwoSumTask().TwoSum(nums, target);
        Array.Sort(actual);
        Assert.AreEqual(expected, actual);
    }
    
}