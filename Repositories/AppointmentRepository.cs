﻿using RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;
        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Appointment? appointment)
        {
            if (appointment == null) return false;
            _context.Appointments.Add(appointment);
            return SaveChanges();
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _context.Appointments.ToList();
        }

        public Appointment? GetById(int id)
        {
            return _context.Appointments.Find(id);
        }

        public bool Remove(int id)
        {
            var appointment = _context.Appointments.Find(id);
            if (appointment == null) return false;
            _context.Appointments.Remove(appointment);
            return SaveChanges();
        }

        public bool SaveChanges()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Appointment? appointment)
        {
            if (appointment == null) return false;
            _context.Appointments.Update(appointment);
            return SaveChanges();
        }
    }
}
