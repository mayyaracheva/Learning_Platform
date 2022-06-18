using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poodle.Data.EntityModels
{
    public class Subscription : IEquatable<Subscription>
    {
        public int Id { get; set; }

        [Display(Name = "Email address")]        
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }
       
        public bool Equals(Subscription other)
        {
            return EmailAddress == other.EmailAddress;
               
        }
    }
}
