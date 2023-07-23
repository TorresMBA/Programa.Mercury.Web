using Mercury.Core.Entities;
using Mercury.Core.Interfaces;
using Mercury.Infrastructure;
using Mercury.Infrastructure.Repositories;
using Mercury.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Mercury.WebApp.Controllers {
    public class CategoryController : Controller {

        //private readonly MercuryContext _mercuryContext;

        //private readonly ICategoryRepository _categoryRepository;

        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public CategoryController(MercuryContext mercuryContext)
        //{
        //    _mercuryContext = mercuryContext;
        //}

        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.Category.GetAllAsync();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            category.CreatedDate = DateTime.Now;
            category.CreatedByUser = "UserTest";
            category.ModifiedDate = DateTime.Now;
            category.ModifiedByUser = "UserEdit";
            _unitOfWork.Category.Add(category);
            await _unitOfWork.SaveAsync();
            return View();
        }
    }
}
