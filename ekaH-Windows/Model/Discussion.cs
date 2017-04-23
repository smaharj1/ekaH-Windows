using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekaH_Windows.Model
{
    public class Discussion
    {
        public long id { get; set; }
        public Nullable<long> assignmentID { get; set; }
        public string content { get; set; }

        public virtual Assignment assignment { get; set; }
    }
}
