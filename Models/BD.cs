using System.Data.SqlClient;
using Dapper;

namespace TP7_PreguntadORT_Benezra_Sasson.Models;

static class BD{
    private static string _connectionString="Server=localhost; DataBase=PreguntadOrt; Trusted_Connection=True;";
    static List<Categoria> ListaCategorias = new List<Categoria>();
    static List<Dificultad> ListaDificultades = new List<Dificultad>();
    static List<Pregunta> ListaPreguntas = new List<Pregunta>();
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
        if(idDificultad==-1){
            using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql= "SELECT Preguntas.* FROM Preguntas inner join Categorias on Categorias.IdCategoria = Preguntas.IdCategoria where Preguntas.IdCategoria=@pIdCategoria";
            ListaPreguntas = db.Query<Pregunta>(sql, new{pIdCategoria=idCategoria, pIdDificultad=idDificultad}).ToList();
            }
        }
        else if(idCategoria==-1){
            using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql= "SELECT Preguntas.* FROM Preguntas inner join Dificultades on Dificultades.IdDificultad = Preguntas.IdPregunta where Dificultades.IdDificultad=@pIdDificultad";
            ListaPreguntas = db.Query<Pregunta>(sql, new{pIdCategoria=idCategoria, pIdDificultad=idDificultad}).ToList();
            }
        }
        else{
            using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql= "SELECT Preguntas.* FROM Preguntas inner join Categorias on Categorias.IdCategoria = Preguntas.IdCategoria inner join Dificultades on Dificultades.IdDificultad = Preguntas.IdPregunta where Preguntas.IdCategoria=@pIdCategoria and Dificultades.IdDificultad=@pIdDificultad";
            ListaPreguntas = db.Query<Pregunta>(sql, new{pIdCategoria=idCategoria, pIdDificultad=idDificultad}).ToList();
            }
        }
        return ListaPreguntas;
    }
    public static ObtenerRespuestas(List preguntas){
        using(SqlConnection db = new SqlConnection(_connectionString)){
            string sql= "";
            ListaPreguntas = db.Query<>(sql, new{}).ToList();
        }
    }
}