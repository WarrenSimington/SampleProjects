using System;
using System.IO;
using System.Security.Cryptography;

namespace Wes.Crypto
{
  public class Rijndael
  {
    #region Constructors
    public Rijndael(byte[] key, byte[] iv)
    {
      //Make sure that the key byte arrays have been instantiated
      if (key == null)
        throw new ArgumentException("No key provided.");

      if (iv == null)
        throw new ArgumentException("No initialization vector provided.");
      
      //Create the internal Rijndael object
      _rijndael = new RijndaelManaged()
      {
        Key = key,
        IV = iv
      };
    } 
    #endregion

    #region Private Members
    private RijndaelManaged _rijndael;
    #endregion

    #region Private Methods
    private void Decrypt(byte[] sourceBytes, out string result)
    {
      ICryptoTransform decryptor = _rijndael.CreateDecryptor();

      using (MemoryStream sourceStream = new MemoryStream(sourceBytes))
      using (CryptoStream cryptoStream = new CryptoStream(sourceStream, decryptor, CryptoStreamMode.Read))
      using (StreamReader cryptoReader = new StreamReader(cryptoStream))
      {
        result = cryptoReader.ReadToEnd();
      }
    }

    private void Encrypt(string sourceString, out byte[] result)
    {
      ICryptoTransform encryptor = _rijndael.CreateEncryptor();

      using (MemoryStream outputStream = new MemoryStream())
      using (CryptoStream cryptoStream = new CryptoStream(outputStream, encryptor, CryptoStreamMode.Write))
      {
        using (StreamWriter cryptoWriter = new StreamWriter(cryptoStream))
        {
          cryptoWriter.Write(sourceString);
        }

        result = outputStream.ToArray();
      }
    }
    #endregion
    
    #region Public Methods
    public string Decrypt(string sourceString)
    {
      //Convert the input param to bytes
      byte[] sourceBytes = Convert.FromBase64String(sourceString);
      
      string result;
      Decrypt(sourceBytes, out result);

      return result;
    }
    
    public string Encrypt(string sourceString)
    {
      byte[] encryptedBytes;
      Encrypt(sourceString, out encryptedBytes);

      return Convert.ToBase64String(encryptedBytes);
    }
    #endregion
  }
}
