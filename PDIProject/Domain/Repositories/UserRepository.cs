﻿using PDIProject.Domain.Entities;
using PDIProject.Domain.Interfaces.Repositories;
using PDIProject.Persistence;

namespace PDIProject.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PDIDataContext _context;
        public UserRepository(PDIDataContext context) 
        {
            _context = context;
        }

        public IEnumerable<User> GetAll() 
        {
            return _context.Users.Where(x => !x.Deleted);
        }

        public User GetById(int id)
        {
            return _context.Users.Where(x => x.Id == id && !x.Deleted).FirstOrDefault();
        }

        public void Add(User user) 
        {
            _context.Users.Add(user);
        }
    }
}
