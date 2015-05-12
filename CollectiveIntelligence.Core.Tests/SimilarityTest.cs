﻿using System.Collections.Generic;
using NUnit.Framework;

namespace CollectiveIntelligence.Core.Tests
{
    [TestFixture]
    public class SimilarityTest
    {
        [Test]
        public void Should_Return_Correct_Euclidean_Distance_When_People_Have_Common_Preferences()
        {
            var person2 = new Similarity.Person()
            {
                Name = "Lisa Rose"
            };
            var person1 = new Similarity.Person()
            {
                Name = "Gene Seymour"
            };
            var list = new List<Similarity.Preference>
            {
                new Similarity.Preference(person1, "Lady in the Water", 2.5),
                new Similarity.Preference(person1, "Snakes on a Plane", 3.5),
                new Similarity.Preference(person1, "Just My Luck", 3.0),
                new Similarity.Preference(person1, "Superman Returns", 3.5),
                new Similarity.Preference(person1, "You, Me and Dupree", 2.5),
                new Similarity.Preference(person1, "The Night Listener", 3.0),
                new Similarity.Preference(person2, "Lady in the Water", 3.0),
                new Similarity.Preference(person2, "Snakes on a Plane", 3.5),
                new Similarity.Preference(person2, "Just My Luck", 1.5),
                new Similarity.Preference(person2, "Superman Returns", 5),
                new Similarity.Preference(person2, "You, Me and Dupree", 3.5),
                new Similarity.Preference(person2, "The Night Listener", 3.0)
            };
            // (2.5-3)^2 + (0)^2 + (3-1.5)^2 + (3.5-5)^2 + (2.5-3.5)^2 + (0)^2
            // 0.5^2 + 1.5^2 + 1.5^2 + 1
            // 0.25 + 2.25 + 2.25 + 1
            // 5.75

            Similarity.Preferences preferences = new Similarity.Preferences(list);
            var result = Similarity.GetEuclideanDistance(preferences, person1, person2);

            Assert.AreEqual(result, 0.29429805508554946);
        }

        [Test]
        public void Should_Return_Zero_Euclidean_Distance_When_People_Have_No_Preferences_In_Common()
        {
            var person2 = new Similarity.Person()
            {
                Name = "Lisa Rose"
            };
            var person1 = new Similarity.Person()
            {
                Name = "Gene Seymour"
            };
            var list = new List<Similarity.Preference>
            {
                new Similarity.Preference(person1, "Lady in the Water", 2.5),
                new Similarity.Preference(person1, "Snakes on a Plane", 3.5),
                new Similarity.Preference(person2, "Just My Luck", 1.5),
                new Similarity.Preference(person2, "Superman Returns", 5),
                new Similarity.Preference(person2, "You, Me and Dupree", 3.5),
                new Similarity.Preference(person2, "The Night Listener", 3.0)
            };

            var preferences = new Similarity.Preferences(list);
            var result = Similarity.GetEuclideanDistance(preferences, person1, person2);

            Assert.AreEqual(result, 0);
        }

        [Test]
        public void Generic_Should_Return_Correct_Euclidean_Distance_When_Entities_Have_Common_Preferences()
        {
            const string entity1 = "Lisa Rose";
            const string entity2 = "Gene Seymour";

            var entity1Preferences = new Dictionary<string, double>
            {
                {"Lady in the Water", 2.5},
                {"Snakes on a Plane", 3.5},
                {"Just My Luck", 3.0},
                {"Superman Returns", 3.5},
                {"You, Me and Dupree", 2.5},
                {"The Night Listener", 3.0}
            };
            var entity2Preferences = new Dictionary<string, double>            
            {
                {"Lady in the Water", 3},
                {"Snakes on a Plane", 3.5},
                {"Just My Luck", 1.5},
                {"Superman Returns", 5},
                {"You, Me and Dupree", 3.5},
                {"The Night Listener", 3.0}
            };

            var preferences = new Dictionary<string, Dictionary<string, double>>
            {
                {entity1, entity1Preferences},
                {entity2, entity2Preferences}
            };
            var result = Similarity<string, string>.GetEuclideanDistance(preferences, entity1, entity2);

            Assert.AreEqual(result, 0.29429805508554946);
        }

        [Test]
        public void Generic_Should_Return_Zero_Euclidean_Distance_When_Entities_Have_No_Preferences_In_Common()
        {
            const string entity1 = "Lisa Rose";
            const string entity2 = "Gene Seymour";

            var entity1Preferences = new Dictionary<string, double>
            {
                {"Lady in the Water", 2.5},
                {"Snakes on a Plane", 3.5},
                {"Just My Luck", 3.0}
            };
            var entity2Preferences = new Dictionary<string, double>            
            {
                {"Superman Returns", 5},
                {"You, Me and Dupree", 3.5},
                {"The Night Listener", 3.0}
            };

            var preferences = new Dictionary<string, Dictionary<string, double>>
            {
                {entity1, entity1Preferences},
                {entity2, entity2Preferences}
            };
            var result = Similarity<string, string>.GetEuclideanDistance(preferences, entity1, entity2);

            Assert.AreEqual(result, 0);
        }
    }
}
