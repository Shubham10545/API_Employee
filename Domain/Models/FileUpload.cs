using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class FileUpload
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string ImageTitle { get; set; }
        [StringLength(50)]
        
        public string ImageName { get; set; }
        [NotMapped]
        public IFormFile files { get; set; }
    }
}
