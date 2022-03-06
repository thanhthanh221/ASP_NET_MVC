using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_NET_MVC.Models{
    [Table("Thư gửi")]
    public class ContactModel {
        [Key]
        public int Id{get;set;}
        [Required(ErrorMessage = "Phải Nhập Họ Tên")]
        [Column("Tên",TypeName = "nvarchar")]
        [StringLength(50)]
        [Display(Name = "Họ Tên")]
        public string? FullName{get; set;}
        [Column("Email",TypeName = "nvarchar")]
        [StringLength(50)]
        [Required(ErrorMessage = "Phải Nhập Email")]
        [EmailAddress(ErrorMessage ="Phải Là Emai")]
        public string? Email{get; set;}
        [Display(Name = "Ngày gửi")]
        public DateTime dateSent{get;set;}
        [Display(Name ="Thông Tin")]
        public string? Message{get; set;}
        [Display(Name ="Số điện thoại")]
        [Phone]
        [StringLength(10,ErrorMessage =" Số điện thoại chỉ dài 10 thôi")]
        public string? Phone{get; set;}



    }
}