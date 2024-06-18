using SPA.Api.Models;
using Microsoft.AspNetCore.Mvc;
using SPA.Api.Data;
using Microsoft.AspNetCore.Http.HttpResults;

namespace SPA.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DespesasController : ControllerBase
{
    private readonly MyDatabase _db;
    public DespesasController(MyDatabase db)
    {
        _db = db;
    }


    // GET action
    [HttpGet]
    public ActionResult<List<Despesa>> GetAll()
    {
        List<Despesa> despesaList = _db.Despesas.ToList();

        return Ok(despesaList);
    }

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Despesa> Get(int id)
    {
        Despesa? despesa = _db.Despesas.SingleOrDefault(x => x.Id == id); 
        if (despesa == null){
            return NotFound();
        }
        return Ok(despesa);
    }

    // POST action
    [HttpPost]
    public IActionResult Create(Despesa despesa)
    {            
        _db.Despesas.Add(despesa);
        _db.SaveChanges();
        return CreatedAtAction(nameof(Create), new {id = despesa.Id}, despesa);
    }

    // PUT action
    [HttpPut]
    public IActionResult Update(Despesa newDespesa)
    {
        Despesa? despesa = _db.Despesas.SingleOrDefault(x => x.Id == newDespesa.Id);
        if(despesa == null)
        {
            return NotFound();
        }
        _db.Despesas.Update(newDespesa);
        _db.SaveChanges();
        return Ok();
    }   

    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        Despesa? despesa = _db.Despesas.SingleOrDefault(despesa => despesa.Id == id);
        if (despesa == null)
        {
            return NotFound();
        }
        _db.Despesas.Remove(despesa);
        _db.SaveChanges();
        return Ok();
    }
}

