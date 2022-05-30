using Microsoft.EntityFrameworkCore;
using Poodle.Data;
using Poodle.Data.EntityModels;
using Poodle.Repositories.Contracts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Poodle.Repositories
{
    public class UsersRepository : IUsersRepository
    {
       
        private readonly ApplicationContext context;

        public UsersRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public IQueryable<User> GetAll()
        {
            return context.Users
                .Include(u => u.Role)
                .Include(u => u.Image)
                .Include(u => u.Courses);
        }

        public IQueryable<User> GetById(int id)
        {
            return this.GetAll().Where(u => u.Id == id);
        }

        public IQueryable<User> GetByEmail(string email)
        {
            return this.GetAll().Where(u => u.Email == email);
        }
        
        public IQueryable<Role> GetRoles()
        {
            return this.context.Roles;
        }
        
    
        public async Task<User> Create(User user, string imageUrl)
        {
            user.CreatedOn = DateTime.UtcNow;
            user.ModifiedOn = DateTime.UtcNow;
            user.RoleId = user.RoleId;

            var image = this.AddNewImage(imageUrl).Result;
            user.ImageId = image.Id;
            var createdUser = await this.context.Users.AddAsync(user);
            await this.context.SaveChangesAsync();

            image.UserId = createdUser.Entity.Id;
            await this.context.SaveChangesAsync();
            return createdUser.Entity;
        }
        public User Update(int id, User user)
        {
            throw new NotImplementedException();
        }

        public User Update(int id, User user, string imageUrl)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Delete(User userToDelete)
        {            
            this.context.Users.Remove(userToDelete);
            await this.context.SaveChangesAsync();
            return userToDelete.Id;
        }

      
        private async Task<Image> AddNewImage(string imageUrl)
        {
            var newImage = new Image();
            newImage.ImageUrl = imageUrl;
            await this.context.Images.AddAsync(newImage);
            await this.context.SaveChangesAsync();

            return newImage;
        }


    }
}
