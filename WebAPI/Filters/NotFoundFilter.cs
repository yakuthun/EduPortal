using Application.Dto;
using Application.Interfaces.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;
/*
  clientten gelen bir id geldiği zaman direk dönüyoruz. Ama dönmeden önce bu id veritabanına var yok mu kontrol etmemiz lazım. 
idye sahip ürünleri kontrol ederken NotFoundFilter kullanılmalı.DI ile geldiği için ServiceFilter olarak almış bulunuyoruz.

 */
namespace WebAPI.Filters
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
    {
        private readonly IService<T> _service;

        public NotFoundFilter(IService<T> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue = context.ActionArguments.Values.FirstOrDefault();
            if (idValue == null)
            {
                await next.Invoke();
            }

            var id = (int)idValue;
            var anyEntity = await _service.AnyAsync(x => x.Id == id); //entity var mı yok mu ?
            if (anyEntity)
            {
                await next.Invoke(); // bir sonraki yere git
                return;
            }
            context.Result = new Microsoft.AspNetCore.Mvc.NotFoundObjectResult(CustomResponseDto<NoContentDto>.Fail(404, $"{typeof(T).Name}({id}) not found"));
        }
    }
}
