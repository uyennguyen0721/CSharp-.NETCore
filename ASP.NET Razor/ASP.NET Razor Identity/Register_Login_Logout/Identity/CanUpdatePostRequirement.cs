using Microsoft.AspNetCore.Authorization;

namespace Register_Login_Logout.Identity
{
    public class CanUpdatePostRequirement : IAuthorizationRequirement
    {
        public bool AdminCanUpdate { set; get; }
        public bool OwnerCanUpdate { set; get; }
        public CanUpdatePostRequirement(bool _adminCanUpdate = true, bool _ownerCanupdate = true)
        {
            AdminCanUpdate = _adminCanUpdate;
            OwnerCanUpdate = _ownerCanupdate;
        }
    }
}