using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAPI.Models
{
    public class CountryDTO : CreateCountryDTO
    {
        public int Id { get; set; }

        public virtual IList<HotelDTO> Hotels { get; set; }
    }

    public class CreateCountryDTO
    {
        
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Too long")]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength: 2, ErrorMessage = "Too long")]
        public string ShortName { get; set; }
    }
}
