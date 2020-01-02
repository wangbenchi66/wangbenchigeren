namespace weatherDal.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cityweather")]
    public partial class cityweather
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cityweather()
        {
            //forecast = new HashSet<forecast>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string shidu { get; set; }

        public Double pm25 { get; set; }

        public Double pm10 { get; set; }

        [Required]
        [StringLength(50)]
        public string quality { get; set; }

        [Required]
        [StringLength(50)]
        public string wendu { get; set; }

        [StringLength(200)]
        public string ganmao { get; set; }

        public int? CityID { get; set; }

        //public virtual cityInfo cityInfo { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<forecast> forecast { get; set; }
        [NotMapped]
        public forecast yesterday { get; set; }
        [NotMapped]
        public virtual ICollection<forecast> forecast { get; set; }
    }
}
