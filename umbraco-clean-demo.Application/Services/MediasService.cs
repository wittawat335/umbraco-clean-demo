using AutoMapper;
using Umbraco.Cms.Core.Models.Membership;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Infrastructure.Persistence.Dtos;
using Umbraco.Extensions;
using umbraco_clean_demo.Application.Interfaces;
using umbraco_clean_demo.Domain.Entities;
using umbraco_clean_demo.Domain.Entities.Kentico;
using umbraco_clean_demo.Domain.Interfaces;
using umbraco_clean_demo.Infrastructure.Utilities;
using System.IO;
using Umbraco.Cms.Core.Models;
using System;
using Umbraco.Cms.Core.Persistence;

namespace umbraco_clean_demo.Application.Services;
public class MediasService(IMediasRepository<Attachment> _attachmentrepository, IMediaService _mediaService, IMapper _mapper): IMediasService
{
    public async Task<Response<string>> MigrateMedia(MigrateModel model)
    {
        var response = new Response<string>();
        var list = await _attachmentrepository.GetAllAsync(Constants.K_Table.Attachment, model);

        foreach (var attachment in list)
        {

            //// ตรวจสอบว่ามีโฟลเดอร์อยู่แล้วหรือยัง ถ้ายังไม่มี ให้สร้างใหม่
            //var folder = _mediaService.GetRootMedia().FirstOrDefault(m => m.Name.Equals(folderName, StringComparison.OrdinalIgnoreCase));
            //if (folder == null)
            //{
            //    folder = _mediaService.CreateMedia(folderName, -1, "Folder");
            //    _mediaService.Save(folder);
            //}

            // Read data from Kentico
            var attachmentId = attachment.AttachmentID;
            var attachmentName = attachment.AttachmentName;
            var attachmentExtension = attachment.AttachmentExtension;
            var attachmentSize = attachment.AttachmentSize;
            //var attachmentBinary = attachment.AttachmentBinary
            //    ? null
            //    : (byte[])attachment.AttachmentBinary;
            //var attachmentGuid = reader.GetGuid(reader.GetOrdinal("AttachmentGUID"));

            // Define media file path
            var fileName = $"{attachmentName}.{attachmentExtension}";
            //var filePath = Path.Combine(umbracoMediaRootPath, $"{attachmentGuid}", fileName);

            //// Ensure the media folder exists
            //var mediaFolderPath = Path.GetDirectoryName(filePath);
            //if (!Directory.Exists(mediaFolderPath))
            //{
            //    Directory.CreateDirectory(mediaFolderPath);
            //}

            // Save the binary data to the media folder
            //if (attachmentBinary != null)
            //{
            //    File.WriteAllBytes(filePath, attachmentBinary);
            //}

            // Create Media Item in Umbraco
            var media = _mediaService.CreateMedia(attachmentName, -1, "Image");
            media.SetValue("umbracoFile", $"/media/111/{fileName}");
            media.SetValue("umbracoBytes", attachmentSize);
            media.SetValue("umbracoExtension", attachmentExtension);

            // Save media to Umbraco
            _mediaService.Save(media);

        }

        //string filePath=""; string fileName=""; string mediaFolder = "";
        //if (!File.Exists(filePath))
        //    throw new FileNotFoundException($"File not found at {filePath}");

        //// Read file content
        //byte[] fileBytes = File.ReadAllBytes(filePath);
        //using (var stream = new MemoryStream(fileBytes))
        //{
        //    // Create a media item in Umbraco
        //    var media = _mediaService.CreateMedia(fileName, -1, "Image");

        //    // Set the media file
        //    media.SetValue("umbracoFile", fileName, stream);

        //    // Save the media item
        //    _mediaService.Save(media);
        //}



        return response;
    }

}