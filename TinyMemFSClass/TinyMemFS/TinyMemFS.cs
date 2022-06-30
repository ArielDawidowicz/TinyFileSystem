using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.IO.Compression;

class TinyMemFS
{
     Dictionary<string, byte[]> dataByteArrDict; // Stores the content of the file in a dictionary of byte arrays [key = fileName, val= data in byteArray]
     Dictionary<string, int> encryptedTimes; // Stores the content of the file in a dictionary of byte arrays [key = fileName, val= data in byteArray]
     Dictionary<string, string[]> metaDataDict; // Stores the meta data of the file in a dictionart (Size, Creation date & time) [key = fileName, val = string array with the meta data]
     Dictionary<string, bool> hiddenInfoDict; // Sets if a file is hidden or not
     Mutex mutex;

    public TinyMemFS()
    {
        dataByteArrDict = new Dictionary<string, byte[]>();
        metaDataDict = new Dictionary<string, string[]>();
        encryptedTimes = new Dictionary<string, int>();
        hiddenInfoDict = new Dictionary<string, bool>();
        mutex = new Mutex(false);
    }

    // Add a new file fileName from path fileToAdd to the file system
    public bool add(String fileName, String fileToAdd)
    {
        mutex.WaitOne();
        if (!File.Exists(fileToAdd) || fileName == null || fileExist(fileName))
        {
            mutex.ReleaseMutex();
            return false;
        }

        using (FileStream fs = new FileStream(fileToAdd, FileMode.Open, FileAccess.Read))
        {
            // Adding the content of the file to dataByteArrDict
            byte[] data = new byte[fs.Length];
            fs.Read(data, 0, Convert.ToInt32(fs.Length));
            dataByteArrDict.Add(fileName, data);

            // Adding the meta data of the file to metaDataDict
            FileInfo fi = new FileInfo(fileToAdd);
            string creationTime = fi.CreationTime.ToString();
            string size = string.Format("{0}", fi.Length.ToString());
            string[] metaData = { creationTime, size };
            metaDataDict.Add(fileName, metaData);

            // Adding the file encrypted times data to encryptedTimes dictionary
            encryptedTimes.Add(fileName, 0);

            // Adding to hiddenDict the file
            hiddenInfoDict.Add(fileName, false);
        }
        mutex.ReleaseMutex();
        return true;
    }

    // Remove 'fileName' from file system if exist
    public bool remove(String fileName)
    {

        mutex.WaitOne();
        if (fileName == null || !metaDataDict.ContainsKey(fileName) || !dataByteArrDict.ContainsKey(fileName) || !encryptedTimes.ContainsKey(fileName) || !hiddenInfoDict.ContainsKey(fileName))
        {
            mutex.ReleaseMutex();
            return false;
        }
        // Removing the data of the file from both dictionaries
        metaDataDict.Remove(fileName);
        dataByteArrDict.Remove(fileName);
        encryptedTimes.Remove(fileName);
        hiddenInfoDict.Remove(fileName);
        mutex.ReleaseMutex();
        return true;
    }

    // Returns a list with the meta data of the files in file system
    public List<String> listFiles()
    {
        mutex.WaitOne();
        List<String> files = new List<string>();
        foreach (String fileName in metaDataDict.Keys)
        {
            if (hiddenInfoDict[fileName])
                continue;
            else
            {
                string file = string.Format("File name: {0}, Size: {1}kb, Creation date and time: {2}", fileName, metaDataDict[fileName][1], metaDataDict[fileName][0]);
                files.Add(file);
            }
            
        }
        mutex.ReleaseMutex();
        return files;
    }

    // Saves the file 'fileName' in 'fileToAdd' path if its in the file system 
    public bool save(String fileName, String fileToAdd)
    {
        mutex.WaitOne();
        if (fileName == null || !metaDataDict.ContainsKey(fileName) || !dataByteArrDict.ContainsKey(fileName) || !encryptedTimes.ContainsKey(fileName) || !hiddenInfoDict.ContainsKey(fileName))
        {
            mutex.ReleaseMutex();
            return false;
        }
        File.WriteAllBytes(fileToAdd, dataByteArrDict[fileName]);
        mutex.ReleaseMutex();
        return true;
    }

