﻿using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace ServiceContracts
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}
