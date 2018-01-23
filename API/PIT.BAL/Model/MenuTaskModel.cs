using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.BAL.Model
{
   public class MenuTaskModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int MenuID { get; set; }
        public int SortOrder { get; set; }
        public string Url { get; set; }

        public List<SubTaskModel> SubTasks { get; set; }
        public virtual MenuModel Menu { get; set; }
    }
}
