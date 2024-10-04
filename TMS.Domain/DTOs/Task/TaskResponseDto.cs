﻿namespace TMS.Domain.DTOs.Task;
public class TaskResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public int CourseId { get; set; }
}
