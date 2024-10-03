﻿namespace TMS.Domain.Entities;
public class Task
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public string TrainerId { get; set; }
    public Trainer Trainer { get; set; }
}
