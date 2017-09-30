using System;
using System.Collections.Generic;
using System.Linq;
using Flu.Tests.Models;
using Xunit;

namespace Flu.Tests
{
    public class FilterEnumerableTest
    {
        public readonly Animal[] Animals = {
            new Dog()
            {
                Name = "Laurence",
                Age = 3,
                Gender = Gender.Male,
                Height = 30
            },
            new Dog()
            {
                Name = "Spooky",
                Age = 12,
                Gender = Gender.Male,
                Height = 70
            },
            new Horse()
            {
                Name = "Fiona",
                Age = 5,
                Gender = Gender.Female,
                Height = 184
            },
            new Horse()
            {
                Name = "Lucky",
                Age = 15,
                Gender = Gender.Male,
                Height = 179
            },
            new Horse()
            {
                Name = "Chap",
                Age = 6,
                Gender = Gender.Male,
                Height = 150
            },
        };

        public readonly PredicateExpression<Animal> IsOld = PredicateExpression.Create<Animal>(a => a.Age > 10);

        public readonly PredicateExpression<Animal> IsHigh = PredicateExpression.Create<Animal>(a => a.Height > 120);

        public readonly PredicateExpression<Animal> IsFemale = PredicateExpression.Create<Animal>(a => a.Gender  == Gender.Female);

        [Fact]
        public void SimplePredicate()
        {
            var oldAnimals = Animals.Where(IsOld).ToList();

            Assert.Equal(2, oldAnimals.Count);
            Assert.Same(Animals[1], oldAnimals[0]);
            Assert.Same(Animals[3], oldAnimals[1]);
        }

        [Fact]
        public void ConjunctionPredicate()
        {
            var oldAndHigh = Animals.Where(IsOld & IsHigh)
                                    .ToList();

            Assert.Equal(1, oldAndHigh.Count);
            Assert.Same(Animals[3], oldAndHigh.First());
        }

        [Fact]
        public void AlternativePredicate()
        {
            var oldOrFemale = Animals.Where(IsOld | IsFemale)
                                     .ToList();

            Assert.Equal(3, oldOrFemale.Count);
            Assert.Same(Animals[1], oldOrFemale[0]);
            Assert.Same(Animals[2], oldOrFemale[1]);
            Assert.Same(Animals[3], oldOrFemale[2]);
        }

        [Fact]
        public void NegatePredicate()
        {
            var notOld = Animals.Where(!IsOld).ToList();

            Assert.Equal(3, notOld.Count);
            Assert.Same(Animals[0], notOld[0]);
            Assert.Same(Animals[2], notOld[1]);
            Assert.Same(Animals[4], notOld[2]);
        }

        [Fact]
        public void ComplexPredicate()
        {
            var predicate = (IsOld | IsFemale) & IsHigh; 

            var oldOrHigh = Animals.Where(predicate).ToList();

            Assert.Equal(2, oldOrHigh.Count);
            Assert.Same(Animals[2], oldOrHigh[0]);
            Assert.Same(Animals[3], oldOrHigh[1]);
        }
    }
}
