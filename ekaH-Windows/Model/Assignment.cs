using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekaH_Windows.Model
{
    public class Assignment
    {
        public long id { get; set; }
        public string courseID { get; set; }
        public int projectNum { get; set; }
        public string projectTitle { get; set; }
        public int weight { get; set; }
        public DateTime deadline { get; set; }
        public string content { get; set; }
        public byte[] attachments { get; set; }

        public virtual ICollection<Submission> submissions { get; set; }
        public virtual Course course { get; set; }
    }

    public class Submission
    {
        public long id { get; set; }
        public long assignmentID { get; set; }
        public string studentID { get; set; }
        public Nullable<int> grade { get; set; }
        public byte[] submissionContent { get; set; }
        public Nullable<System.DateTime> submissionDateTime { get; set; }

        //public virtual assignment assignment { get; set; }
        public virtual StudentInfo student_info { get; set; }
    }
}
