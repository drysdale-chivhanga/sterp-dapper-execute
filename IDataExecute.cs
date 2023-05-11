using System.Data;

namespace Sterp.DapperExecute;

/// <summary>
/// Interface.Data.Execute
/// </summary>
public interface IDataExecute
{

    /// <summary>
    /// GetData.StoredProcedure
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    /// <param name="query"></param>
    /// <param name="parameters"></param>
    /// <param name="connectionString"></param>
    /// <param name="commandType"></param>
    /// <returns></returns>
    Task<IEnumerable<T>> GetData<T, U>(string query, U parameters, string connectionString = "DefaultCon", CommandType commandType = CommandType.StoredProcedure);
    /// <summary>
    /// SaveData
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="storedProcedure"></param>
    /// <param name="parameters"></param>
    /// <param name="connectionString"></param>
    /// <returns></returns>
    Task SaveData<T>(string storedProcedure, T parameters, string connectionString = "DefaultCon");


    /// <summary>
    /// GetFirstLevelMasterDetailData
    /// </summary>
    /// <typeparam name="T1">Master-Entity</typeparam>
    /// <typeparam name="T2">Detail-Entities</typeparam>
    /// <typeparam name="U">Parameter(s)</typeparam>
    /// <param name="storedProcedure"></param>
    /// <param name="parameters"></param>
    /// <param name="connectionString"></param>
    /// <returns>Master.Entity and Detail.Entities</returns>
    Task<(T1, IEnumerable<T2>)> GetFirstLevelMasterDetailData<T1, T2, U>(string storedProcedure, U parameters, string connectionString = "DefaultCon");
}
