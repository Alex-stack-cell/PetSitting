using Microsoft.AspNetCore.Mvc;
using APIPetSitting.Models;
using APIPetSitting.Mappers;
using BLLPetSitting.Services;
using System.Linq;
using System.Collections.Generic;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIPetSitting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CommentService _commentService;
        public CommentController(CommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Comment> comments = _commentService.GetAll().Select(c => c.ToApi());
            return Ok(comments);
        }
        // GET: api/<CommentController>/5/scoreAsc
        [HttpGet("scoreAsc")]
        public IActionResult GetByScoreAsc()
        {
            IEnumerable<Comment> comments = _commentService.GetCommentByScoreAsc().Select(c => c.ToApi());
            return Ok(comments);
        }
        // GET: api/<CommentController>/5/scoreDesc
        [HttpGet("scoreDesc")]
        public IActionResult GetByScoreDesc()
        {
            IEnumerable<Comment> comments = _commentService.GetCommentByScoreDesc().Select(c => c.ToApi());
            return Ok(comments);
        }
        // GET api/<CommentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IEnumerable<Comment> comment = _commentService.GetById(id).Select(c => c.ToApi());
            return Ok(comment);
        }

        // POST api/<CommentController>
        [HttpPost]
        public IActionResult Post([FromBody] Comment comment)
        {
            int rowsAffected;
            try
            {
                rowsAffected = _commentService.Create(comment.ToBll());
            }
            catch (Exception)
            {

                return new StatusCodeResult(422);
            }
            return Ok(rowsAffected);
        }

        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Comment comment)
        {
            if (_commentService.Update(comment.ToBll())!=0)
            {
                int rowAffected = _commentService.Update(comment.ToBll());
                return Ok(rowAffected);
            }
            return BadRequest();
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_commentService.Delete(id) != 0)
            {
                int rowAffected = _commentService.Delete(id);
                return Ok(rowAffected);
            }
            return BadRequest();
        }
    }
}
