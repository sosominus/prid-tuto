using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prid_tuto.Models;


namespace prid_tuto.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class MembersController : ControllerBase
{
    private readonly MsnContext _context;

    /*
    Le contrôleur est instancié automatiquement par ASP.NET Core quand une requête HTTP est reçue.
    Le paramètre du constructeur recoit automatiquement, par injection de dépendance, 
    une instance du context EF (MsnContext).
    */
    public MembersController(MsnContext context) {
        _context = context;
    }

    // GET: api/Members
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Member>>> GetAll() {
        // Récupère une liste de tous les membres
        return await _context.Members.ToListAsync();
    }

    // GET: api/Members
    [HttpGet("{pseudo}")]
    public async Task<ActionResult<Member?>> GetOne(string pseudo) {
        var member = await _context.Members.FindAsync(pseudo);
        if (member == null)
            return NotFound();
        return member;
    }

    [HttpPost]
    public async Task<ActionResult<Member>> PostMember (Member member){
        _context.Members.Add(member);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetOne) , new {pseudo = member.Pseudo}, member); 
    }


}