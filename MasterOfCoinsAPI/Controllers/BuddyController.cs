using MasterOfCoinsAPI.Interfaces;
using MasterOfCoinsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MasterOfCoinsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuddyController : Controller
    {
        IBuddyRepository buddyRepository;
        public BuddyController(IBuddyRepository repository)
        {
            buddyRepository = repository;   
        }

        [HttpGet]
        public List<Buddy> Get()
        {
            var buddies = buddyRepository.GetAll();
            return buddies;
        }

        [HttpGet("{id}")]
        public Buddy Get(int id)
        {
            return buddyRepository.GetById(id);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Post(Buddy buddy)
        {
            buddyRepository.Create(buddy);
            return new JsonResult("Buddy Created Successfully");
        }

        [HttpPut]
        //[ValidateAntiForgeryToken]
        public ActionResult Put(Buddy buddy)
        {
            buddyRepository.Update(buddy);
            return new JsonResult("Buddy updated Successfully");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var isDeleted = buddyRepository.Delete(id);
            var resultMessage = isDeleted 
                ? $"Buddy with Id = {id} deleted successfully." 
                : $"Buddy with Id = {id} could not be deleted.";
            return new JsonResult(resultMessage);
        }
    }
}
