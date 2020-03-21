using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HqFilling.Model;
using HqFilling.Biz;

namespace HqFilling.Controllers
{
    public class MachineController : Controller
    {
        //
        // GET: /Machine/

        public ActionResult Index()
        {
            return View(new MachineModel());
        }
        
        [HttpPost]
        public ActionResult Index(MachineModel machineModel)
        {
            if (ModelState.IsValid)
            {
                if (machineModel.MachineId > 0) { machineModel.DbAction = "U"; }
                else { machineModel.DbAction = "I"; }
                machineModel.CreatedBy = 1;
               
                MachineBiz machineBiz = new MachineBiz();
                int rslt = machineBiz.SaveMachineNumber(machineModel);
                if (rslt > 0)
                {
                    return RedirectToAction("GetAllMachineList", "Machine");
                }
            }
            return View(machineModel);
        }

        [HttpGet]
        public ActionResult EditMachine(int id)
        {
            MachineModel machineModel = new MachineModel();
            machineModel.MachineId = id;
            machineModel.DbAction = "S";
            MachineBiz machineBiz = new MachineBiz();
            machineModel = machineBiz.GetMachineModel(machineModel);
            return View("Index", machineModel);
        }

        [HttpGet]
        public ActionResult DeleteMachine(int id)
        {
            MachineModel machineModel = new MachineModel();
            machineModel.MachineId = id;
            machineModel.DbAction = "D";
            MachineBiz machineBiz = new MachineBiz();
            int rslt = machineBiz.SaveMachineNumber(machineModel);
            if (rslt == 0)
            {
                return RedirectToAction("GetAllMachineList", "Machine");
            }
            return View();
        }

        public ActionResult GetAllMachineList()
        {
            List<MachineModel> machineModelList = new List<MachineModel>();
            MachineModel machineModel = new MachineModel();
            machineModel.DbAction = "S";
            MachineBiz machineBiz = new MachineBiz();
            machineModelList = machineBiz.GetAllMachineList(machineModel);

            return View(machineModelList);
        }
        

        [HttpGet]
        public ActionResult ViewMachineDetail(int id)
        {
            MachineModel machineModel = new MachineModel();
            return View(machineModel);
        }
    }
}
