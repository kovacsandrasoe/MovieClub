﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieClub.Entities.Dtos.Rating
{
    public class RatingViewDto
    {
        public string Text { get; set; } = "";
        public int Rate { get; set; }
    }
}
