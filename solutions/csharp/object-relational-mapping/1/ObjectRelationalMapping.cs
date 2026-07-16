using System;

public class Orm : IDisposable
{
    private readonly Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Begin()
    {
        // NO manual state checks here.
        // Let the database throw naturally if it isn't Closed.
        this.database.BeginTransaction();
    }
    public void Write(string data)
    {
        try
        {
            // NO manual state checks here.
            // If the database is Closed, this call throws an exception natively,
            // which immediately jumps into the catch block below.
            this.database.Write(data);
        }
        catch (Exception)
        {
            // Clean up the database and absorb the exception so the test can continue
            this.database.Dispose();
        }
    }
     public void Commit()
    {
        try
        {
            // NO manual state checks here.
            this.database.EndTransaction();
        }
        catch (Exception)
        {
            // Clean up the database and absorb the exception
            this.database.Dispose();    
        }
    }

    public void Dispose()
    {
        this.database.Dispose();
    }
}