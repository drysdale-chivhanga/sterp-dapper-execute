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
    /// <param name="query"></param>
    /// <param name="parameters"></param>
    /// <param name="connectionString"></param>
    /// <param name="cType">commandType</param>
    /// <returns></returns>
    public async Task<IEnumerable<T>> GetData<T, U>(string query, U parameters, string connectionString = "DefaultCon", CommandType cType = CommandType.StoredProcedure)
    {
        using MySqlConnection connection = new(connectionString);
        return await connection.QueryAsync<T>(query, parameters, commandType: cType);
    }



    /// <summary>
    /// GetFirstLevelMasterDetailData
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="U"></typeparam>
    /// <param name="storedProcedure"></param>
    /// <param name="parameters"></param>
    /// <param name="connectionString"></param>
    /// <returns></returns>
    public async Task<(T1, IEnumerable<T2>)> GetFirstLevelMasterDetailData<T1, T2, U>(string storedProcedure, U parameters, string connectionString = "DefaultCon")
    {
        using MySqlConnection connection = new(connectionString);
        List<T1> masters = new();
        List<T2> details = new();
        using (var lists = await connection.QueryMultipleAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure))
        {
            masters = lists.Read<T1>().ToList();
            details = lists.Read<T2>().ToList();
        }
        return (masters.First(), details);
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
