TintMemFS class – File System

In this project i built a thread safe file system that stores the content and meta data of multiple files. The main idea is that the content of the files turns into byte arrays, and i saved them in dictionary so that the files are stored in the memory of the process. The system allows to add, remove, copy, rename, compare, encrypt, decrypt, export to disk files, make a list of all the files in the system, export all the data in the system to a single file that can be loaded later and restore the data and meta data. has well the system is able to set files hidden so they won't be visible in the list of the files, and sort the data of system by date created, size in kilobytes decreasing or by name. To encrypt and decrypt the files we used the AES class from System.Security.Cryptography package i made a modification that to encrypt we receive as parameter in Encrypt(string key) function a key(password) and cast the string to byte[32] and sets as a key to a AES object. This allow us to decrypt back the files with the same key and if the key entered is wrong, inform the user. This encryption method allows us to make a 'chain' of encryptions so that if a file is encrypted for example three times so to decrypt the file the user will need all the three keys that were used to encrypt. I save a counter of each file that indicates us if the file was encrypted so if we have encrypted files and then we add a new file and we want to decrypt the files so the new file has not been encrypted yet and we'll know it and we won't try to decrypt it. In the beginning of each function the mutex has to be required so that no one can interrupt the users that are already making any change or reading data from the system, and at the end of the function we release the mutex.
Properties:
•	Dictionary<string, byte[]> dataByteArrDict – A dictionary that stores all the conent of the files saved in the file system as byte arrays. [key = file name, value = content of file as byte[].
•	Dictionary<string, string[]> metaDataDict – A dictionary that stores the meta data of the files in the file system (size in kb, creation time and date) [key = file name, value = {size, creation information}.

•	Dictionary<string, int> encryptedTimes – A dictionary that stores a counter of how many times each file in the system has been encrypted [key = file name, value = times encrypted].
 
•	Dictionary<string, bool> hiddenInfoDict – A dictionary that saves the value of each file in the system to true if the file is 'hidden', else false [key = file name, value = true/false].

•	Mutex – A mutex to make the system thread safe.


Methods:
•	public bool add(String fileName, String fileToAdd) – adds the data and meta data of 'filename' that saved in path 'fileToAdd', returns true if the addition was successful.

•	public bool remove(String fileName) – removes 'fileName' content and meta data from the system and return true if the removal was successful, else false.

•	public List<String> listFiles() – return a list of all the files stored in the system in the format – Name: filename, Size : 100kb , Creation date and time: 1-1-2001 14:21:59.

•	public bool save(String fileName, String fileToAdd) – stores the file in the path 'fileToAdd' as 'fileName' and returns true or false accordingly if the file was saved successfully.

•	public bool encrypt(String key) – encrypts all the file in system according to the key and return true if encryption succeeded ,else false.

•	public bool decrypt(String key) – decrypts all the file in the system if the key is the same key that was used to encrypt. If the key is not the same the decryption won't work and returns false.

•	public bool saveToDisk(String fileName) – this function makes a single file in format of ".DATA" that stores all the data in the system. (the actually format is a zipfile that stores all the content and meta data of the files in the system).

•	public bool loadFromDisk(String fileName) – loads the information of the files in the data file and returns true if it succeeded.

•	public bool setHidden(String fileName, bool hidden) – sets the file 'fileName' to hidden according to the 'hidden' parameter and stores this information in the hiddenInfoDict dictionary.

•	public bool rename(String fileName, String newFileName) – renames the file 'fileName' to 'newFileName' if 'fileName' is in the system and if 'newFileName' doesn't exist already in the system, otherwise returns false.

•	public bool copy(String fileName1, String fileName2) – this function copy the content and meta data of 'fileName1' if this file exist in the system to a new 'fileName2' file if it doesn't exist in the system and returns true, otherwise returns false.

•	public void sortByName() – all the files in the system a sorted by alphabetical orded. 

•	public void sortByDate() - all the files in the system a sorted by creation date and time. 
•	public void sortBySize() - all the files in the system a sorted by size in kilo bytes decreasing. 

•	public bool compare(String fileName1, String fileName2) – this function compares to files 'fileName1' and 'fileName2' if they are stored in the system, according to the content of the files.

•	public Int64 getSize() – returns the total size of the files in the system in kilobytes.

TinyMemFS GUI: 

I built a GUI to this class with windows forms and explained every button in the app. The 
file of the images is very large so here is a link to the image: 

![TinyMemFSGUI](https://user-images.githubusercontent.com/101277239/176740023-5f08c155-3acd-4b36-ab8c-588d66d0d01c.jpg)

