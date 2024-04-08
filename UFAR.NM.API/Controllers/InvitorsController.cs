using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using UFAR.NM.API.Data;
using UFAR.NM.API.Models;
using UFAR.NM.API.Models.Entites;

namespace UFAR.NM.API.Controllers
{
    public class InvitorsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public InvitorsController(ApplicationDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddInvatorsViewModel viewModel)
        {
           
            if (ModelState.IsValid)
            {
                var Invations = new Invations
                {
                    Name = viewModel.Name,
                    Email = viewModel.Email,
                    Phone = viewModel.Phone,
                    //               WillAttend = viewModel.WillAttend
                };
                await dbContext.Invitors.AddAsync(Invations);
                await dbContext.SaveChangesAsync();
                return View("Thanks", viewModel);   
            }
            else
            {
                return View();
            }
           
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var Inventors = await dbContext.Invitors.ToListAsync();
            return View(Inventors);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
           var Inventors = await dbContext.Invitors.FindAsync(id);
           return View(Inventors);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, Invations updatedItem)
        {
           
            if (ModelState.IsValid)
            {
                try
                {
                    dbContext.Update(updatedItem);
                    dbContext.SaveChanges();
                    return RedirectToAction("List", "invitors");
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Handle exception
                    throw;
                }
            }

            // If ModelState is not valid, return the view with errors
            return View(updatedItem);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Invations viewModel)
        {
            var Invations = await dbContext.Invitors.AsNoTracking().FirstOrDefaultAsync(x => x.Id == viewModel.Id);

            if(Invations is not null)
            {
                dbContext.Invitors.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "invitors");
        }
    }
}