    // This function encrypts all the files in the file system according to the key 
    public bool encrypt(String key)
    {
        mutex.WaitOne();
        Dictionary<string, byte[]> tmpEncryptedDataByteArrDict = new Dictionary<string, byte[]>();   
        try
        {
            AesEncryptor encryptor = new AesEncryptor();

            foreach(string fileName in dataByteArrDict.Keys)
            {
                tmpEncryptedDataByteArrDict.Add(fileName, encryptor.Encrypt(dataByteArrDict[fileName], key));
            }
            
        }
        catch (Exception ex)
        {
            mutex.ReleaseMutex();
            return false;
        }
        dataByteArrDict = tmpEncryptedDataByteArrDict;
        foreach (string fileName in encryptedTimes.Keys)
        {
            encryptedTimes[fileName]++;
        }
        mutex.ReleaseMutex();
        return true;
    }

    // This function decrypts all the encrypted files in the file system according to the key.
    // if the key is wrong the files remain encrypted and the function returns false
    public bool decrypt(String key)
    {
        mutex.WaitOne();
        Dictionary<string, byte[]> tmpDecryptedDataByteArrDict = new Dictionary<string, byte[]>();
        try 
        {
            AesEncryptor encryptor = new AesEncryptor();
            foreach (string fileName in dataByteArrDict.Keys)
            {
                if (encryptedTimes[fileName] == 0)
                {
                    tmpDecryptedDataByteArrDict.Add(fileName, dataByteArrDict[fileName]);
                }
                else
                {
                    tmpDecryptedDataByteArrDict.Add(fileName, encryptor.Decrypt(dataByteArrDict[fileName], key));
                }
            }
        }catch (Exception ex)
        {
            mutex.ReleaseMutex();
            return false;
        }
        foreach (string fileName in encryptedTimes.Keys)
        {
            if (encryptedTimes[fileName] == 0)
                continue;
            else
            {
                encryptedTimes[fileName]--;
            }
            
        }
        dataByteArrDict = tmpDecryptedDataByteArrDict;
        mutex.ReleaseMutex();
        return true;
    }

    // This function saves 'fileName' as a data file that includes all the file system data 
    // if the file couldnt be saved return false
    public bool saveToDisk(String fileName)
    {
        mutex.WaitOne();
        try
        {
            string dir = @"C:\\" + fileName;
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            string path = dir + "\\metaData.txt";
            if (!File.Exists(path))
            {
                List<string> list = this.listFiles();
                using (StreamWriter sw = File.CreateText(path))
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        sw.WriteLine(list[i]);
                    }
                }
            }
            path = dir + "\\hiddenFiles.txt";
            if (!File.Exists(path))
            {
                string[] data;
                using (StreamWriter sw = File.CreateText(path))
                {
                    foreach (string file in hiddenInfoDict.Keys)
                    {
                        int n = hiddenInfoDict[file] == true ? 1 : 0;
                        sw.WriteLine(file + ":" + n.ToString());
                    }
                }
            }

            path = dir + "\\encryptedTimes.txt";
            if (!File.Exists(path))
            {
                string[] data;
                using (StreamWriter sw = File.CreateText(path))
                {
                    foreach (string file in encryptedTimes.Keys)
                    {
                        int n = encryptedTimes[file];
                        sw.WriteLine(file + ":" + n.ToString());
                    }
                }
            }
            foreach (string file in dataByteArrDict.Keys)
            {
                path = dir + "\\" + file;
                if (!File.Exists(path))
                {
                    File.WriteAllBytes(path, dataByteArrDict[file]);
                }
            }
            ZipFile.CreateFromDirectory(dir, fileName + ".DATA");

