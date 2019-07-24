using System.Threading.Tasks;

namespace GarageManager.Extensions.PDFConverter.ViewRender
{
    public interface IViewRenderService
    {
        Task<string> RenderToStringAsync(string viewName, object model);
    }
}
