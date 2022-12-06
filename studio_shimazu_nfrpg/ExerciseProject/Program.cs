// See https://aka.ms/new-console-template for more information

// 28. nからmまでの偶数の和を求める関数を作成せよ
int SumEvenNumberInRange(int first, int last)
{
    int result = 0;
    for (int i = first; i <= last; i++)
    {
        if (i%2 == 0) result += i;
    }
    return result;
}

int n = 1;
int m = 100;
Console.WriteLine(SumEvenNumberInRange(n, m));

// 別解
int result = Enumerable.Range(n, m).Where(x => x % 2 == 0).Sum();
Console.WriteLine(result);


// 29. 【演習】3のつく数字と3の倍数でアホになる演習問題(18:30)
List<int> CreateThreeList(int limit)
{
    HashSet<int> resultSet = new HashSet<int>();
    for (int i = 0; i <= limit; i++)
    {
        // 3 の倍数を設定
        if (i%3 == 0) resultSet.Add(i);

        // 3のつく数字を設定
        char[] iCharArray = i.ToString().ToCharArray();
        foreach (char iChar in iCharArray)
        {
            if (iChar == '3') {
                resultSet.Add(i);
                break;
            }
        }
    }
    return new List<int>(resultSet);
}

int limit = 100;
List<int> list = CreateThreeList(limit);
foreach (int item in list)
{
    Console.WriteLine(item);
}



// 31. Propertyの作成と利用方法
SampleClass a = new SampleClass();
// Console.WriteLine(a._name);
Console.WriteLine(a.Name);
a.Name = "xxx";
Console.WriteLine(a.Name);