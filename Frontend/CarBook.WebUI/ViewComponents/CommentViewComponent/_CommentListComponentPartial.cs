using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.CommentViewComponent
{
    public class _CommentListComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
