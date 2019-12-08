﻿using System.Collections.Generic;

namespace CosmosDBStudio.Model
{
    public class QueryOptions
    {
        public int? MaxItemCount { get; set; }
        public object? PartitionKey { get; set; }
        //public IList<string> PreTriggerInclude { get; set; }
        //public IList<string> PostTriggerInclude { get; set; }
    }
}