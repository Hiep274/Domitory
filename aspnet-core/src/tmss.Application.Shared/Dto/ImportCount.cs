using System;

namespace tmss.Dto
{
    public class ImportCount
    {
        public int? TotalCount { get; set; }
        public int? InvalidCount { get; set; }
        public int? ImportedCount { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
