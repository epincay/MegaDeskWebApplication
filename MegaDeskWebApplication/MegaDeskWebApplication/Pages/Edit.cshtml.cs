using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MegaDeskWebApplication.Models;

namespace MegaDeskWebApplication
{
    public class EditModel : PageModel
    {
        private readonly MegaDeskWebApplication.Models.MegaDeskWebApplicationContext _context;

        public List<Quote.MaterialList> MaterialList = Enum.GetValues(typeof(Quote.MaterialList)).Cast<Quote.MaterialList>().ToList();

        public EditModel(MegaDeskWebApplication.Models.MegaDeskWebApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Quote Quote { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Quote = await _context.Quote.FirstOrDefaultAsync(m => m.ID == id);

            if (Quote == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //Less than 1000 inches

            if (Quote.Width * Quote.Depth < Quote.BASESIZE)
            {
                Quote.TotalAmount += Quote.BASEPRICE;

                switch (Quote.Material)
                {
                    case "Oak":
                        Quote.TotalAmount += Quote.OAKPRICE;
                        break;
                    case "Laminate":
                        Quote.TotalAmount += Quote.LAMINATEPRICE;
                        break;
                    case "Pine":
                        Quote.TotalAmount += Quote.PINEPRICE;
                        break;
                    case "Rosewood":
                        Quote.TotalAmount += Quote.ROSEPRICE;
                        break;
                    case "Veneer":
                        Quote.TotalAmount += Quote.VENEERPRICE;
                        break;
                }

                //Validation for RushOrder
                switch (Quote.RushOrder)
                {
                    case 3:
                        Quote.TotalAmount += Quote.RUSHDAYS3;
                        break;
                    case 5:
                        Quote.TotalAmount += Quote.RUSHDAYS5;
                        break;
                    case 7:
                        Quote.TotalAmount += Quote.RUSHDAYS7;
                        break;
                }
            }

            //Between 1000 and 2000 inches

            else if (Quote.Width * Quote.Depth < Quote.MIDDLESIZE)
            {
                Quote.TotalAmount += Quote.Width * Quote.Depth;
                switch (Quote.Material)
                {
                    case "Oak":
                        Quote.TotalAmount += Quote.OAKPRICE;
                        break;
                    case "Laminate":
                        Quote.TotalAmount += Quote.LAMINATEPRICE;
                        break;
                    case "Pine":
                        Quote.TotalAmount += Quote.PINEPRICE;
                        break;
                    case "Rosewood":
                        Quote.TotalAmount += Quote.ROSEPRICE;
                        break;
                    case "Veneer":
                        Quote.TotalAmount += Quote.VENEERPRICE;
                        break;
                }

                //Validation for RushOrder
                switch (Quote.RushOrder)
                {
                    case 3:
                        Quote.TotalAmount += 70;
                        break;
                    case 5:
                        Quote.TotalAmount += 50;
                        break;
                    case 7:
                        Quote.TotalAmount += 35;
                        break;
                }
            }


            //Greater than 2000

            else if (Quote.Width * Quote.Depth >= Quote.MIDDLESIZE)
            {
                Quote.TotalAmount += Quote.Width * Quote.Depth;
                switch (Quote.Material)
                {
                    case "Oak":
                        Quote.TotalAmount += Quote.OAKPRICE;
                        break;
                    case "Laminate":
                        Quote.TotalAmount += Quote.LAMINATEPRICE;
                        break;
                    case "Pine":
                        Quote.TotalAmount += Quote.PINEPRICE;
                        break;
                    case "Rosewood":
                        Quote.TotalAmount += Quote.ROSEPRICE;
                        break;
                    case "Veneer":
                        Quote.TotalAmount += Quote.VENEERPRICE;
                        break;
                }

                //Validation for RushOrder
                switch (Quote.RushOrder)
                {
                    case 3:
                        Quote.TotalAmount += 80;
                        break;
                    case 5:
                        Quote.TotalAmount += 60;
                        break;
                    case 7:
                        Quote.TotalAmount += 40;
                        break;
                }
            }

            //Validation for Drawers
            switch (Quote.NumOfDrawers)
            {
                case 0:
                    Quote.TotalAmount += 0;
                    break;
                case 1:
                    Quote.TotalAmount += 50;
                    break;
                case 2:
                    Quote.TotalAmount += 100;
                    break;
                case 3:
                    Quote.TotalAmount += 150;
                    break;
                case 4:
                    Quote.TotalAmount += 200;
                    break;
                case 5:
                    Quote.TotalAmount += 250;
                    break;
                case 6:
                    Quote.TotalAmount += 300;
                    break;
                case 7:
                    Quote.TotalAmount += 350;
                    break;
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Quote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuoteExists(Quote.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool QuoteExists(int id)
        {
            return _context.Quote.Any(e => e.ID == id);
        }
    }
}
