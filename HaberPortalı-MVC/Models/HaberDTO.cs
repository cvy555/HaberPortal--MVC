// Models/HaberDTO.cs
namespace HaberPortal_MVC.Models
{
    public class HaberDTO
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public int KategoriId { get; set; }
        public string ResimUrl { get; set; } 
        public DateTime YayinlanmaTarihi { get; set; }
    }
}
