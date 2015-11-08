using System;
using System.Data;
using System.Data.SqlClient;

namespace Wes.Database
{
  public class MsSql
  {
    #region Constructors
    public MsSql(string connectionString)
    {
      _connectionString = connectionString;
    } 
    #endregion

    #region Private Constants
    //Param constants
    private const string PARAM_SQLERROR = "@SqlError";
    
    //Result constants
    private const int RESULT_SUCCESS = 0;
    #endregion

    #region Private Members
    private string _connectionString; 
    #endregion
    
    #region Public Methods
    /// <summary>
    /// Adds output param(s) to the command that are used to return errors to the caller.
    /// </summary>
    /// <param name="command"></param>
    public void AddErrorHandlingParamsToSqlCommand(SqlCommand command)
    {
      SqlParameter paramProcedureError = new SqlParameter(PARAM_SQLERROR, SqlDbType.Int);
      paramProcedureError.Direction = ParameterDirection.Output;
      command.Parameters.Add(paramProcedureError);
    }

    /// <summary>
    /// Closes the connection, committing the transaction (if any) by default.
    /// </summary>
    /// <param name="command"></param>
    public void FreeCommand(SqlCommand command)
    {
      FreeCommand(command, true);
    }
    
    /// <summary>
    /// Closes the connetion, and performs a commit or rollback as needed.
    /// </summary>
    /// <param name="command"></param>
    /// <param name="commit"></param>
    public void FreeCommand(SqlCommand command, bool commit)
    {
      //If for some reason we receive a null command object, just exit
      if (command == null)
        return;

      //Check to see if we're in a transaction. If so, commit or rollback depending on the param
      //we received
      if (command.Transaction != null)
      {
        if (commit)
          command.Transaction.Commit();
        else
          command.Transaction.Rollback();
      }
      
      //Close the connection
      command.Connection.Close();
    }

    /// <summary>
    /// Returns a DataTable object populated by the provided command object.
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    public DataTable GetDataTable(SqlCommand command)
    {
      //Instantiate the result DataSet object
      DataTable result = new DataTable();

      //Create the data adapter with the SqlCommand object that we received
      SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
      
      //Fill the result dataset
      dataAdapter.Fill(result);

      //Return the result
      return result;
    }

    /// <summary>
    /// Creates a new connection using the internal connection string and opens the connection.
    /// This overload does not start a transaction by default, and is set to execute command text.
    /// </summary>
    /// <returns></returns>
    public SqlCommand GetNewCommand()
    {
      return GetNewCommand(string.Empty, CommandType.Text);
    }

    /// <summary>
    /// Creates a new connection using the internal connection string and opens the connection.
    /// Initiates a transaction, if needed.
    /// </summary>
    /// <param name="startTransaction"></param>
    /// <returns></returns>
    public SqlCommand GetNewCommand(bool startTransaction)
    {
      return GetNewCommand(string.Empty, CommandType.Text, startTransaction);
    }

    /// <summary>
    /// Creates a new connection using the internal connection string and opens the connection.
    /// Sets the command type as needed.
    /// </summary>
    /// <param name="commandText"></param>
    /// <param name="commandType"></param>
    /// <returns></returns>
    public SqlCommand GetNewCommand(string commandText, CommandType commandType)
    {
      return GetNewCommand(commandText, commandType, false);
    }

    /// <summary>
    /// Creates a new connection using the internal connection string and opens the connection.
    /// Sets the command type and initiates a transaction as needed.
    /// </summary>
    /// <param name="commandText"></param>
    /// <param name="commandType"></param>
    /// <param name="startTransaction"></param>
    /// <returns></returns>
    public SqlCommand GetNewCommand(string commandText, CommandType commandType, bool startTransaction)
    {
      //Create the result object
      SqlCommand result = new SqlCommand();
      result.CommandText = commandText;
      result.CommandType = commandType;

      //Create the result object's data connection and open it
      result.Connection = new SqlConnection(_connectionString);

      //Open the connection
      result.Connection.Open();

      //Start a transaction if we need to
      if (startTransaction)
      {
        SqlTransaction transaction = result.Connection.BeginTransaction();
        result.Transaction = transaction;
      }

      return result;
    }

    /// <summary>
    /// Resets the provided command and prepares it for another command/stored procedure/etc.
    /// </summary>
    /// <param name="command"></param>
    public void ResetCommand(SqlCommand command)
    {
      command.Parameters.Clear();
      command.CommandText = string.Empty;
      command.CommandType = CommandType.Text;
    }
    
    /// <summary>
    /// Checks the error handling parameters for errors that may have occured during command execution.
    /// </summary>
    /// <param name="command"></param>
    public void VerifyStoredProcedureResult(SqlCommand command)
    {
      //Get the parameter from the SqlCommand object
      SqlParameter paramProcedureError = command.Parameters[PARAM_SQLERROR];

      //Make sure that it is instantiated
      if (paramProcedureError == null)
        throw new ApplicationException("Null error result parameter encountered.");

      int procResult = Convert.ToInt32(paramProcedureError.Value);
      if (procResult != RESULT_SUCCESS)
        throw new ApplicationException(string.Format("Database error encountered: {0}", procResult));
    }
    #endregion
  }
}
