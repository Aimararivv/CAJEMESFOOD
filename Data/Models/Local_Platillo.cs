namespace CajemesFoodAlejandro_Aimara.Data.Models
{
    public class Local_Platillo
    {
        public int id { get; set; }
        public int Localid { get; set; }
        public Local Local { get; set; }
        public int Platilloid { get; set; }
        public Platillo Platillo { get; set; }
    }
}

