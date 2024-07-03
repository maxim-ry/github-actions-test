namespace WebApplication1.Services
{
    public class ScopedService : IScopedService
    {
        private readonly Guid _operationID;

        public ScopedService()
        {
            _operationID = Guid.NewGuid();
        }

        public Guid GetOperationID() => _operationID;
    }
}
