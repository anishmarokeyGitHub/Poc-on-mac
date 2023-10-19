namespace Sample;

public sealed class VowlesFinder : IVowlesFinder
{
    HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' }; 

    public int Count(string sentence)
    {        
        var countOfVowels = sentence.ToLower().Count(c => vowels.Contains(c));
        return countOfVowels;
    }
}
