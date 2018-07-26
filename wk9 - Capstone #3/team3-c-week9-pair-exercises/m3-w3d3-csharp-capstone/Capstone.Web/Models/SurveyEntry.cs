using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Capstone.Web.DAL;


namespace Capstone.Web.Models
{
    public class SurveyEntry
    {
        public List<Park> ParkList { get; set; }
        

        [Required]
        public string ParkCode { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a vaild email address")]
        public string EmailAddress { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string ActivityLevel { get; set; }
    }
}