using Microsoft.EntityFrameworkCore;
using TRAFETY.Bd.Contexto;
using TRAFETY.Shared.Enum;

namespace TRAFETY.Server.Repositorios
{
    public class Repositorio<E> : IRepositorio<E> where E : class, IEntidadBase
    {
        public Context Context { get; }

        public Repositorio(Context context)
        {
            Context = context;
        }

        public async Task<List<E>> GetFull()
        {
            try
            {
                var list = await Context.Set<E>().ToListAsync();
                return list;
            }
            catch (Exception) { throw; }
        }

        public async Task<List<E>> GetActivos()
        {
            {
                try
                {
                    var list = await Context.Set<E>()
                        .Where(e => e.EstadoRegistro == EnumEstadoRegistro.activo)
                        .ToListAsync();
                    return list;
                }
                catch (Exception) { throw; }
            }
        }

        public async Task<E> GetById(int id)
        {
            try
            {
                var res = await Context.Set<E>().AsNoTracking()
                                              .FirstOrDefaultAsync(e => e.Id == id);
                return res;
            }
            catch (Exception e) { throw; }
        }

        public async Task<int> Insert(E entity)
        {
            try
            {
                entity.EstadoRegistro=EnumEstadoRegistro.activo;
                await Context.Set<E>().AddAsync(entity);
                await Context.SaveChangesAsync();
                return entity.Id;
            }
            catch (Exception e) { throw; }
        }

        public async Task<bool> Update(E entrada, int id)
        {
            try
            {
                if (entrada.Id != id)
                {
                    return false;
                }
                var entity = await GetById(id);
                if (entity == null)
                {
                    return false;
                }

                Context.Set<E>().Update(entrada);

                var resp = await Context.SaveChangesAsync();
                return resp > 0;
            }
            catch (Exception) { throw; }
        }

        public async Task<bool> Baja(int id, string usuarioId)
        {
            try
            {
                var entity = await GetById(id);
                if (entity == null)
                {
                    return false;
                }
                string pepe = entity.Observacion == string.Empty ? string.Empty : $"{entity.Observacion}/r/n";
                entity.Observacion = $"{pepe}Dado de baja {DateTime.UtcNow}";
                entity.EstadoRegistro = EnumEstadoRegistro.borrado; //ERROR
                entity.IdBaja = usuarioId;
                entity.FechaBaja = DateTime.UtcNow;

                Context.Set<E>().Update(entity);
                var resp = await Context.SaveChangesAsync();
                return resp > 0;
            }
            catch (Exception) { throw; }
        }
    }
}
