namespace TP7_PreguntadORT_Benezra_Sasson.Models;

public class Puntaje{
    public int IdPuntaje { get; set; }
    public string Username { get; set; }
    public int PuntajeFinal { get; set; }
    public DateTime HoraHecho { get; set; }

    public Puntaje(){
    }
    public Puntaje(int? idPuntaje, string username, int puntajeFinal, DateTime horaHecho){
        IdPuntaje = idPuntaje ?? 0; // Si es null, asigna 0
        Username = username;
        PuntajeFinal = puntajeFinal;
        HoraHecho = horaHecho;
    }
}