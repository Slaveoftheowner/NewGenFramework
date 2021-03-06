﻿
using System.Collections.Generic;
using System.Linq;
using BayiPuan.Business.Abstract;
using NewGenFramework.Core.Aspects.Postsharp.CacheAspects;
using NewGenFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
using BayiPuan.DataAccess.Abstract;
using BayiPuan.Entities.Concrete;
using NewGenFramework.Core.CrossCuttingConcerns.Transaction;

namespace BayiPuan.Business.Concrete.Managers
{
    public class RelationalPersonManager : ManagerBase, IRelationalPersonService
    {
        private readonly IRelationalPersonDal _relationalPersonDal;

        public RelationalPersonManager(IRelationalPersonDal relationalPersonDal)
        {
            _relationalPersonDal = relationalPersonDal;
        }
        
         // [LogAspect(typeof(DatabaseLogger))]
        [CacheAspect(typeof(MemoryCacheManager))]
        // [PerformanceCounterAspect(1)]      
        public List<RelationalPerson> GetAll()
        {
            return _relationalPersonDal.GetList();
        }

        public RelationalPerson GetById(int relationalPersonId)
        {
            return _relationalPersonDal.Get(u => u.RelationalPersonId == relationalPersonId);
        }      

        //[FluentValidationAspect(typeof(RelationalPersonValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public RelationalPerson Add(RelationalPerson relationalPerson)
        {
            return _relationalPersonDal.Add(relationalPerson);
        }
        //[FluentValidationAspect(typeof(RelationalPersonValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(RelationalPerson relationalPerson)
        {
              _relationalPersonDal.Update(relationalPerson);
        }

        public void Delete(RelationalPerson relationalPerson)
        {
            _relationalPersonDal.Delete(relationalPerson);
        }    

        public List<RelationalPerson> GetByRelationalPerson(int relationalPersonId)
        {
            return _relationalPersonDal.GetList(filter: t => t.RelationalPersonId == relationalPersonId).ToList();
        }
    }
}
