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
        Juego.InicializarJuego();
        ViewBag.ListaDificultades=Juego.ObtenerDificultades();
        ViewBag.ListaCategorias=Juego.ObtenerCategorias();
        return View();
    }
    public IActionResult Comenzar(string username, int dificultad, int categoria)
    {
        
        return View();
    }
}
