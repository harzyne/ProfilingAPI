using System;    
using System.Collections.Generic;    
using System.ComponentModel.DataAnnotations;    
using System.Linq;    
using System.Threading.Tasks;    
    
namespace ScoreAPI.Models  
{    
    public class User    
    {    
        public int UserId { get; set; }    
        [Required]    
        public string Name { get; set; }    
        [Required]    
        public int Answer1 { get; set; }    
        [Required]    
        public int Answer2 { get; set; }    
        public string Score { get; set; }   
    }    
}  