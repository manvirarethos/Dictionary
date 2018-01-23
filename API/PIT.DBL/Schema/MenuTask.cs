using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.DBL.Schema
{
    public class MenuTask : BaseScheme
    {

        public string Name { get; set; }
        public string Title { get; set; }
        public int MenuID { get; set; }
        public int SortOrder { get; set; }
        public string Url { get; set; }

        public List<SubTask> SubTasks { get; set; }
      
    }
}
