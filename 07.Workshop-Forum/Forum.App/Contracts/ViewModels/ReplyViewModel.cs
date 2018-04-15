using System;
using System.Collections.Generic;
using System.Linq;

namespace Forum.App.Contracts.ViewModels
{
    public class ReplyViewModel : ContentViewModel, IReplyViewModel
    {
       
        public ReplyViewModel(string author, string text)
            : base(text)
        {
            this.Author = author;
         //   this.Content = content.ToArray();
        }

        public string Author { get; }

       // public string[] Content { get; }
    }
}
