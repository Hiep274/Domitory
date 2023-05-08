using Abp.Auditing;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using tmss.Dto;
using tmss.Storage;

namespace tmss.Web.Controllers
{
    public class FileController : tmssControllerBase
    {
        private readonly ITempFileCacheManager _tempFileCacheManager;

        public FileController(
            ITempFileCacheManager tempFileCacheManager
        )
        {
            _tempFileCacheManager = tempFileCacheManager;
        }

        [DisableAuditing]
        public ActionResult DownloadTempFile(FileDto file)
        {
            var fileBytes = _tempFileCacheManager.GetFile(file.FileToken);
            if (fileBytes == null)
            {
                return NotFound(L("RequestedFileDoesNotExists"));
            }

            return File(fileBytes, file.FileType, file.FileName);
        }

    }
}