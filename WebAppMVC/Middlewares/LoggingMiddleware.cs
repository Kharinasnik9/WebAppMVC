using WebAppMVC.Models.Db;

namespace WebAppMVC.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IRequestRepository repository)
        {
            var request = new Request
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Url = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}"
            };

            await repository.AddRequest(request);

            // Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }
    }
}
