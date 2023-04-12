using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedNUnitApp;

namespace AdvancedNUnitTests;

public class CounterTests
{
    Counter _sut;

    [SetUp]
    public void Init()
    {
        _sut = new Counter(6);
    }
   

    [Test]
    [Category("Counter Tests")]
    public void Increment_IncreasesCountByOne()
    {
        // arrange
        Init();
        int result = 7;

        // act
        _sut.Increment();


        // assert
        Assert.That(_sut.Count, Is.EqualTo(result));

    }

    [Test]
    [Category("Counter Tests")]
    public void Decrement_DecreasesCountByOne()
    {
        // arrange
        Init();
        int result = 5;

        // act
        _sut.Decrement();


        // assert
        Assert.That(_sut.Count, Is.EqualTo(result));
    }
}
