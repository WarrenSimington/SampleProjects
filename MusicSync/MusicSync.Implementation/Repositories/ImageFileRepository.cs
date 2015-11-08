using log4net;
using MusicSync.Common.Interfaces;
using MusicSync.Common.Library;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace MusicSync.Implementation.Repositories
{
  public class ImageFileRepository : ILibraryImageRepository
  {
    #region Constructors
    public ImageFileRepository()
      : this(string.Empty)
    {
    }

    public ImageFileRepository(string targetImageDirPath)
    {
      if (string.IsNullOrEmpty(targetImageDirPath))
      {
        //Grab the target image directory path from a config file (in the AppSettings section)
        const string CONFIG_KEY_LIBRARY_IMAGE_DIRECTORY = "LibraryImageDirectory";
        string imageDirPath = ConfigurationManager.AppSettings[CONFIG_KEY_LIBRARY_IMAGE_DIRECTORY];

        _targetImageDirPath = imageDirPath;
      }
      else
        _targetImageDirPath = targetImageDirPath;

      //Check to see if the target directory exists. If not, try to create it.
      if (!Directory.Exists(_targetImageDirPath))
        Directory.CreateDirectory(_targetImageDirPath);
    } 
    #endregion

    #region Private Members
    private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    private string _targetImageDirPath; 
    #endregion

    #region ILibraryImageRepository implementation
    /// <summary>
    /// Saves album cover art images to a target destination directory.
    /// This method also sets file attributes to normal (removes hidden & system attributes).
    /// </summary>
    /// <param name="songs"></param>
    public void SaveLibraryImages(ILibraryRepository repository)
    {
      _log.Debug("Saving library album cover images...");

      //Image filename format
			//AlbumArt_{C8C1D82E-2891-4008-A00C-0264635F01A6}_Large.jpg
      
      FileAttributes destFileAttributes = FileAttributes.Normal;
      foreach (AlbumCoverData albumCoverData in repository.GetAlbumCoverData())
      {
        //Build the path to the source image
        string sourceFileName = string.Format("AlbumArt_{0}_Large.jpg", albumCoverData.WmCollectionId);
        string sourceImagePath = Path.Combine(albumCoverData.Directory, sourceFileName);

        //Build destination image file path
        string destImagePath = Path.Combine(_targetImageDirPath, Path.ChangeExtension(albumCoverData.Id, ".jpg"));

        //Check to see if the source file exists
        if (!File.Exists(sourceImagePath))
        {
          //Check to see if any alternate filenames exist before we log and give up on this album
          sourceImagePath = Path.Combine(albumCoverData.Directory, "AlbumArtSmall.jpg");

          if (!File.Exists(sourceImagePath))
          {
            //We still didn't find the album using the default image, so log it and continue to the next album
            _log.Warn(string.Format("No album image found for {0}.", albumCoverData.Title));
          }
        }
        
        //Copy the file
        File.Copy(sourceImagePath, destImagePath, true);

        //Set the file attributes
        File.SetAttributes(destImagePath, destFileAttributes);
      }

      _log.Debug("Library album cover images saved.");
    }
    #endregion
  }
}
