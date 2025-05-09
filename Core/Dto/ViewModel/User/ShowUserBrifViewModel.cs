﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.ViewModel.User
{
    public class ShowUserBrifViewModel
    {
        public int UserId { get; set; }
        
        public string UserName { get; set; }
        public string Email { get; set; }
    }

    public class ShowUsersExam
    {
        public int ExamId { get; set; }
        public string ExamTitle { get; set; }
        public IEnumerable<ShowUserBrifViewModel> UsersList { get; set; }
    }
}

