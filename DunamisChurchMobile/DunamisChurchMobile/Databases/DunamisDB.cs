using DunamisChurchMobile.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DunamisChurchMobile.Databases
{
    public class DunamisDB
    {
        SQLiteConnection database;
        public DunamisDB(string dbPath)
        {
            database = new SQLiteConnection(dbPath);
            database.CreateTable<SeedOfDestiny>();
            database.CreateTable<Event>();
            database.CreateTable<Testimony>();
            database.CreateTable<YoutubeItem>();
        }

        #region Events' Database

        public List<Event> GetAllEvents()
        {
            var events = database.Table<Event>().ToList();
            return events;
        }

        public int AddUpdatedEvents(List<Event> UpdatedEvents)
        {
            database.DropTable<Event>();
            database.CreateTable<Event>();
            var events = database.InsertAll(UpdatedEvents);
            return events;
        }
        #endregion

        #region Testimonies' Database

        public List<Testimony> GetAllTestimonies()
        {
            var testimonies = database.Table<Testimony>().ToList();
            return testimonies;
        }

        public int AddUpdatedTestimonies(List<Testimony> UpdatedTestimonies)
        {
            database.DropTable<Testimony>();
            database.CreateTable<Testimony>();
            var testimonies = database.InsertAll(UpdatedTestimonies);
            return testimonies;
        }
        #endregion

        #region SeedOfDestinies' Database

        public List<SeedOfDestiny> GetAllSeedOfDestinies()
        {
            var seedOfDestinies = database.Table<SeedOfDestiny>().ToList();
            return seedOfDestinies;
        }

        public int AddUpdatedSeedOfDestinies(List<SeedOfDestiny> UpdatedSeedOfDestinies)
        {
            database.DropTable<SeedOfDestiny>();
            database.CreateTable<SeedOfDestiny>();
            var seedOfDestinies = database.InsertAll(UpdatedSeedOfDestinies);
            return seedOfDestinies;
        }
        #endregion

    }
}
