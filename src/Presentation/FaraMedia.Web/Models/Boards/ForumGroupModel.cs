﻿using System.Collections.Generic;

namespace Fara.Web.Models.Boards
{
    public class ForumGroupModel
    {
        public ForumGroupModel()
        {
            this.Forums = new List<ForumRowModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string SeName { get; set; }
        public string Description { get; set; }

        public IList<ForumRowModel> Forums { get; set; }
    }
}