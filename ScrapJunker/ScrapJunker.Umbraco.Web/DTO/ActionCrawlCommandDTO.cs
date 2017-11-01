﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScrapJunker.Umbraco.Web.DTO
{
    public class ActionCrawlCommandDTO
    {
        [Required]
        public string Url { get; set; }

        [Range(0, 120)]
        public int? CrawlTimeoutSeconds { get; set; }
        [Range(0, 5)]
        public int? MaxConcurrentThreads { get; set; }
        [Range(0, 500)]
        public int? MaxPagesToCrawl { get; set; }

        public int Id { get; set; }
    }
}