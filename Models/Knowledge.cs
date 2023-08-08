using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment.Models
{
    public class Knowledge
    {
        public int KID { get; set; }
        public string Kname { get; set; }

        public bool IsCheck { get; set; }
    }

    public class KnowledgeList
    {
        public List<Knowledge> knowledge{ get; set; }
    }
}
