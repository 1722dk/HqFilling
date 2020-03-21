using System;
using System.Data;
using System.Data.SqlClient;
using HqFilling.Model;

namespace HqFilling.DbContext
{
    public class DbUser : DbContext
    {
        #region private property
        
        private SqlDataReader _dataReader;
        private SqlParameter[] _spParameters;
        private DataTable _dataTable;
        private DataSet _dataSet;
        private string _spName;
        private int _result;
        
        #endregion

        #region Constructor
        
        // Default constructor
        public DbUser()
        {
            this._dataReader = null;
            this._spParameters = null;
            this._dataTable = null;
            this._dataSet = null;
            this._spName = null;
            this._result = 0;
        }

        #endregion

        #region DbUser public method

        public int SaveUserInfo(UserModel userModel)
        {
            _spName = "sp_user_info";
            _dataTable = new DataTable();
            _spParameters = new SqlParameter[]{
                                                new SqlParameter("@UserId", userModel.UserId), 
                                                new SqlParameter("@FirstName", userModel.FirstName), 
                                                new SqlParameter("@LastName", userModel.LastName),
                                                new SqlParameter("@UserName", userModel.Username), 
                                                new SqlParameter("@Password", userModel.Password),
                                                new SqlParameter("@PresentAddress", userModel.PresentAddress),
                                                new SqlParameter("@ParmanentAddress", userModel.ParmanentAddress),
                                                new SqlParameter("@Phone", userModel.Phone),
                                                new SqlParameter("@Phone2", userModel.Phone2),
                                                new SqlParameter("@Email", userModel.Email),
                                                new SqlParameter("@IsActive", userModel.IsActive), 
                                                new SqlParameter("@CreatedBy", userModel.CreatedBy), 
                                                new SqlParameter("@DbAction", userModel.DbAction)
                                             };
            _dataTable = ExecuteDataTable(_spName, _spParameters);
            if (_dataTable.Rows.Count > 0)
            {
                _result = Int32.Parse(_dataTable.Rows[0]["UserId"].ToString());
            }
            return _result;
        }
        public DataTable GetUserInfo(UserModel userModel)
        {
            _spName = "sp_user_info";
            _dataTable = new DataTable();
            _spParameters = new SqlParameter[]{
                                                new SqlParameter("@UserId", userModel.UserId),  
                                                new SqlParameter("@DbAction", userModel.DbAction)
                                             };
            _dataTable = ExecuteDataTable(_spName, _spParameters);
            return _dataTable;
        }

        public DataSet GetUserInfoWithFeatures(UserModel userModel)
        {
            _spName = "sp_user_info";
            _dataSet = new DataSet();
            _spParameters = new SqlParameter[]{
                                                new SqlParameter("@UserId", userModel.UserId), 
                                                new SqlParameter("@UserName", userModel.Username), 
                                                new SqlParameter("@Password", userModel.Password), 
                                                new SqlParameter("@DbAction", userModel.DbAction)
                                             };
            _dataSet = ExecuteDataSet(_spName, _spParameters);
            return _dataSet;
        }

        #endregion
    }
}
