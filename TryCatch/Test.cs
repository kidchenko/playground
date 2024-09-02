public class Test
{

    public static string Juca()
    {
        try
        {
            throw new System.Exception();
            return "try";
        }
        catch (System.Exception ex)
        {
            return "catch";
        }
        finally
        {
            return "finally";
        }
    }
}