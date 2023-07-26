## TinyMemFS - Thread-Safe In-Memory File System for C#

TinyMemFS is a C# project that implements a thread-safe file system capable of storing the content and meta data of multiple files entirely in memory. The core idea is to represent the file content as byte arrays and manage them within a dictionary, enabling efficient in-memory file storage. The system offers a wide range of functionalities, such as adding, removing, copying, renaming, comparing, encrypting, decrypting, and exporting files. It also supports hiding files and sorting the data based on various criteria.

### Features

- **Thread Safety:** TinyMemFS ensures that concurrent operations do not interfere with each other, providing a robust and secure environment for file manipulation.

- **File Encryption:** Utilizing the AES class from the System.Security.Cryptography package, the system encrypts and decrypts files using a user-provided key. Multiple encryption passes are supported, requiring all encryption keys to be present for successful decryption.

- **Meta Data Storage:** Each file's meta data, including size (in kilobytes) and creation time and date, is maintained within the file system.

- **Hidden Files:** The system allows files to be hidden, making them invisible in file lists.

- **Sorting Options:** The system supports sorting files by name, creation date, and size (in kilobytes).

### Properties

- `Dictionary<string, byte[]> dataByteArrDict`: A dictionary storing file content as byte arrays. (Key = file name, Value = content of file as byte[]).

- `Dictionary<string, string[]> metaDataDict`: A dictionary storing meta data for each file. (Key = file name, Value = {size, creation information}).

- `Dictionary<string, int> encryptedTimes`: A dictionary tracking the number of times each file has been encrypted. (Key = file name, Value = times encrypted).

- `Dictionary<string, bool> hiddenInfoDict`: A dictionary indicating whether each file is 'hidden' or not. (Key = file name, Value = true/false).

- `Mutex`: A mutex ensuring thread safety during file system operations.

### Methods

- `public bool Add(string fileName, string fileToAdd)`: Adds the content and meta data of the specified file to the system. Returns true if the addition is successful.

- `public bool Remove(string fileName)`: Removes the content and meta data of the specified file from the system. Returns true if the removal is successful.

- `public List<string> ListFiles()`: Returns a list of all files stored in the system, formatted as "Name: filename, Size: 100kb, Creation date and time: 1-1-2001 14:21:59."

- `public bool Save(string fileName, string fileToAdd)`: Stores the specified file from the provided path as 'fileName'. Returns true if the file is successfully saved.

- `public bool Encrypt(string key)`: Encrypts all files in the system using the given key. Returns true if encryption is successful, else false.

- `public bool Decrypt(string key)`: Decrypts all files in the system if the provided key matches the one used for encryption. Returns false if the key is incorrect.

- `public bool SaveToDisk(string fileName)`: Saves all data in the system as a single ".DATA" file (in ZIP format) for later retrieval.

- `public bool LoadFromDisk(string fileName)`: Loads file information from the data file and returns true if successful.

- `public bool SetHidden(string fileName, bool hidden)`: Sets the specified file as hidden or unhidden according to the 'hidden' parameter, updating the hiddenInfoDict.

- `public bool Rename(string fileName, string newFileName)`: Renames the specified file to 'newFileName' if 'fileName' exists and 'newFileName' is not already in the system. Returns true on success, otherwise false.

- `public bool Copy(string fileName1, string fileName2)`: Copies the content and meta data of 'fileName1' to 'fileName2' if 'fileName2' does not exist in the system. Returns true if the copy is successful.

- `public void SortByName()`: Sorts all files in the system in alphabetical order.

- `public void SortByDate()`: Sorts all files in the system based on creation date and time.

- `public void SortBySize()`: Sorts all files in the system based on size (in kilobytes) in descending order.

- `public bool Compare(string fileName1, string fileName2)`: Compares the content of 'fileName1' and 'fileName2' if both files exist in the system.

- `public Int64 GetSize()`: Returns the total size of all files in the system in kilobytes.

### TinyMemFS GUI

A user-friendly GUI has been developed using Windows Forms, providing easy access to the TinyMemFS functionalities. For a visual representation, please refer to the following link: [Image Link](your_image_link_here)

Please feel free to explore and use TinyMemFS to manage and manipulate in-memory files securely and efficiently. 

![TinyMemFSGUI](https://user-images.githubusercontent.com/101277239/176740023-5f08c155-3acd-4b36-ab8c-588d66d0d01c.jpg)

