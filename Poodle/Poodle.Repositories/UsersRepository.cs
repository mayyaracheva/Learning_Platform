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
            => context.Users;
                

        public IQueryable<User> GetById(int id)        
            => this.GetAll().Where(u => u.Id == id);
        

        public IQueryable<User> GetByEmail(string email)        
         => this.GetAll().Where(u => u.Email == email);
        
        
        public IQueryable<Role> GetRoles()      
            =>this.context.Roles;
        
        
    
        public async Task<User> Create(User user, string imageUrl)
        {
            user.CreatedOn = DateTime.UtcNow;
            user.ModifiedOn = DateTime.UtcNow;
            user.RoleId = user.RoleId;

            var image = await this.AddNewImage(imageUrl);
            user.ImageId = image.Id;
            var createdUser = await this.context.Users.AddAsync(user);
            await this.context.SaveChangesAsync();

            image.UserId = createdUser.Entity.Id;
            await this.context.SaveChangesAsync();
            return createdUser.Entity;
        }
        

        public User Update(int id, string firstname, string lastname, string password, string email, string imageUrl)
        {
            var userToUpdate = this.GetById(id).FirstOrDefault();

            userToUpdate.FirstName = firstname != "string" ? firstname : userToUpdate.FirstName;
            userToUpdate.LastName = lastname != "string" ? lastname : userToUpdate.LastName;
            userToUpdate.Email = email != "user@example.com" ? email : userToUpdate.Email;
            userToUpdate.Password = password != "string" ? password : userToUpdate.Password;
            userToUpdate.Image.ImageUrl = imageUrl != "string" ? imageUrl : userToUpdate.Image.ImageUrl;

            userToUpdate.ModifiedOn = DateTime.Now;
            this.context.SaveChanges();

            return userToUpdate;
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
