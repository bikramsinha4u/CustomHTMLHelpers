using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomHTMLHelpers.Models
{
    public class DemoModel
    {
        public int Id { get; set; } = 5;

        public bool IsActive { get; set; } = true;

        public bool Discounted { get; set; } = false;
    }
}