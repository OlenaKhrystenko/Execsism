public class Orm
{
    private Database database;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Write(string data)
    {
        try
        {
            this.database.BeginTransaction();
            this.database.Write(data);
            this.database.EndTransaction();
        }
        catch
        {
            this.database.Dispose();
            throw;
        }
    }

    public bool WriteSafely(string data)
    {
        try
        {
            Write(data);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
