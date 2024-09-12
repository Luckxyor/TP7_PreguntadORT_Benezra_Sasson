namespace TP7_PreguntadORT_Benezra_Sasson.Models;

public class Puntaje{
    public string Username { get; set; }
    public int PuntajeFinal { get; set; }
    public DateTime HoraHecho { get; set; }

    public Puntaje(){
    }
    public Puntaje(string username, int puntajeFinal, DateTime horaHecho){
        Username = username;
        PuntajeFinal = puntajeFinal;
        HoraHecho = horaHecho;
    }
}