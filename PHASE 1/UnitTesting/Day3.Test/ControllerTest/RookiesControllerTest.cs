using Day3.Services;
using Day3.Controllers;
using Moq;
using NUnit.Framework;
using Day3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day3.Test;

public class RookiesControllerTest
{
    private Mock<IPersonService> _personService = new Mock<IPersonService>();
    private RookiesController _rookiesController;

    [SetUp]
    public void Setup()
    {
        _rookiesController = new RookiesController(_personService.Object);
    }

    [Test]
    public void GetAllPerson()
    {
        // Arrange
        List<PersonModel> _people = new()
        {
            new PersonModel()
            {
                FirstName = "Banh",
                LastName = "Kha",
                BirthPlace = "HaNoi",
            },
             new PersonModel()
            {
                FirstName = "Bo",
                LastName = "Tran",
                BirthPlace = "HaNoi",
            }
        };

        _personService.Setup(s => s.GetAll()) //Chon dau vao kieu co dang PersonModel
                        .Returns(_people);
                        
        // Act  
        var result = _rookiesController.Index();
        var view = (ViewResult)result;
        var list = (List<PersonModel>)view.ViewData.Model;

        // Assert
        Assert.AreEqual(2, list.Count());
    }


    [Test]
    public void CreateNewPerson_ReturnIndex()
    {
        // Arrange
        var addPerson = new PersonModelCreate();
        var response = new PersonModel();

        _personService.Setup(s => s.Create(It.IsAny<PersonModel>())) //Chon dau vao kieu co dang PersonModel
                .Returns(response);

        // Act
        var result = (RedirectToActionResult)_rookiesController.Create(addPerson);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("Index", result.ActionName);
    }

    [Test]
    public void CreateNewPerson_ReturnView()
    {
        // Arrange
        var addPerson = new PersonModelCreate();

        _personService.Setup(s => s.Create(It.IsAny<PersonModel>())) //Chon dau vao kieu co dang PersonModel
                .Throws(new Exception());

        // Act
        var result = _rookiesController.Create(addPerson);
        var objectResult = result as ObjectResult;

        // Assert
        Assert.IsNotNull(objectResult);
        Assert.AreEqual(400, objectResult.StatusCode);
    }

    [Test]
    public void EditPerson_ReturnValue()
    {
        // Arrange
        int index = 1;
        var response = new PersonModel()
        {
            FirstName = "a",
            LastName = "b",
        };

        _personService.Setup(s => s.GetOne(It.IsAny<int>())) //Chon dau vao kieu co dang int
                .Returns(response);
        // Act
        var result = _rookiesController.Edit(index);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<ViewResult>(result);
        var viewResult = (ViewResult)result;
        Assert.IsInstanceOf<PersonModelUpdate>(viewResult.ViewData.Model);
    }

    [Test]
    public void EditPerson_ReturnNull()
    {
        // Arrange
        int index = 100;

        _personService.Setup(s => s.GetOne(It.IsAny<int>())) //Chon dau vao kieu co dang int
                .Returns(null as PersonModel);

        // Act
        var result = _rookiesController.Edit(index);

        // Assert
        Assert.IsInstanceOf<BadRequestResult>(result);
    }


    [Test]
    public void DetailPerson_ReturnNull()
    {
        // Arrange
        int index = 100;
        var response = new PersonModel()
        {
            FirstName = "a",
            LastName = "b",
        };

        _personService.Setup(s => s.GetOne((index))) //Chon dau vao kieu co dang int
                .Returns(response);

        // Act
        var result = _rookiesController.Details(index);

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
    }

    [Test]
    public void DetailPerson_ReturnValue()
    {
        // Arrange
        int index = 1;

        _personService.Setup(s => s.GetOne(It.IsAny<int>())) //Chon dau vao kieu co dang int
                .Returns(null as PersonModel);

        // Act
        var result = _rookiesController.Details(index);

        // Assert
        Assert.IsInstanceOf<ContentResult>(result);
        var contentResult = (ContentResult)result;
        Assert.AreEqual("NotFound", contentResult.Content);
    }

    [Test]
    public void DeletePerson_WhenPersonWasDeleted()
    {
        // Arrange
        int index = 1;

        _personService.Setup(s => s.GetOne(It.IsAny<int>())) //Chon dau vao kieu co dang int
                .Returns(null as PersonModel);

        // Act
        var result = _rookiesController.Delete(index);

        // Assert
        Assert.IsInstanceOf<NotFoundResult>(result);
    }

    [Test]
    public void DeletePerson_WhenPersonWasNotDeleted()
    {
        // Arrange
        int index = 1;
        var response = new PersonModel()
        {
            FirstName = "a",
            LastName = "b",
        };

        _personService.Setup(s => s.Delete(It.IsAny<int>())) //Chon dau vao kieu co dang int
                .Returns(response);

        // Act
        var result = (RedirectToActionResult)_rookiesController.Delete(index);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("Index", result.ActionName);
    }

}