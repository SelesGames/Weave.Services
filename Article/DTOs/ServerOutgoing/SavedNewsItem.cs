﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Weave.Services.Article.DTOs.ServerOutgoing
{
    [DataContract]
    public class SavedNewsItem
    {
        [DataMember(Order= 1)] public Guid Id { get; set; }
        [DataMember(Order= 2)] public string SourceName { get; set; }
        [DataMember(Order= 3)] public string Title { get; set; }
        [DataMember(Order= 4)] public string Link { get; set; }
        [DataMember(Order= 5)] public string UtcPublishDateTime { get; set; }
        [DataMember(Order= 6)] public string ImageUrl { get; set; }
        [DataMember(Order= 7)] public string YoutubeId { get; set; }
        [DataMember(Order= 8)] public string VideoUri { get; set; }
        [DataMember(Order= 9)] public string PodcastUri { get; set; }
        [DataMember(Order=10)] public string ZuneAppId { get; set; }
        [DataMember(Order=11)] public DateTime AddedOn { get; set; }
        [DataMember(Order=12)] public string Notes { get; set; }
        [DataMember(Order=13)] public List<string> Tags { get; set; }
        [DataMember(Order=14)] public Image Image { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
