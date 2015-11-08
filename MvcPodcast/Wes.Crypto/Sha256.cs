using System;
using System.IO;
using System.Security.Cryptography;

namespace Wes.Crypto
{
  public static class Sha256
  {
    #region Public Methods
    public static byte[] GetHashBytes(byte[] sourceData)
    {
      SHA256Managed sha256 = new SHA256Managed();
      return sha256.ComputeHash(sourceData);
    }

    public static byte[] GetHashBytes(string filePath)
    {
      using (FileStream sourceFile = new FileStream(filePath, FileMode.Open, FileAccess.Read))
      using (BinaryReader reader = new BinaryReader(sourceFile))
      {
        byte[] fileData = reader.ReadBytes((int)sourceFile.Length);
        return GetHashBytes(fileData);
      }
    }

    public static string GetHashBase64String(byte[] sourceData)
    {
      byte[] resultBytes = GetHashBytes(sourceData);
      return Convert.ToBase64String(resultBytes);
    }

    public static string GetHashBase64String(string filePath)
    {
      byte[] resultBytes = GetHashBytes(filePath);
      return Convert.ToBase64String(resultBytes);
    }
    #endregion
  }
}
