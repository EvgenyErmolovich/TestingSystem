using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApplication.Models.Test
{
    public class PreviewTestViewModel
    {
        public int Id { get; set; }

        [DisplayName("Test name")]
        public string Name { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        public double MinPercentage { get; set; }

        public int QuestionQuantity { get; set; }

        public int UsersQuantity { get; set; }

        public double AveragePercentage { get; set; }

        [DisplayName("Is test ready")]
        public bool IsReady { get; set; }
    }
}