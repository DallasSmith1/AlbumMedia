using FFmpeg.AutoGen;
using FFMpegCore;
using NReco.VideoConverter;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AlbumMedia.Classes
{
    public class Photo
    {
        /// <summary>
        /// create a photo object
        /// </summary>
        /// <param name="file"></param>
        /// <param name="dateTaken"></param>
        /// <param name="dateUploaded"></param>
        /// <param name="location"></param>
        /// <param name="keywords"></param>
        /// <param name="subject"></param>
        /// <param name="user"></param>
        public Photo(string file, DateTime dateTaken, DateTime dateUploaded, string location, string keywords, string subject, string user, bool isPublic) 
        {
            this.file = file;
            this.dateTaken = dateTaken;
            this.dateUploaded = dateUploaded;
            this.location = location;
            this.keywords = keywords;
            this.subject = subject;
            this.user = user;
            this.isPublic = isPublic;
        }

        public static BitmapImage bitMap;
        public static Uri uri;
        public string file;
        public DateTime dateTaken;
        public DateTime dateUploaded;
        public string location;
        public string keywords;
        public string subject;
        public string user;
        public bool isPublic;
        private Stream mediaStream;
        static public List<string> imageExtensions = new List<string>()
        {
            "jpg", "png", "jpeg", "img", "IMG", "PNG", "JPG"
        };
        static public List<string> videoExtensions = new List<string>()
        {
            "mp4", "MOV", "webm", "MP4"
        };

        /// <summary>
        /// get bitmapimage of the file
        /// </summary>
        /// <returns></returns>
        public BitmapImage GetBitMap()
        {
            try
            {
                /*
                DisposeMediaStream();

                var bitmap = new BitmapImage();
                mediaStream = new FileStream(Properties.Settings.Default.SHAREDFOLDER + "\\Users\\" + user + "\\" + file, FileMode.Open);

                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.None;
                bitmap.StreamSource = mediaStream;
                bitmap.EndInit();

                bitmap.Freeze();
                return bitmap;
                */
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
                bitMap = new BitmapImage(new Uri(Properties.Settings.Default.SHAREDFOLDER + "\\Users\\" + user + "\\" + file, UriKind.Absolute));
            }
            catch
            {
                throw new CorruptFileException();
                /*
                if (File.Exists(Properties.Settings.Default.TEMPORARYFOLDER + file.Split('.').First() + "_ABThumbnail.jpg"))
                {
                    bitMap = new BitmapImage(new Uri(Properties.Settings.Default.TEMPORARYFOLDER + file.Split('.').First() + "_ABThumbnail.jpg", UriKind.Relative));
                }
                else
                {
                    string FFMPEG = "..\\FFMPEG\\";

                    string inputFile = Properties.Settings.Default.SHAREDFOLDER + "\\Users\\" + user + "\\" + file;
                    string outputFile = Properties.Settings.Default.TEMPORARYFOLDER + file.Split('.').First() + "_ABThumbnail.jpg";

                    var startInfo = new ProcessStartInfo
                    {
                        FileName = FFMPEG + "ffmpeg.exe",
                        Arguments = $"-i " + inputFile + " -an -vf scale=500x500 " + outputFile + " -ss 00:00:00 -vframes 1",
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        WorkingDirectory = FFMPEG
                    };

                    using (var process = new Process { StartInfo = startInfo}) 
                    {
                        process.Start();
                        process.WaitForExit();
                    };

                    bitMap = new BitmapImage(new Uri(Properties.Settings.Default.TEMPORARYFOLDER + file.Split('.').First() + "_ABThumbnail.jpg", UriKind.Relative));
                }
                */
            }
            return bitMap;
        }

        /// <summary>
        /// get Uri from media file
        /// </summary>
        /// <returns></returns>
        public Uri GetUri()
        {
            try
            {
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
                uri = new Uri(Properties.Settings.Default.SHAREDFOLDER + "\\Users\\" + user + "\\" + file, UriKind.Absolute);
            }
            catch
            {
                throw new CorruptFileException();
            }
            return uri;
        }

        /// <summary>
        /// disposes media stream
        /// </summary>
        private void DisposeMediaStream()
        {
            if (mediaStream != null)
            {
                mediaStream.Close();
                mediaStream.Dispose();
                mediaStream = null;
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
            }
        }

        /// <summary>
        /// checks if the file has a valid file extension
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static bool IsValidImage(string file)
        {
            if (imageExtensions.Contains(file.Split('.').Last()))
            { 
                return true;
            }
            return false;
        }

        /// <summary>
        /// checks if its a valid video file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static bool IsValidVideo(string file)
        {
            if (videoExtensions.Contains(file.Split('.').Last()))
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// checks if its a valid file in general
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static bool IsValidFile(string file)
        {
            if (imageExtensions.Contains(file.Split('.').Last()) || videoExtensions.Contains(file.Split('.').Last()))
            {
                return true;
            }
            return false;
        }
    }
}
