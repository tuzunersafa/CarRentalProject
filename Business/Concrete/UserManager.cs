﻿using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Core.Entites.Concrete;
using Core.Utitilies.Result.Data_Result;
using Core.Utitilies.Result.Void_Result;
using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserServices
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }





        public IResult Add(User entity)
        {
            _userDal.Add(entity);
            return new Result(true, entity.FirstName + " " + Messages.Added);
        }

        public IResult Delete(User entity)
        {
            _userDal.Delete(entity);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<User> Get(Expression<Func<User, bool>> filter)
        {
            return new SuccessDataResult<User>(_userDal.Get(filter), Messages.Listed);
        }

        public IDataResult<List<User>> GetAll(Expression<Func<User, bool>> filter = null)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(filter), Messages.Listed);
        }


        public IDataResult<List<OperationClaim>> GetClaimsOfUser(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetOperationClaimsOfUser(user), Messages.Listed);
        } 


        public IResult Update(User entity)
        {
            _userDal.Update(entity);
            return new SuccessResult(Messages.Updated);

        }
    }
}
