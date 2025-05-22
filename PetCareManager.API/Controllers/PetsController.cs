[ApiController]
[Route("api/[controller]")]
public class PetsController : ControllerBase
{
    private readonly AppDbContext _context;
    public PetsController(AppDbContext context) => _context = context;

    [HttpGet] public async Task<ActionResult<IEnumerable<Pet>>> Get() => await _context.Pets.Include(p => p.Owner).ToListAsync();
    [HttpGet("{id}")] public async Task<ActionResult<Pet>> Get(int id) => await _context.Pets.Include(p => p.Owner).FirstOrDefaultAsync(p => p.Id == id);
    [HttpPost] public async Task<IActionResult> Post(Pet pet) { _context.Pets.Add(pet); await _context.SaveChangesAsync(); return CreatedAtAction(nameof(Get), new { id = pet.Id }, pet); }
    [HttpPut("{id}")] public async Task<IActionResult> Put(int id, Pet pet) { if (id != pet.Id) return BadRequest(); _context.Entry(pet).State = EntityState.Modified; await _context.SaveChangesAsync(); return NoContent(); }
    [HttpDelete("{id}")] public async Task<IActionResult> Delete(int id) { var pet = await _context.Pets.FindAsync(id); if (pet == null) return NotFound(); _context.Pets.Remove(pet); await _context.SaveChangesAsync(); return NoContent(); }
}