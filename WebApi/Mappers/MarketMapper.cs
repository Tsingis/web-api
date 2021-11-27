using System;
using System.Collections.Generic;

public static class MarketMapper
{
    public static List<MarketChartPoint> MapMarketChartToMarketChartPoints(MarketChart marketChart)
    {
        if (marketChart.Prices.Length != marketChart.Market_caps.Length &&
            marketChart.Prices.Length != marketChart.Total_volumes.Length)
        {
            throw new Exception("Unequal number of data points in market chart");
        }

        var marketChartPoints = new List<MarketChartPoint>();
        for (var i = 0; i < marketChart.Prices.Length; i++)
        {
            var marketData = new MarketChartPoint();
            marketData.Date = (long)marketChart.Prices[i][0];
            marketData.Price = marketChart.Prices[i][1];
            marketData.MarketCap = marketChart.Market_caps[i][1];
            marketData.TotalVolume = marketChart.Total_volumes[i][1];
            marketChartPoints.Add(marketData);
        }
        return marketChartPoints;
    }
}