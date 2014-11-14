﻿using System;
using System.Runtime.Serialization;

namespace Weave.Services.User.DTOs.ServerIncoming
{
    [DataContract]
    public class UpdatedFeed
    {
        [DataMember(Order=1)]  public Guid Id { get; set; }
        [DataMember(Order=2)]  public string Name { get; set; }
        [DataMember(Order=3)]  public string Category { get; set; }
        [DataMember(Order=4)]  public ArticleViewingType ArticleViewingType { get; set; }
    }
}