using AutoMapper;
using CourseLibrary.API.Entities;
using CourseLibrary.API.Services;
using CouuseLibrary.API.Helpers;
using CouuseLibrary.API.Models;
using CouuseLibrary.API.ResourcesParameters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CouuseLibrary.API.Controller
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;
        private readonly IMapper _mapper;

        public AuthorsController(ICourseLibraryRepository courseLibraryRepository,
            IMapper mapper)
        {
            //Instanciar o repositório através do construtor
            _courseLibraryRepository = courseLibraryRepository ??
                throw new ArgumentNullException(nameof(courseLibraryRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        // IActionResult: define um contrato que representa o resultado de um método de ação
        // Nesta ação devemos obtyer os autores 12 
        [HttpGet()]
        [HttpHead]
        public ActionResult<IEnumerable<AuthorDto>> GetAuthors(
            [FromQuery] AuthorsResourceParameters authorsResourceParameters)
        {
            var authorsFromRepo = _courseLibraryRepository.GetAuthors(authorsResourceParameters);
            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo));
        }

        // Atributo name da rota serve para passarmos o nome ao metodo post
        // desta forma quem chama o metodo POST pode conhecer como o GET funciona. 
        [HttpGet("{authorId:guid}", Name ="GetAuthor")]
        public IActionResult GetAuthor(Guid authorId)
        {
            var authorsFromRepo = _courseLibraryRepository.GetAuthor(authorId);
            
            if (authorsFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AuthorDto>(authorsFromRepo));
        }

        [HttpPost]
        public ActionResult<AuthorDto> CreateAuthor(AuthorForCreationDto author)
        {
            var authorEntity = _mapper.Map<Author>(author);
            _courseLibraryRepository.AddAuthor(authorEntity);
            _courseLibraryRepository.Save();

            // Depois de salvo, mapeamos o AuthorEntity que possui o ID preenchido.
            // Isto acontece pois retornei o AuthorDto ao fim da inserção
            var authorToReturn = _mapper.Map<AuthorDto>(authorEntity);

            return CreatedAtRoute("GetAuthor",
                new { authorId = authorToReturn.Id },
                authorToReturn);
        }

        [HttpOptions]
        public IActionResult GetAuthorsOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST");
            return Ok();
        }

        [HttpDelete("{authorId}")]
        public ActionResult DeleteAuthor (Guid authorId)
        {
            var authorsFromRepo = _courseLibraryRepository.GetAuthor(authorId);

            if (authorsFromRepo == null)
            {
                return NotFound();
            }

            _courseLibraryRepository.DeleteAuthor(authorsFromRepo);

            _courseLibraryRepository.Save();

            return NoContent();
        }
    }
}
