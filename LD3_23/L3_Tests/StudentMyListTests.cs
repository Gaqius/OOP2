using System;
using System.Collections.Generic;
using System.Text;
using Bogus;
using L3.Code;

namespace L3_Tests
{
    public class StudentMyListTests : MyListTests<Student>
    {
        private readonly Faker faker = new Faker();
        protected override Student CreateItem()
        {
            string Surname = faker.Name.LastName();
            string Name = faker.Name.FindName();
            string Group = faker.Random.String(4);
            string Month = faker.Random.Word();
            string ExcersiseID = faker.Random.String(3);
            return new Student(Surname, Name, Group, Month, ExcersiseID);
        }
    }
}
