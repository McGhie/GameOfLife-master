namespace Gameoflife
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserTemplate")]
    public partial class UserTemplate
    {
        public int UserTemplateID { get; set; }

        public int UserID { get; set; }

        [Required]
        public string Name { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        [Required]
        public string Cells { get; set; }
    }
}
