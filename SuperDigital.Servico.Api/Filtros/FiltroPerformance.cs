using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SuperDigital.Servico.Api.Filtros
{
    /// <summary>
    /// Filtro de medicao da performance
    /// </summary>
    public class FiltroPerformance : IAsyncActionFilter
    {
        #region |Membros|
        #region |Atributos|
        private const string NOME_PROPRIEDADE = "TempoDeProcessamento";
        #endregion
        #region |Metodos|
        /// <summary>
        /// Quando action e executada e finalizada
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var stop = new Stopwatch();

            stop.Start();

            var resultContext = await next();

            stop.Stop();

            if (resultContext.Result is ObjectResult view)
            {
                var item = view.Value;

                if (item?.GetType().GetProperty(NOME_PROPRIEDADE) != null)
                    item.GetType().GetProperty(NOME_PROPRIEDADE).SetValue(item, Convert.ToInt32(stop.Elapsed.TotalMilliseconds));

                view.Value = item;
            }
        }
        #endregion
        #endregion
    }
}