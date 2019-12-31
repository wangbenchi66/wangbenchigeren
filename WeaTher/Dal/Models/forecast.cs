namespace Dal.Models
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
        [Column(Order = 0)]
        public int forecastid { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string date { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(30)]
        public string high { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(30)]
        public string low { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime ymd { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(30)]
        public string week { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(30)]
        public string sunrise { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(30)]
        public string sunset { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(30)]
        public string fx { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(30)]
        public string fl { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(10)]
        public string type { get; set; }

        [StringLength(200)]
        public string notice { get; set; }

        public int? cityweatherid { get; set; }

        public virtual cityweather cityweather { get; set; }
    }
}
