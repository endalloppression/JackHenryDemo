using System;
using System.Threading.Tasks;
using Tweetinvi;

namespace JackHenryDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Staring Twitter Sample Stream V2...");
            var tweetCount = 0;
            await Task.Factory.StartNew(async () =>
            {
                try
                {
                    tweetCount = await new TwitterFactory().GetTwitterStreamAsync(new TwitterClient(args[0], args[1], args[2]));

                    Console.WriteLine("\t Total estimated number of tweets: " + tweetCount);
                    Console.WriteLine("\t Estimated rate of tweets over a 60 second time period: " + tweetCount / 2);
                    Console.WriteLine("\t Stopping Twitter Sample Stream V2... \n");
                }
                catch (NullReferenceException tweet)
                {
                    Console.WriteLine(tweet.Message.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }

            });
        }
    }
}
