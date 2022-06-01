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
        
    
        public User Create(User user, string imageUrl)
        {
            user.CreatedOn = DateTime.UtcNow;
            user.ModifiedOn = DateTime.UtcNow;
            user.RoleId = user.RoleId;

            var image = this.AddNewImage(imageUrl);
            user.ImageId = image.Id;
            var createdUser = this.context.Users.Add(user);
            this.context.SaveChanges();

            image.UserId = createdUser.Entity.Id;
            this.context.SaveChanges();
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

        public int Delete(User userToDelete)
        {            
            this.context.Users.Remove(userToDelete);
            this.context.SaveChanges();
            return userToDelete.Id;
        }

      
        private Image AddNewImage(string imageUrl)
        {
            var newImage = new Image();
            newImage.ImageUrl = imageUrl;
            this.context.Images.Add(newImage);
            this.context.SaveChanges();

            return newImage;
        }


    }
}
