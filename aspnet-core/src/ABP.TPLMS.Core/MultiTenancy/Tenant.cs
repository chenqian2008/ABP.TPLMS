using Abp.MultiTenancy;
using ABP.TPLMS.Authorization.Users;

namespace ABP.TPLMS.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
