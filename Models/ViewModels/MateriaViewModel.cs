namespace Practica2_U2_211G0353.Models.ViewModels
{
    public class MateriaView
    {
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public int HorasTeoricas { get; set; }
        public int HorasPracticas { get; set; }
        public int Creditos { get; set; }
    }
    public class SemestreView
    {
        public int Semestre { get; set; }
        public List<MateriaView> Materias { get; set; }
    }
    public class CarreraViewModel
    {
        public string Carrera { get; set; }
        public string Plan { get; set; }
        public int CreditosTotales { get; set; }
        public List<SemestreView> Semestres { get; set; }
    }
}
