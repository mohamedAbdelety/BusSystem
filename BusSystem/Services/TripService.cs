﻿using BusSystem.Data;
using BusSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusSystem.Services
{
    public class TripService : IRepository<Trip>
    {
        private readonly ApplicationDbContext _context;

        public TripService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Trip> GetAll()
        {
            return _context.Trips.Include(t => t.Bus).Include("Route").Include("Route.DropOff").Include("Route.PickUp").ToList();
        }

        public Trip Details(int id)
        {
            return _context.Trips.Include(t => t.Bus).Include(t => t.Route).FirstOrDefault(m => m.ID == id);
        }

        public void Add(Trip trip)
        {
            _context.Add(trip);
            _context.SaveChangesAsync();
        }

        public void Update(Trip trip)
        {
            _context.Update(trip);
            _context.SaveChangesAsync();
        }

        public void Remove(Trip trip)
        {
            _context.Trips.Remove(trip);
            _context.SaveChangesAsync();
        }
    }
}
