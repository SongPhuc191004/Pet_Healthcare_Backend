﻿using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ServiceContracts;
using Services.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;
        private readonly IConfiguration _configuration;
        public PhotoService(IConfiguration configuration) 
        {
            _configuration = configuration;
            var acc = new Account(
                cloud: configuration["CloudinarySettings:CloudName"],
                apiKey: configuration["CloudinarySettings:ApiKey"],
                apiSecret: configuration["CloudinarySettings:ApiSecret"]
                );
            _cloudinary = new Cloudinary(acc);
        }
        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();
            if(file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face")
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }
            return uploadResult;
        }

        public async Task<DeletionResult> DeletePhotoAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);
            var result = await _cloudinary.DestroyAsync(deleteParams);
            return result;
        }
    }
}
