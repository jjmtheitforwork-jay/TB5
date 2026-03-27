using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB5.AdoDotNetSample
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string StudentId { get; set; }

        public int marks { get; private set; }


        public void SetMark(int mark)
        {
            marks = mark;
        }
        /// <summary>
        /// Get Grade
        /// </summary>
        /// <returns></returns>
        public string Grade()
        {
            return marks >= 40 ? "Pass" : "Fail";
        }
    }
}
