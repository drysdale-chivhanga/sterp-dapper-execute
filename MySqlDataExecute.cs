using Dapper;
using MySqlConnector;
using System.Data;

namespace Sterp.DapperExecute;
/// <summary>
/// MySql.Data.Execute
/// </summary>
public class MySqlDataExecute : IDataExecute
{

    /// <summary>
    /// GetData
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    /// <param name="storedProcedure"></param>
    /// <param name="parameters"></param>
    /// <param name="connectionString"></param>
    /// <returns>List</returns>
    public async Task<IEnumerable<T>> GetData<T, U>(string storedProcedure, U parameters, string connectionString = "DefaultCon")
    {
        using MySqlConnection connection = new(connectionString);
        return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    /// <summary>
    /// SaveData
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="storedProcedure"></param>
    /// <param name="parameters"></param>
    /// <param name="connectionString"></param>
    /// <returns>Void</returns>
    public async Task SaveData<T>(string storedProcedure, T parameters, string connectionString = "DefaultCon")
    {
        using MySqlConnection connection = new(connectionString);
        await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }
}
