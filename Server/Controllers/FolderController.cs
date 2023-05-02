using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreadCommunityWeb.Blz.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolderController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        public FolderController(IWebHostEnvironment env)
        {
            _env = env;
        }

        /// <summary>
        /// Создать папку
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(CreateFolder))]
        public async Task<ActionResult> CreateFolder(string folderName)
        {
            var path = $"{_env.WebRootPath}\\{folderName}";
            return Ok();
        }

        /// <summary>
        /// Сохранить файл
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(SaveFile))]
        public async Task<ActionResult> SaveFile(byte[] bytes, string fileName)
        {

            return Ok();
        }

        /// <summary>
        /// Удалить файл
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(DeleteFile))]
        public async Task<ActionResult> DeleteFile(string folderName, string fileName)
        {

            return Ok();
        }
    }
}
