﻿using System;

namespace Domain.Model
{
    public class WebComic
    {

        public string Month { get; set; }
        public int Num { get; set; }
        public string Link { get; set; }
        public string Year { get; set; }
        public string News { get; set; }
        public string Safe_Title { get; set; }
        public string Transcript { get; set; }
        public string Alt { get; set; }
        public string Img { get; set; }
        public string Title { get; set; }
        public string Day { get; set; }

        public bool IsTodayComic { get; set; }
    }
}

