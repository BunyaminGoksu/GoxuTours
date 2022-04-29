using System;
using System.Collections.Generic;
using System.Text;

namespace GoxuTour.Application.Repositories
{
    public interface IRepository <TEntity>
    {
        //Generic
        //Hangi başka bir tip için bu interface oluşturalacaksa o bahsettiğimi<  "başka tip"i generic tip olarak (tip parametresi olarak) oluşturur
        
        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();

        void Create(TEntity entity);

        void Delete(TEntity entity);

        void Update(TEntity entity);
    }
}
