namespace Services
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class PostData
    {
        public string Title { get; set; }
        public string Contents { get; set; }
        public CategoryData[] Categories { get; set; }
    }
}