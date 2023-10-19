using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Sample;

public class Examples
{

    public static int FindSmallestInteger(int num)
    {
        int current = 1;

        while (true)
        {
            int square = current * current;
            if (square.ToString().Length == num)
            {
                return current;
            }
            current++;
        }
    }
    public static string SimpleSymbols(string str)
    {
        if (char.IsLetter(str[0]))
        {
            return "false";
        }

        if (char.IsLetter(str[str.Length - 1]))
        {
            return "false";
        }

        for (int i = 1; i < str.Length - 1; i++)
        {
            if (char.IsLetter(str[i]))
            {
                if (str[i - 1] != '+' || str[i + 1] != '+')
                {
                    return "false";
                }
            }
        }

        return "true";
    }

    public static int FindLargestFourDigits(int[] array)
    {
        // Sort the array in descending order
        var sortedArray = array.OrderByDescending(x => x).ToArray();

        // Take the first four elements
        var largestFourDigits = sortedArray.Take(4).ToArray();

        return largestFourDigits.Sum();
    }
    public static int PermutationsStep(int num)
    {
        string strNum = num.ToString();

        if (strNum.Length == 1)
        {
            return -1;
        }

        for (int i = strNum.Length - 2; i >= 0; i--)
        {
            if (strNum[i] < strNum[i + 1])
            {
                string newNumStr = strNum.Substring(0, i) + strNum[i + 1] + strNum[i] + strNum.Substring(i + 2);
                return int.Parse(newNumStr);
            }
        }

        return -1;
    }
    public static int Consecutive(int[] arr)
    {
        // Create a set of integers from the minimum to maximum in the array
        var big = Enumerable.Range(arr.Min(), arr.Max() - arr.Min() + 1).ToHashSet();

        // Create a set from the input array
        var small = arr.ToHashSet();

        // Return the count of numbers needed to make the array consecutive
        return big.Except(small).Count();
    }
    public static int FirstFactorial(int num)
    {
        int factorial = 1;
        for (int i = 2; i <= num; i++)
        {
            factorial = factorial *= i;
        }
        return factorial;

    }
    public static int FindMissingNumber(int[] array)
    {
        int n = array.Length + 1;
        int xorSum = 0;

        // Calculate the expected sum of numbers from 1 to n
        int expectedSum = n * (n + 1) / 2;

        // Calculate the actual sum of elements in the array
        int actualSum = 0;
        foreach (int num in array)
        {
            actualSum += num;
        }

        // The missing number is the difference between the expected sum and the actual sum
        return expectedSum - actualSum;
    }

    public static List<int> GetDuplicates(int[] array)
    {
        Dictionary<int, int> ht = new Dictionary<int, int>();
        List<int> dups = new List<int>();

        foreach (int x in array)
        {
            if (ht.ContainsKey(x))
            {
                dups.Add(x);
            }
            else
            {
                ht[x] = x;
            }
        }

        return dups.Distinct().ToList();
    }

    public static string ArrayRotation(int[] array)
    {
        int r = array[0];

        // Rotate the array and convert elements to strings
        var rotatedArray = array[r..].Select(a => a.ToString()).Concat(array[..r].Select(a => a.ToString()));

        // Rotate the array and convert elements to strings
        var rotatedArrayOlder = new ArraySegment<int>(array, r, array.Length - r)
            .Select(a => a.ToString())
            .Concat(new ArraySegment<int>(array, 0, r).Select(a => a.ToString()));
        // Join the rotated array elements into a single string

        return string.Join("", rotatedArray);
    }

    public static string LetterCapitalize(string str)
    {
        // Split the input string into words, capitalize each word, and join them back
        return string.Join(" ", str.Split(' ').Select(word => char.ToUpper(word[0]) + word.Substring(1)));
    }

    public static string LetterChanges(string str)
    {
        string aLow = "abcdefghijklmnopqrstuvwxyz";
        string aCap = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string vow = "aeiou";

        char[] charArray = str.ToCharArray();

        for (int i = 0; i < charArray.Length; i++)
        {
            char currentChar = charArray[i];

            if (currentChar == 'z')
            {
                charArray[i] = 'A';
            }
            else if (currentChar == 'Z')
            {
                charArray[i] = 'A';
            }
            else if (aLow.Contains(currentChar))
            {
                charArray[i] = aLow[aLow.IndexOf(currentChar) + 1];

                if (vow.Contains(charArray[i]))
                {
                    charArray[i] = char.ToUpper(charArray[i]);
                }
            }
            else if (aCap.Contains(currentChar))
            {
                charArray[i] = aCap[aCap.IndexOf(currentChar) + 1];
            }
        }

        return new string(charArray);
    }
    public static string LongestWord(string sen)
    {
        int length = 0;
        string[] words = Regex.Split(sen, @"\W");

        foreach (string word in words)
        {
            if (word.Length > length)
            {
                length = word.Length;
            }
        }

        // Find the first word with the longest length
        string longestWord = words.FirstOrDefault(word => word.Length == length);

        return longestWord;
    }

    public static int MaxStockProfit(List<int> prices)
    {
        List<int> profit = new List<int> { 0 };
        int buy = prices[0];
        int sell = prices[0];

        foreach (int price in prices.Skip(1))
        {
            if (price > sell)
            {
                sell = price;
                profit[profit.Count - 1] = sell - buy;
            }

            if (price < buy)
            {
                buy = price;
                sell = price;
                profit.Add(0);
            }
        }

        return profit.Max();
    }
    public static string PatternChaser(string input)
    {
        string p = "";
        Dictionary<string, string> hash = new Dictionary<string, string>();

        for (int i = 2; i <= input.Length / 2; i++)
        {
            for (int j = 0; j <= input.Length - i; j++)
            {
                string patPrev = (j == 0) ? "" : input.Substring(j - 1, i - 1);
                string pat = input.Substring(j, i);

                if (hash.ContainsKey(pat))
                {
                    if (pat != patPrev)
                    {
                        p = pat;
                    }
                }
                else
                {
                    hash[pat] = pat;
                }
            }
        }

        if (string.IsNullOrEmpty(p))
        {
            return "no null";
        }
        else
        {
            return "yes " + p;
        }
    }

}