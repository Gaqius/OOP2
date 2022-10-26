using System;
using System.Collections.Generic;
using System.Text;
using Bogus;

namespace L3_Tests
{
    public class IntMyListTests : MyListTests<int>
    {
        private readonly Faker faker = new Faker();
        protected override int CreateItem()
        {
            return faker.Random.Number(100);
        }
    }
}
