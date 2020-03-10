using Android.Content;
using MedicalHerbs.Data;
using MedicalHerbs.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocalDatabase))]
namespace MedicalHerbs.Data
{
    public class LocalDatabase
    {
        readonly SQLiteAsyncConnection _database;

        //подключаем БД 
        public LocalDatabase(string dbPath)
        {
            string databasePath = GetDatabasePath(dbPath);
            _database = new SQLiteAsyncConnection(databasePath);
            //_database.CreateTableAsync<Disease>().Wait();
        }

        //возвращаем полный путь локальной БД
        public string GetDatabasePath(string sqliteFilename)
        {
            string documentsPath;
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    break;
                case Device.iOS:
                    documentsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "..", "Library");
                    break;
                case Device.UWP:
                    documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    break;
                default:
                    documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    break;
            }
            
           
            
            var path = Path.Combine(documentsPath, sqliteFilename);
            // копирование файла БД из папки Assets по пути path
            if (!File.Exists(path))
            {
                // получаем контекст приложения
                Context context = Android.App.Application.Context;
                var dbAssetStream = context.Assets.Open(sqliteFilename);

                var dbFileStream = new FileStream(path, FileMode.OpenOrCreate);
                var buffer = new byte[1024];

                int b = buffer.Length;
                int length;

                while ((length = dbAssetStream.Read(buffer, 0, b)) > 0)
                {
                    dbFileStream.Write(buffer, 0, length);
                }

                dbFileStream.Flush();
                dbFileStream.Close();
                dbAssetStream.Close();
            }
            return path;
        }

        public Task<List<Disease>> GetNotesAsync()
        {
            return _database.Table<Disease>().ToListAsync();
        }

        public Task<List<Disease>> GetFavoriteAsync()
        {
            return _database.Table<Disease>().Where(i => i.Favorite == true).ToListAsync();
        }


        public void SaveNotesAsync(List<Disease> diseasesList)
        {
            _database.InsertAllAsync(diseasesList);
        }

        public Task<Disease> GetNoteAsync(int id)
        {
            return _database.Table<Disease>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<Disease> GetNameAsync(string name)
        {
            return _database.Table<Disease>()
                           .Where(i => i.Name == name)
                           .FirstOrDefaultAsync();


        }
        public Task<int> SaveNoteAsync(Disease disease)
        {
            if (disease.Id != 0)
            {
                return _database.UpdateAsync(disease);
            }
            else
            {
                return _database.InsertAsync(disease);
            }
        }

        public Task<int> DeleteNoteAsync(Disease disease)
        {
            return _database.DeleteAsync(disease);
        }
    }
}

