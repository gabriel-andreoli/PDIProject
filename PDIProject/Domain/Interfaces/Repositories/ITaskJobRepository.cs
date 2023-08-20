﻿using PDIProject.Domain.DTOs;
using PDIProject.Domain.Entities;

namespace PDIProject.Domain.Interfaces.Repositories
{
    public interface ITaskJobRepository
    {
        void AddTaskJobUser(TaskJobUser obj);
        void Add(TaskJob taskJob);
    }
}
