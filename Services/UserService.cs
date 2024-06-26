﻿using Entities;
using RepositoryContracts;
using ServiceContracts;
using ServiceContracts.DTO.UserDTO;
using ServiceContracts.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<Vet>?> GetAvailableVetsAsync(DateOnly date, int slotId)
        {
            var vetList = await _userRepository.GetAvailableVetsAsync(date, slotId);
            if (vetList == null)
            {
                return vetList;
            }
            var result = vetList
                .Where(v => v.IsDeleted == false);
                
            return result;
        }
        public async Task<Vet?> GetAvailableVetById(string id)
        {
            return await _userRepository.GetVetById(id);
        }
    }
}
