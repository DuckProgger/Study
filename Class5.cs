using System;

class parameters
{
    public int Min(params int[] nums)
    {
        int m;
        if (nums.Length == 0)
        {
            Console.WriteLine("Ошибка: нет аргументов.");
            return 0;
        }
        m = nums[0];
        for (int i = 1; i < nums.Length; i++)
            if (nums[i] < m) m = nums[i];
        return m;
    }
}

class test
{
    static void par()
    {
        parameters ob = new parameters();

        int[] values = { 1, 2, 3, 4, 5 };

        int Min = ob.Min(1,1,2,3,5);

        Console.WriteLine(Min);
    }
}