﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.CQRS.Users.Queries.GetUsersByUserName
{
    public class UserSummaryDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Avatar { get; set; }
    }
}
