using RoulleteApi.DataAccess;
using RoulleteApi.Entities;
using System;
using System.Collections.Generic;

namespace RoulleteApi.Application
{
    public class RouletteAppService
    {
        private readonly IRepository<Roulette> _rouletteRepo;
        private readonly PostgreSQLDbContext _appDbContext;
        public RouletteAppService(IRepository<Roulette> rouletteRepo, PostgreSQLDbContext appDbContext)
        {
            _rouletteRepo = rouletteRepo;
            _appDbContext = appDbContext;
        }
        internal Roulette Save(Roulette roulette)
        {
            try
            {
                //_appDbContext.Database.BeginTransaction();
                //var oldRoulette = _rouletteRepo.Get(roulette.Id);

                    _rouletteRepo.Add(roulette);
                //if (oldRoulette == null)
                //{
                //}
                //else
                //{
                //    _rouletteRepo.Update(roulette);
                //}

                _appDbContext.SaveChanges();

                return roulette;
            }
            catch (Exception ex)
            {
                //_appDbContext.Database.RollbackTransaction();
                throw new Exception(ex.Message);
            }
        }

        internal IEnumerable<Roulette> GetRoulettes()
        {
            try
            {
                return _rouletteRepo.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal Roulette GetRouletteById(string id)
        {
            try
            {
                return _rouletteRepo.Get(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
