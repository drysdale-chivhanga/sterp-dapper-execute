namespace Sterp.DapperExecute;

/// <summary>
/// Interface.Data.Execute
/// </summary>
public interface IDataExecute
{
    /// <summary>
    /// GetData
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    /// <param name="storedProcedure"></param>
    /// <param name="parameters"></param>
    /// <param name="connectionString"></param>
    /// <returns></returns>
    Task<IEnumerable<T>> GetData<T, U>(string storedProcedure, U parameters, string connectionString = "DefaultCon");
    /// <summary>
    /// SaveData
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="storedProcedure"></param>
    /// <param name="parameters"></param>
    /// <param name="connectionString"></param>
    /// <returns></returns>
    Task SaveData<T>(string storedProcedure, T parameters, string connectionString = "DefaultCon");
}
