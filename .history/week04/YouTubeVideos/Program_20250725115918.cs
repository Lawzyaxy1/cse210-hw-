using System;
using System.Collections.Generic;

// Comment Class
// Represents a comment made by a user on a video   

public class Comment
{
    private string _commenterName;
    private string _commentText;

    public Comment(string commenterName, string commentText)
    {
        _commenterName = commenterName;
        _commentText = commentText;
    }

    // Getter for commenter's name
    public string GetCommenterName()
    {
        return _commenterName;
    }

    // Getter for comment text
    public string GetCommentText()
    {
        return _commentText;
    }
}

// Video Class
public class Video
{
    private string _title;
    private string _author;
    private int _lengthInSeconds; 
    private List<Comment> _comments; 
    public Video(string title, string author, int lengthInSeconds)
    {
        _title = title;
        _author = author;
        _lengthInSeconds = lengthInSeconds;
        _comments = new List<Comment>();
    }

    // Method to add a comment to the video
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Method to return the number of comments
    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    // Getter for title
    public string GetTitle()
    {
        return _title;
    }

    // Getter for author
    public string GetAuthor()
    {
        return _author;
    }

    // Getter for length in seconds
    public int GetLengthInSeconds()
    {
        return _lengthInSeconds;
    }

    // Getter for comments
    public List<Comment> GetComments()
    {
        return _comments;
    }
}

// Program Class to demonstrate functionality
public class Program
{
    public static void Main(string[] args)
    {
        // Create a list to store Video objects
        List<Video> videos = new List<Video>();

        // Video 1 
        Video video1 = new Video("Introduction to C# Programming", "CodeMaster", 1200); 
        video1.AddComment(new Comment("User123", "Great explanation for beginners!"));
        video1.AddComment(new Comment("DevPro", "Very clear and concise. Thanks!"));
        video1.AddComment(new Comment("CodingNewbie", "I learned so much, thank you!"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Top 10 Ancient Civilizations", "HistoryBuff", 2700)
        video2.AddComment(new Comment("AncientFan", "Fascinating insights into the past."));
        video2.AddComment(new Comment("EduExplorer", "Could you do a video on Mesopotamia next?"));
        video2.AddComment(new Comment("KnowledgeSeeker", "Amazing video, kept me engaged throughout."));
        video2.AddComment(new Comment("CuriousCat", "I never knew that about the Incas!"));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Healthy Meals in Under 30 Minutes", "CookingGuru", 900); 
        video3.AddComment(new Comment("FoodieLover", "These recipes look delicious and easy!"));
        video3.AddComment(new Comment("BusyParent", "Perfect for my hectic schedule."));
        video3.AddComment(new Comment("ChefInTraining", "Tried the pasta, it was amazing!"));
        videos.Add(video3);

        // Video 4 
        Video video4 = new Video("Exploring the Amazon Rainforest", "NatureDocumentary", 3600);
        video4.AddComment(new Comment("WildlifeWatcher", "Stunning visuals and informative content."));
        video4.AddComment(new Comment("EcoWarrior", "We need to protect these precious ecosystems."));
        video4.AddComment(new Comment("TravelBug", "Adding Amazon to my bucket list!"));
        video4.AddComment(new Comment("ExplorerDan", "Been there, truly breathtaking."));
        videos.Add(video4);


        // Display all videos and their comments
        Console.WriteLine("--- YouTube Videos and Comments ---\n");
        foreach (Video video in videos)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthInSeconds()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.GetCommenterName()}: \"{comment.GetCommentText()}\"");
            }
            Console.WriteLine("----------------------------------------\n");
        }
    }
}