            Directory.Delete(dir, true);
            mutex.ReleaseMutex();
            return true;
        }catch (Exception ex)
        {
            mutex.ReleaseMutex();
            return false;
        }
        
    }


    // This function loads all the the data from 'filiName'
    // return false if the load failed
    public bool loadFromDisk(String fileName)
    {
        mutex.WaitOne();
        Dictionary<string, int> tmpEncryptedTimes = encryptedTimes;
        Dictionary<string, byte[]> tmpDataByte = dataByteArrDict;
        Dictionary<string, string[]> tmpMeta = metaDataDict;
        Dictionary<string, bool> tmpHidden = hiddenInfoDict;

        encryptedTimes = new Dictionary<string, int>();
        dataByteArrDict = new Dictionary<string, byte[]>();
        metaDataDict = new Dictionary<string, string[]>();
        hiddenInfoDict = new Dictionary<string, bool>();

        try
        {
            using (ZipArchive zip = ZipFile.OpenRead(fileName))
            {
                foreach (var file in zip.Entries)
                {
                    if (file.Name == "encryptedTimes.txt")
                    {
                        var stream = file.Open();
                        string data;
                        using (var ms = new StreamReader(stream))
                        {
                            data = ms.ReadToEnd();
                            string[] lines = data.Split("\r\n");
                            string name, size, creation;
                            for (int i = 0; i < lines.Length - 1; i++)
                            {
                                string[] splitedLine = lines[i].Split(":");
                                encryptedTimes.Add(splitedLine[0], Int32.Parse(splitedLine[1]));
                            }
                        }
                    }

                    else if (file.Name == "hiddenFiles.txt")
                    {
                        var stream = file.Open();
                        string data;
                        using (var ms = new StreamReader(stream))
                        {
                            data = ms.ReadToEnd();
                            string[] lines = data.Split("\r\n");
                            string name, size, creation;
                            for (int i = 0; i < lines.Length - 1; i++)
                            {
                                string[] splitedLine = lines[i].Split(":");
                                bool b = Int32.Parse(splitedLine[1]) == 1 ? true : false;
                                hiddenInfoDict.Add(splitedLine[0], b);
                            }
                        }

                    }
                    else if (file.Name == "metaData.txt")
                    {
                        var stream = file.Open();
                        string data;
                        using (var ms = new StreamReader(stream))
                        {
                            data = ms.ReadToEnd();
                            string[] lines = data.Split("\r\n");
                            string name, size, creation;
                            for (int i = 0; i < lines.Length - 1; i++)
                            {
                                string[] splitedLine = lines[i].Split(" ");
                                name = splitedLine[2].Remove(splitedLine[2].Length - 1);
                                size = splitedLine[4].Remove(splitedLine[4].Length - 3);
                                creation = splitedLine[9] + " " + splitedLine[10];
                                string[] metaData = { creation, size };
                                metaDataDict.Add(name, metaData);
                            }
                        }
                    }
                    else
                    {
                        var stream = file.Open();
                        byte[] data;
                        using (var ms = new MemoryStream())
                        {
                            stream.CopyTo(ms);
                            data = ms.ToArray();
                            dataByteArrDict.Add(file.Name, data);
                        }
                    }
                }
                mutex.ReleaseMutex();
                return true;
            }
            
        }catch (Exception ex)
        {
            encryptedTimes = tmpEncryptedTimes;
            dataByteArrDict = tmpDataByte;
            metaDataDict = tmpMeta;
            hiddenInfoDict = tmpHidden;
            mutex.ReleaseMutex();
            return false;
        }
        
    }


    //Not implemented
    public bool compressFile(String fileName)
    {
        return false;
    }

    //Not implemented
    public bool uncompressFile(String fileName)
    {
        return false;
    }


    // Sets fileName to hidden and wont appear in listFile()
    // if fileName doesnt exist in the file system reutrn false
    public bool setHidden(String fileName, bool hidden)
    {
        mutex.WaitOne();
        if (fileName == null)
        {
            mutex.ReleaseMutex();
            return false;
        }
        if (!metaDataDict.ContainsKey(fileName) || !dataByteArrDict.ContainsKey(fileName) || !encryptedTimes.ContainsKey(fileName) || !hiddenInfoDict.ContainsKey(fileName))
        {
            mutex.ReleaseMutex();
            return false;
        }
        hiddenInfoDict[fileName] = hidden;
        mutex.ReleaseMutex();
        return true;
    }

    // Renames the fileName to newFileName if fileName exist in the file system
    // If fileName doesnt exist or newFileName already exist return false
    public bool rename(String fileName, String newFileName)
    {
        mutex.WaitOne();
        if (fileName == null || newFileName == null)
        {
            mutex.ReleaseMutex();
            return false;
        }

        if (!metaDataDict.ContainsKey(fileName) || !dataByteArrDict.ContainsKey(fileName) || !encryptedTimes.ContainsKey(fileName) || !hiddenInfoDict.ContainsKey(fileName))
        {
            mutex.ReleaseMutex();
            return false;
        }
        if (metaDataDict.ContainsKey(newFileName) || dataByteArrDict.ContainsKey(newFileName) || encryptedTimes.ContainsKey(newFileName) || hiddenInfoDict.ContainsKey(newFileName))
        {
            mutex.ReleaseMutex();
            return false;
        }
        string[] tmpMetaData = metaDataDict[fileName];
        byte[] tmpData = dataByteArrDict[fileName];
        int tmpTimes = encryptedTimes[fileName];
        bool tmpHidden = hiddenInfoDict[fileName];
        metaDataDict.Remove(fileName);
        dataByteArrDict.Remove(fileName);
        encryptedTimes.Remove(fileName);
        hiddenInfoDict.Remove(fileName);
        metaDataDict.Add(newFileName, tmpMetaData);
        encryptedTimes.Add(newFileName, tmpTimes);
        dataByteArrDict.Add(newFileName, tmpData);
        hiddenInfoDict.Add(newFileName, tmpHidden);
        mutex.ReleaseMutex();
        return true;
    }

    // Copy the content,size and creation date of fileName1 to a new fileName2 file
    // if fileName1 doesnt exist in the file system or filename2 already exists return false
    public bool copy(String fileName1, String fileName2)
    {
        mutex.WaitOne();
        if (fileName1 == null || fileName2 == fileName1)
        {
            mutex.ReleaseMutex();
            return false;
        }
        if (!metaDataDict.ContainsKey(fileName1) || !dataByteArrDict.ContainsKey(fileName1) || !encryptedTimes.ContainsKey(fileName1) || !hiddenInfoDict.ContainsKey(fileName1))
        {
            mutex.ReleaseMutex();
            return false;
        }
        if (metaDataDict.ContainsKey(fileName2) || dataByteArrDict.ContainsKey(fileName2) || encryptedTimes.ContainsKey(fileName2) || hiddenInfoDict.ContainsKey(fileName2))
        {
            mutex.ReleaseMutex();
            return false;
        }
        metaDataDict.Add(fileName2, metaDataDict[fileName1]);
        dataByteArrDict.Add(fileName2, dataByteArrDict[fileName1]);
        encryptedTimes.Add(fileName2, encryptedTimes[fileName1]);
        hiddenInfoDict.Add(fileName2, hiddenInfoDict[fileName1]);
        mutex.ReleaseMutex();
        return true;
    }


    // This function sorts all the files in alphabetical order
    // All the dictionaries get sorted
    public void sortByName()
    {
        mutex.WaitOne();
        Dictionary<string, string[]> tmpMeta = new Dictionary<string, string[]>();
        Dictionary<string, byte[]> tmpData = new Dictionary<string, byte[]>();
        Dictionary<string, int> tmpEcryptedTimes = new Dictionary<string, int>();
        Dictionary<string, bool> tmpHidden = new Dictionary<string, bool>();

        foreach (KeyValuePair<string, string[]> k in metaDataDict.OrderBy(key => key.Key))
        {
            tmpMeta.Add(k.Key, k.Value);
            tmpData.Add(k.Key, dataByteArrDict[k.Key]);
            tmpEcryptedTimes.Add(k.Key, encryptedTimes[k.Key]);
            tmpHidden.Add(k.Key, hiddenInfoDict[k.Key]);
        }
        metaDataDict = tmpMeta;
        dataByteArrDict = tmpData;
        encryptedTimes = tmpEcryptedTimes;
        hiddenInfoDict = tmpHidden;
        mutex.ReleaseMutex();
    }

    // This function sorts all the files from new to old
    // All the dictionaries get sorted
    public void sortByDate()
    {
        mutex.WaitOne();
        Dictionary<string, string[]> tmpMeta = new Dictionary<string, string[]>();
        Dictionary<string, byte[]> tmpData = new Dictionary<string, byte[]>();
        Dictionary<string, int> tmpEcryptedTimes = new Dictionary<string, int>();
        Dictionary<string, bool> tmpHidden = new Dictionary<string, bool>();

        foreach (KeyValuePair<string, string[]> k in metaDataDict.OrderBy(key => key.Value[0]))
        {
            tmpMeta.Add(k.Key, k.Value);
            tmpData.Add(k.Key, dataByteArrDict[k.Key]);
            tmpEcryptedTimes.Add(k.Key, encryptedTimes[k.Key]);
            tmpHidden.Add(k.Key, hiddenInfoDict[k.Key]);
        }
        metaDataDict = tmpMeta;
        dataByteArrDict = tmpData;
        encryptedTimes = tmpEcryptedTimes;
        hiddenInfoDict = tmpHidden;
        mutex.ReleaseMutex();
    }

    // This function sorts all the files from high to low by size
    // All the dictionaries get sorted
    public void sortBySize()
    {
        mutex.WaitOne();
        Dictionary<string, string[]> tmpMeta = new Dictionary<string, string[]>();
        Dictionary<string, byte[]> tmpData = new Dictionary<string, byte[]>();
        Dictionary<string,int> tmpEcryptedTimes = new Dictionary<string, int>();
        Dictionary<string, bool> tmpHidden = new Dictionary<string, bool>();

        foreach (KeyValuePair<string, string[]> k in metaDataDict.OrderByDescending(key => Int64.Parse(key.Value[1]))){
            tmpMeta.Add(k.Key, k.Value);
            tmpData.Add(k.Key, dataByteArrDict[k.Key]);
            tmpEcryptedTimes.Add(k.Key, encryptedTimes[k.Key]);
            tmpHidden.Add(k.Key, hiddenInfoDict[k.Key]);
        }
        metaDataDict = tmpMeta;
        dataByteArrDict = tmpData;
        encryptedTimes = tmpEcryptedTimes;
        hiddenInfoDict = tmpHidden;
        mutex.ReleaseMutex();
    }


    // Returns true if the content of data of fileName1 and fileName2 are the same
    // otherwise returns false
    public bool compare(String fileName1, String fileName2)
    {
        mutex.WaitOne();
        if (fileName1 == null || fileName2 == null)
        {
            mutex.ReleaseMutex();
            return false;
        }
        if (!dataByteArrDict.ContainsKey(fileName1) || !dataByteArrDict.ContainsKey(fileName2))
        {
            mutex.ReleaseMutex();
            return false;
        }
        mutex.ReleaseMutex();
        return (dataByteArrDict[fileName1] == dataByteArrDict[fileName2]);
    }

    // return the size of all files in the FS (sum of all sizes)
    public Int64 getSize()
    {
        mutex.WaitOne();
        Int64 size = 0;
        foreach (string fileName in metaDataDict.Keys)
        {
            size += Int64.Parse(metaDataDict[fileName][1]);
        }
        mutex.ReleaseMutex();
        return size;
    }

    public bool fileExist(string file)
    {
        return dataByteArrDict.ContainsKey((string)file);
    }


    public class AesEncryptor
    {
        public byte[] Encrypt(byte[] data, string key)
        {
            byte[] tmpKey = Encoding.UTF8.GetBytes(key);
            byte[] keyInbyteArr = new byte[32];
            tmpKey.CopyTo(keyInbyteArr, 0);

            using (var aes = Aes.Create())
            {
                aes.KeySize = 256;
                aes.BlockSize = 128;
                aes.Key = keyInbyteArr;
                aes.IV = new byte[16] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                {
                    return PerformCryptography(data, encryptor);
                }
            }
        }

        public byte[] Decrypt(byte[] data, string key)
        {

            byte[] tmpKey = Encoding.UTF8.GetBytes(key);
            byte[] keyInbyteArr = new byte[32];
            tmpKey.CopyTo(keyInbyteArr, 0);

            using (var aes = Aes.Create())
            {
                aes.KeySize = 256;
                aes.BlockSize = 128;

                aes.Key = keyInbyteArr;
                aes.IV = new byte[16] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

                using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                {
                    return PerformCryptography(data, decryptor);
                }
            }
        }

        private byte[] PerformCryptography(byte[] data, ICryptoTransform cryptoTransform)
        {
            using (var ms = new MemoryStream())
            using (var cryptoStream = new CryptoStream(ms, cryptoTransform, CryptoStreamMode.Write))
            {
                cryptoStream.Write(data, 0, data.Length);
                cryptoStream.FlushFinalBlock();
                return ms.ToArray();
            }
        }
    }

}
