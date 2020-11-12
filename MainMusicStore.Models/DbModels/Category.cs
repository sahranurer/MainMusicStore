using System.ComponentModel.DataAnnotations;

namespace MainMusicStore.Models.DbModels
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Bu Alan Boş Geçilmez !")]
        [StringLength(250,MinimumLength =3,ErrorMessage ="Şartlara Uygun Değer Giriniz !")]
        public string CategoryName { get; set; }


    }
}
