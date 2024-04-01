using Joke.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class JokesController : ControllerBase
{
    private readonly JokeContext _context;

    public JokesController(JokeContext context)
    {
        _context = context;
    }


    [HttpGet]
    public IActionResult GetRandomJoke()
    {
        var random = new Random();
        var joke = _context.Jokes.OrderBy(j => j.Id).FirstOrDefault(j => j.Likes == 0 && j.Dislikes == 0);

        if (joke == null)
            return Ok("That's all the jokes for today! Come back another day!");

        return Ok(joke);
    }

    [HttpPost("{id}/like")]
    public IActionResult LikeJoke(int id)
    {
        var joke = _context.Jokes.FirstOrDefault(j => j.Id == id);
        if (joke == null)
            return NotFound();

        joke.Likes++;
        _context.SaveChanges();

        return Ok("You liked the joke!");
    }

    [HttpPost("{id}/dislike")]
    public IActionResult DislikeJoke(int id)
    {
        var joke = _context.Jokes.FirstOrDefault(j => j.Id == id);
        if (joke == null)
            return NotFound();

        joke.Dislikes++;
        _context.SaveChanges();

        return Ok("You disliked the joke!");
    }
}
