using System.ComponentModel.DataAnnotations;

namespace HomeworkManager.Models;

public enum TodoStatus
{
    ToDo,
    InProgress,
    Done
}

public class HomeworkTask
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Opis jest wymagany")]
    [StringLength(200, MinimumLength = 3, ErrorMessage = "Opis musi mieć od 3 do 200 znaków")]
    [Display(Name = "Opis zadania")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Termin wykonania jest wymagany")]
    [DataType(DataType.Date)]
    [Display(Name = "Termin wykonania")]
    public DateTime Deadline { get; set; } = DateTime.Today.AddDays(7);

    [Display(Name = "Status")]
    public TodoStatus Status { get; set; } = TodoStatus.ToDo;
}
