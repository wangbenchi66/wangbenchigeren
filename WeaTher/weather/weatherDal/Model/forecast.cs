namespace weatherDal.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("forecast")]
    public partial class forecast
    {
        [Key]
        public int FID { get; set; }

        [Required]
        [StringLength(20)]
        public string date { get; set; }

        [Required]
        [StringLength(30)]
        public string high { get; set; }

        [Required]
        [StringLength(30)]
        public string low { get; set; }

        public DateTime ymd { get; set; }

        [Required]
        [StringLength(30)]
        public string week { get; set; }

        [Required]
        [StringLength(30)]
        public string sunrise { get; set; }

        [Required]
        [StringLength(30)]
        public string sunset { get; set; }

        [Required]
        [StringLength(30)]
        public string fx { get; set; }

        [Required]
        [StringLength(30)]
        public string fl { get; set; }

        [Required]
        [StringLength(10)]
        public string type { get; set; }

        [StringLength(200)]
        public string notice { get; set; }

        public int? ID { get; set; }

        public virtual cityweather cityweather { get; set; }
    }
}
