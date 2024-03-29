﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.UserDTOs
{
    public class ChangePwdViewModel
    {
        [Required]

        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string oldPassword { get; set; }

        [DataType(DataType.Password)]
        public string newPassword { get; set; }
    }
}
