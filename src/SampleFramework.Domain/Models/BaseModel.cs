﻿using System;
using Our.Umbraco.Ditto;
using SampleFramework.Domain.DittoProcessors;

namespace SampleFramework.Domain.Models
{
    public class BaseModel
    {
        public int Id { get; set; }

        [ContentKeyProcessor]
        public string Key { get; set; }

        public int Level { get; set; }

        public string DocumentTypeId { get; set; }

        public string DocumentTypeAlias { get; set; }

        public string NodeName { get; set; }

        [UmbracoProperty("creatorName")]
        public string Creator { get; set; }

        public string Path { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public string Version { get; set; }

        public int SortOrder { get; set; }
    }
}
