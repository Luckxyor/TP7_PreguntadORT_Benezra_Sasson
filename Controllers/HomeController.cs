using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP7_PreguntadORT_Benezra_Sasson.Models;

namespace TP7_PreguntadORT_Benezra_Sasson.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult ConfigurarJuego()
    {
        
        ViewBag.ListaDificultades=Juego.ObtenerDificultades();
        ViewBag.ListaCategorias=Juego.ObtenerCategorias();
        return View();
    }
    public IActionResult Comenzar(string username, int dificultad, int categoria)
    {
        Juego.CargarPartida(username, dificultad, categoria);
        Jugar();
        return View();
    }
    public IActionResult Jugar(){
        Pregunta PreguntaElegida=Juego.ObtenerProximaPregunta();
        if (PreguntaElegida==null){
            ViewBag.PreguntaElegida=PreguntaElegida;
            return View("Fin");
        }
        else{return View();}
    }

    [HttpPost]
    public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta){
        
        return View("Respuesta");
    }
}
