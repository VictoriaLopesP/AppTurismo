using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

namespace AppTurismo.Pages.Notes
{
    public class ViewNotesModel : PageModel
    {
        private readonly string notesPath;

        public ViewNotesModel(IWebHostEnvironment env)
        {
            notesPath = Path.Combine(env.ContentRootPath, "wwwrooot", "files");

            if (!Directory.Exists(notesPath))
            {
                Directory.CreateDirectory(notesPath);
            }
        }

        [BindProperty]
        public string Title { get; set; } = string.Empty;

        [BindProperty]
        public string Content { get; set; } = string.Empty;

        public List<string> FileNames { get; set; } = new();

        public string? FileContent { get; set; }
        public string? SelectedFile { get; set; }

        public void OnGet([FromQuery] string? filename)
        {
            FileNames = Directory.GetFiles(notesPath, "*.txt")
                                 .Select(Path.GetFileName)
                                 .ToList();

            if (!string.IsNullOrEmpty(filename))
            {
                var filePath = Path.Combine(notesPath, filename);
                if (System.IO.File.Exists(filePath))
                {
                    FileContent = System.IO.File.ReadAllText(filePath);
                    SelectedFile = filename;
                }
            }
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(Title) || string.IsNullOrWhiteSpace(Content))
            {
                ModelState.AddModelError(string.Empty, "Título e conteúdo são obrigatórios.");
                OnGet(null);
                return Page();
            }

            var safeTitle = Path.GetFileNameWithoutExtension(Title);
            var filePath = Path.Combine(notesPath, safeTitle + ".txt");

            System.IO.File.WriteAllText(filePath, Content);

            return RedirectToPage();
        }
    }
}
