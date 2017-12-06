using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingQuestion.Entity
{
    public class Coordinate 
    {
        [Required]
        [Range(0,60)]
        public int X { get; set; }
        [Required]
        [Range(0, 60)]
        public int Y { get; set; }     
        
        
    }
}
