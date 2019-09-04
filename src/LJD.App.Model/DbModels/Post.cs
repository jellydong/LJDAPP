using System;
using System.Collections.Generic;

namespace LJD.App.Model.DbModels
{
    public partial class Post
    {
        public string ObjectId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
