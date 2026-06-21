using Microsoft.AspNetCore.Mvc;
using HomeworkManager.Models;

namespace HomeworkManager.Controllers;

public class TasksController : Controller
{
    // GET /Tasks
    public IActionResult Index(string? filter)
    {
        var tasks = TaskRepository.GetAll();

        if (!string.IsNullOrWhiteSpace(filter) && Enum.TryParse<TodoStatus>(filter, out var status))
            tasks = [.. tasks.Where(t => t.Status == status)];

        ViewBag.Filter = filter ?? "All";
        return View(tasks);
    }

    // GET /Tasks/Details/5
    public IActionResult Details(int id)
    {
        var task = TaskRepository.GetById(id);
        if (task is null) return NotFound();
        return View(task);
    }

    // GET /Tasks/Create
    public IActionResult Create()
    {
        return View(new HomeworkTask());
    }

    // POST /Tasks/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(HomeworkTask task)
    {
        if (!ModelState.IsValid)
            return View(task);

        TaskRepository.Add(task);
        TempData["Success"] = "Zadanie zostało dodane!";
        return RedirectToAction(nameof(Index));
    }

    // GET /Tasks/Edit/5
    public IActionResult Edit(int id)
    {
        var task = TaskRepository.GetById(id);
        if (task is null) return NotFound();
        return View(task);
    }

    // POST /Tasks/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, HomeworkTask task)
    {
        if (id != task.Id) return BadRequest();

        if (!ModelState.IsValid)
            return View(task);

        TaskRepository.Update(task);
        TempData["Success"] = "Zadanie zostało zaktualizowane!";
        return RedirectToAction(nameof(Index));
    }

    // POST /Tasks/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        TaskRepository.Delete(id);
        TempData["Success"] = "Zadanie zostało usunięte.";
        return RedirectToAction(nameof(Index));
    }
}
