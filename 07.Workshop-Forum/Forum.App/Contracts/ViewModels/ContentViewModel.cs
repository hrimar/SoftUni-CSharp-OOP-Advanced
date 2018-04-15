using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum.App.Contracts.ViewModels
{
  public abstract class ContentViewModel // - показва съдърж. на един пост
    {
        private const int lineLength = 37;

        public ContentViewModel(string text)
        {
            this.Content = this.GetLines(text);
        }

        public string[] Content { get; }

        private string[] GetLines(string content)
        {
            char[] contentChars = content.ToCharArray();

            ICollection<string> lines = new List<string>();

            for (int i = 0; i < content.Length; i+=lineLength)
            {
                char[] row = contentChars.Skip(i).Take(lineLength).ToArray();
                string rowString = string.Join("", row);
                lines.Add(rowString);
            }

            return lines.ToArray();
        }
    }
}
