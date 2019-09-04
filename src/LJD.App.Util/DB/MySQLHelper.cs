using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LJD.App.Util; 
using MySql.Data;
using MySql.Data.MySqlClient;

public class MySqlHelper
{
    private readonly string conStr = AppConfigurtaionHelper.Configuration["ConnectionStrings:MySqlConn"];
    private MySqlConnection SqlConn;
    private MySqlTransaction SqlTrans = null;
    #region 私有实用方法&构造函数 Start
    public MySqlHelper()
    {
        SqlConn = new MySqlConnection(conStr);
        SqlTrans = null;
    }
    public MySqlHelper(string connstring)
    {
        conStr = connstring;
        SqlConn = new MySqlConnection(conStr);
        SqlTrans = null;
    }
    private void AttachParameters(MySqlCommand command, MySqlParameter[] commandParameters)
    {
        foreach (MySqlParameter p in commandParameters)
        {
            if ((p.Direction == ParameterDirection.Input || p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
            {

                p.Value = DBNull.Value;
            }
            if (p.MySqlDbType == MySqlDbType.DateTime)
            {
                if (DateTime.Compare(Convert.ToDateTime(p.Value), DateTime.Parse("1901-01-01")) < 0)
                {
                    p.Value = DBNull.Value;
                }
            }

            command.Parameters.Add(p);
        }
    }

    private void AssignParameterValues(MySqlParameter[] commandParameters, object[] parameterValues)
    {
        if ((commandParameters == null) || (parameterValues == null))
        {
            return;
        }

        if (commandParameters.Length != parameterValues.Length)
        {
            throw new ArgumentException("参数个数不匹配");
        }

        for (int i = 0, j = commandParameters.Length; i < j; i++)
        {
            commandParameters[i].Value = parameterValues[i];
        }
    }

    private void PrepareCommand(MySqlCommand command, MySqlConnection connection, MySqlTransaction transaction, CommandType commandType, string commandText, MySqlParameter[] commandParameters)
    {
        //if the provided connection is not open, we will open it
        if (connection.State != ConnectionState.Open)
        {
            connection.Open();
        }

        //associate the connection with the command
        command.Connection = connection;

        //set the command text (stored procedure name or SQL statement)
        command.CommandText = commandText;

        //if we were provided a transaction, assign it.
        if (transaction != null)
        {
            command.Transaction = transaction;
        }

        //set the command type
        command.CommandType = commandType;

        //attach the command parameters if they are provided
        if (commandParameters != null)
        {
            AttachParameters(command, commandParameters);
        }

        return;
    }
    #endregion 私有实用方法&构造函数 End

    #region DataHelpers

    public string CheckNull(object obj)
    {
        return (string)obj;
    }

    public string CheckNull(DBNull obj)
    {
        return null;
    }

    #endregion

    /// <summary>
    /// 在开始事务后，必须要有一种方法，即使用方法。
    /// 若不使用，则是不使用，则是不使用
    /// 事务也在事务中，不会提交。连接总是打开的。
    /// </summary>
    public void BeginTranscation()
    {
        try
        {
            if (SqlTrans != null) return;
            if (SqlConn.State == ConnectionState.Closed) SqlConn.Open();
            SqlTrans = SqlConn.BeginTransaction();
        }
        catch (System.Exception ex)
        {
            throw ex;
        }
    }

    public void EndTranscation()
    {
        try
        {
            if (SqlTrans == null) return;
            SqlTrans.Commit();
        }
        catch (System.Exception ex)
        {
            SqlTrans.Rollback();
            throw ex;
        }
        finally
        {
            SqlTrans = null;
            SqlConn.Close();
        }
    }

    public void Rollback()
    {
        if (SqlTrans == null) return;
        SqlTrans.Rollback();
        SqlTrans = null;
    }

    //insert delete update
    /// <summary>
    /// 执行一个SQL语句，返回受影响的行数
    /// </summary>
    /// <param name="sql">SQL语句</param>
    /// <param name="cmdType">类型</param>
    /// <param name="pms">参数</param>
    /// <returns>受影响的行数</returns>
    public int ExecuteNonQuery(string sql, CommandType cmdType, params MySqlParameter[] pms)
    {
        MySqlConnection Connection = new MySqlConnection(conStr);
        try
        {
            if (SqlTrans != null)
            {
                MySqlCommand cmd = new MySqlCommand(sql, SqlConn);
                cmd.CommandType = cmdType;
                cmd.Transaction = SqlTrans;
                if (pms != null)
                {
                    cmd.Parameters.AddRange(pms);
                }
                return cmd.ExecuteNonQuery();
            }
            else
            {
                if (Connection.State == ConnectionState.Closed) Connection.Open();

                MySqlCommand cmd = new MySqlCommand(sql, Connection);
                cmd.CommandType = cmdType;
                if (pms != null)
                {
                    cmd.Parameters.AddRange(pms);
                }
                return cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
        finally
        {
            if (SqlTrans == null) Connection.Close();
        }
    }

    /// <summary>
    /// 执行多个SQL语句。事务处理
    /// </summary>
    /// <param name="sqlStringArray"></param>
    public void ExecuteNonQueryArrayList(ArrayList sqlStringArray)
    {
        MySqlConnection Connection = new MySqlConnection(conStr);
        MySqlCommand cmd = new MySqlCommand();
        if (Connection.State == ConnectionState.Closed) Connection.Open();
        cmd.Connection = Connection;
        try
        {
            SqlTrans = Connection.BeginTransaction();
            cmd.Transaction = SqlTrans;
            foreach (string i in sqlStringArray)
            {
                cmd.CommandText = i;
                cmd.ExecuteNonQuery();
            }

            SqlTrans.Commit();
        }
        catch (Exception ex)
        {
            SqlTrans.Rollback();
            throw ex;
        }
        finally
        {
            SqlTrans = null;
        }
    }

    /// <summary>
    /// 执行一个SQL语句，返回单个值
    /// </summary>
    /// <param name="sql">SQL语句</param>
    /// <param name="cmdType">类型</param>
    /// <param name="pms">参数</param>
    /// <returns>返回值</returns>
    public string ExecuteScalar(string sql, CommandType cmdType, params MySqlParameter[] pms)
    {
        MySqlConnection Connection = new MySqlConnection(conStr);
        try
        {
            if (SqlTrans == null)
            {
                if (Connection.State == ConnectionState.Closed)
                {
                    Connection.Open();
                }
            }
            else
            {
                Connection = SqlConn;
            }
            MySqlCommand cmd = new MySqlCommand(sql, Connection);
            cmd.CommandType = cmdType;
            if (pms != null)
            {
                cmd.Parameters.AddRange(pms);
            }
            if (SqlTrans != null) cmd.Transaction = SqlTrans;
            object obj = cmd.ExecuteScalar();
            if (obj != null) return obj.ToString().Trim();
            else return "";
        }
        catch (Exception ex)
        {

            throw ex;
        }
        finally
        {
            if (SqlTrans == null) Connection.Close();
        }
    }
    /// <summary>
    /// 执行一个SQL语句，返回DataReader
    /// </summary>
    /// <param name="sql">SQL语句</param>
    /// <param name="cmdType">类型</param>
    /// <param name="pms">参数</param>
    /// <returns>DataReader</returns>
    public MySqlDataReader ExecuteReader(string sql, CommandType cmdType, params MySqlParameter[] pms)
    {
        MySqlConnection con = new MySqlConnection(conStr);
        using (MySqlCommand cmd = new MySqlCommand(sql, con))
        {
            cmd.CommandType = cmdType;
            if (pms != null)
            {
                cmd.Parameters.AddRange(pms);
            }
            //con.Open();
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch
            {
                con.Close();
                con.Dispose();
                throw;
            }
        }
    }

    /// <summary>
    /// 执行一个SQL语句，返回DataTable
    /// </summary>
    /// <param name="sql">SQL语句</param>
    /// <param name="cmdType">类型</param>
    /// <param name="pms">参数</param>
    /// <returns>DataTable</returns>
    public DataTable ExecuteDataTable(string sql, CommandType cmdType, params MySqlParameter[] pms)
    {
        #region 第二版。
        MySqlConnection Connection = new MySqlConnection(conStr);
        DataTable dt = new DataTable();
        try
        {
            //无事物，使用 Connection
            if (SqlTrans == null)
            {
                if (Connection.State == ConnectionState.Closed)
                {
                    Connection.Open();
                }
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand(sql, Connection);
                adapter.SelectCommand.CommandType = cmdType;
                if (pms != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(pms);
                }
                adapter.Fill(dt);
            }
            else
            {
                //有事物，使用 SqlConn
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = new MySqlCommand(sql, SqlConn);
                adapter.SelectCommand.Transaction = SqlTrans;
                adapter.SelectCommand.CommandType = cmdType;
                if (pms != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(pms);
                }
                adapter.Fill(dt);
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
        finally
        {
            Connection.Close();
        }
        #endregion

        return dt;
    }


    /// <summary>
    /// 执行一个SQL语句，返回List
    /// </summary>
    /// <typeparam name="T">实体类类型</typeparam>
    /// <param name="sql">SQL语句</param>
    /// <param name="cmdType">SQL类型</param>
    /// <param name="pms">参数</param>
    /// <returns></returns>
    public List<T> GetListBySql<T>(string sql, CommandType cmdType, params MySqlParameter[] pms)
    {
        return ExecuteDataTable(sql, cmdType, pms).ToList<T>();
    }

    /// <summary>
    /// 返回分页 DataTable
    /// </summary> 
    /// <param name="pageSize">每页记录数</param>
    /// <param name="pageIndex">页码（从1开始）</param>
    /// <param name="orderBy">排序（必填）</param>
    /// <param name="sqlCommand">SQL语句</param>
    /// <param name="cmdType">SQL类型</param> 
    /// <returns>泛型集合</returns>
    public DataTable GetPagerDataTable(int pageSize, int pageIndex, string orderBy, string sqlCommand)
    {
        StringBuilder stringBuilder = new StringBuilder();
        string text = " SELECT  * FROM (\r\n  {2} ) t ORDER BY {3} \r\n  limit {1} offset {0}   ";
        bool flag = orderBy == string.Empty;
        if (flag)
        {
            throw new Exception("orderBy排序不能为空");
        }
        text = string.Format(text, new object[]
        {
            (pageIndex-1)*pageSize,
            pageSize,
            sqlCommand,
            orderBy
        });
        stringBuilder.Append(text);
        return ExecuteDataTable(stringBuilder.ToString(), CommandType.Text);
    }

    public DataTable GetPagerDataTable(int pageSize, int pageIndex, string orderBy, string sqlCommand, out int count)
    {
        StringBuilder stringBuilder = new StringBuilder();
        string countSql = string.Format("SELECT COUNT(*) FROM ( {0} ) t ", sqlCommand);

        count = ExecuteScalar(countSql, CommandType.Text).ToInt();//使用了拓展方法。

        return GetPagerDataTable(pageSize, pageIndex, orderBy, sqlCommand);

    }
    /// <summary>
    /// 返回分页List
    /// </summary>
    /// <typeparam name="T">实体类类型</typeparam>
    /// <param name="pageSize">每页记录数</param>
    /// <param name="pageIndex">页码（从1开始）</param>
    /// <param name="orderBy">排序（必填）</param>
    /// <param name="sqlCommand">SQL语句</param>
    /// <param name="cmdType">SQL类型</param> 
    /// <returns>泛型集合</returns>
    public List<T> GetPagerList<T>(int pageSize, int pageIndex, string orderBy, string sqlCommand)
    {
        StringBuilder stringBuilder = new StringBuilder();
        string text = "SELECT  * FROM (\r\n  {2} ) t ORDER BY {3} \r\n  limit {1} offset {0}  ";
        bool flag = orderBy == string.Empty;
        if (flag)
        {
            throw new Exception("orderBy排序不能为空");
        }
        text = string.Format(text, new object[]
        {
            (pageIndex-1)*pageSize,
            pageSize,
            sqlCommand,
            orderBy
        });
        stringBuilder.Append(text);
        return ExecuteDataTable(stringBuilder.ToString(), CommandType.Text).ToList<T>();
    }

    public List<T> GetPagerList<T>(int pageSize, int pageIndex, string orderBy, string sqlCommand, out int count)
    {
        StringBuilder stringBuilder = new StringBuilder();
        string countSql = string.Format("SELECT COUNT(*) FROM ( {0} ) t ", sqlCommand);

        count = ExecuteScalar(countSql, CommandType.Text).ToInt();//使用了拓展方法。

        return GetPagerList<T>(pageSize, pageIndex, orderBy, sqlCommand);

    }
    /// <summary>
    /// 返回单个实体类
    /// </summary>
    /// <typeparam name="T">实体类类型</typeparam>
    /// <param name="sql">SQL语句</param>
    /// <param name="cmdType">SQL类型</param>
    /// <param name="pms">参数</param>
    /// <returns></returns>
    public T QueryEntity<T>(string sql, CommandType cmdType, params MySqlParameter[] pms)
    {
        return ExecuteDataTable(sql, cmdType, pms).ToList<T>().FirstOrDefault();
    }
    /// <summary>
    /// 分页返回DataReader
    /// </summary>
    /// <param name="pageSize">每页记录数</param>
    /// <param name="pageIndex">页码</param>
    /// <param name="orderBy">排序（必填）</param>
    /// <param name="sqlCommand">SQL语句</param>
    /// <param name="pms">参数</param>
    /// <returns></returns>
    public MySqlDataReader GetPagerReader(int pageSize, int pageIndex, string orderBy, string sqlCommand, params MySqlParameter[] pms)
    {
        StringBuilder stringBuilder = new StringBuilder();
        string text = " SELECT  * FROM (\r\n  {2} ) t ORDER BY {3} \r\n  limit {1} offset {0}   ";
        bool flag = orderBy == string.Empty;
        if (flag)
        {
            throw new Exception("orderBy排序不能为空");
        }
        text = string.Format(text, new object[]
        {
            (pageIndex-1)*pageSize,
            pageSize,
            sqlCommand,
            orderBy
        });
        stringBuilder.Append(text);
        return ExecuteReader(stringBuilder.ToString(), CommandType.Text, pms);
    }
}
