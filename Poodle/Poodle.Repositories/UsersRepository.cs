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

        public IQueryable<User> Get()
        {
            return context.Users
                .Include(u => u.Role)
                .Include(u => u.Image)
                .Include(u => u.Courses);
        }

        public IQueryable<User> Get(int id)
        {
            return this.Get().Where(u => u.Id == id);
        }

        public IQueryable<User> Get(string email)
        {
            return this.Get().Where(u => u.Email == email);
        }       
        

        public async Task<User> Create(User user, int roleId, string imageUrl)
        {
            user.CreatedOn = DateTime.UtcNow;
            user.ModifiedOn = DateTime.UtcNow;
            user.RoleId = roleId;

            var image = this.AddNewImage(imageUrl);
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

        public User Delete(int id, bool isDeleted)
        {
            throw new NotImplementedException();
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
