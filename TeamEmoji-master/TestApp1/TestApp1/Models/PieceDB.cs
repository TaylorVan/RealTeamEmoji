using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestApp1
{
    public class PieceDB
    {
        readonly SQLiteAsyncConnection _database;

        public PieceDB(string dbPath)
        {
            //Open database at path specified 
            _database = new SQLiteAsyncConnection(dbPath);
            //Create/open the 'Piece' table
            _database.CreateTableAsync<Piece>().Wait();
        }

        public Task<List<Piece>> GetAllPieces()
        {
            //Returns all available pieces
            return _database.Table<Piece>().ToListAsync();
        }

        public Task<List<Piece>> GetPiecesByCategory(string category)
        {
            return _database.Table<Piece>().Where(i => i.Catagory == category).ToListAsync();
        }

        public Task<Piece> GetPieceByPartNum(string partNum)
        {
            //Return piece based on partNumber 
            return _database.Table<Piece>().Where(i => i.PartNum == partNum).FirstOrDefaultAsync();
        }

        
    }
}