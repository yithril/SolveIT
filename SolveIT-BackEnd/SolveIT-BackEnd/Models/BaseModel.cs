﻿namespace SolveIT_BackEnd.Models;

public abstract class BaseModel
{
    public int Id { get; set; }
    public int CreatedById { get; set; }
    public User CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public int? UpdatedById { get; set; }
    public User UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public bool IsActive { get; set; }
}