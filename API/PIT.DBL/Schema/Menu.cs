﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.DBL.Schema
{
  public  class Menu
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string StyleClass { get; set; }
        public int SortOrder { get; set; }
        public bool Enabled { get; set; }

        public List<MenuTask> Task { get; set; }
        public Menu()
        {
            Task = new List<MenuTask>();
        }
    }
}
