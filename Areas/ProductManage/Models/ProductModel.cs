using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ASP_NET_MVC.Models{
    [Table("Sản Phẩm")]
    public class ProductModel{
        [Key]
        [Required]
        public int ID{set;get;}
        [Column("Tên",TypeName = "nvarchar")]
        [StringLength(50,ErrorMessage ="Không được quá dài")]
        public string? Name{set;get;}
        [Display(Name = "giá")]
        [Column("Giá")]
        public int Price{set;get;}
    }
}