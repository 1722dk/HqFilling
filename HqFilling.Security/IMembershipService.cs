using HqFilling.Security.Models;

namespace HqFilling.Security
{
    public interface IMembershipService
    {
        AuthStatus ValidateUser(string userName, string password);
        string[] GetRoles(string userName);
    }
}
