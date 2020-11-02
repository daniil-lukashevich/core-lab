using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public string Type { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet([FromQuery]string id)
        {
            Type = $"GET: {id}";
        }

        public void OnPost([FromForm] string name)
        {
            Type = name;
        }

        public void OnPostView()
        {
            Type = "View";
        }

        public void OnPostDelete()
        {
            Type = "Delete";
        }
    }
}
