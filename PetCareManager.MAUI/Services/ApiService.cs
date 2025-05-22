public class ApiService
{
    HttpClient _client = new HttpClient { BaseAddress = new Uri("https://10.0.2.2:7043/api/") };
    public async Task<List<Owner>> GetOwnersAsync() => await _client.GetFromJsonAsync<List<Owner>>("owners");
    public async Task<List<Pet>> GetPetsAsync() => await _client.GetFromJsonAsync<List<Pet>>("pets");
    public async Task AddOwnerAsync(Owner o) => await _client.PostAsJsonAsync("owners", o);
    public async Task AddPetAsync(Pet p) => await _client.PostAsJsonAsync("pets", p);
}