using System.Collections.Generic;
using System.Data;
using HqFilling.Model;
using HqFilling.Repository;

namespace HqFilling.Biz
{
    public class MachineBiz
    {
        private MachineRepository _machineRepository;
        private MachineModel _machineModel;
        
        // Default constructor
        public MachineBiz()
        {
            _machineRepository = new MachineRepository();
            _machineModel = new MachineModel();
        }

        // Get machine info from MachineRepository class
        public int SaveMachineNumber(MachineModel machineModel)
        {
            _machineRepository = new MachineRepository();
            int newMachine = _machineRepository.SaveMachineNumber(machineModel);

            return newMachine;
        }

        // Get machine item detail from MachineRepository class
        public MachineModel GetMachineModel(MachineModel machineModel)
        {
            _machineRepository = new MachineRepository();
            return _machineRepository.GetMachineModel(machineModel);
        }
        public List<MachineModel> GetMachineVolumeList(MachineModel machineModel)
        {
            _machineRepository = new MachineRepository();
            return _machineRepository.GetMachineVolumeList(machineModel);
        }
        public List<MachineModel> GetAllMachineList(MachineModel machineModel)
        {
            _machineRepository = new MachineRepository();
            return _machineRepository.GetAllMachineList(machineModel);
        }
    }
}
