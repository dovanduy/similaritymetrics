using System;
using System.Collections.Generic;
using CollectiveIntelligence.Core.Obsolete;
using NUnit.Framework;

namespace CollectiveIntelligence.Core.Tests
{
    [TestFixture]
    public class SimilarityMetricsTests
    {
        [Test]
        public void Should_Return_Correct_Euclidean_Distance_When_Entities_Have_Common_Preferences()
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
            var sim = new Similarity<string, string>();
            var result = sim.GetSimilarityByEuclideanDistance(preferences, entity1, entity2);

            Assert.AreEqual(result, 0.29429805508554946);
        }

        [Test]
        public void Should_Return_Zero_Euclidean_Distance_When_Entities_Have_No_Preferences_In_Common()
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
            var sim = new Similarity<string, string>();
            var result = sim.GetSimilarityByEuclideanDistance(preferences, entity1, entity2);

            Assert.AreEqual(result, 0);
        }

        [Test]
        public void Should_Return_Correct_Pearson_Correlation_When_People_Have_Common_Preferences()
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
            var sim = new Similarity<string, string>();
            var result = sim.GetPearsonCorrelation(preferences, entity1, entity2);

            Assert.AreEqual(Math.Round(result, 12), 0.396059017191);
        }

        [Test]
        public void Should_Return_Zero_Pearson_Correlation_When_People_Have_Common_Preferences()
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

            var sim = new Similarity<string, string>();
            var result = sim.GetPearsonCorrelation(preferences, entity1, entity2);

            Assert.AreEqual(result, 0);
        }
    }

    [TestFixture]
    public class SimilarityGeneralTests
    {
        [Test]
        public void Should_Return_TopMatches_In_Decreasing_Order()
        {
            const string lisaRose = "Lisa Rose";
            const string geneSeymour = "Gene Seymour";
            const string michaelPhillips = "Michael Phillips";
            const string claudiaPuig = "Claudia Puig";
            const string mickLaSalle = "Mick LaSalle";
            const string jackMatthews = "Jack Matthews";
            const string toby = "Toby";

            var lisaRosePreferences = new Dictionary<string, double>
            {
                {"Lady in the Water", 2.5},
                {"Snakes on a Plane", 3.5},
                {"Just My Luck", 3.0},
                {"Superman Returns", 3.5},
                {"You, Me and Dupree", 2.5},
                {"The Night Listener", 3.0}
            };
            var geneSeymourPreferences = new Dictionary<string, double>            
            {
                {"Lady in the Water", 3},
                {"Snakes on a Plane", 3.5},
                {"Just My Luck", 1.5},
                {"Superman Returns", 5},
                {"You, Me and Dupree", 3.5},
                {"The Night Listener", 3.0}
            };

            var michaelPhillipsPreferences = new Dictionary<string, double>            
            {
                {"Lady in the Water", 2.5},
                {"Snakes on a Plane", 3},
                {"Superman Returns", 3.5},
                {"The Night Listener", 4.0}
            };

            var claudiaPuigPreferences = new Dictionary<string, double>            
            {
                {"Snakes on a Plane", 3.5},
                {"Just My Luck", 3.0},
                {"The Night Listener", 4.5},
                {"Superman Returns", 4},
                {"You, Me and Dupree", 2.5}
            };

            var mickLaSallePreferences = new Dictionary<string, double>
            {
                {"Lady in the Water", 3},
                {"Snakes on a Plane", 4},
                {"Just My Luck", 2},
                {"Superman Returns", 3},
                {"You, Me and Dupree", 2.0}
            };

            var jackMatthewsPreferences = new Dictionary<string, double>
            {
                {"Lady in the Water", 3},
                {"Snakes on a Plane", 4},
                {"The Night Listener", 3},
                {"Superman Returns", 5},
                {"You, Me and Dupree", 3.5}
            };

            var tobyPreferences = new Dictionary<string, double>
            {
                {"Snakes on a Plane", 4.5},
                {"You, Me and Dupree", 1},
                {"Superman Returns", 4}
            };

            var preferences = new Dictionary<string, Dictionary<string, double>>
            {
                {lisaRose, lisaRosePreferences},
                {geneSeymour, geneSeymourPreferences},
                {michaelPhillips, michaelPhillipsPreferences},
                {claudiaPuig, claudiaPuigPreferences},
                {mickLaSalle, mickLaSallePreferences},
                {jackMatthews, jackMatthewsPreferences},
                {toby, tobyPreferences}
            };
            var sim = new Similarity<string, string>();
            const string entity = lisaRose;
            const int limit = 5;
            var result = sim.TopMatches(preferences, entity, limit, sim.GetPearsonCorrelation);
            var previousPair = new KeyValuePair<double, string>(1000, null);

            foreach (var currentPair in result)
            {
                Assert.LessOrEqual(currentPair.Key, previousPair.Key);
                previousPair = currentPair;
            }
        }

        [Test]
        public void Should_Return_ExactNumber_Of_TopMatches()
        {
            const string lisaRose = "Lisa Rose";
            const string geneSeymour = "Gene Seymour";
            const string michaelPhillips = "Michael Phillips";
            const string claudiaPuig = "Claudia Puig";
            const string mickLaSalle = "Mick LaSalle";
            const string jackMatthews = "Jack Matthews";
            const string toby = "Toby";

            var lisaRosePreferences = new Dictionary<string, double>
            {
                {"Lady in the Water", 2.5},
                {"Snakes on a Plane", 3.5},
                {"Just My Luck", 3.0},
                {"Superman Returns", 3.5},
                {"You, Me and Dupree", 2.5},
                {"The Night Listener", 3.0}
            };
            var geneSeymourPreferences = new Dictionary<string, double>            
            {
                {"Lady in the Water", 3},
                {"Snakes on a Plane", 3.5},
                {"Just My Luck", 1.5},
                {"Superman Returns", 5},
                {"You, Me and Dupree", 3.5},
                {"The Night Listener", 3.0}
            };

            var michaelPhillipsPreferences = new Dictionary<string, double>            
            {
                {"Lady in the Water", 2.5},
                {"Snakes on a Plane", 3},
                {"Superman Returns", 3.5},
                {"The Night Listener", 4.0}
            };

            var claudiaPuigPreferences = new Dictionary<string, double>            
            {
                {"Snakes on a Plane", 3.5},
                {"Just My Luck", 3.0},
                {"The Night Listener", 4.5},
                {"Superman Returns", 4},
                {"You, Me and Dupree", 2.5}
            };

            var mickLaSallePreferences = new Dictionary<string, double>
            {
                {"Lady in the Water", 3},
                {"Snakes on a Plane", 4},
                {"Just My Luck", 2},
                {"Superman Returns", 3},
                {"You, Me and Dupree", 2.0}
            };

            var jackMatthewsPreferences = new Dictionary<string, double>
            {
                {"Lady in the Water", 3},
                {"Snakes on a Plane", 4},
                {"The Night Listener", 3},
                {"Superman Returns", 5},
                {"You, Me and Dupree", 3.5}
            };

            var tobyPreferences = new Dictionary<string, double>
            {
                {"Snakes on a Plane", 4.5},
                {"You, Me and Dupree", 1},
                {"Superman Returns", 4}
            };

            var preferences = new Dictionary<string, Dictionary<string, double>>
            {
                {lisaRose, lisaRosePreferences},
                {geneSeymour, geneSeymourPreferences},
                {michaelPhillips, michaelPhillipsPreferences},
                {claudiaPuig, claudiaPuigPreferences},
                {mickLaSalle, mickLaSallePreferences},
                {jackMatthews, jackMatthewsPreferences},
                {toby, tobyPreferences}
            };
            var sim = new Similarity<string, string>();
            const string entity = lisaRose;
            const int limit = 3;
            var result = sim.TopMatches(preferences, entity, limit, sim.GetPearsonCorrelation);

            Assert.AreEqual(result.Count, limit);
        }
    }


}
