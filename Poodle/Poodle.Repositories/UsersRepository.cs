
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
        

        public async Task<User> Update(int id, User user, string imageUrl)
        {
            var userToUpdate = this.GetById(id).FirstOrDefault();

            userToUpdate.FirstName = user.FirstName != "string" ? user.FirstName : userToUpdate.FirstName;
            userToUpdate.LastName = user.LastName != "string" ? user.LastName : userToUpdate.LastName;
            userToUpdate.Email = user.Email != "user@example.com" ? user.Email : userToUpdate.Email;
            userToUpdate.Password = user.Password != "string" ? user.Password : userToUpdate.Password;
            userToUpdate.Image.ImageUrl = imageUrl != "string" ? imageUrl : userToUpdate.Image.ImageUrl;

            userToUpdate.ModifiedOn = DateTime.Now;
            await this.context.SaveChangesAsync();

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
