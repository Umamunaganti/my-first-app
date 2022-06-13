using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace my_first_app.MODELS
{
    public class Employee
    {
        [JsonProperty("Name")]
        [Required]
        [Display(Name= "Employee Name")]
        [StringLength(100,ErrorMessage="Name not be exceed")]
        public string Name { get; set; }

        [JsonProperty("id")]
        
        public string Employeeid { get; set; }
         [JsonProperty("Age")]
        [Required]
        //[Display(Name="Date of Birth")]
        //[DataType(DataType.Date),DisplayFormat(DataFormatString ="{0:dd/mm/yyyy}",ApplyFormatInEditMode = true)]
        //public Nullable<System.DateTime> Date_of_Birth { get; set; }
        public string DateOfBirth { get; set; }

         [JsonProperty("Contact")]
        [Required]
        [Range(1,10)]
        public string PhoneNumber { get; set; }

        [JsonProperty("Email")]
        [Required]
        [RegularExpression(".+\\@.+\\..+",ErrorMessage ="please enter valid Email")]
        public string Email { get; set; }

         
    }
}
