using System;
using System.IO;

namespace Driver___Vehicle_Licenses_Department__DVLD_.Global_Classes
{
    public class Util
    {

        public static string GenerateGuid()
        {
           
            Guid Guidd = Guid.NewGuid();

          

            return Guidd.ToString();
        }

        public static string ReplaceFileNameWithGuid(string SourceFilePath)
        {
            //string FileName = Path.GetExtension(SourceFilePath);

            string FileName = SourceFilePath;
            FileInfo File = new FileInfo(FileName);
            string Extenstion = File.Extension;

            string FileNameWithGuid = GenerateGuid() + Extenstion;

            return FileNameWithGuid;
        }

        public static bool CreateFolderIfNotExists(string FolderPath)
        {
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    Directory.CreateDirectory(FolderPath);
                    return true;

                }catch(Exception Ex)
                {
                    return false;
                }

            }

            return true;

        }

        public static bool CopyImageToProjectImagesFolder(ref string SourceFile)
        {
            string DestinationFolder = @"D:\Programming\Mohamed-Abu-Hadhud\Desktop Projects\DVLD\Driver & Vehicle Licenses Department (DVLD)\ImagesSavedInDatabase\";
            if (!CreateFolderIfNotExists(DestinationFolder))
                return false;

            string DestinationFile = DestinationFolder + ReplaceFileNameWithGuid(SourceFile);
            try
            {
                File.Copy(SourceFile, DestinationFile, true);
            }
            catch (IOException Ex)
            {
                return false;
            }

            SourceFile = DestinationFile;
            return true;
        }

    }
}
