using MasterOfCoinsAPI.Interfaces;
using MasterOfCoinsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MasterOfCoinsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupDetailsController : Controller
    {
        IGroupDetailsRepository groupDetailsRepository;
        public GroupDetailsController(IGroupDetailsRepository repository)
        {
            this.groupDetailsRepository = repository;
        }

        [HttpGet]
        public List<GroupDetails> Index()
        {
            var groupDetails = groupDetailsRepository.GetAll();
            return groupDetails;
        }

        [HttpGet("{id}")]
        public GroupDetails Details(int id)
        {
            var groupDetail = groupDetailsRepository.GetById(id);
            return groupDetail;
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(GroupDetails entity)
        {
            groupDetailsRepository.Create(entity);
            return new JsonResult("Group created successfully");
        }

        [HttpPut]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(GroupDetails entity)
        {
            groupDetailsRepository.Update(entity);
            return new JsonResult("Group Details updated successfully");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var isDeleted = groupDetailsRepository.Delete(id);
            var resultMessage = isDeleted 
                ? "Group deleted successfully" 
                : "Error occurred during delete.";
            return new JsonResult(resultMessage);
        }
    }
}
