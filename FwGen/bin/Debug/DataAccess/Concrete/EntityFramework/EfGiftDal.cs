﻿using NewGenFramework.Core.DataAccess.EntityFramework;
using NewGenFramework.DataAccess.Abstract;
using NewGenFramework.DataAccess.Concrete.Context;
using NewGenFramework.Entities.Concrete;

namespace NewGenFramework.DataAccess.Concrete.EntityFramework
{
		 public class EfGiftDal:EfEntityRepositoryBase<Gift,NewGenFrameworkContext>,IGiftDal
		{
		}
}
