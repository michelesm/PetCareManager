[ApiController]
[Route("api/[controller]")]
public class OwnersController : ControllerBase
{
    private readonly AppDbContext _context;
    public OwnersController(AppDbContext context) => _context = context;

    [HttpGet] public async Task<ActionResult<IEnumerable<Owner>>> Get() => await _context.Owners.Include(o => o.Pets).ToListAsync();
    [HttpGet("{id}")] public async Task<ActionResult<Owner>> Get(int id) => await _context.Owners.Include(o => o.Pets).FirstOrDefaultAsync(o => o.Id == id);
    [HttpPost] public async Task<IActionResult> Post(Owner owner) { _context.Owners.Add(owner); await _context.SaveChangesAsync(); return CreatedAtAction(nameof(Get), new { id = owner.Id }, owner); }
    [HttpPut("{id}")] public async Task<IActionResult> Put(int id, Owner owner) { if (id != owner.Id) return BadRequest(); _context.Entry(owner).State = EntityState.Modified; await _context.SaveChangesAsync(); return NoContent(); }
    [HttpDelete("{id}")] public async Task<IActionResult> Delete(int id) { var owner = await _context.Owners.FindAsync(id); if (owner == null) return NotFound(); _context.Owners.Remove(owner); await _context.SaveChangesAsync(); return NoContent(); }
}