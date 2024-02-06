using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeViewers.Wpf.Models;

namespace YoutubeViewers.Wpf.BusinessLogic
{
    internal class Database
    {
        public IEnumerable<YoutubeUsers> GetYoutubeUsers()
        {
            yield return new YoutubeUsers { Username = "User1", IsMember = true, IsSubscribed = true };
            yield return new YoutubeUsers { Username = "User2", IsMember = false, IsSubscribed = true };
            yield return new YoutubeUsers { Username = "User3", IsMember = true, IsSubscribed = false };
            yield return new YoutubeUsers { Username = "User4", IsMember = false, IsSubscribed = false };
        }
    }
}
