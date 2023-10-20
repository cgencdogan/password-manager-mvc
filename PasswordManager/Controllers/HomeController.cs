using Business.Abstract;
using Common.DataTransferObjects;
using Common.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace PasswordManager.Controllers;

[Authorize]
public class HomeController : Controller {
    private readonly ISavedPasswordService _savedPasswordService;
    private readonly ICategoryService _categoryService;

    public HomeController(ISavedPasswordService savedPasswordService, ICategoryService categoryService) {
        _savedPasswordService = savedPasswordService;
        _categoryService = categoryService;
    }

    public async Task<IActionResult> Index() {
        var homeIndexVM = new HomeIndexVM();

        var savedPasswords = await _savedPasswordService.GetAllByUserIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
        var categories = await _categoryService.GetAllByUserIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

        homeIndexVM.SavedPasswords = savedPasswords;
        homeIndexVM.Categories = categories;
        return View(homeIndexVM);
    }

    [HttpPost]
    public async Task<IActionResult> AddCategory(string categoryName) {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var result = await _categoryService.AddAsync(categoryName, userId);
        if (result.Success) {
            return Ok(new { message = result.Message });
        }
        return BadRequest(new { message = result.Message });
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCategory(Guid categoryId) {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var result = await _categoryService.DeleteAsync(categoryId, userId);
        if (result.Success) {
            return Ok(new { message = result.Message });
        }
        return BadRequest(new { message = result.Message });
    }

    [HttpPost]
    public async Task<IActionResult> SavePassword(SavedPasswordDto savedPasswordDto) {
        savedPasswordDto.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var result = await _savedPasswordService.AddAsync(savedPasswordDto);
        if (result.Success) {
            return Ok(new { message = result.Message });
        }
        return BadRequest(new { message = result.Message });
    }

    [HttpDelete]
    public async Task<IActionResult> DeletePassword(Guid savedPasswordId) {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var result = await _savedPasswordService.DeleteAsync(savedPasswordId, userId);
        if (result.Success) {
            return Ok(new { message = result.Message });
        }
        return BadRequest(new { message = result.Message });
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePassword(SavedPasswordDto savedPasswordDto) {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var result = await _savedPasswordService.UpdateAsync(savedPasswordDto, userId);
        if (result.Success) {
            return Ok(new { message = result.Message });
        }
        return BadRequest(new { message = result.Message });
    }

    [Route("/Home/HandleError/{code:int}")]
    public IActionResult HandleError(int code) {
        ViewData["ErrorCode"] = code;
        switch (code) {
            case 404:
                return View("~/Views/Shared/404.cshtml");
            case 500:
                return View("~/Views/Shared/500.cshtml");
            default:
                return View("~/Views/Shared/HttpError.cshtml");
        }
    }
}
