using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace WebProject.Controllers.Trial
{
    public class ImageController : ApiController
    {
        [HttpPost]
        [Route("api/Image/UploadImage")]
        public async Task<string> UploadImage()
        {
            var ctx = HttpContext.Current;
            var root = ctx.Server.MapPath("~/App_Data");

            var Provider =
                new MultipartFormDataStreamProvider(root);

           

            try
            {
               await Request.Content.ReadAsMultipartAsync(Provider);

                foreach(var file in Provider.FileData)
                {
                    var name = file.Headers
                        .ContentDisposition
                        .FileName;
                    name = name.Trim('"');
                    var LocalFileName = file.LocalFileName;
                    var filepath = Path.Combine(root, name);
                    File.Move(LocalFileName, filepath);
                }
            }
            catch(Exception e)
            {
                return $"error: { e.Message}";
            }

            return "File Uploaded";
        }
    }
}
