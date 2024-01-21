using System.Collections.Generic;
using WebApiNet5._0.Models;

namespace WebApiNet5._0.Services
{
    public interface ILoaiRepository
    {
        List<LoaiVM> GetAll();
        LoaiVM GetById(int id);
        LoaiVM Add(LoaiModel loaiModel);
        void Update(LoaiVM loai);
        void Delete(int id);
    }
}
