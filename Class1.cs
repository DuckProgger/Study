using System;
class ForeachDemo
{
    static void Arr()
    {
        int[][] nums = new int[3][];

        nums[0] = new int[4];
        nums[1] = new int[7];
        nums[2] = new int[3];

        for (int i = 0; i < nums[0].Length; i++)
            nums[0][i] = i * 3;

        for (int i = 0; i < nums[1].Length; i++)
            nums[1][i] = i * 2 + 7;

        for (int i = 0; i < nums[2].Length; i++)
            nums[2][i] = i * 4 - 3;

        for(int i = 0; i < nums.Length; i++)
            foreach (int x in nums[i])
               Console.WriteLine(x);
    }
}

