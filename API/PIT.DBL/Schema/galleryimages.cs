using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.DBL.Schema
{
  public  class GalleryImage
    {
        public int ID { get; set; }
        public int GalleryID { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
