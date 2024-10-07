using EduHomeFtoB.Areas.AdminPanel.Controllers;
using Microsoft.AspNetCore.Mvc;
using Podcast.BLL.Services.Contracts;
using Podcast.BLL.ViewModels.TopicViewModels;

namespace Podcast.MVC.Areas.Admin.Controllers;
[Area("Admin")]

public class TopicController : Controller
{
    private readonly ITopicService _topicService;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly string FOLDER_PATH;
    public TopicController(ITopicService topicService,IWebHostEnvironment webHostEnvironment)
    {
        _topicService = topicService;
        _webHostEnvironment = webHostEnvironment;
        FOLDER_PATH = Path.Combine(_webHostEnvironment.WebRootPath,"images","topics");
    }

    public async Task< IActionResult> Index()
    {

        var result = await _topicService.GetListAsync();
        return View(result);
    }
    public IActionResult Create()
    {        
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(TopicCreateViewModel vm)
    {
        var succeeded=await _topicService.CreateAsync(vm,ModelState,FOLDER_PATH);

        if (succeeded) return RedirectToAction("Index");

        return View(vm);
    }

    public async Task<IActionResult> Update(int? id)
    {
        if (id == null) return NotFound();
        var existingTopic = await _topicService.GetUTopicForUpdateAsync(id.Value);
        if (existingTopic == null) return NotFound();
        return View(existingTopic);
    }

    [HttpPost]
    public async Task<IActionResult> Update(TopicUpdateViewModel vm)
    {
        var result = await _topicService.UpdateAsync(vm, ModelState,FOLDER_PATH);
        if (result==false) return View(vm);
        if (result == null) return BadRequest();
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var result = await _topicService.RemoveTopicAsync(id.Value);

        if (result == false) return BadRequest();

        return RedirectToAction("Index");
    }

}
