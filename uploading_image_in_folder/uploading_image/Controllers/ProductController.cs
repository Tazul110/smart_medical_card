
using Microsoft.AspNetCore.Mvc;
using uploading_image.models;

namespace uploading_image.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPut("UploadImage")]
        public async Task<IActionResult> UploadImage(IFormFile formFile, string productcode)
        {
            APIResponseFormat response = new ApiResponse();
            try
            {
                string Filepath = GetFilepath(productcode);
                if (!System.IO.Directory.Exists(Filepath))
                {
                    System.IO.Directory.CreateDirectory(Filepath);
                }
                string imagepath = Filepath + "\\" + productcode + ".png";
                if (System.IO.File.Exists(imagepath))
                {
                    System.IO.File.Delete(imagepath);
                }

                // Create a FileStream to write the uploaded file content to the new file
                using (FileStream stream = System.IO.File.Create(imagepath))
                {
                    // Copy the contents of the uploaded file to the newly created file
                   // await stream.CopyToAsync(stream);      //this line make error.like white page after link visite.
                    await formFile.CopyToAsync(stream);
                    response.ResponseCode = 200;
                    response.Result = "pass";
                }
            }
            catch (Exception ex)
            {
                response.Errormessage = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet("GetImage")]
        public async Task<IActionResult> GetImage(string productcode)
        {
            string Imageurl = string.Empty;
            string hosturl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            try
            {
                string Filepath = GetFilepath(productcode);
                string imagepath = Filepath + "\\" + productcode + ".png";
                if (System.IO.File.Exists(imagepath))
                {
                    Imageurl = hosturl + "/upload/product/" + productcode + "/" + productcode + ".png"; // Added a slash before "Upload"
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
            }
            return Ok(Imageurl);
        }


        /* [HttpGet("GetImage")]
         public async Task<IActionResult> GetImage(string productcode)
         {
             string Imageurl=string.Empty;
             string hosturl=$"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
             try
             {
                 string Filepath = GetFilepath(productcode);
                 string imagepath = Filepath + "\\" + productcode + ".png";
                 if(System.IO.File.Exists(imagepath))
                 {
                     Imageurl = hosturl + "/Upload/product/" + productcode + "/" + productcode + ".png";
                 }
                 else
                 {
                     return NotFound();
                 }
             }
             catch (Exception ex)
             {

             }
             return Ok(Imageurl);
         }*/

        [NonAction]
        private string GetFilepath(string productcode)
        {
            return this._webHostEnvironment.WebRootPath + "\\Upload\\product\\" + productcode;
        }
    }
}
