﻿using TeatroApi.Models;

namespace TeatroApi.Data
{
    public interface IAsientosRepository
    {
        List<Asientos> GetAll();
        Asientos? Get(int id);
        void Add(Asientos asientos);
        void Delete(int id);
        void Update(Asientos asientos);
    }
}
