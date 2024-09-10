using static RainFramework.Dao.RFDBContext;

namespace RainFramework.Dao
{
    public class TenantService : ITenantService
    {
        public int GetTenantId()
        {
            Console.WriteLine("---");
            return 1;
        }

        public void SetTenantId(int tenantId)
        {
            throw new NotImplementedException();
        }
    }
}
