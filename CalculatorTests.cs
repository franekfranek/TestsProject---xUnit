using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestProject
{
    public class CalculatorTests
    {
        private readonly Calculator _sut; // system under tests

        public CalculatorTests()
        {
            _sut = new Calculator();
        }

        [Fact(Skip = "I do not like naming of it XD")]
        public void AddTwoNubersShouldEquelTheirEqual()
        {
            _sut.Add(5);
            _sut.Add(8);
            Assert.Equal(13, _sut.Value);
        }
        [Theory]
        [InlineData(13, 5, 8)]
        [InlineData(0, -5, 5)]
        [InlineData(0, 0, 0)]
        public void AddTwoNumbersShouldEquelTheirEqualFact(
            decimal expected, decimal firstToAdd, decimal secondToAdd)
        {
            _sut.Add(firstToAdd);
            _sut.Add(secondToAdd);
            Assert.Equal(expected, _sut.Value);
        }
        [Theory]
        [MemberData(nameof(TestData))]
        public void AddManyNumbersShouldEquelTheirEqualFact(
            decimal expected, params decimal[] valuesToAdd)
            //params enables the methdo to accept infinite number of decimals
        {
            foreach (var val in valuesToAdd)
            {
                _sut.Add(val);
            }
            Assert.Equal(expected, _sut.Value);
        }

        [Theory]
        [ClassData(typeof(DivisionTestData))]
        public void DivideManyNumbersFact(
            decimal expected, params decimal[] valuesToAdd)

        {
            foreach (var val in valuesToAdd)
            {
                _sut.Divide(val);
            }
            Assert.Equal(expected, _sut.Value);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { 15, new decimal[] { 10, 5 } };
            yield return new object[] { 15, new decimal[] { 5, 5, 5 } };
            yield return new object[] { -10, new decimal[] { -30, 20 } };

        }

        public class DivisionTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { 15, new decimal[] { 60, 4 } };
                yield return new object[] { 1, new decimal[] { 1, 1 } };
                yield return new object[] { 30, new decimal[] { 60, 2 } };
                yield return new object[] { 0, new decimal[] { 0, 2 } };
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
