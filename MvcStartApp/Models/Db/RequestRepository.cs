using Microsoft.EntityFrameworkCore;

namespace MvcStartApp.Models.Db
{
    public class RequestRepository : IRequestRepository
    {
        // ссылка на контекст
        private readonly BlogContext _context;

        // Метод-конструктор для инициализации
        public RequestRepository(BlogContext context)
        {
            _context = context;
        }
        public async Task AddRequest(HttpContext httpContext)
        {
            Request request = new Request();
            request.Date = DateTime.Now;  
            request.Id = Guid.NewGuid();
            request.Url = httpContext.Request.Host.Value + httpContext.Request.Path;

            // Добавление пользователя
            var entry = _context.Entry(request);
            if (entry.State == EntityState.Detached)
                await _context.Requests.AddAsync(request);

            // Сохранение изенений
            await _context.SaveChangesAsync();
        }
    }
}
