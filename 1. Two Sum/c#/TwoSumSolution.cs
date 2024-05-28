using System.Formats.Asn1;

public class TwoSumSolution
{
    static void Main(string[] args)
    {
        int[] array = [3,2,4];
        int target = 6;
        var output = TwoSumForeach(array, target);
        Console.WriteLine(output[0] + " " + output[1]);
        output = TwoSumDictionary(array, target);
        Console.WriteLine(output[0] + " " + output[1]);
    }

    /// <summary>
    /// 这是我直接能想到的第一种解法，通过遍历两遍数组
    /// </summary>
    public static int[] TwoSumForeach(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            int _i = nums[i];
            for (int j = 0; j < nums.Length; j++)
            {
                if (i != j)
                {
                    int _j = nums[j];
                    if ((_i + _j) == target)
                    {
                        return new int[] {i, j };
                    }
                }
            }
        }
        throw new ArgumentException("No two sum solution");
    }

    /// <summary>
    /// 第二种解法,只遍历一次数组，把遍历过的元素与目标值的差值存入字典，结构为[当前元素与目标值的差值，当前元素的index]
    /// </summary>
    public static int[] TwoSumDictionary(int[] nums, int target) 
    {
        Dictionary<int, int> numsDict = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++) 
        {
            int targetNum = target - nums[i];//计算目标值和当前元素的查值
            if (numsDict.ContainsKey(targetNum))
            {
                return new int[]{ numsDict[targetNum],i };//如果找到了需求这个差值的元素，直接输出对应的index
            }
            else
            {
                numsDict[nums[i]] = i;//尚未有目标元素
            }
        }
        throw new ArgumentException("No two sum solution");
    }

}