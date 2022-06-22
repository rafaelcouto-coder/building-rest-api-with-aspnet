using CouuseLibrary.API.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CouuseLibrary.API.Models
{
    [CourseTitleMustBeDifferenteFromDescription]
    public class CourseForCreationDto : CourseForManipulationDto
    {
        
    }
}
