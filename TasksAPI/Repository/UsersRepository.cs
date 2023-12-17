﻿using TasksAPI.Data;
using TasksAPI.Models;
using TasksAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TasksAPI.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DataContext _context;

        public UsersRepository(DataContext context)
        {
            _context = context;
        }

        public User GetUser(int id)
        {
            return _context.Users.Where(t => t.Id == id).Include(u => u.Objectives).FirstOrDefault();
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.OrderBy(t => t.Id).Include(u => u.Objectives).ToList();
        }

        public ICollection<Objective> GetUserObjectives(int id)
        {
            return _context.Users.Where(t => t.Id == id).Select(u => u.Objectives).FirstOrDefault();
        }

        public bool UserExists(int id)
        {
            return _context.Users.Any(p => p.Id == id);
        }

        public bool save()
        {
            throw new NotImplementedException();
        }
    }
}
