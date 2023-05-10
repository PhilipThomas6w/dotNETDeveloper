using Microsoft.EntityFrameworkCore;
using NorthwindAPI.Controllers;

using NorthwindAPI.Data.Repositories;

 

namespace NorthwindAPI.Services

{

    public class NorthwindService<T> : INorthwindService<T> where T : class

    {

        private readonly ILogger _logger;

        private readonly INorthwindRepository<T> _repository;



        public NorthwindService(ILogger<INorthwindService<T>> logger, INorthwindRepository<T> repository)

        {

            _logger = logger;

            _repository = repository;

        }



        public async Task<bool> CreateAsync(T entity)

        {

            _repository.Add(entity);
            await _repository.SaveAsync();
            return true;

        }



        public Task<bool> DeleteAsync(int id)

        {

            throw new NotImplementedException();

        }



        public async Task<IEnumerable<T>?> GetAllAsync()

        {

            return (await _repository.GetAllAsync()).ToList();
        }



        public async Task<T?> GetAsync(int id)

        {

            if (_repository.IsNull)

            {

                return null;

            }



            var entity = await _repository.FindAsync(id);



            if (entity == null)

            {

                _logger.LogWarning($"{typeof(T).Name} with id: {id} was not found");

                return null;

            }



            _logger.LogInformation($"{typeof(T).Name} with id: {id} found");



            return entity;

        }



        public async Task<bool> UpdateAsync(int id, T entity)
        {

            try
            {
                _repository.Update(entity);
                await _repository.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if ( await SupplierExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;

        }

        private async Task<bool> SupplierExists(int id)
        {
            return (await _repository.FindAsync(id)) is null;
        }

    }

}