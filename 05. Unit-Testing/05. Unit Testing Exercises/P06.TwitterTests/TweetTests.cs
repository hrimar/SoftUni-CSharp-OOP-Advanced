using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using P06.TwitterProject;
using Moq;

namespace P06.TwitterTests
{
    public class TweetTests
    {
       
            [Test]
            public void ReceiveMessage_WritesToConsole()
            {
                var client = new Mock<IClient>();
                Tweet tweet = new Tweet(client.Object);

                tweet.ReceiveMessage("msg");

                client.Verify(c => c.WriteToConsole("msg"), Times.Once);
            }

            [Test]
            public void ReceiveMessage_SendsToServer()
            {
               var client = new Mock<IClient>();
                Tweet tweet = new Tweet(client.Object);

                tweet.ReceiveMessage("msg");

                client.Verify(c => c.SendToServer("msg"), Times.Once);
            }
        
    }
}
