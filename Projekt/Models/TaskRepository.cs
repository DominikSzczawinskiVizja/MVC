using System.Text.Json;
using System.Text.Json.Serialization;

namespace HomeworkManager.Models;
//"bazy danych", a bardziej szybki store danych w pamieci cache.
public static class TaskRepository
{
    private static readonly string _filePath = Path.Combine(
        AppContext.BaseDirectory, "data.json");

    private static readonly JsonSerializerOptions _json = new()
    {
        WriteIndented = true,
        Converters = { new JsonStringEnumConverter() }
    };

    private static readonly List<HomeworkTask> _cache = Load();

    //getall
    public static List<HomeworkTask> GetAll() =>
        [.. _cache.OrderBy(t => t.Deadline)];

    //get by id
    public static HomeworkTask? GetById(int id) =>
        _cache.FirstOrDefault(t => t.Id == id);

    //add
    public static void Add(HomeworkTask task)
    {
        task.Id = _cache.Count > 0 ? _cache.Max(t => t.Id) + 1 : 1;
        _cache.Add(task);
        Save();
    }
    
    //update
    public static bool Update(HomeworkTask updated)
    {
        var existing = GetById(updated.Id);
        if (existing is null) return false;
        existing.Description = updated.Description;
        existing.Deadline = updated.Deadline;
        existing.Status = updated.Status;
        Save();
        return true;
    }

    //delete
    public static bool Delete(int id)
    {
        var task = GetById(id);
        if (task is null) return false;
        _cache.Remove(task);
        Save();
        return true;
    }

    //load
    private static List<HomeworkTask> Load()
    {
        if (!File.Exists(_filePath))
            return SeedData();
        try
        {
            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<HomeworkTask>>(json, _json) ?? SeedData();
        }
        catch { return SeedData(); }
    }

    //save
    private static void Save()
    {
        var json = JsonSerializer.Serialize(_cache, _json);
        File.WriteAllText(_filePath, json);
    }

    //seed danych
    private static List<HomeworkTask> SeedData() =>
    [
        new HomeworkTask { Id = 1, Description = "Napisać wypracowanie z polskiego",       Deadline = DateTime.Today.AddDays(2),  Status = TodoStatus.ToDo },
        new HomeworkTask { Id = 2, Description = "Rozwiązać zadania z matematyki str. 45", Deadline = DateTime.Today.AddDays(-1), Status = TodoStatus.Done },
        new HomeworkTask { Id = 3, Description = "Przeczytać rozdział 7 z historii",       Deadline = DateTime.Today.AddDays(5),  Status = TodoStatus.InProgress },
    ];
}