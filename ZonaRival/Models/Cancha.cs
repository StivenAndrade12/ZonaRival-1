namespace ZonaRival.Models
{
    public class Cancha
    {
        public int CanchaId { get; set; }
        public string NombreCancha { get; set; }

        // Relación muchos a muchos con Equipo
        public List<EquipoCancha> EquiposCanchas { get; set; }
    }
}
