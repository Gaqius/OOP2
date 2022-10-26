using System;
using Xunit;
using L3.Code;
using FluentAssertions;
using System.Collections;
using System.Linq;

namespace L3_Tests
{
    public abstract class MyListTests<T>
        where T : IComparable<T>, IEquatable<T>
    {
        protected abstract T CreateItem();

        private MyList<T> CreateLoadedList(int count)
        {
            var list = new MyList<T>();

            for (int i = 0; i < count; i++)
            {
                list.Add(CreateItem());
            }
            return list;
        }

        [Fact]
        [Trait("TestMethod", "Constructor")]
        public void MakingList()
        {
            Action action = () => new MyList<T>();

            action.Should().NotThrow();
        }

        [Theory]
        [Trait("TestMethod", "Add")]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(5)]
        public void AddingShouldWork(int count)
        {
            MyList<T> list = CreateLoadedList(count);
            Action task = () => list.Add(CreateItem());

            task.Should().NotThrow();
        }

        [Theory]
        [Trait("TestMethod", "Count")]
        [Trait("TestMethod", "Add")]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(5)]
        public void HowManyWereAdded(int count)
        {
            MyList<T> list = CreateLoadedList(count);

            list.Count().Should().Be(count);
        }

        [Theory]
        [Trait("TestMethod", "Enumerator")]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(5)]
        public void IEnumerableIsImplemented(int count)
        {
            var genericList = new System.Collections.Generic.List<T>();
            MyList<T> list = new MyList<T>();

            for (int i = 0; i < count; i++)
            {
                var item = CreateItem();
                list.Add(item);
                genericList.Add(item);
            }

            genericList.Zip(list, (a, b) => a.Equals(b)).All((t) => t).Should();
        }

        [Fact]
        [Trait("TestMethod", "ToString")]
        public void Verify_ToString_Override()
        {
            var list = new MyList<T>();
            Assert.True(list.ToString() != list.GetType().ToString());
        }

        [Theory]
        [Trait("TestMethod", "Equals")]
        [InlineData(1)]
        [InlineData(5)]
        public void VerifyIfListsAreEqualInLenght(int count)
        {
            var firstList = CreateLoadedList(count);
            var secondList = CreateLoadedList(count);

            firstList.Equals(secondList).Should().BeTrue();
        }

        [Theory]
        [Trait("TestMethod", "Sort")]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(5)]
        public void SortShouldWork(int count)
        {
            var list = CreateLoadedList(count);
            Action action = () => list.Sort();

            action.Should().NotThrow();
        }

        [Fact]
        [Trait("TestMethod", "Sort")]
        public void NothingToSortOnEmptyList()
        {
            var list = new MyList<T>();
            var listDummy = new MyList<T>();

            list.Sort();

            list.Equals(listDummy).Should().BeTrue();
        }

        
    }
}