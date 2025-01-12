﻿using FluentAssertions;
using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Application.Models.Todo;
using Todo.Application.Services.Todo;
using Todo.Contracts.Todo;
using Todo.Controllers;
using Todo.Domain.Entity;
using Todo.Test.Application.Todo;
using Todo.Test.CommonMock;

namespace Todo.Test.Api
{
    public class TodoControllerTest
    {
        [Fact]
        public void GetTodos_ShouldOK()
        {
            //Arrange
            var todoService = new Mock<ITodoService>();
            var mockRequest = new GetTodosRequest();
            var queryParams = new TodoQueryParams();
            todoService.Setup(x=>x.GetTodos(It.IsAny<Guid>(), It.IsAny<TodoQueryParams>())).Returns(Result.Ok(new List<TodoItem>()));
            var controller = new TodoController(todoService.Object, CommonMocks.SessionData);
            //Act
            var result = controller.GetTodos(mockRequest) as IStatusCodeActionResult;
            //Assert
            result.Should().NotBeNull();
            result?.StatusCode.Should().Be(200);
        }
        [Fact]
        public void AddTodo_ShouldOK()
        {
            //Arrange
            var todoService = new Mock<ITodoService>();
            var controller = new TodoController(todoService.Object, CommonMocks.SessionData);
            todoService.Setup(service => service.AddTodo(CommonMocks.SessionData.UserId, It.IsAny<TodoItemBody>())).Returns(Result.Ok());
            //Act
            var result = controller.AddTodo(TodoMocks.addTodoReqeust) as IStatusCodeActionResult;
            //Assert
            result.Should().NotBeNull();
            result?.StatusCode.Should().Be(200);
        }
        [Fact]
        public void UpdateTodo_ShouldOK()
        {
            //Arrange
            var todoService = new Mock<ITodoService>();
            var controller = new TodoController(todoService.Object, CommonMocks.SessionData);
            todoService.Setup(service => service.UpdateTodo(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<TodoItemBody>()))
                .Returns(Result.Ok(TodoMocks.todoItem));
            //Act
            var result = controller.UpdateTodo(TodoMocks.todoItem.Id, TodoMocks.updateTodoRequest) as IStatusCodeActionResult;
            //Assert
            result.Should().NotBeNull();
            result?.StatusCode.Should().Be(200);
        }
        [Fact]
        public void DeleteTodo_ShouldOK()
        {
            //Arrange
            var todoService = new Mock<ITodoService>();
            var controller = new TodoController(todoService.Object, CommonMocks.SessionData);
            todoService.Setup(service => service.RemoveTodo(It.IsAny<Guid>(), It.IsAny<Guid>()))
               .Returns(Result.Ok());
            //Act
            var result = controller.DeleteTodo(TodoMocks.todoItem.Id) as IStatusCodeActionResult;
            //Assert
            result.Should().NotBeNull();
            result?.StatusCode.Should().Be(200);
        }
    }
}
