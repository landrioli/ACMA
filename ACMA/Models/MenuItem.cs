using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACMA.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public string Controller { get; set; }
        public string ActionName { get; set; }
        public int ParentId { get; set; }
        public bool HasSubMenu { get; set; }
    }
}