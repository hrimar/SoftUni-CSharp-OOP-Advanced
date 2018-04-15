using Forum.App.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.App.Commands
{
    public class PostCommand : ICommand
    {
        private ISession session;
        private IPostService postService;
        private IMenuFactory menuFactory;

        public PostCommand(ISession session, IPostService postService,
            IMenuFactory menuFactory)
        {
            this.session = session;
            this.postService = postService;
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            int userId = this.session.UserId;

            string postTitle = args[0];
            string postCategory = args[1];
            string postContent = args[2];

            bool validTitle = !string.IsNullOrEmpty(postTitle);
            bool validCategory = !string.IsNullOrEmpty(postCategory);
            bool validContent = !string.IsNullOrEmpty(postContent);

            if(!validCategory || !validContent || !validTitle)
            {
                throw new ArgumentException("All field must be filled!");
            }

            int postId = this.postService.AddPost(userId, postTitle, postCategory, postContent);

            this.session.Back();
            IMenu menu = this.menuFactory.CreateMenu("ViewPostMenu");

            if (menuFactory is IIdHoldingMenu idHoldingMenu)
            {
                idHoldingMenu.SetId(postId);
            }

            return menu;
        }
    }
}
