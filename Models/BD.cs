using System.Data.SqlClient;
using Dapper;

namespace TP7_PreguntadORT_Benezra_Sasson.Models;

static class BD{
    private static string _connectionString="Server=localhost; DataBase=PreguntadOrt; Trusted_Connection=True;";
    static List<Categoria> ListaCategorias = new List<Categoria>();
    static List<Dificultad> ListaDificultades = new List<Dificultad>();
    static List<Pregunta> ListaPreguntas = new List<Pregunta>();
    static List<Respuesta> ListaRespuestas= new List<Respuesta>();
    static List<Puntaje> ListaPuntajes= new List<Puntaje>();
    public static List<Categoria> ObtenerCategorias(){
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql= "SELECT * FROM Categorias";
            ListaCategorias = db.Query<Categoria>(sql).ToList();
        }
        return ListaCategorias;
    }
    public static List<Dificultad> ObtenerDificultades(){
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql= "SELECT * FROM Dificultades";
            ListaDificultades = db.Query<Dificultad>(sql).ToList();
        }
        return ListaDificultades;
    }
    public static List<Pregunta> ObtenerPreguntas(int idDificultad, int idCategoria){
        if(idDificultad!=-1 && idCategoria!=-1){
            using(SqlConnection db = new SqlConnection(_connectionString)){
                string sql= "SELECT * FROM Preguntas where IdCategoria=@pIdCategoria and IdDificultad=@pIdDificultad";
                ListaPreguntas = db.Query<Pregunta>(sql, new{pIdCategoria=idCategoria, pIdDificultad=idDificultad}).ToList();
            }
        }
        else if(idDificultad==-1 && idCategoria!=-1){
            using(SqlConnection db = new SqlConnection(_connectionString)){
                string sql= "SELECT * FROM Preguntas where IdCategoria=@pIdCategoria";
                ListaPreguntas = db.Query<Pregunta>(sql, new{pIdCategoria=idCategoria, pIdDificultad=idDificultad}).ToList();
            }
        }
        else if(idCategoria==-1 && idDificultad!=-1){
            using(SqlConnection db = new SqlConnection(_connectionString)){
                string sql= "SELECT * FROM Preguntas where IdDificultad=@pIdDificultad";
                ListaPreguntas = db.Query<Pregunta>(sql, new{pIdCategoria=idCategoria, pIdDificultad=idDificultad}).ToList();
            }
        }
        else{
            using(SqlConnection db = new SqlConnection(_connectionString)){
                string sql= "SELECT * FROM Preguntas";
                ListaPreguntas = db.Query<Pregunta>(sql).ToList();
            }
        }
        return ListaPreguntas;
    }
    public static List<Respuesta> ObtenerRespuestas(int idPregunta){
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql= "Select * from Respuestas where IdPregunta=@pIdPregunta";
            ListaRespuestas = db.Query<Respuesta>(sql, new{pIdPregunta=idPregunta}).ToList();
        }
        return ListaRespuestas;
    }
    public static bool EsCorrecta(int idRespuesta){
        bool Correcta=false;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql= "Select Correcta from Respuestas where IdRespuesta=@pIdRespuesta";
            Correcta = db.QueryFirstOrDefault<bool>(sql, new{pIdRespuesta=idRespuesta});
        }
        return Correcta;
    }
    public static string CualEraCorrecta(int idPregunta){
        string correcta=null;
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql= "Select Contenido from Respuestas inner join Preguntas on Respuestas.IdPregunta=Preguntas.IdPregunta where Correcta=1 and Preguntas.IdPregunta=@pIdPregunta";
            correcta = db.QueryFirstOrDefault<string>(sql, new{pIdPregunta=idPregunta});
        }
        return correcta;
    }
    public static void IngresarPuntaje(Puntaje puntaje){
        string sql= "Insert into Puntajes(Username, PuntajeFinal, HoraHecho) VALUES (@pUsername, @pPuntajeFinal, @pHoraHecho)";
        using(SqlConnection db = new SqlConnection(_connectionString)){
            db.Execute(sql, new{pUsername=puntaje.Username, pPuntajeFinal=puntaje.PuntajeFinal, pHoraHecho=puntaje.HoraHecho});
        }
    }

    public static List<Puntaje> ObtenerPuntajes(){
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql= "SELECT top 10 Username, PuntajeFinal, HoraHecho FROM Puntajes Order by PuntajeFinal desc";
            ListaPuntajes = db.Query<Puntaje>(sql).ToList();
        }
        return ListaPuntajes;
    }
}