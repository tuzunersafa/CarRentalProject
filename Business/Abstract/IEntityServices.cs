using Core.Utitilies.Result.Data_Result;
using Core.Utitilies.Result.Void_Result;
using Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEntityServices <T> where T : class, IEntity,new()
    {
        IDataResult<List<T>> GetAll(Expression<Func<T, bool>> filter = null);

        IDataResult<T> Get(Expression<Func<T, bool>> filter);

        //public List<T> GetById(int id);
        //public List<T> GetAll();
        IResult Add(T entity);
        IResult Delete(T entity);
        IResult Update(T entity);
    }
}
