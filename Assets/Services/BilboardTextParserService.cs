using System.Text;

namespace Assets.Services
{
    public class BilboardTextParserService
    {
        public string Parse(string input)
        {
            var words = input.Split(' ');
            StringBuilder subResult = new StringBuilder();
            StringBuilder result = new StringBuilder();
            var currentWordCount = 0;

            foreach (var item in words)
            {
                if (currentWordCount + item.Length > 30)
                {
                    result.AppendLine(subResult.ToString().TrimEnd());
                    subResult.Clear();
                    currentWordCount = 0;
                }
                subResult.Append(item + " ");
                currentWordCount += item.Length + 1;
            }
            result.Append(subResult.ToString().TrimEnd());

            return result.ToString();
        }
    }
}
