
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Drawing.Imaging;
using System.Linq;
using LazZiya.ImageResize;



namespace Core.Tools
{
   public static class FileTools
    {


        public static string GetFileName(IFormFile FileAttach)
        {
            Guid g = Guid.NewGuid();
            var extention = Path.GetExtension(FileAttach.FileName);
            var fileData = FileAttach.FileName.Split('.');
            string FileName = $"{fileData[0]}_{g.ToString("N").Substring(0, 16)}"+extention;
            return FileName;
        }
        public static string UploadFile(IFormFile FileAttach, string FileName,string FolderName)
        {
            try
            {
                var p = Directory.GetCurrentDirectory() + "/wwwroot/FileUpload/" + FolderName;
                if (!Directory.Exists(p))
                {
                    Directory.CreateDirectory(p);
                }
               
                string path  =p+"/"+FileName;
                using (var stream=new  FileStream(path,FileMode.Create))
                {
                    FileAttach.CopyTo(stream);
                }
                return "/FileUpload/" + FolderName + "/" + FileName;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
          
        }
        public static bool DeleteFile( string Path)
        {
            try
            {
                var p = Directory.GetCurrentDirectory() + "/wwwroot/"+Path;
                if (File.Exists(p))
                {
                    File.Delete(p);
                }

              
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }


        public static void Image_resize(string input_Image_Path, string output_Image_Path, int new_Width)
        {

         

            using(var img = Image.FromFile(Directory.GetCurrentDirectory() + "/wwwroot/" + input_Image_Path))
            {
                img.Scale(150,150)
                    .SaveAs(Directory.GetCurrentDirectory() + "/wwwroot/" + output_Image_Path);
            }
        


          

      

        }

    }
}