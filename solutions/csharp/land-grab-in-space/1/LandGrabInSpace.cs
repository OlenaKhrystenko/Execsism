public struct Coord : IEquatable<Coord>
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }

    public bool Equals(Coord other)
    {
        return this.X == other.X && this.Y == other.Y;
    }

    public override bool Equals(object obj)
    {
        return obj is Coord other && Equals(other);
    }

    public override int GetHashCode()
    {
        return (X << 16) | Y;
    }
}

public struct Plot : IEquatable<Plot>
{
    public Plot(Coord c1, Coord c2, Coord c3, Coord c4)
    {
        coord1 = c1;
        coord2 = c2;
        coord3 = c3;
        coord4 = c4;
    }
    // TODO: Complete implementation of the Plot struct
    public Coord coord1 {get;}
    public Coord coord2 {get;}
    public Coord coord3 {get;}
    public Coord coord4 {get;}

    public bool Equals(Plot other)
    {
        return coord1.Equals(other.coord1) &&
            coord2.Equals(other.coord2) &&
            coord3.Equals(other.coord3) &&
            coord4.Equals(other.coord4);
    }

    public override bool Equals(object obj)
    {
        return obj is Plot other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(coord1, coord2, coord3, coord4);
    }
}


public class ClaimsHandler
{
    private readonly HashSet<Plot> _stakedPlots = new HashSet<Plot>();
    private Plot? _lastClaimedPlot;
    
    public void StakeClaim(Plot plot)
    {
        _stakedPlots.Add(plot);
        _lastClaimedPlot = plot;
    }

    public bool IsClaimStaked(Plot plot)
    {
        return _stakedPlots.Contains(plot);
    }

    public bool IsLastClaim(Plot plot)
    {
        return _lastClaimedPlot.HasValue && _lastClaimedPlot.Value.Equals(plot);
    }

    public Plot GetClaimWithLongestSide()
    {
        if (_stakedPlots.Count == 0)
        {
            throw new InvalidOperationException("No claims have been staked.");
        }

        Plot longestPlot = default;
        int maxSide = -1;

        foreach (var plot in _stakedPlots)
        {
            int minX = Math.Min(Math.Min(plot.coord1.X, plot.coord2.X), Math.Min(plot.coord3.X, plot.coord4.X));
            int maxX = Math.Max(Math.Max(plot.coord1.X, plot.coord2.X), Math.Max(plot.coord3.X, plot.coord4.X));
            int minY = Math.Min(Math.Min(plot.coord1.Y, plot.coord2.Y), Math.Min(plot.coord3.Y, plot.coord4.Y));
            int maxY = Math.Max(Math.Max(plot.coord1.Y, plot.coord2.Y), Math.Max(plot.coord3.Y, plot.coord4.Y));

            int sideX = maxX - minX;
            int sideY = maxY - minY;
            int currentLongestSide = Math.Max(sideX, sideY);

            if (currentLongestSide > maxSide)
            {
                maxSide = currentLongestSide;
                longestPlot = plot;
            }
        }
        return longestPlot;
    }
}
