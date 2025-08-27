using MediatR;
using StockTrackingSystem.Business.User.Models;
using System.ComponentModel.DataAnnotations;

namespace StockTrackingSystem.Business.User.Requests;

public class AddUserRequest : IRequest<AddUserModel>
{
    [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz.")]
    [MinLength(3, ErrorMessage = "Kullanıcı adı en az 3 karakter olmalı.")]
    [MaxLength(50, ErrorMessage = "Kullanıcı adı en fazla 50 karakter olabilir.")]
    [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Kullanıcı adı yalnızca harf ve rakamlardan oluşabilir, boşluk içeremez.")]
    public string UserName { get; set; }


    [Required(ErrorMessage = "E-posta alanı boş bırakılamaz.")]
    [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz. Örnek: ornek@site.com")]
    public string Email { get; set; }


    [Required(ErrorMessage = "Şifre boş geçilemez.")]
    [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
    public string Password1 { get; set; }


    [Required(ErrorMessage = "Şifre tekrar boş geçilemez.")]
    [Compare("Password1", ErrorMessage = "Şifreler eşleşmiyor.")]
    public string Password2 { get; set; }
}
