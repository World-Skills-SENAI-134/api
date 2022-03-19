using Microsoft.AspNetCore.Mvc;
using Session2.Contexts;
using System.Linq;

namespace Session2.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class RankingController : ControllerBase
    {
        private readonly Session2Context context = new();

        // itens do roteiro.txt

        //11 - Listar os primeiros 500 participantes em C#
        //12 - Ordenar participantes por nome em C#
        [HttpGet("participantes/listar")]
        public IActionResult Listar()
        {
            return Ok(context.Participantes.OrderBy(p => p.Nome).Take(500).ToList());
        }

        //13 - Buscar participantes por nome completo em C#
        [HttpGet("participantes/buscarPorNomeCompleto/{nome}")]
        public IActionResult BuscarPorNomeCompleto(string nome)
        {
            return Ok(context.Participantes.Where(p => p.Nome == nome).Take(500).ToList());
        }

        [HttpGet("participantes/buscaAvancada/{seletor}/{filtro}")]
        public IActionResult BuscaAvanca(string seletor, string filtro)
        {
            switch (seletor)
            {
                //14 - Buscar participantes de um determinado estado em C#
                case "+":
                    return Ok(context.Participantes
                                        .Where(p => p.Cidade.Estado.Sigla == filtro).Take(500).ToList());

                //15 - Buscar participantes por filtro de string em C#
                case "%STRING":
                    return Ok(context.Participantes
                                        .Where(p => p.Nome.EndsWith(filtro)).Take(500).ToList());

                case "STRING%":
                    return Ok(context.Participantes
                                        .Where(p => p.Nome.StartsWith(filtro)).Take(500).ToList());

                case "%STRING%":
                    return Ok(context.Participantes
                                        .Where(p => p.Nome.Contains(filtro)).Take(500).ToList());

                //16 - Ordenar participantes por nome de A - Z em C#
                case "!>":
                    if (filtro == "PA")
                    {
                        return Ok(context.Participantes
                                        .OrderBy(p => p.Nome).Take(500).ToList());
                    }
                    break;

                //17 - Ordenar participantes por nome de Z - A em C#
                case "!<":
                    if (filtro == "PA")
                    {
                        return Ok(context.Participantes
                                        .OrderByDescending(p => p.Nome).Take(500).ToList());
                    }
                    break;

                default:
                    break;
            }

            return Ok();
        }
    }
}
