using System;
using System.Collections.Generic;

namespace CollectiveIntelligence.Core
{
    public interface ISimilarity<TEntity, TItem>
    {
        double GetSimilarityByEuclideanDistance(Dictionary<TEntity, Dictionary<TItem, double>> preferences,
            TEntity entity1, TEntity entity2);

        double GetPearsonCorrelation(Dictionary<TEntity, Dictionary<TItem, double>> preferences, TEntity entity1,
            TEntity entity2);

        SortedDictionary<double, TEntity> TopMatches(Dictionary<TEntity, Dictionary<TItem, double>> preferences, TEntity entity,
            int limit, Func<Dictionary<TEntity, Dictionary<TItem, double>>, TEntity, TEntity, double> metricFunc);
    }
}