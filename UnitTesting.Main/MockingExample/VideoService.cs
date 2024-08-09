using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using TestNinja.Mocking.Models;
using TestNinja.MockingExample.CustomExceptions;
using TestNinja.MockingExample.Interfaces;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        private readonly IFileReader fr;
        public VideoService(IFileReader fileReader)
        {
            fr = fileReader;
        }
        public string ReadVideoTitle()
        {
            var str = fr.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video.Title == null)
                throw new NullReferenceException("Video Title is null");
            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();
            
            using (var context = new VideoContext())
            {
                var videos = 
                    (from video in context.Videos
                    where !video.IsProcessed
                    select video).ToList();
                
                foreach (var v in videos)
                    videoIds.Add(v.Id);

                return string.Join(",", videoIds);
            }
        }

        public List<Video> GetUnprocessedVideos()
        {
            using (var context = new VideoContext())
            {
              return context.Videos.Where(v => v.IsProcessed == false).ToList();
            }
        }
        public string GetIdsAsCsv(List<string> ids)
        {
            if(ids == null)
            {
                throw new ArgumentNullException("Die Liste ist Leer");
            }
            // method returns empty if not elements
            return string.Join(",", ids); 
        }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}