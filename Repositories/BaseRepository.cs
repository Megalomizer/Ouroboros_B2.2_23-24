using OuroborosEvents.Abstractions;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuroborosEvents.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : TableData, new()
    {
        SQLiteConnection connection;
        public string? StatusMessage { get; set; }

        public BaseRepository()
        {
            connection = new SQLiteConnection(Constants.DatabasePath, Constants.flags);
            connection.CreateTable<T>();
        }

        /// <summary>
        /// Save the given entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="recursive"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void SaveEntity(T entity, bool recursive = false)
        {
            try
            {
                try
                {
                    if (entity.Id != 0)
                        connection.UpdateWithChildren(entity);
                    else
                        connection.InsertWithChildren(entity);
                }
                catch (Exception ex)
                {
                    if(entity.Id != 0)
                        connection.Update(entity);
                    else
                        connection.Insert(entity);
                }
            }
            catch(Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        /// <summary>
        /// Get the entity based on the given ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public T? GetEntity(int id)
        {
            try
            {
                T entity = new T();

                try
                {
                    entity = connection.GetWithChildren<T>(id);
                }
                catch (Exception ex)
                {
                    entity = connection.Table<T>().FirstOrDefault(e => e.Id == id);
                }

                return entity;
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }

            return null;
        }

        /// <summary>
        /// Get a list of all entities
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<T> GetEntities()
        {
            try
            {
                List<T> entity = new List<T>();

                try
                {
                    entity = connection.GetAllWithChildren<T>().ToList();
                }
                catch (Exception ex)
                {
                    entity = connection.Table<T>().ToList();
                }

                return entity;
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }

            return null;
        }

        /// <summary>
        /// Delete the given entity
        /// </summary>
        /// <param name="entity"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void DeleteEntity(T entity)
        {
            try
            {
                connection.Delete(entity);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }       
    }
}
