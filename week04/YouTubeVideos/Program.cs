using System;

class Program
{
    static void Main(string[] args)
  {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

        Video video1 = new Video("Unboxing OREO cookies Limited Edition", "Percy Yarleque", 240);
        video1.AddComment(new Comment("Mia", "Wow, I love the packaging!"));
        video1.AddComment(new Comment("James", "Looks tasty."));
        video1.AddComment(new Comment("Alex", "Where can I buy it?"));

        Video video2 = new Video("Coca-Cola Ad - Summer 2025", "Coca Cola Company", 90);
        video2.AddComment(new Comment("Luna", "This ad makes me smile."));
        video2.AddComment(new Comment("Carlos", "I remember this song from my childhood."));
        video2.AddComment(new Comment("Bea", "Coca-Cola never disappoints."));

        Video video3 = new Video("Street Interview: Favorite Drink?", "Luisisto-Comunica", 600);
        video3.AddComment(new Comment("Rob", "Coke is still the #1."));
        video3.AddComment(new Comment("Nina", "Great editing!"));
        video3.AddComment(new Comment("Leo", "Loved this content."));


        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (Video video in videos)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($" - {comment.CommenterName}: {comment.Text}");
            }

            Console.WriteLine(); 
        }
    }
}