using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using ViewDemo01.Controllers;
using Xunit;

namespace ViewDemo01.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void ModelObjectType()
        {
            ExampleController controller = new ExampleController();
            ViewResult result = (ViewResult)controller.Index();
            result.ViewData.Model.Should().BeOfType<DateTime>();
            result.ViewData["Message"].Should().Be("Hello");
        }

        [Fact]
        public void Redirection()
        {
            ExampleController controller = new ExampleController();
            RedirectResult result = controller.Redirect();
            result.Url.Should().Be("/Example/Index");
            result.Permanent.Should().BeFalse();
        }

        [Fact]
        public void NotFoundActionMethod()
        {
            HttpResultController controller = new HttpResultController();
            StatusCodeResult result = controller.NotFoundDemo();
            result.StatusCode.Should().Be(404);
        }
    }
}