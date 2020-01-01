namespace weatherDal.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cityInfo")]
    public partial class cityInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cityInfo()
        {
            //cityweather = new HashSet<cityweather>();
        }

        [Key]
        public int CityID { get; set; }

        [Required]
        [StringLength(20)]
        public string city { get; set; }

        [Required]
        [StringLength(30)]
        public string citykey { get; set; }

        [Required]
        [StringLength(20)]
        public string parent { get; set; }

        [Required]
        [StringLength(100)]
        public string updateTime { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<cityweather> cityweather { get; set; }
    }
}
