namespace MusicSync.Common.Interfaces
{
	public interface ILibraryImageRepository
  {
    /// <summary>
    /// Retrieves and saves library item images to the repository.
    /// </summary>
    /// <param name="songs"></param>
    void SaveLibraryImages(ILibraryRepository repository);
  }
}
