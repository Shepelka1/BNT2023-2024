using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class IdentityManager
    {
        private readonly IdentityContext identityContext;

        public IdentityManager(IdentityContext identityContext)
        {
            this.identityContext = identityContext;
        }

        public async Task SeedDataAsync(string adminUsername, string adminPass)
        {
            await identityContext.SeedDataAsync(adminUsername, adminPass);
        }
        private async Task CreateAdminAccountAsync(string username, string password)
        {
            await identityContext.CreateUserAsync(username, password, "admin", "admin", Role.Admin);
        }

        public async Task CreateUserAsync(string username, string password, string firstName, string lastName, Role role)
        {
            await identityContext.CreateUserAsync(username, password, firstName, lastName, role);
        }

        public async Task<User> LogInUserAsync(string username, string password)
        {
            return await identityContext.LogInUserAsync(username, password);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await identityContext.GetAllUsersAsync();
        }

        public async Task<User> FindUserByNameAsync(string name)
        {
            return await identityContext.FindUserByNameAsync(name);
        }

        public async Task DeleteUserByNameAsync(string name)
        {
            await identityContext.DeleteUserByNameAsync(name);
        }

        public async Task UpdateUserAsync(string username, string firstName, string lastName, Role role)
        {
            await identityContext.UpdateUserAsync(username, firstName, lastName, role);
        }

        public async Task ChangeUserPasswordAsync(User user, string currentPassword, string newPassword)
        {
            await identityContext.ChangeUserPasswordAsync(user, currentPassword, newPassword);
        }
    }
}
