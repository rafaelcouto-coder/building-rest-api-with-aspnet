using System;
using System.Collections.Generic;

namespace CouuseLibrary.API.Models
{
    public class AuthorForCreationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string MainCategory { get; set; }

        // Coleção para adicionar vários cursos ao mesmo tempo que cria um author.
        public ICollection<CourseForCreationDto> Courses { get; set; }
            // Dica: Inicializar para evitar instancias nulas. 
            = new List<CourseForCreationDto>();
    }
}
