namespace WebApplication1.Services
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IScopedService _scopedService;

        public CustomMiddleware(RequestDelegate next, IScopedService scopedService)
        {
            _next = next;
            _scopedService = scopedService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var operationID = _scopedService.GetOperationID();
            context.Response.Headers.Add("X-Operation-ID", operationID.ToString());
            await _next(context);
        }
    }
}
