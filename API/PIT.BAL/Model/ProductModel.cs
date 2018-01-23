using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.BAL.Model
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int UnitId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
