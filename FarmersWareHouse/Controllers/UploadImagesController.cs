using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmersWareHouse.Controllers
{
    public class UploadImagesController : Controller
    {
        public  CADPEntities db = new CADPEntities();
        // GET: UploadImages
        public ActionResult Index()
        {
            ViewBag.StateID =new  SelectList(db.tbl_LK_State,"stateID","stateName");
            ViewBag.SubComponentID = new SelectList(db.tbl_LK_ME_SubComponent, "SubComponentID", "SubComponentName");

            return View();
        }

        [HttpPost]
        public ActionResult Index(ArtWork  artwork, HttpPostedFileBase image)  //public ActionResult Index(ArtWork artwork, HttpPostedFileBase image)
        {

            if (Request.Files["image"].ContentLength > 0)
            {
                artwork.ImageMimeType = image.ContentLength;

            }
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    //attach the uploaded image to the object before saving to Database
                    artwork.ImageMimeType = image.ContentLength;
                    artwork.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(artwork.ImageData, 0, image.ContentLength);

                    //Save image to file
                    var filename = image.FileName;
                    var filePathOriginal = Server.MapPath("/Content/Uploads/Originals");
                    var filePathThumbnail = Server.MapPath("/Content/Uploads/Thumbnails");
                    string savedFileName = Path.Combine(filePathOriginal, filename);
                    image.SaveAs(savedFileName);

                    artwork.FileName = savedFileName;  // save the filename
                    //Read image back from file and create thumbnail from it
                    var imageFile = Path.Combine(Server.MapPath("~/Content/Uploads/Originals"), filename);
                    using (var srcImage = Image.FromFile(imageFile))
                    using (var newImage = new Bitmap(100, 100))
                    using (var graphics = Graphics.FromImage(newImage))
                    using (var stream = new MemoryStream())
                    {
                        graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        graphics.DrawImage(srcImage, new Rectangle(0, 0, 100, 100));
                        newImage.Save(stream, ImageFormat.Png);
                        var thumbNew = File(stream.ToArray(), "image/png");
                        artwork.ArtworkThumbnail = thumbNew.FileContents;
                    }
                    //  Save model object to database
                    db.ArtWorks.Add(artwork);
                    db.SaveChanges();
                }

            

                return RedirectToAction("Index");
            }


            return View();
        }

        public FileContentResult GetThumbnailImage(int fileID)
        {
            ArtWork art = db.ArtWorks.FirstOrDefault(p => p.fileID  == fileID);
            if (art != null)
            {
                return File(art.ArtworkThumbnail, art.ImageMimeType.ToString());
            }
            else
            {
                return null;
            }
        }
    }
}
