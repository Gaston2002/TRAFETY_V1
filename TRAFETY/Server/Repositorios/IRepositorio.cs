﻿using TRAFETY.Bd.Contexto;

namespace TRAFETY.Server.Repositorios
{
    public interface IRepositorio<E> where E : class, IEntidadBase
    {
        Context Context { get; }

        Task<bool> Baja(int id, string usuarioId);
        Task<List<E>> GetActivos();
        Task<E> GetById(int id);
        Task<List<E>> GetFull();
        Task<int> Insert(E entity);
        Task<bool> Update(E entrada, int id);
    }
}