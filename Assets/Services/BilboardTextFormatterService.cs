using System.Text;

namespace Assets.Services
{
    public class BilboardTextFormatterService
    {
        private const int LINE_BUFFER = 30;

        private StringBuilder _line;
        private StringBuilder _output;

        public BilboardTextFormatterService()
        {
            _line = new StringBuilder();
            _output = new StringBuilder();
        }

        public string Format(string input)
        {
            Reset();
            Process(input);
            return _output.ToString();
        }

        private void Reset()
        {
            _line.Clear();
            _output.Clear();
        }

        private void Process(string input)
        {
            foreach (var word in GetWords(input))
            {
                if (LineBufferOverflow(word))
                    ProcessOutput();

                ProcessLine(word);
            }
            AppendLine();
        }

        private bool LineBufferOverflow(string word)
        {
            return _line.Length + word.Length > LINE_BUFFER;
        }

        private void ProcessOutput()
        {
            _output.AppendLine(_line.ToString().TrimEnd());
            _line.Clear();
        }

        private void ProcessLine(string word)
        {
            _line.Append(word + " ");
        }

        private void AppendLine()
        {
            _output.Append(_line.ToString().TrimEnd());
        }

        private string[] GetWords(string input)
        {
            return input.Split(' ');
        }
    }
}
