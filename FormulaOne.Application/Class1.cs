namespace FormulaOne.Application
{
    /// <summary>
    /// dummy class used to force loading assembly in startup. 
    /// it wasn't being loaded without this, and hence the automapper profiles were not being loaded
    /// </summary>
    public class ApplicationAssemblyMarker
    {

    }
}
