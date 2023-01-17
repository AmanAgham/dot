using System;
using System.Collections.Generic;

#nullable disable

namespace test.Models
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Communication { get; set; }
        public string Entusiasm { get; set; }
        public int? Feedback1 { get; set; }
    }
}
