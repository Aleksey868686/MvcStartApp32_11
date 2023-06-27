namespace MvcStartApp.Models.Db
{
    public interface IRequestRepository
    {
        Task AddRequest(HttpContext httpContext);
    }
}
