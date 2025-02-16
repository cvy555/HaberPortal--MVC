namespace HaberPortal_MVC.Models
{
    public class HaberDetayDTO
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public DateTime YayinlanmaTarihi { get; set; }
        public string KategoriAd { get; set; }
        public string YazarAdSoyad { get; set; }
        public string ResimUrl { get; set; }
    }
}
