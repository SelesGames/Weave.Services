﻿
namespace Weave.Services.Mobilizer.DTOs
{
    public class MobilizerResult
    {
        public string author { get; set; }
        public string content { get; set; }
        public string date_published { get; set; }
        public string domain { get; set; }
        public string lead_image_url { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string word_count { get; set; }

        public override string ToString()
        {
            return string.Format("{0} | {1}", title, domain);
        }
    }
}
