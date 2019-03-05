using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer;
using Moq;
using Presentation.Controllers;
using System.Web.Mvc;

namespace UnitTestLayer
{
    /// <summary>
    /// Summary description for EmployeeControllerUnitTest
    /// </summary>
    [TestClass]
    public class EmployeeControllerUnitTest
    {
        Mock<IEmployeeLogic> mockemployee = new Mock<IEmployeeLogic>();

        [TestMethod]
       public void TestMethod1()
        {
            var Empcontroller = new EmployeeController(mockemployee.Object);
           var result = Empcontroller.Index()as ActionResult;
            Assert.IsInstanceOfType(result, typeof(ViewResult)); ;
        }
        
    }
}