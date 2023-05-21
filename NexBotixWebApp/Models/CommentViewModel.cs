using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NexBotixWebApp.Models
{
    public class CommentViewModel
    {

       [Required(ErrorMessage = "{0} is Required")]
        public int postId { get; set; }
        [Required(ErrorMessage = "{0} is Required")]
        public int id { get; set; }
        [Required(ErrorMessage = "{0} is Required")]
        public string name { get; set; }
        [Required(ErrorMessage = "{0} is Required")]
        public string email { get; set; }
        [Required(ErrorMessage = "{0} is Required")]
        public string body { get; set; }
    }
}
