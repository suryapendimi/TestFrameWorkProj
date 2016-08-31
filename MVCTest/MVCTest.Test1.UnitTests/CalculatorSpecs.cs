using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MVCTest.Test1.UnitTests
{
    public class Calculator
    {
        public int Add(int x, int y)
        {
            return x+y;
        }
    }

    //[TestFixture]
    //public class CalculatorSpecs
    //{
    //    [Test]
    //    public void then_zero_plus_zero_is_Zero()
    //    {
            
    //        var sut=new Calculator();
    //        var result = sut.Add(0, 0);
    //        Assert.That(result, Is.EqualTo(0));
    //    }

    //    [Test]
    //    public void then_one_plus_one_is_two()
    //    {

    //        var sut = new Calculator();
    //        var result = sut.Add(1, 1);
    //        Assert.That(result, Is.EqualTo(2));
    //    }

    //    [Test]
    //    public void then_one_plus_two_is_three()
    //    {

    //        var sut = new Calculator();
    //        var result = sut.Add(1, 2);
    //        Assert.That(result, Is.EqualTo(3));
    //    }
    //}
}
