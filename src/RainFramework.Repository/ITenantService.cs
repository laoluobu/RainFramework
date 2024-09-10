namespace RainFramework.Dao;

public abstract partial class RFDBContext
{
    public interface ITenantService
    {
        int GetTenantId();
        void SetTenantId(int tenantId);
    }
}