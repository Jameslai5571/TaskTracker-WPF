using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TaskTracker_WPF.Models;

namespace TaskTracker_WPF.Services
{
    internal class SaveLoadService
    {
        private readonly string _filePath;
        private readonly string _fileName;

        //private TaskBook _taskBook;

        public SaveLoadService()
        {
            //_taskBook = taskBook;
            _filePath = "";
            _fileName = "Taskbook.json";

            if (File.Exists(_fileName))
            {
                //string jsonString = File.ReadAllText(_fileName);
                //_taskBook = JsonSerializer.Deserialize<TaskBook>(jsonString)!;

                //_taskBook = LoadAsync().Result;
            }
            else
            {
                //File.Create(_fileName).Close();
            }


        }

        public async void SaveAsync(TaskBook taskBook)
        {
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };

            //changed from openwrite -> create, because need to truncate out non-overwritten data, when new data is shorter than old data
            using FileStream writeStream = File.Create(_fileName);

            //not saving all items due to access issues, need to public for it to serialize properly
            //added [JsonInclude] to private access properties
            await JsonSerializer.SerializeAsync<TaskBook>(writeStream, taskBook, options);

            writeStream.Close();

            Debug.WriteLine(File.ReadAllText(_fileName));
        }

        public async Task<TaskBook> LoadAsync()
        {
            try
            {
                using FileStream openStream = File.OpenRead(_fileName);

                TaskBook loadTaskBook = await JsonSerializer.DeserializeAsync<TaskBook>(openStream);
                
                string jsonString = File.ReadAllText(_fileName);
                TaskBook testTaskBook = JsonSerializer.Deserialize<TaskBook>(jsonString);

                openStream.Close();

                return loadTaskBook;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("File not exists" +  ex.Message);

                return null;
            }

        }
    }
}
