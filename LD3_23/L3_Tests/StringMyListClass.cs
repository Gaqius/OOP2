using System;
using System.Collections.Generic;
using System.Text;
using Bogus;
using L3.Code;

namespace L3_Tests
{
    public class StringMyListClass : MyListTests<string>
    {
        private readonly Faker faker = new Faker();
        protected override string CreateItem()
        {
            return faker.Name.FullName();
        }
    }
}
