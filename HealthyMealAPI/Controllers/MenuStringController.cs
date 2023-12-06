using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HealthyMealAPI;
using HealthyMealAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;

namespace HealthyMealAPI.Controllers;

[EnableCors]
[Route("api/[controller]/[action]")]
[ApiController]
public class MenuStringController : Controller
{
    private readonly HealthyMealContext _context;

    /// <summary>
    /// Конструктор контроллера блюда, получающий в качестве параметра контекст БД
    /// </summary>
    /// <param name="context">Контекст БД</param>
    public MenuStringController(HealthyMealContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Получить все строки меню.
    /// </summary>
    /// <param name="menuId"> ID меню. </param>
    /// <returns> Список меню пользователя. </returns>
    [HttpGet]
    [Authorize(Roles = "admin, user")]
    public async Task<ActionResult<List<MenuString>>> GetMenuStrings(string menuId)
    {
        List<MenuString> menuStrings = new List<MenuString>();
        await foreach (var menuStr in _context.MenuStrings)
        {
            if (menuStr.MenuId == menuId)
            {
                menuStrings.Add(menuStr);
            }
        }
        return menuStrings;
    }

    /// <summary>
    /// Получить конкретную строку меню.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [Authorize(Roles = "admin, user")]
    public async Task<ActionResult<MenuString>> GetMenuString(string id)
    {
        var menuStr = await _context.MenuStrings.FindAsync(id);
        if (menuStr == null)
        {
            return NotFound();
        }
        return Ok(menuStr);
    }

    /// <summary>
    /// Создать строку меню.
    /// </summary>
    /// <param name="menuStr"> Строка меню. </param>
    /// <returns> Созданная строка меню. </returns>
    [HttpPost]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<MenuString>> Post([FromBody] MenuString menuStr)
    {
        menuStr.Id = Guid.NewGuid().ToString();
        _context.MenuStrings.Add(menuStr);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetMenuString", new { id = menuStr.Id }, menuStr);
    }

    /// <summary>
    /// Изменяет строку меню.
    /// </summary>
    /// <param name="menuStr"> Строка меню. </param>
    /// <returns> Результат выполнения запроса. </returns>
    [HttpPut]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<MenuString>> Put([FromBody] MenuString menuStr)
    {
        var menuStr1 = await _context.MenuStrings.FindAsync(menuStr.Id);
        if (menuStr1 == null)
        {
            return NotFound();
        }
        _context.MenuStrings.Update(menuStr1);
        await _context.SaveChangesAsync();
        return Ok("Сущность изменена");
    }
    /// <summary>
    /// Удаляет строку меню
    /// </summary>
    /// <param name="id">id удаляемой строки меню</param>
    /// <returns>Статус выполнения запроса</returns>
    [HttpDelete("{id}")]
    [Authorize(Roles = "user")]
    public async Task<IActionResult> Delete([FromRoute] string id)
    {
        var menuStr = await _context.MenuStrings.FindAsync(id);
        if (menuStr == null)
        {
            return NotFound();
        }
        _context.MenuStrings.Remove(menuStr);
        await _context.SaveChangesAsync();
        return Ok("Сущность успешно удалена");
    }
}

