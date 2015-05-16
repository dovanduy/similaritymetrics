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

        double GetSimilarity(Dictionary<TEntity, Dictionary<TItem, double>> preferences, TEntity entity1,
            TEntity entity2,
            Func<Dictionary<TEntity, Dictionary<TItem, double>>, TEntity, TEntity, double> metricFunc);
    }
}