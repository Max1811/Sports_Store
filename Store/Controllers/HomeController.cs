using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Data.Entities;
using Store.Business.Models;
using Store.Data.Repository.EFGenericRepository;
using Store.Data.Repository.Interfaces;
using Store.Mapper;

namespace Store.Controllers
{
    public class HomeController : Controller
    {
        private IUserRepository _userRepository;
        private readonly IMapper mapper;

        public HomeController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            this.mapper = mapper;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            User entity = _userRepository.Get(new System.Guid("3B038F9E-5818-4AAF-BAB9-08D79752B010"));
            UserModel model = mapper.Map<UserModel>(entity);


            return View(model);
        }


    }
}
