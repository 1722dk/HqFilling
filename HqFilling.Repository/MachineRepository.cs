using System;
using System.Collections.Generic;
using System.Data;
using HqFilling.Model;
using HqFilling.DbContext;

namespace HqFilling.Repository
{
    public class MachineRepository
    {
        private DBMachine _dbMachine;
        private MachineModel _machineModel;
        
        // Default constructor
        public MachineRepository()
        {
            _dbMachine = new DBMachine();
            _machineModel = new MachineModel();
        }

        public int SaveMachineNumber(MachineModel machineModel)
        {
            _dbMachine = new DBMachine();
            int newId = 0;
            try
            {
                newId = _dbMachine.SaveMachineNumber(machineModel);
            }
            catch (Exception exception) { }
            return newId;
        }
        public MachineModel GetMachineModel(MachineModel machineModel)
        {
            try
            {
                _dbMachine = new DBMachine();
                DataTable dtMachine = _dbMachine.GetAllMachines(machineModel);
                foreach (DataRow dr in dtMachine.Rows)
                {
                    _machineModel = new MachineModel();
                    _machineModel.MachineId = Convert.ToInt32(dr["MachineId"].ToString());
                    _machineModel.MachineName = dr["MachineName"].ToString();
                    _machineModel.MachineCode = dr["MachineCode"].ToString();
                    _machineModel.MachineVolume = Convert.ToDouble(dr["MachineVolume"].ToString());
                    _machineModel.Comment = dr["Comment"].ToString();

                    machineModel = _machineModel;
                }
            }
            catch (Exception exception) { }

            return machineModel;
        }
        public List<MachineModel> GetMachineVolumeList(MachineModel machineModel)
        {
            List<MachineModel> machineModelList = new List<MachineModel>();
            try
            {
                _dbMachine = new DBMachine();
                DataTable dtMachine = _dbMachine.GetAllMachines(machineModel);
                foreach (DataRow dr in dtMachine.Rows)
                {
                    _machineModel = new MachineModel();
                    _machineModel.MachineId = Convert.ToInt32(dr["MachineId"].ToString());
                    _machineModel.MachineVolume = Convert.ToDouble(dr["MachineVolume"].ToString());
                    machineModelList.Add(_machineModel);
                }
            }
            catch (Exception exception) { }

            return machineModelList;
        }

        public List<MachineModel> GetAllMachineList(MachineModel machineModel)
        {
            List<MachineModel> machineModelList = new List<MachineModel>();
            try
            {
                _dbMachine = new DBMachine();
                DataTable dtMachine = _dbMachine.GetAllMachines(machineModel);
                foreach (DataRow dr in dtMachine.Rows)
                {
                    _machineModel = new MachineModel();
                    _machineModel.MachineId = Convert.ToInt32(dr["MachineId"].ToString());
                    _machineModel.MachineName = dr["MachineName"].ToString();
                    _machineModel.MachineCode = dr["MachineCode"].ToString();
                    _machineModel.MachineVolume = Convert.ToDouble(dr["MachineVolume"].ToString());
                    _machineModel.CreatedDate = Convert.ToDateTime(dr["ModifiedDate"].ToString());
                    machineModelList.Add(_machineModel);
                }
            }
            catch (Exception exception) { }

            return machineModelList;
        }
    }
}
