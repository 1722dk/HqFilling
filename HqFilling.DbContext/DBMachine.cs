using System;
using System.Data;
using System.Data.SqlClient;
using HqFilling.Model;

namespace HqFilling.DbContext
{
    public class DBMachine : DbContext
    {
        #region private property
        private SqlDataReader _dataReader;
        private SqlParameter[] _spParameters;
        private DataTable _dataTable;
        private DataSet _dataSet;
        private string _spName;
        #endregion
        
        #region Constructor
        // default constructor
        public DBMachine()
        {
            this._dataReader = null;
            this._spParameters = null;
            this._dataTable = null;
            this._dataSet = null;
            this._spName = null;
        }

        #endregion

        #region DBPoint public method

        public int SaveMachineNumber(MachineModel machineModel)
        {
            _spName = "sp_machine_number";
            _dataTable = new DataTable();
            _spParameters = new SqlParameter[]{
                                                new SqlParameter("@MachineId", machineModel.MachineId), 
                                                new SqlParameter("@MachineName", machineModel.MachineName),
                                                new SqlParameter("@MachineCode", machineModel.MachineCode), 
                                                new SqlParameter("@MachineVolume", machineModel.MachineVolume),
                                                new SqlParameter("@FuelTypeId", machineModel.FuelTypeId),
                                                new SqlParameter("@Comment", machineModel.Comment),
                                                new SqlParameter("@DbAction", machineModel.DbAction)
                                             };
            _dataTable = ExecuteDataTable(_spName, _spParameters);
            int newId = 0;
            if (_dataTable.Rows.Count > 0)
            {
                newId = Convert.ToInt32(_dataTable.Rows[0]["MachineId"].ToString());
            }
            return newId;
        }
        public DataTable GetAllMachines(MachineModel machineModel)
        {
            _spName = "sp_machine_number";
            _dataTable = new DataTable();
            _spParameters = new SqlParameter[]{
                                                new SqlParameter("@MachineId", machineModel.MachineId), 
                                                new SqlParameter("@MachineName", machineModel.MachineName),
                                                new SqlParameter("@MachineCode", machineModel.MachineCode), 
                                                new SqlParameter("@MachineVolume", machineModel.MachineVolume),
                                                new SqlParameter("@FuelTypeId", machineModel.FuelTypeId),
                                                new SqlParameter("@Comment", machineModel.Comment),
                                                new SqlParameter("@DbAction", machineModel.DbAction)
                                             };
            _dataTable = ExecuteDataTable(_spName, _spParameters);
            return _dataTable;
        }

        #endregion
    }
}
