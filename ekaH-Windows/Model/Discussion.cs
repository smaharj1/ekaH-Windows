using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekaH_Windows.Model
{
    /// <summary>
    /// It holds the data structure for discussion threads of the application.
    /// </summary>
    public class Discussion
    {
        public long Id { get; set; }
        public Nullable<long> AssignmentID { get; set; }
        public string Content { get; set; }

        public virtual Assignment Assignment { get; set; }
    }
}
