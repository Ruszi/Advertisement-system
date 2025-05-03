using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt_2._1.Data;
using Projekt_2._1.Models;


namespace Projekt2._1.Controllers
{
    public class ApartmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApartmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Apartments
        public async Task<IActionResult> Index()
        {
            // Pobieramy listę mieszkań z bazy danych
            var apartments = await _context.Apartments.ToListAsync();
            return View(apartments); // Przekazujemy listę mieszkań do widoku 'Index'
        }

        // GET: Apartments/Create
        public IActionResult Create()
        {
            return View(); // Wyświetlamy formularz do tworzenia mieszkania
        }

        // POST: Apartments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Address,Area,Price,Description")] Apartment apartment)
        {
            if (ModelState.IsValid)
            {
                // Dodajemy nowe mieszkanie do bazy danych
                _context.Add(apartment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Po zapisaniu przekierowujemy na listę mieszkań
            }
            return View(apartment); // W przypadku błędów formularza wracamy do formularza tworzenia
        }

        // GET: Apartments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Jeśli nie ma ID, zwróć 'Not Found'
            }

            var apartment = await _context.Apartments.FindAsync(id);
            if (apartment == null)
            {
                return NotFound(); // Jeśli mieszkanie nie istnieje, zwróć 'Not Found'
            }
            return View(apartment); // Zwróć formularz edycji z istniejącym mieszkaniem
        }

        // POST: Apartments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Address,Area,Price,Description")] Apartment apartment)
        {
            if (id != apartment.Id)
            {
                return NotFound(); // Jeśli ID się nie zgadza, zwróć 'Not Found'
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apartment); // Zaktualizuj mieszkanie w bazie danych
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApartmentExists(apartment.Id))
                    {
                        return NotFound(); // Jeśli mieszkanie nie istnieje, zwróć 'Not Found'
                    }
                    else
                    {
                        throw; // W przeciwnym razie, zgłoś wyjątek
                    }
                }
                return RedirectToAction(nameof(Index)); // Po zapisaniu przekieruj na listę mieszkań
            }
            return View(apartment); // Jeśli były błędy formularza, wróć do formularza edycji
        }

        // GET: Apartments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Jeśli nie ma ID, zwróć 'Not Found'
            }

            var apartment = await _context.Apartments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apartment == null)
            {
                return NotFound(); // Jeśli mieszkanie nie istnieje, zwróć 'Not Found'
            }

            return View(apartment); // Zwróć widok usuwania mieszkania
        }

        // POST: Apartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apartment = await _context.Apartments.FindAsync(id);
            _context.Apartments.Remove(apartment); // Usuń mieszkanie z bazy danych
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); // Po usunięciu przekieruj na listę mieszkań
        }

        private bool ApartmentExists(int id)
        {
            return _context.Apartments.Any(e => e.Id == id); // Sprawdź, czy mieszkanie istnieje w bazie danych
        }
    }
}
