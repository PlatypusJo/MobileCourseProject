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
public class MenuController : Controller
{
    private readonly HealthyMealContext _context;

    /// <summary>
    /// Конструктор контроллера блюда, получающий в качестве параметра контекст БД
    /// </summary>
    /// <param name="context">Контекст БД</param>
    public MenuController(HealthyMealContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Получить все меню пользователя
    /// </summary>
    /// <param name="userId"> ID пользователя. </param>
    /// <returns> Список меню пользователя. </returns>
    [HttpGet]
    [Authorize(Roles = "admin, user")]
    public async Task<ActionResult<List<Menu>>> GetMenus(string userId)
    {
        List<Menu> menus = new List<Menu>();
        await foreach (var menu in _context.Menus)
        {
            if (menu.UserId == userId)
            {
                menus.Add(menu);
            }
        }
        return menus;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [Authorize(Roles = "admin, user")]
    public async Task<ActionResult<Menu>> GetMenu(string id)
    {
        var menu = await _context.Menus.FindAsync(id);
        if (menu == null)
        {
            return NotFound();
        }
        return Ok(menu);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="menu"></param>
    /// <returns></returns>
    [HttpPost]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Menu>> Post([FromBody] Menu menu)
    {
        menu.Id = Guid.NewGuid().ToString();
        _context.Menus.Add(menu);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetMenu", new { id = menu.Id }, menu);
    }
   
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="menu"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Menu>> Put([FromRoute] string id, [FromBody] Menu menu)
    {
        var menu1 = await _context.Menus.FindAsync(menu.Id);
        if (menu1 == null)
        {
            return NotFound();
        }
        _context.Menus.Update(menu1);
        await _context.SaveChangesAsync();
        return Ok("Сущность изменена");
    }
    /// <summary>
    /// Удаляет блюдо и связанные с ним сущности по id из БД
    /// </summary>
    /// <param name="id">id удаляемого блюда</param>
    /// <returns>Статус выполнения запроса</returns>
    // DELETE api/<DishController>/5
    [HttpDelete("{id}")]
    [Authorize(Roles = "user")]
    public async Task<IActionResult> Delete([FromRoute] string id)
    {
        var menu = await _context.Menus.FindAsync(id);
        if (menu == null)
        {
            return NotFound();
        }

        await foreach(var menuStr in _context.MenuStrings)
        {
            if (menuStr.MenuId == menu.Id)
            {
                _context.MenuStrings.Remove(menuStr);
            }
        }

        _context.Menus.Remove(menu);
        await _context.SaveChangesAsync();
        return Ok("Сущность успешно удалена");
    }
}

