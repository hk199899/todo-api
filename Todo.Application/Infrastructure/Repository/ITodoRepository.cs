﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entity;

namespace Todo.Infrastructure.Repository
{
    public interface ITodoRepository
    {
        public void Add(TodoItem todoItem);
        public void Update(TodoItem todoItem);
        public void Delete(TodoItem todoItem);
        public TodoItem? Get(Guid id);
        public List<TodoItem> Get(List<Guid> ids);
        public List<TodoItem> GetByUserId(Guid userId);
    }
}
