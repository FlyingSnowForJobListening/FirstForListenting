using System;
using System.ComponentModel.DataAnnotations;

namespace FS.Database.Entries
{
    public class BaseEntry
    {
        [Key]
        public int Id { get; set; }
        public Guid ItemGuid { get; set; }
        public string Commnet1 { get; set; }
        public string Commnet2 { get; set; }
        public string Commnet3 { get; set; }
        public string Commnet4 { get; set; }
        public string Commnet5 { get; set; }
    }
}
