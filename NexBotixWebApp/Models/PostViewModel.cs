using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NexBotixWebApp.Models
{
    public class PostViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "{0} is Required")]
        public string title { get; set; }
        [Required(ErrorMessage = "{0} is Required")]
        public string body { get; set; }
        [Required(ErrorMessage = "{0} is Required")]
        public int userId { get; set; }
    }
}
