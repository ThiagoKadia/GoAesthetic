using GoAestheticComuns.Constantes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoAetheticApi.Controllers
{
    [Route("v1/api/taco-download")]
    [ApiController]
    [Authorize(Roles = Roles.Sistema)]
    public class DownloadController : ControllerBase
    {
        [HttpGet]
        public ActionResult TacoTableDownload()
        {
            const string archiveType = @"application/pdf";
            const string path = @"TabelaTaco.pdf";
            const string downloadArchiveName = "GoAesthetic_TabelaTaco.pdf";

            var fullPath = Path.GetFullPath(path);

            var stream = new FileStream(fullPath, FileMode.Open);

            return File(stream, archiveType, downloadArchiveName);
        }
    }
}