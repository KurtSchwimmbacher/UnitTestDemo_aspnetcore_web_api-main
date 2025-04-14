using System;
using Xunit;
using Moq;
using UnitTestDemoApplication.Services;
using UnitTestDemoApplication.Interfaces;
using UnitTestDemoApplication.Models;


namespace UnitTestDemo.Tests;

public class TodoServiceTest
{


    // ONE ISSUE WITH TESTS IN THIS SCENARIO
    // dont want tests to actually communicate with the DB
    // we need to mock the actual DB



    // TODO: GET correct todo item
    // TODO: input incorrect - item not found (return null)

    // GETTING ITEMS

    // ADDING ITEMS
    // OPTIONAL: Make sure input is not null and correct
    // TODO: add an item, that it was actually successfully added

    // creating a mock repo for services
    private readonly Mock<ITodoRepository> _mockRepo;
    private readonly TodoService _service;

    public TodoServiceTest()
    {
        _mockRepo = new Mock<ITodoRepository>();
        // using the mock repo in our services file that we are testing 
        _service = new TodoService(_mockRepo.Object);
    }


    // adding items
    [Fact]
    public async Task AddTodoAsync_AddsItem()
    {
        // Arrange
        // setting up our new todo item that we want to add
        TodoItem newItem = new TodoItem { Title = "Test Adding", IsCompleted = false };
        // setting up our mock repo to return the item
        _mockRepo.Setup(x => x.AddAsync(It.IsAny<TodoItem>())).ReturnsAsync(newItem);

        // Act
        // call the adding functionality
        var result = await _service.AddTodoAsync("Test Adding");

        // Assert
        // result matches to our new item
        Assert.Equal(newItem, result);
        Assert.Equal("Test Adding", result.Title);
        Assert.False(result.IsCompleted);
        Assert.NotNull(result);
        // Equal - 1. what we expect 2. what we got

    }

}
