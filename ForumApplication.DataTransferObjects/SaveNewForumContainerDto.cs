﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.DataTransferObjects
{
    public class SaveNewForumContainerDto
    {
        public int UserId { get; set; }
        public string Title { get; set; }
    }
}