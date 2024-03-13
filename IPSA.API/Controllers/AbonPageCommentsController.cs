using AutoMapper;
using IPSA.API.Repositories.Contracts;
using IPSA.Models;
using IPSA.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IPSA.API.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class AbonPageCommentsController(IAbonPageCommentsRepository abonPageCommentsRepository, IMapper mapper) : ControllerBase
    {
        private readonly IAbonPageCommentsRepository _abonPageCommentsRepository = abonPageCommentsRepository;
        private readonly IMapper _mapper = mapper;

        [HttpGet("Abonent/{abonId:int}")]
        public async Task<ActionResult<List<AbonPageCommentDto>>> GetAbonentPageComments(int abonId)
        {
            try
            {
                var abonPageComments = _abonPageCommentsRepository.GetAbonentPageComments(abonId);

                if (abonPageComments is null)
                {
                    return NoContent();
                }

                var result = _mapper.Map<List<AbonPageCommentDto>>(abonPageComments);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при получении данных из базы");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddNewAbonPageComment(AbonPageCommentDto commentDto)
        {
            try
            {
                if (commentDto is null)
                {
                    return BadRequest("Ошибка. Комментарий не содержит данных.");
                }

                var newComment = _mapper.Map<AbonPageComment>(commentDto);
                await _abonPageCommentsRepository.AddNewAbonentPageComment(newComment);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при добавлении комментария в базу");
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAbonPageComment(AbonPageCommentDto commentDto)
        {
            try
            {
                if (commentDto is null)
                {
                    return BadRequest("Ошибка. Комментарий не содержит данных.");
                }

                var updComment = _mapper.Map<AbonPageComment>(commentDto);
                var currComment = _abonPageCommentsRepository.GetSingleAbonPageComment(commentDto.Id);
                
                if (currComment is not null)
                {
                    currComment.Text = updComment.Text;
                    currComment.CommentDateTime = updComment.CommentDateTime;

                    await _abonPageCommentsRepository.UpdateAbonentPageComment(currComment);
                }
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при обновлении комментария");
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAbonPageComment(int commentId)
        {
            try
            {
                await _abonPageCommentsRepository.DeleteAbonentPageComment(commentId);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ошибка при попытке удаления комментария");
            }
        }
    }
}
