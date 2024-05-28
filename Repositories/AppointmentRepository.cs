﻿using RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;
        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Appointment> AddAsync(Appointment appointmentModel)
        {
            await _context.Appointments.AddAsync(appointmentModel);
            await _context.SaveChangesAsync();
            return appointmentModel;
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            return await _context.Appointments
                .Include(a => a.Customer)
                .Include(a => a.Pet)
                .Include(a => a.Vet)
                .Include(a => a.Slot)
                .Include(a => a.Service)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetByDateAsync(DateOnly date)
        {
            return await _context.Appointments
                .Where(a => a.Date == date)
                .ToListAsync();
        }

        public async Task<Appointment?> GetByIdAsync(int id)
        {
            return await _context.Appointments
                .Include(a => a.Customer)
                .Include(a => a.Pet)
                .Include(a => a.Vet)
                .Include(a => a.Slot)
                .Include(a => a.Service)
                .FirstOrDefaultAsync(a => a.AppointmentId == id);
        }

        public async Task<Appointment?> RemoveAsync(int id)
        {
            var appointmentModel = await _context.Appointments.FindAsync(id);
            if (appointmentModel == null)
            {
                return null;
            }
            _context.Remove(appointmentModel);
            await _context.SaveChangesAsync();
            return appointmentModel;
        }

        public async Task<Appointment?> UpdateAsync(Appointment appointmentModel)
        {
            await _context.SaveChangesAsync();
            return appointmentModel;
        }
    }
}
