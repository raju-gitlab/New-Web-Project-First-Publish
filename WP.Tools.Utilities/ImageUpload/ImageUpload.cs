using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WP.Tools.Utilities.ImageUpload
{
    public class ImageUpload
    {
        public static string Upload(HttpPostedFileBase postedFile)
        {
            string ImageName = Guid.NewGuid().ToString().Replace("-", string.Empty).ToLower();
            string Name = Path.GetFileName(postedFile.FileName);
            string path = HttpContext.Current.Server.MapPath("~/App_Data");
            string FIleName = string.Concat(path, ImageName);
            postedFile.SaveAs(FIleName);
            return FIleName;
            
        }
    }
}
