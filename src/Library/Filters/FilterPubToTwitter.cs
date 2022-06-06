using System;
using TwitterUCU;

namespace CompAndDel.Filters
{
    public class FilterPubToTwitter : IFilter
    {
        public string Post { get; }

        public FilterPubToTwitter(string post)
        {
            Post = post;
        }

        public IPicture Filter(IPicture image)
        {
            PictureProvider provider = new PictureProvider();
            new PictureProvider().SavePicture(image, @"out-pub-to-twitter-tmp.jpg");

            var twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter(Post, @"out-pub-to-twitter-tmp.jpg"));

            return image;
        }
    }
}
