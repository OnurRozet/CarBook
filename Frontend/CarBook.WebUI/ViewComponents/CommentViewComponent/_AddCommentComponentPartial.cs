using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.CommentViewComponent
{
    public class _AddCommentComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
