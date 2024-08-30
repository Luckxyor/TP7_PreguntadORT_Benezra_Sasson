namespace TP7_PreguntadORT_Benezra_Sasson.Models;

public class Pregunta{
    public int IdPregunta { get; set; }
    public int IdCategoria { get; set; }
    public int IdDificultad { get; set; }
    public string Enunciado { get; set; }
    public string? Foto { get; set; }

    public Pregunta(){
    }
}