using Microsoft.EntityFrameworkCore;
using pract12_trpo.Classes;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract12_trpo.Data.Service
{
    public class UsersService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;
        public static ObservableCollection<User> Users { get; set; } = new();
        public UsersService()
        {
            GetAll();
        }
        public void Add(User user)
        {
            var _user = new User
            {
                Login = user.Login,
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                CreatedAt = user.CreatedAt,
                UserProfile = user.UserProfile,
                RoleId = user.RoleId,
                Role = user.Role,
            };
            _db.Add<User>(_user);
            Commit();
            Users.Add(_user);
        }
        public int Commit() => _db.SaveChanges();
        public void GetAll()
        {
            var users = _db.Users
                        .Include(u => u.UserProfile)
                        .Include(u => u.Role)
                        .ToList();
            Users.Clear();
            foreach (var u in users)
            {
                Users.Add(u);
            }
        }
        public void Remove(User user)
        {
            _db.Remove<User>(user);
            if (Commit() > 0)
            {
                if (Users.Contains(user))
                {
                    Users.Remove(user);
                }
            }
        }
    }
}
