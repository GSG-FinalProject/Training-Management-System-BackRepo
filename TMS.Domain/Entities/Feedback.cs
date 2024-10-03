using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Domain.Entities;
public class Feedback
{
    public int Id { get; set; }
    public string Comments { get; set; }
    public int TaskId { get; set; }
    public Task Task { get; set; }
    public string TrainerId { get; set; }
    public Trainer Trainer { get; set; }
    public string TraineeId { get; set; }
    public Trainee Trainee { get; set; }
}