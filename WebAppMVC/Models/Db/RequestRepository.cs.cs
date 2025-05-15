using Microsoft.EntityFrameworkCore;

namespace WebAppMVC.Models.Db

{
    public class RequestRepository : IRequestRepository
    {
        private readonly BlogContext _context;

        public RequestRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task AddRequest(Request request)
        {
            await _context.Requests.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task<Request[]> GetRequests()
        {
            return await _context.Requests
                .OrderByDescending(r => r.Date)
                .ToArrayAsync();
        }
    }
}
