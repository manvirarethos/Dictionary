using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.DBL.Schema
{
  public  class gallery
    {
        public int ID { get; set; }
        public string GalleryName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime  ModifiedDate { get; set; }
       
    }
}
