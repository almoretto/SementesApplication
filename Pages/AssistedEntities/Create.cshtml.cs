﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SementesApplication
{ 
    public class CreateModelAssistedEntities : PageModel
    {
        private readonly SementesApplication.Data.SementesApplicationContext _context;

        public CreateModelAssistedEntities(SementesApplication.Data.SementesApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AssistedEntities AssistedEntities { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AssistedEntities.Add(AssistedEntities);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
