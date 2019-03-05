using System;
using System.Collections.Generic;
using DAL.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ServiceLayer;

namespace UnitTestLayer
{
    [TestClass]
    public class EmployeeServiceUnitTest
    {
        Mock<IEmployeeLogic> mockemployee = new Mock<IEmployeeLogic>();

        [TestMethod]
        public void TestMethod1()
        { 
            var emp = new List<Employee>()
            {
                new Employee() {EID = 6, Ename = "Mark", Salary = 120000,DeptID= 101},
                new Employee() {EID = 7, Ename = "Misha", Salary = 10000,DeptID= 102},
                new Employee() {EID = 8, Ename = "Sue", Salary = 15000,DeptID= 101},
                new Employee() {EID = 9, Ename = "Marry", Salary= 890000,DeptID= 103},
            };
            //whenever you access this method it return emp..mocking data 
            var employees= mockemployee.Setup(x => x.GetAllEmloyees()).Returns(emp);
            
            //Assert.IsTrue(employees);
            Assert.AreEqual(4, emp.Count);

        }
    }
}
