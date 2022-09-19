using Microsoft.AspNetCore.Mvc;

namespace BattleRap.API.Controllers.Interfaces
{
    public interface IBaseController<T, TDTO, TPatchDTO>
    {
        Task<ActionResult<IEnumerable<T>>> Get(int page, int pageSize);
        Task<ActionResult<T>> Get(int id);
        Task<ActionResult<T>> Post(TDTO entity);
        Task<ActionResult<T>> Put(int id, TDTO entity);
        Task<ActionResult<T>> Patch(int id, TPatchDTO entity);
        Task<ActionResult<T>> Delete(int id);
    }
}
