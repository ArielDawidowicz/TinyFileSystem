namespace TinyMemFSGUI
{
    public partial class Form1 : Form
    {
        TinyMemFS fileSystem;
        int sortIdx = -1;
        public Form1()
        {
            InitializeComponent();
            fileSystem = new TinyMemFS();
            dataGridView1.Columns.Add("", "");
            dataGridView1.Columns[0].Width = 600;
        }

        public void ClearGrid()
        {
            dataGridView1.Rows.Clear();
        }

        public void DisplayInformation()
        {
            List<string> list = fileSystem.listFiles();
            foreach (string file in list)
            {
                dataGridView1.Rows.Add(file);
            }
        }

        public void UpdateSize()
        {
            float f = fileSystem.getSize();
            sizeTxt.Text = f.ToString() + " Kb";
        }

        public void UpdateSorted()
        {
            if (sortIdx == 0)
                fileSystem.sortByName();

            if (sortIdx == 1)
                fileSystem.sortByDate();

            if (sortIdx == 2)
                fileSystem.sortBySize();
            ClearGrid();
            DisplayInformation();
        }

        public void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                fileSystem.sortByName();
                sortIdx = 0;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                fileSystem.sortByDate();
                sortIdx = 1;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                fileSystem.sortBySize();
                sortIdx = 2;
            }
            ClearGrid();
            DisplayInformation();
        }

        private void addFileBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    string name = Microsoft.VisualBasic.Interaction.InputBox("Please enter the name of the file", "Add file", "");
                    if (name == null || filePath == null)
                        MessageBox.Show("Bad name or path");

                    if (!fileSystem.add(name, filePath))
                    {
                        MessageBox.Show("Cannot save two files with the same name");
                    }
                    ClearGrid();
                    DisplayInformation();
                    UpdateSize();
                    UpdateSorted();
                }
                else
                {
                    MessageBox.Show("Bad File");
                }
            }
        }

        private void removeFileBtn_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            string s;
            if (selectedRowCount > 0)
            {
                int idx = dataGridView1.SelectedRows[0].Index;
                s = dataGridView1[0, idx].Value.ToString();
                string[] splitted = s.Split(" ");
                s = splitted[2];
                s = s.Remove(s.Length - 1);
            }
            else
            {
                s = Microsoft.VisualBasic.Interaction.InputBox("Please enter the name of the file to remove", "Remove file", "");
                if (s.Length <= 0 || !fileSystem.fileExist(s))
                {
                    MessageBox.Show("Invalid name");
                    return;
                }
            }
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove " + s + "?", "Remove file", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (fileSystem.remove(s))
                {
                    MessageBox.Show(s + " removed");
                    ClearGrid();
                    DisplayInformation();
                    UpdateSize();
                    UpdateSorted();
                }
                else
                {
                    MessageBox.Show("Couldn't remove " + s);
                }
            }
            else if (dialogResult == DialogResult.No) ;
        }


        private void renameFileBtn_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            string s;
            if (selectedRowCount > 0)
            {
                int idx = dataGridView1.SelectedRows[0].Index;
                s = dataGridView1[0, idx].Value.ToString();
                string[] splitted = s.Split(" ");
                s = splitted[2];
                s = s.Remove(s.Length - 1);
            }
            else
            {
                s = Microsoft.VisualBasic.Interaction.InputBox("Please enter the name of the file to rename", "Rename file", "");
                if (s.Length <= 0 || !fileSystem.fileExist(s))
                {
                    MessageBox.Show("Invalid name");
                    return;
                }
            }
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to rename " + s + "?", "Rename file", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string newName = Microsoft.VisualBasic.Interaction.InputBox("Please enter a new name", "Rename file", "");
                if (fileSystem.rename(s, newName))
                {
                    MessageBox.Show(s + " Renamed to : " + newName);
                    ClearGrid();
                    DisplayInformation();
                    UpdateSize();
                    UpdateSorted();
                }
                else
                {
                    MessageBox.Show("Couldn't rename " + s + ", A file named " + newName + " allready exist");
                }

            }
            else if (dialogResult == DialogResult.No) ;
        }

        private void CopyFileBtn_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            string s;
            if (selectedRowCount > 0)
            {
                int idx = dataGridView1.SelectedRows[0].Index;
                s = dataGridView1[0, idx].Value.ToString();
                string[] splitted = s.Split(" ");
                s = splitted[2];
                s = s.Remove(s.Length - 1);
            }
            else
            {
                s = Microsoft.VisualBasic.Interaction.InputBox("Please enter the name of the file to copy", "Copy file", "");
                if (s.Length <= 0 || !fileSystem.fileExist(s))
                {
                    MessageBox.Show("Invalid name");
                    return;
                }
            }
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to copy " + s + "?", "Copy file", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string newName = Microsoft.VisualBasic.Interaction.InputBox("Please enter a name for the copy", "Copy file", "");
                    if(newName.Length <= 0)
                {
                    MessageBox.Show("Invalid name");
                    return;
                }
                    if (fileSystem.copy(s, newName))
                    {
                        MessageBox.Show(s + " Copied to : " + newName);
                        ClearGrid();
                        DisplayInformation();
                        UpdateSize();
                        UpdateSorted();
                    }
                    else
                    {
                        MessageBox.Show("Couldn't copy " + s + ", A file named " + newName + " allready exist");
                    }

                }
                else if (dialogResult == DialogResult.No);
        }



        private void EncryptFileBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to encrypt all the files ?\n" + "You can" +
                    " decrypt the files only with the same key.", "Encrypt files", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string key = Microsoft.VisualBasic.Interaction.InputBox("Please enter a key to encrypt", "Encrypt file", "");
                if (key.Length <= 0)
                {
                    MessageBox.Show("Invalid key");
                    return;
                }

                if (fileSystem.encrypt(key))
                {
                    MessageBox.Show("The files are now encrypted\n Remember the key to decrypt!");
                    ClearGrid();
                    DisplayInformation();
                    UpdateSize();
                    UpdateSorted();
                }
                else
                {
                    MessageBox.Show("Couldn't encrypt the files");
                }

            }
            else if (dialogResult == DialogResult.No);

        }

        private void DecryptFileBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to decrypt the files?", "Decrypt files", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string key = Microsoft.VisualBasic.Interaction.InputBox("Please enter the key to decrypt", "Decrypt file", "");
                if (key.Length <= 0)
                {
                    MessageBox.Show("Invalid key");
                    return;
                }

                if (fileSystem.decrypt(key))
                {
                    MessageBox.Show("The files are now decrypted");
                    ClearGrid();
                    DisplayInformation();
                    UpdateSize();
                    UpdateSorted();
                }
                else
                {
                    MessageBox.Show("Couldn't decrypt the files");
                }

            }
            else if (dialogResult == DialogResult.No) ;

        }

        private void saveListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string name = Microsoft.VisualBasic.Interaction.InputBox("Please enter a name for the list", "Save list", "");
                    if (name.Length <= 0)
                    {
                        MessageBox.Show("Invalid name");
                        return;
                    }
                    try
                    {
                        string path = fbd.SelectedPath + "\\" + name + ".txt";
                        if (!File.Exists(path))
                        {
                            List<string> list = fileSystem.listFiles();
                            using (StreamWriter sw = File.CreateText(path))
                            {
                                for (int i = 0; i < list.Count; i++)
                                {
                                    sw.WriteLine(list[i]);
                                }
                                MessageBox.Show("List saved!");
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Couldnt save the list");
                    }

                }
                else
                {
                    MessageBox.Show("Bad path");
                }
            }
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            string s;
            if (selectedRowCount > 0)
            {
                int idx = dataGridView1.SelectedRows[0].Index;
                s = dataGridView1[0, idx].Value.ToString();
                string[] splitted = s.Split(" ");
                s = splitted[2];
                s = s.Remove(s.Length - 1);
            }
            else
            {
                s = Microsoft.VisualBasic.Interaction.InputBox("Please enter the name of the file to export", "Export file", "");
                if (s.Length <= 0)
                {
                    MessageBox.Show("Invalid name");
                    return;
                }
            }
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        try
                        {
                            string path = fbd.SelectedPath + "\\" + s;
                            if (!File.Exists(path))
                            {
                                if (fileSystem.save(s, path))
                                    MessageBox.Show("File exported!");
                                else
                                    MessageBox.Show("Couldnt export the file");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(s + " doesnt exist in the file system");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bad path");
                    }
                }
            }

        public void newFile()
        {
            fileSystem =  new TinyMemFS();
            ClearGrid();
            DisplayInformation();
            UpdateSize();
            UpdateSorted();
        }

        public void saveDialog()
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to save the data before creating a new file ?", "New file", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string name = Microsoft.VisualBasic.Interaction.InputBox("Please enter a name for the data file", "New file", "");
                if (name.Length <= 0)
                {
                    MessageBox.Show("Invalid name");
                    return;
                }
                if (fileSystem.saveToDisk(name))
                {
                    MessageBox.Show("System data saved in: " + name + ".DATA");
                    newFile();
                }
                else
                {
                    MessageBox.Show("Couldnt save the data");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                newFile();
            }

        }
        private void newFileSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveDialog();
        }

        private void loadFileSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveDialog();
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "(*.DATA)|*.DATA";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.FileName.Length >= 0)
                {
                    filePath = openFileDialog.FileName;
                    try
                    {
                        fileSystem.loadFromDisk(filePath);
                        DisplayInformation();
                        return;
                    }catch (Exception ex)
                    {
                        MessageBox.Show("Couldn't load the data");
                    }
                }
            }
        }

        private void saveFileSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string name = Microsoft.VisualBasic.Interaction.InputBox("Please enter a name for the data file", "Save list", "");
            if (name.Length <= 0)
            {
                MessageBox.Show("Invalid name");
                return;
            }
            try
            {
                fileSystem.saveToDisk(name);
                MessageBox.Show("System data saved in: " + name + ".DATA");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Couldnt save the data");
            }
        }
    }
}