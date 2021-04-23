
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dto
{
    public class Items1
    {
        public int ItemId { get; set; }
        public int ItemKind { get; set; }
        public string ItemName { get; set; }
        public System.DateTime CreationDate { get; set; }
        public int? VisitedCounter { get; set; }
        public bool EnableSearch { get; set; }
        public string ContextUrl { get; set; }
        public string ImgUrl { get; set; }
        public string Summery { get; set; }
        public string Video { get; set; }
    }
}