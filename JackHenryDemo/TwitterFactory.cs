using System;
using System.Threading.Tasks;
using Tweetinvi;

namespace JackHenryDemo
{
    internal class TwitterFactory
    {
        public async Task<int> GetTwitterStreamAsync(TwitterClient appClient)
        {
            var sampleStreamV2 = appClient.StreamsV2.CreateSampleStream();
            var tweetCount = 0;
            sampleStreamV2.TweetReceived += (sender, args) =>
            {
                try
                {
                    Console.WriteLine("Author ID: " + args.Tweet.AuthorId);
                    Console.WriteLine("Tweet ID: " + args.Tweet.Id);
                    Console.WriteLine("Source: " + args.Tweet.Source);
                    Console.WriteLine("Created At: " + args.Tweet.CreatedAt);
                    Console.WriteLine("Language: " + args.Tweet.Lang);
                    Console.WriteLine("Tweet: " + args.Tweet.Text + "\n");
                    tweetCount++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            };
            sampleStreamV2.StartAsync().Wait(120000);
            return tweetCount;
        }
    }
}
