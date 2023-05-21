using System;
using System.ComponentModel.DataAnnotations;

namespace NexBotixWebApp.Models
{
    public class TableOutputModel
    {
        [Required(ErrorMessage = "{0} is Required")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "{0} is Required")]
        public int TotalPosts { get; set; }
        public int TotalCommentsForAllPosts { get; set; }
    }
}